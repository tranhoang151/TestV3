using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using TestV3.Services;
using TestV3.Models;

namespace TestV3.Controllers
{
    public class TableViewerController : Controller
    {
        private readonly DynamicTableImportService _tableService;

        public TableViewerController(DynamicTableImportService tableService)
        {
            _tableService = tableService;
        }

        public IActionResult Index(string tableName = null, int page = 1)
        {
            // Get all available tables
            var tables = _tableService.GetAllTables();

            if (tables.Count == 0)
            {
                ViewBag.NoTables = true;
                return View();
            }

            // If no table is specified, use the first one
            if (string.IsNullOrEmpty(tableName) && tables.Count > 0)
            {
                tableName = tables[0];
            }

            // Get data for the selected table
            var (data, columns) = _tableService.GetTableData(tableName, page);

            // Prepare view model
            var viewModel = new TableViewerModel
            {
                Tables = tables,
                SelectedTable = tableName,
                Data = data,
                Columns = columns,
                CurrentPage = page,
                TotalPages = (int)data.ExtendedProperties["TotalPages"],
                TotalRecords = (int)data.ExtendedProperties["TotalCount"]
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetTableData(string tableName, int page = 1)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                return BadRequest("Table name is required");
            }

            var (data, columns) = _tableService.GetTableData(tableName, page);

            var viewModel = new TableViewerModel
            {
                SelectedTable = tableName,
                Data = data,
                Columns = columns,
                CurrentPage = page,
                TotalPages = (int)data.ExtendedProperties["TotalPages"],
                TotalRecords = (int)data.ExtendedProperties["TotalCount"]
            };

            return PartialView("_TableDataPartial", viewModel);
        }
    }
}