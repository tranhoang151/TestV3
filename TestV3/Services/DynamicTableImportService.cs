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

        // Thêm phương thức mới để lấy danh sách sheet từ file Excel
        public List<string> GetExcelSheets(Stream fileStream)
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

                    var sheetNames = new List<string>();
                    for (int i = 0; i < dataSet.Tables.Count; i++)
                    {
                        sheetNames.Add(dataSet.Tables[i].TableName);
                    }

                    return sheetNames;
                }
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        // Sửa phương thức ImportExcel để chỉ import sheet được chọn
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
                        var sheetName = SanitizeTableName(dataTable.TableName);

                        // Skip if not the selected sheet (when a sheet is selected)
                        if (!string.IsNullOrEmpty(selectedSheet) && sheetName != selectedSheet)
                        {
                            continue;
                        }

                        if (dataTable.Rows.Count == 0 || dataTable.Columns.Count == 0)
                        {
                            importedCounts.Add(sheetName, 0);
                            continue;
                        }

                        // Create or update table and import data
                        var importedCount = CreateTableAndImportData(dataTable, sheetName);
                        importedCounts.Add(sheetName, importedCount);

                        // If we're only importing a specific sheet, we can break after finding it
                        if (!string.IsNullOrEmpty(selectedSheet))
                        {
                            break;
                        }
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
            // Default to NVARCHAR(MAX) for simplicity
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

        // Add these methods to the existing DynamicTableImportService class

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