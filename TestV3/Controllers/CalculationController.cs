using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestV3.Data;
using TestV3.Services;
using System.IO;
using ClosedXML.Excel;

namespace TestV3.Controllers
{
    public class CalculationController : Controller
    {
        private readonly ICalculationService _calculationService;
        private readonly ApplicationDbContext _context;
        private const int PageSize = 10;

        public CalculationController(ICalculationService calculationService, ApplicationDbContext context)
        {
            _calculationService = calculationService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateFmpEvn()
        {
            try
            {
                await _calculationService.CalculateAndSaveFmpEvnAsync();
                TempData["Success"] = "FMP EVN data calculated and saved successfully.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error calculating FMP EVN data: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CalculatePmEvn()
        {
            try
            {
                await _calculationService.CalculateAndSavePmEvnAsync();
                TempData["Success"] = "PM EVN data calculated and saved successfully.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error calculating PM EVN data: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CalculateFmpSai()
        {
            try
            {
                await _calculationService.CalculateAndSaveFmpSaiAsync();
                TempData["Success"] = "FMP Sai data calculated and saved successfully.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error calculating FMP Sai data: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CalculatePmSai()
        {
            try
            {
                await _calculationService.CalculateAndSavePmSaiAsync();
                TempData["Success"] = "PM Sai data calculated and saved successfully.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error calculating PM Sai data: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetTableData(string tableName, int page = 1)
        {
            ViewBag.CurrentPage = page;

            switch (tableName)
            {
                case "FmpEvn":
                    var fmpEvnQuery = _context.FMP_EVN.AsQueryable();
                    int fmpEvnTotal = await fmpEvnQuery.CountAsync();
                    ViewBag.TotalPages = (int)Math.Ceiling(fmpEvnTotal / (double)PageSize);
                    ViewBag.TableName = "FmpEvn";

                    var fmpEvnData = await fmpEvnQuery
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();

                    return PartialView("_FmpEvnTable", fmpEvnData);

                case "PmEvn":
                    var pmEvnQuery = _context.Pm_EVN.AsQueryable();
                    int pmEvnTotal = await pmEvnQuery.CountAsync();
                    ViewBag.TotalPages = (int)Math.Ceiling(pmEvnTotal / (double)PageSize);
                    ViewBag.TableName = "PmEvn";

                    var pmEvnData = await pmEvnQuery
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();

                    return PartialView("_PmEvnTable", pmEvnData);

                case "FmpSai":
                    var fmpSaiQuery = _context.FMP_Sai.AsQueryable();
                    int fmpSaiTotal = await fmpSaiQuery.CountAsync();
                    ViewBag.TotalPages = (int)Math.Ceiling(fmpSaiTotal / (double)PageSize);
                    ViewBag.TableName = "FmpSai";

                    var fmpSaiData = await fmpSaiQuery
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();

                    return PartialView("_FmpSaiTable", fmpSaiData);

                case "PmSai":
                    var pmSaiQuery = _context.Pm_Sai.AsQueryable();
                    int pmSaiTotal = await pmSaiQuery.CountAsync();
                    ViewBag.TotalPages = (int)Math.Ceiling(pmSaiTotal / (double)PageSize);
                    ViewBag.TableName = "PmSai";

                    var pmSaiData = await pmSaiQuery
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();

                    return PartialView("_PmSaiTable", pmSaiData);

                default:
                    return Content("Invalid table name");
            }
        }

        public async Task<IActionResult> ExportToExcel(string tableName)
        {
            try
            {
                // Create a new memory stream to store the Excel file
                using (var memoryStream = new MemoryStream())
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add(tableName);

                        // Add headers based on table type
                        int colIndex = 1;

                        // Common columns
                        worksheet.Cell(1, colIndex++).Value = "ID";
                        worksheet.Cell(1, colIndex++).Value = "Ngày";
                        worksheet.Cell(1, colIndex++).Value = "Giá";

                        // Add timeslot headers
                        for (int hour = 0; hour <= 23; hour++)
                        {
                            worksheet.Cell(1, colIndex++).Value = hour + "h30";
                            worksheet.Cell(1, colIndex++).Value = (hour + 1) + "h";
                        }
                        worksheet.Cell(1, colIndex++).Value = "Tổng";

                        // Apply formatting to header
                        var headerRange = worksheet.Range(1, 1, 1, colIndex - 1);
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                        // Add data based on table type
                        int rowIndex = 2;

                        switch (tableName)
                        {
                            case "FmpEvn":
                                var fmpEvnData = await _context.FMP_EVN.ToListAsync();
                                foreach (var item in fmpEvnData)
                                {
                                    colIndex = 1;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Id;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Ngay;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Gia;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy0h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy1h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy1h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy2h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy2h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy3h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy3h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy4h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy4h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy5h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy5h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy6h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy6h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy7h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy7h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy8h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy8h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy9h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy9h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy10h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy10h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy11h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy11h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy12h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy12h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy13h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy13h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy14h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy14h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy15h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy15h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy16h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy16h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy17h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy17h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy18h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy18h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy19h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy19h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy20h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy20h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy21h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy21h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy22h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy22h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy23h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy23h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy24h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Tong;
                                    rowIndex++;
                                }
                                break;

                            case "PmEvn":
                                var pmEvnData = await _context.Pm_EVN.ToListAsync();
                                foreach (var item in pmEvnData)
                                {
                                    colIndex = 1;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Id;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Ngay;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Gia;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy0h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy1h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy1h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy2h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy2h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy3h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy3h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy4h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy4h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy5h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy5h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy6h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy6h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy7h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy7h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy8h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy8h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy9h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy9h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy10h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy10h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy11h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy11h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy12h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy12h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy13h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy13h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy14h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy14h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy15h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy15h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy16h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy16h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy17h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy17h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy18h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy18h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy19h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy19h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy20h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy20h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy21h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy21h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy22h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy22h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy23h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy23h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy24h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Tong;
                                    rowIndex++;
                                }
                                break;

                            case "FmpSai":
                                var fmpSaiData = await _context.FMP_Sai.ToListAsync();
                                foreach (var item in fmpSaiData)
                                {
                                    colIndex = 1;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Id;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Ngay;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Gia;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy0h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy1h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy1h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy2h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy2h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy3h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy3h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy4h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy4h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy5h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy5h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy6h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy6h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy7h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy7h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy8h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy8h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy9h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy9h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy10h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy10h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy11h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy11h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy12h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy12h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy13h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy13h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy14h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy14h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy15h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy15h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy16h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy16h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy17h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy17h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy18h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy18h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy19h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy19h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy20h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy20h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy21h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy21h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy22h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy22h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy23h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy23h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy24h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Tong;
                                    rowIndex++;
                                }
                                break;

                            case "PmSai":
                                var pmSaiData = await _context.Pm_Sai.ToListAsync();
                                foreach (var item in pmSaiData)
                                {
                                    colIndex = 1;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Id;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Ngay;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Gia;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy0h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy1h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy1h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy2h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy2h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy3h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy3h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy4h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy4h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy5h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy5h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy6h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy6h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy7h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy7h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy8h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy8h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy9h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy9h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy10h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy10h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy11h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy11h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy12h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy12h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy13h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy13h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy14h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy14h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy15h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy15h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy16h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy16h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy17h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy17h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy18h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy18h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy19h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy19h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy20h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy20h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy21h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy21h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy22h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy22h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy23h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy23h30;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.ChuKy24h;
                                    worksheet.Cell(rowIndex, colIndex++).Value = item.Tong;
                                    rowIndex++;
                                }
                                break;

                            default:
                                return Content("Invalid table name");
                        }

                        // Auto-fit columns
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(memoryStream);
                    }

                    memoryStream.Position = 0;
                    string fileName = $"{tableName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error exporting to Excel: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}