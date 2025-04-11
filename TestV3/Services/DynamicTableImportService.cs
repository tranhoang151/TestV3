using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using ExcelDataReader;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestV3.Services
{
    public class DynamicTableImportService
    {
        private readonly string _connectionString;

        public DynamicTableImportService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public (bool Success, string Message, Dictionary<string, int> ImportedCounts) ImportExcel(Stream fileStream, string selectedSheet = null)
        {
            try
            {
                // Register encoding provider for Excel
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count == 0)
                    {
                        return (false, "Excel file has no data", new Dictionary<string, int>());
                    }

                    var importedCounts = new Dictionary<string, int>();

                    // Process each sheet in the Excel file or just the selected one
                    for (int i = 0; i < dataSet.Tables.Count; i++)
                    {
                        var dataTable = dataSet.Tables[i];
                        var sheetName = dataTable.TableName;

                        // Skip if not the selected sheet (when a sheet is selected)
                        if (!string.IsNullOrEmpty(selectedSheet) && sheetName != selectedSheet)
                        {
                            continue;
                        }

                        var sanitizedSheetName = SanitizeTableName(sheetName);

                        if (dataTable.Rows.Count == 0 || dataTable.Columns.Count == 0)
                        {
                            importedCounts.Add(sanitizedSheetName, 0);
                            continue;
                        }

                        // Create or update table and import data
                        var importedCount = CreateTableAndImportData(dataTable, sanitizedSheetName);
                        importedCounts.Add(sanitizedSheetName, importedCount);
                    }

                    int totalCount = importedCounts.Values.Sum();
                    return (true, $"Successfully imported {totalCount} records from {importedCounts.Count} sheets", importedCounts);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error reading Excel file: {ex.Message}", new Dictionary<string, int>());
            }
        }

        public List<string> GetExcelSheets(Stream fileStream)
        {
            try
            {
                // Register encoding provider for Excel
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                fileStream.Position = 0; // Đảm bảo đọc từ đầu stream

                using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    var sheetNames = new List<string>();
                    for (int i = 0; i < dataSet.Tables.Count; i++)
                    {
                        sheetNames.Add(dataSet.Tables[i].TableName);
                    }

                    return sheetNames;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting Excel sheets: {ex.Message}");
                return new List<string>();
            }
        }

        private int CreateTableAndImportData(DataTable dataTable, string tableName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Check if table exists
                bool tableExists = CheckIfTableExists(connection, tableName);

                // Create table if it doesn't exist
                if (!tableExists)
                {
                    CreateTable(connection, dataTable, tableName);
                }
                else
                {
                    // Verify table structure matches Excel structure
                    VerifyAndUpdateTableStructure(connection, dataTable, tableName);
                }

                // Import data
                return ImportDataToTable(connection, dataTable, tableName);
            }
        }

        private bool CheckIfTableExists(SqlConnection connection, string tableName)
        {
            string query = @"
                SELECT COUNT(1) 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_NAME = @TableName AND TABLE_SCHEMA = 'dbo'";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TableName", tableName);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        private void CreateTable(SqlConnection connection, DataTable dataTable, string tableName)
        {
            // Build CREATE TABLE statement
            StringBuilder createTableSql = new StringBuilder();
            createTableSql.AppendLine($"CREATE TABLE [dbo].[{tableName}] (");
            createTableSql.AppendLine("    [Id] INT IDENTITY(1,1) PRIMARY KEY,");

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                string columnName = SanitizeColumnName(dataTable.Columns[i].ColumnName);
                string columnType = DetermineColumnType(dataTable, i);

                createTableSql.Append($"    [{columnName}] {columnType}");
                if (i < dataTable.Columns.Count - 1)
                    createTableSql.AppendLine(",");
                else
                    createTableSql.AppendLine();
            }
            createTableSql.AppendLine(")");

            // Execute CREATE TABLE
            using (var command = new SqlCommand(createTableSql.ToString(), connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void VerifyAndUpdateTableStructure(SqlConnection connection, DataTable dataTable, string tableName)
        {
            // Get existing columns
            var existingColumns = GetExistingColumns(connection, tableName);

            // Check for new columns in Excel that don't exist in the table
            foreach (DataColumn column in dataTable.Columns)
            {
                string columnName = SanitizeColumnName(column.ColumnName);
                if (!existingColumns.Contains(columnName))
                {
                    // Add new column
                    string columnType = DetermineColumnType(dataTable, dataTable.Columns.IndexOf(column));
                    string alterSql = $"ALTER TABLE [dbo].[{tableName}] ADD [{columnName}] {columnType}";

                    using (var command = new SqlCommand(alterSql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private List<string> GetExistingColumns(SqlConnection connection, string tableName)
        {
            var columns = new List<string>();
            string query = @"
                SELECT COLUMN_NAME 
                FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_NAME = @TableName AND TABLE_SCHEMA = 'dbo'";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TableName", tableName);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(reader.GetString(0));
                    }
                }
            }
            return columns;
        }

        private int ImportDataToTable(SqlConnection connection, DataTable dataTable, string tableName)
        {
            int importedCount = 0;

            // Begin transaction
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // Build column list for INSERT statement
                    var columnNames = new List<string>();
                    var paramNames = new List<string>();

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        string columnName = SanitizeColumnName(column.ColumnName);
                        columnNames.Add($"[{columnName}]");
                        paramNames.Add($"@{columnName}");
                    }

                    // Build INSERT statement
                    string insertSql = $"INSERT INTO [dbo].[{tableName}] ({string.Join(", ", columnNames)}) " +
                                      $"VALUES ({string.Join(", ", paramNames)})";

                    // Insert each row
                    using (var command = new SqlCommand(insertSql, connection, transaction))
                    {
                        // Create parameters once
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            string paramName = $"@{SanitizeColumnName(column.ColumnName)}";
                            command.Parameters.Add(new SqlParameter(paramName, SqlDbType.NVarChar, 4000));
                        }

                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Skip empty rows
                            if (row.ItemArray.All(x => x is DBNull || string.IsNullOrWhiteSpace(x.ToString())))
                                continue;

                            // Set parameter values for this row
                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                string paramName = $"@{SanitizeColumnName(dataTable.Columns[i].ColumnName)}";
                                var value = row[i];
                                command.Parameters[paramName].Value = value == DBNull.Value ? DBNull.Value : value;
                            }

                            command.ExecuteNonQuery();
                            importedCount++;
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return importedCount;
        }

        private string DetermineColumnType(DataTable dataTable, int columnIndex)
        {
            DataColumn column = dataTable.Columns[columnIndex];

            // Skip empty columns or columns with no rows
            if (dataTable.Rows.Count == 0)
                return "NVARCHAR(MAX)";

            // Check if all values are null or empty
            bool allNullOrEmpty = true;
            // Flags for type detection
            bool couldBeInt = true;
            bool couldBeDecimal = true;
            bool couldBeDateTime = true;
            bool couldBeBoolean = true;

            int maxLength = 0;

            // Examine sample values (up to the first 100 rows for performance)
            for (int i = 0; i < Math.Min(dataTable.Rows.Count, 100); i++)
            {
                var value = dataTable.Rows[i][columnIndex];

                // Skip null or empty values
                if (value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()))
                    continue;

                allNullOrEmpty = false;
                string stringValue = value.ToString().Trim();
                maxLength = Math.Max(maxLength, stringValue.Length);

                // Test for Int
                if (couldBeInt && !int.TryParse(stringValue, out _))
                {
                    couldBeInt = false;
                }

                // Test for Decimal/Float
                if (couldBeDecimal && !decimal.TryParse(stringValue, out _))
                {
                    couldBeDecimal = false;
                }

                // Test for DateTime
                if (couldBeDateTime && !DateTime.TryParse(stringValue, out _))
                {
                    couldBeDateTime = false;
                }

                // Test for Boolean
                if (couldBeBoolean)
                {
                    string lowerValue = stringValue.ToLower();
                    if (!(lowerValue == "true" || lowerValue == "false" ||
                          lowerValue == "yes" || lowerValue == "no" ||
                          lowerValue == "1" || lowerValue == "0"))
                    {
                        couldBeBoolean = false;
                    }
                }
            }

            // If all values are null or empty, use NVARCHAR(MAX)
            if (allNullOrEmpty)
                return "NVARCHAR(MAX)";

            // Determine the best type based on the flags
            if (couldBeInt)
                return "INT";
            if (couldBeDecimal)
                return "DECIMAL(18, 6)";
            if (couldBeDateTime)
                return "DATETIME";
            if (couldBeBoolean)
                return "BIT";

            // For string values, determine the appropriate length
            if (maxLength <= 50)
                return $"NVARCHAR(50)";
            else if (maxLength <= 255)
                return $"NVARCHAR(255)";
            else if (maxLength <= 4000)
                return $"NVARCHAR(4000)";
            else
                return "NVARCHAR(MAX)";
        }

        private string SanitizeTableName(string tableName)
        {
            // Remove invalid characters and ensure name starts with a letter
            string sanitized = new string(tableName.Where(c => char.IsLetterOrDigit(c) || c == '_').ToArray());

            // Ensure name starts with a letter or underscore
            if (sanitized.Length == 0 || !char.IsLetter(sanitized[0]))
                sanitized = "Table_" + sanitized;

            return sanitized;
        }

        private string SanitizeColumnName(string columnName)
        {
            // Remove invalid characters and ensure name starts with a letter
            string sanitized = new string(columnName.Where(c => char.IsLetterOrDigit(c) || c == '_').ToArray());

            // Ensure name starts with a letter or underscore
            if (sanitized.Length == 0 || !char.IsLetter(sanitized[0]))
                sanitized = "Column_" + sanitized;

            return sanitized;
        }

        public List<string> GetAllTables()
        {
            var tables = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT TABLE_NAME 
                    FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo'
                    ORDER BY TABLE_NAME";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tables.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return tables;
        }

        public (DataTable Data, List<string> Columns) GetTableData(string tableName, int page = 1, int pageSize = 50)
        {
            var result = new DataTable();
            var columns = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // First get the column names
                string columnQuery = @"
                    SELECT COLUMN_NAME 
                    FROM INFORMATION_SCHEMA.COLUMNS 
                    WHERE TABLE_NAME = @TableName AND TABLE_SCHEMA = 'dbo'
                    ORDER BY ORDINAL_POSITION";

                using (var command = new SqlCommand(columnQuery, connection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columns.Add(reader.GetString(0));
                        }
                    }
                }

                // Check if 'Id' column exists for ordering
                bool hasIdColumn = columns.Contains("Id");
                string orderByColumn = hasIdColumn ? "Id" : columns.FirstOrDefault() ?? "1";

                // Then get the data with paging
                int offset = (page - 1) * pageSize;
                string dataQuery = $@"
                    SELECT * FROM [dbo].[{tableName}]
                    ORDER BY {orderByColumn}
                    OFFSET {offset} ROWS
                    FETCH NEXT {pageSize} ROWS ONLY";

                using (var adapter = new SqlDataAdapter(dataQuery, connection))
                {
                    adapter.Fill(result);
                }

                // Get total count for pagination
                string countQuery = $"SELECT COUNT(*) FROM [dbo].[{tableName}]";
                using (var command = new SqlCommand(countQuery, connection))
                {
                    int totalCount = (int)command.ExecuteScalar();
                    // Add total count as a property of the DataTable
                    result.ExtendedProperties["TotalCount"] = totalCount;
                    result.ExtendedProperties["TotalPages"] = (int)Math.Ceiling((double)totalCount / pageSize);
                    result.ExtendedProperties["CurrentPage"] = page;
                }
            }

            return (result, columns);
        }
    }
}

