using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using TestV3.Services;

namespace TestV3.Controllers
{
    public class CfdCalculationController : Controller
    {
        private readonly ICfdCalculationService _cfdCalculationService;

        public CfdCalculationController(ICfdCalculationService cfdCalculationService)
        {
            _cfdCalculationService = cfdCalculationService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> PriceData()
        {
            var priceData = await _cfdCalculationService.GetCfdPm1PcDataAsync();
            return View(priceData);
        }

        public async Task<IActionResult> QuantityData()
        {
            var quantityData = await _cfdCalculationService.GetCfdPm1QcDataAsync();
            return View(quantityData);
        }

        public async Task<IActionResult> FmpData()
        {
            var fmpData = await _cfdCalculationService.GetFmpEvnDataAsync();
            return View(fmpData);
        }

        //PM1 Actions
        public async Task<IActionResult> PM1Index()
        {
            var cfdData = await _cfdCalculationService.GetCfdPm1DataAsync();
            return View(cfdData);
        }

        [HttpPost]
        public async Task<IActionResult> CalculatePM1()
        {
            try
            {
                await _cfdCalculationService.CalculateAndSaveCfdPm1Async();
                TempData["SuccessMessage"] = "CFD PM1 data has been calculated and saved successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error calculating CFD PM1 data: {ex.Message}";
            }

            return RedirectToAction(nameof(PM1Index));
        }

        public async Task<IActionResult> Summary()
        {
            var summaryData = await _cfdCalculationService.GetSummaryDataAsync();
            return View(summaryData);
        }

        [HttpGet]
        public async Task<IActionResult> ExportPM1ToExcel()
        {
            var cfdData = await _cfdCalculationService.GetCfdPm1DataAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CFD PM1");

                // Add headers
                worksheet.Cell(1, 1).Value = "Ngày";
                worksheet.Cell(1, 2).Value = "0h30";
                worksheet.Cell(1, 3).Value = "1h";
                worksheet.Cell(1, 4).Value = "1h30";
                worksheet.Cell(1, 5).Value = "2h";
                worksheet.Cell(1, 6).Value = "2h30";
                worksheet.Cell(1, 7).Value = "3h";
                worksheet.Cell(1, 8).Value = "3h30";
                worksheet.Cell(1, 9).Value = "4h";
                worksheet.Cell(1, 10).Value = "4h30";
                worksheet.Cell(1, 11).Value = "5h";
                worksheet.Cell(1, 12).Value = "5h30";
                worksheet.Cell(1, 13).Value = "6h";
                worksheet.Cell(1, 14).Value = "6h30";
                worksheet.Cell(1, 15).Value = "7h";
                worksheet.Cell(1, 16).Value = "7h30";
                worksheet.Cell(1, 17).Value = "8h";
                worksheet.Cell(1, 18).Value = "8h30";
                worksheet.Cell(1, 19).Value = "9h";
                worksheet.Cell(1, 20).Value = "9h30";
                worksheet.Cell(1, 21).Value = "10h";
                worksheet.Cell(1, 22).Value = "10h30";
                worksheet.Cell(1, 23).Value = "11h";
                worksheet.Cell(1, 24).Value = "11h30";
                worksheet.Cell(1, 25).Value = "12h";
                worksheet.Cell(1, 26).Value = "12h30";
                worksheet.Cell(1, 27).Value = "13h";
                worksheet.Cell(1, 28).Value = "13h30";
                worksheet.Cell(1, 29).Value = "14h";
                worksheet.Cell(1, 30).Value = "14h30";
                worksheet.Cell(1, 31).Value = "15h";
                worksheet.Cell(1, 32).Value = "15h30";
                worksheet.Cell(1, 33).Value = "16h";
                worksheet.Cell(1, 34).Value = "16h30";
                worksheet.Cell(1, 35).Value = "17h";
                worksheet.Cell(1, 36).Value = "17h30";
                worksheet.Cell(1, 37).Value = "18h";
                worksheet.Cell(1, 38).Value = "18h30";
                worksheet.Cell(1, 39).Value = "19h";
                worksheet.Cell(1, 40).Value = "19h30";
                worksheet.Cell(1, 41).Value = "20h";
                worksheet.Cell(1, 42).Value = "20h30";
                worksheet.Cell(1, 43).Value = "21h";
                worksheet.Cell(1, 44).Value = "21h30";
                worksheet.Cell(1, 45).Value = "22h";
                worksheet.Cell(1, 46).Value = "22h30";
                worksheet.Cell(1, 47).Value = "23h";
                worksheet.Cell(1, 48).Value = "23h30";
                worksheet.Cell(1, 49).Value = "24h";
                worksheet.Cell(1, 50).Value = "Tổng";

                // Style the header row
                var headerRow = worksheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;

                // Add data rows
                int row = 2;
                foreach (var item in cfdData)
                {
                    worksheet.Cell(row, 1).Value = item.Ngay;
                    worksheet.Cell(row, 2).Value = item.ChuKy0h30 ?? 0;
                    worksheet.Cell(row, 3).Value = item.ChuKy1h ?? 0;
                    worksheet.Cell(row, 4).Value = item.ChuKy1h30 ?? 0;
                    worksheet.Cell(row, 5).Value = item.ChuKy2h ?? 0;
                    worksheet.Cell(row, 6).Value = item.ChuKy2h30 ?? 0;
                    worksheet.Cell(row, 7).Value = item.ChuKy3h ?? 0;
                    worksheet.Cell(row, 8).Value = item.ChuKy3h30 ?? 0;
                    worksheet.Cell(row, 9).Value = item.ChuKy4h ?? 0;
                    worksheet.Cell(row, 10).Value = item.ChuKy4h30 ?? 0;
                    worksheet.Cell(row, 11).Value = item.ChuKy5h ?? 0;
                    worksheet.Cell(row, 12).Value = item.ChuKy5h30 ?? 0;
                    worksheet.Cell(row, 13).Value = item.ChuKy6h ?? 0;
                    worksheet.Cell(row, 14).Value = item.ChuKy6h30 ?? 0;
                    worksheet.Cell(row, 15).Value = item.ChuKy7h ?? 0;
                    worksheet.Cell(row, 16).Value = item.ChuKy7h30 ?? 0;
                    worksheet.Cell(row, 17).Value = item.ChuKy8h ?? 0;
                    worksheet.Cell(row, 18).Value = item.ChuKy8h30 ?? 0;
                    worksheet.Cell(row, 19).Value = item.ChuKy9h ?? 0;
                    worksheet.Cell(row, 20).Value = item.ChuKy9h30 ?? 0;
                    worksheet.Cell(row, 21).Value = item.ChuKy10h ?? 0;
                    worksheet.Cell(row, 22).Value = item.ChuKy10h30 ?? 0;
                    worksheet.Cell(row, 23).Value = item.ChuKy11h ?? 0;
                    worksheet.Cell(row, 24).Value = item.ChuKy11h30 ?? 0;
                    worksheet.Cell(row, 25).Value = item.ChuKy12h ?? 0;
                    worksheet.Cell(row, 26).Value = item.ChuKy12h30 ?? 0;
                    worksheet.Cell(row, 27).Value = item.ChuKy13h ?? 0;
                    worksheet.Cell(row, 28).Value = item.ChuKy13h30 ?? 0;
                    worksheet.Cell(row, 29).Value = item.ChuKy14h ?? 0;
                    worksheet.Cell(row, 30).Value = item.ChuKy14h30 ?? 0;
                    worksheet.Cell(row, 31).Value = item.ChuKy15h ?? 0;
                    worksheet.Cell(row, 32).Value = item.ChuKy15h30 ?? 0;
                    worksheet.Cell(row, 33).Value = item.ChuKy16h ?? 0;
                    worksheet.Cell(row, 34).Value = item.ChuKy16h30 ?? 0;
                    worksheet.Cell(row, 35).Value = item.ChuKy17h ?? 0;
                    worksheet.Cell(row, 36).Value = item.ChuKy17h30 ?? 0;
                    worksheet.Cell(row, 37).Value = item.ChuKy18h ?? 0;
                    worksheet.Cell(row, 38).Value = item.ChuKy18h30 ?? 0;
                    worksheet.Cell(row, 39).Value = item.ChuKy19h ?? 0;
                    worksheet.Cell(row, 40).Value = item.ChuKy19h30 ?? 0;
                    worksheet.Cell(row, 41).Value = item.ChuKy20h ?? 0;
                    worksheet.Cell(row, 42).Value = item.ChuKy20h30 ?? 0;
                    worksheet.Cell(row, 43).Value = item.ChuKy21h ?? 0;
                    worksheet.Cell(row, 44).Value = item.ChuKy21h30 ?? 0;
                    worksheet.Cell(row, 45).Value = item.ChuKy22h ?? 0;
                    worksheet.Cell(row, 46).Value = item.ChuKy22h30 ?? 0;
                    worksheet.Cell(row, 47).Value = item.ChuKy23h ?? 0;
                    worksheet.Cell(row, 48).Value = item.ChuKy23h30 ?? 0;
                    worksheet.Cell(row, 49).Value = item.ChuKy24h ?? 0;
                    worksheet.Cell(row, 50).Value = item.Tong ?? 0;
                    row++;
                }

                // Add totals row
                worksheet.Cell(row, 1).Value = "Tổng cộng";
                worksheet.Cell(row, 1).Style.Font.Bold = true;

                // Calculate totals for each column
                for (int col = 2; col <= 50; col++)
                {
                    var columnLetter = worksheet.Column(col).ColumnLetter();
                    worksheet.Cell(row, col).FormulaA1 = $"SUM({columnLetter}2:{columnLetter}{row - 1})";
                    worksheet.Cell(row, col).Style.Font.Bold = true;
                }

                // Style the totals row
                worksheet.Row(row).Style.Fill.BackgroundColor = XLColor.LightGray;

                // Auto-fit columns
                worksheet.Columns().AdjustToContents();

                // Create a memory stream to save the workbook
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    // Return the Excel file
                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"CfdPm1_{DateTime.Now:yyyyMMdd}.xlsx");
                }
            }
        }


        //PM4 Actions
        public async Task<IActionResult> PM4Index()
        {
            var cfdData = await _cfdCalculationService.GetCfdPm4DataAsync();
            return View(cfdData);
        }

        [HttpPost]
        public async Task<IActionResult> CalculatePM4()
        {
            try
            {
                await _cfdCalculationService.CalculateAndSaveCfdPm4Async();
                TempData["SuccessMessage"] = "CFD PM4 data has been calculated and saved successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error calculating CFD PM4 data: {ex.Message}";
            }

            return RedirectToAction(nameof(PM4Index));
        }

        public async Task<IActionResult> ExportPM4ToExcel()
        {
            var cfdData = await _cfdCalculationService.GetCfdPm4DataAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CFD PM4");

                // Add headers
                worksheet.Cell(1, 1).Value = "Ngày";
                worksheet.Cell(1, 2).Value = "0h30";
                worksheet.Cell(1, 3).Value = "1h";
                worksheet.Cell(1, 4).Value = "1h30";
                worksheet.Cell(1, 5).Value = "2h";
                worksheet.Cell(1, 6).Value = "2h30";
                worksheet.Cell(1, 7).Value = "3h";
                worksheet.Cell(1, 8).Value = "3h30";
                worksheet.Cell(1, 9).Value = "4h";
                worksheet.Cell(1, 10).Value = "4h30";
                worksheet.Cell(1, 11).Value = "5h";
                worksheet.Cell(1, 12).Value = "5h30";
                worksheet.Cell(1, 13).Value = "6h";
                worksheet.Cell(1, 14).Value = "6h30";
                worksheet.Cell(1, 15).Value = "7h";
                worksheet.Cell(1, 16).Value = "7h30";
                worksheet.Cell(1, 17).Value = "8h";
                worksheet.Cell(1, 18).Value = "8h30";
                worksheet.Cell(1, 19).Value = "9h";
                worksheet.Cell(1, 20).Value = "9h30";
                worksheet.Cell(1, 21).Value = "10h";
                worksheet.Cell(1, 22).Value = "10h30";
                worksheet.Cell(1, 23).Value = "11h";
                worksheet.Cell(1, 24).Value = "11h30";
                worksheet.Cell(1, 25).Value = "12h";
                worksheet.Cell(1, 26).Value = "12h30";
                worksheet.Cell(1, 27).Value = "13h";
                worksheet.Cell(1, 28).Value = "13h30";
                worksheet.Cell(1, 29).Value = "14h";
                worksheet.Cell(1, 30).Value = "14h30";
                worksheet.Cell(1, 31).Value = "15h";
                worksheet.Cell(1, 32).Value = "15h30";
                worksheet.Cell(1, 33).Value = "16h";
                worksheet.Cell(1, 34).Value = "16h30";
                worksheet.Cell(1, 35).Value = "17h";
                worksheet.Cell(1, 36).Value = "17h30";
                worksheet.Cell(1, 37).Value = "18h";
                worksheet.Cell(1, 38).Value = "18h30";
                worksheet.Cell(1, 39).Value = "19h";
                worksheet.Cell(1, 40).Value = "19h30";
                worksheet.Cell(1, 41).Value = "20h";
                worksheet.Cell(1, 42).Value = "20h30";
                worksheet.Cell(1, 43).Value = "21h";
                worksheet.Cell(1, 44).Value = "21h30";
                worksheet.Cell(1, 45).Value = "22h";
                worksheet.Cell(1, 46).Value = "22h30";
                worksheet.Cell(1, 47).Value = "23h";
                worksheet.Cell(1, 48).Value = "23h30";
                worksheet.Cell(1, 49).Value = "24h";
                worksheet.Cell(1, 50).Value = "Tổng";

                // Style the header row
                var headerRow = worksheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;

                // Add data rows
                int row = 2;
                foreach (var item in cfdData)
                {
                    worksheet.Cell(row, 1).Value = item.Ngay;
                    worksheet.Cell(row, 2).Value = item.ChuKy0h30 ?? 0;
                    worksheet.Cell(row, 3).Value = item.ChuKy1h ?? 0;
                    worksheet.Cell(row, 4).Value = item.ChuKy1h30 ?? 0;
                    worksheet.Cell(row, 5).Value = item.ChuKy2h ?? 0;
                    worksheet.Cell(row, 6).Value = item.ChuKy2h30 ?? 0;
                    worksheet.Cell(row, 7).Value = item.ChuKy3h ?? 0;
                    worksheet.Cell(row, 8).Value = item.ChuKy3h30 ?? 0;
                    worksheet.Cell(row, 9).Value = item.ChuKy4h ?? 0;
                    worksheet.Cell(row, 10).Value = item.ChuKy4h30 ?? 0;
                    worksheet.Cell(row, 11).Value = item.ChuKy5h ?? 0;
                    worksheet.Cell(row, 12).Value = item.ChuKy5h30 ?? 0;
                    worksheet.Cell(row, 13).Value = item.ChuKy6h ?? 0;
                    worksheet.Cell(row, 14).Value = item.ChuKy6h30 ?? 0;
                    worksheet.Cell(row, 15).Value = item.ChuKy7h ?? 0;
                    worksheet.Cell(row, 16).Value = item.ChuKy7h30 ?? 0;
                    worksheet.Cell(row, 17).Value = item.ChuKy8h ?? 0;
                    worksheet.Cell(row, 18).Value = item.ChuKy8h30 ?? 0;
                    worksheet.Cell(row, 19).Value = item.ChuKy9h ?? 0;
                    worksheet.Cell(row, 20).Value = item.ChuKy9h30 ?? 0;
                    worksheet.Cell(row, 21).Value = item.ChuKy10h ?? 0;
                    worksheet.Cell(row, 22).Value = item.ChuKy10h30 ?? 0;
                    worksheet.Cell(row, 23).Value = item.ChuKy11h ?? 0;
                    worksheet.Cell(row, 24).Value = item.ChuKy11h30 ?? 0;
                    worksheet.Cell(row, 25).Value = item.ChuKy12h ?? 0;
                    worksheet.Cell(row, 26).Value = item.ChuKy12h30 ?? 0;
                    worksheet.Cell(row, 27).Value = item.ChuKy13h ?? 0;
                    worksheet.Cell(row, 28).Value = item.ChuKy13h30 ?? 0;
                    worksheet.Cell(row, 29).Value = item.ChuKy14h ?? 0;
                    worksheet.Cell(row, 30).Value = item.ChuKy14h30 ?? 0;
                    worksheet.Cell(row, 31).Value = item.ChuKy15h ?? 0;
                    worksheet.Cell(row, 32).Value = item.ChuKy15h30 ?? 0;
                    worksheet.Cell(row, 33).Value = item.ChuKy16h ?? 0;
                    worksheet.Cell(row, 34).Value = item.ChuKy16h30 ?? 0;
                    worksheet.Cell(row, 35).Value = item.ChuKy17h ?? 0;
                    worksheet.Cell(row, 36).Value = item.ChuKy17h30 ?? 0;
                    worksheet.Cell(row, 37).Value = item.ChuKy18h ?? 0;
                    worksheet.Cell(row, 38).Value = item.ChuKy18h30 ?? 0;
                    worksheet.Cell(row, 39).Value = item.ChuKy19h ?? 0;
                    worksheet.Cell(row, 40).Value = item.ChuKy19h30 ?? 0;
                    worksheet.Cell(row, 41).Value = item.ChuKy20h ?? 0;
                    worksheet.Cell(row, 42).Value = item.ChuKy20h30 ?? 0;
                    worksheet.Cell(row, 43).Value = item.ChuKy21h ?? 0;
                    worksheet.Cell(row, 44).Value = item.ChuKy21h30 ?? 0;
                    worksheet.Cell(row, 45).Value = item.ChuKy22h ?? 0;
                    worksheet.Cell(row, 46).Value = item.ChuKy22h30 ?? 0;
                    worksheet.Cell(row, 47).Value = item.ChuKy23h ?? 0;
                    worksheet.Cell(row, 48).Value = item.ChuKy23h30 ?? 0;
                    worksheet.Cell(row, 49).Value = item.ChuKy24h ?? 0;
                    worksheet.Cell(row, 50).Value = item.Tong ?? 0;
                    row++;
                }

                // Add totals row
                worksheet.Cell(row, 1).Value = "Tổng cộng";
                worksheet.Cell(row, 1).Style.Font.Bold = true;

                // Calculate totals for each column
                for (int col = 2; col <= 50; col++)
                {
                    var columnLetter = worksheet.Column(col).ColumnLetter();
                    worksheet.Cell(row, col).FormulaA1 = $"SUM({columnLetter}2:{columnLetter}{row - 1})";
                    worksheet.Cell(row, col).Style.Font.Bold = true;
                }

                // Style the totals row
                worksheet.Row(row).Style.Fill.BackgroundColor = XLColor.LightGray;

                // Auto-fit columns
                worksheet.Columns().AdjustToContents();

                // Create a memory stream to save the workbook
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    // Return the Excel file
                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"CfdPm4_{DateTime.Now:yyyyMMdd}.xlsx");
                }
            }
        }


        //TB1 Actions
        public async Task<IActionResult> TB1Index()
        {
            var cfdData = await _cfdCalculationService.GetCfdTb1DataAsync();
            return View(cfdData);
        }

        [HttpPost]
        public async Task<IActionResult> CalculateTB1()
        {
            try
            {
                await _cfdCalculationService.CalculateAndSaveCfdTb1Async();
                TempData["SuccessMessage"] = "CFD TB1 data has been calculated and saved successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error calculating CFD TB1 data: {ex.Message}";
            }

            return RedirectToAction(nameof(TB1Index));
        }

        public async Task<IActionResult> ExportTB1ToExcel()
        {
            var cfdData = await _cfdCalculationService.GetCfdTb1DataAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CFD TB1");

                // Add headers
                worksheet.Cell(1, 1).Value = "Ngày";
                worksheet.Cell(1, 2).Value = "0h30";
                worksheet.Cell(1, 3).Value = "1h";
                worksheet.Cell(1, 4).Value = "1h30";
                worksheet.Cell(1, 5).Value = "2h";
                worksheet.Cell(1, 6).Value = "2h30";
                worksheet.Cell(1, 7).Value = "3h";
                worksheet.Cell(1, 8).Value = "3h30";
                worksheet.Cell(1, 9).Value = "4h";
                worksheet.Cell(1, 10).Value = "4h30";
                worksheet.Cell(1, 11).Value = "5h";
                worksheet.Cell(1, 12).Value = "5h30";
                worksheet.Cell(1, 13).Value = "6h";
                worksheet.Cell(1, 14).Value = "6h30";
                worksheet.Cell(1, 15).Value = "7h";
                worksheet.Cell(1, 16).Value = "7h30";
                worksheet.Cell(1, 17).Value = "8h";
                worksheet.Cell(1, 18).Value = "8h30";
                worksheet.Cell(1, 19).Value = "9h";
                worksheet.Cell(1, 20).Value = "9h30";
                worksheet.Cell(1, 21).Value = "10h";
                worksheet.Cell(1, 22).Value = "10h30";
                worksheet.Cell(1, 23).Value = "11h";
                worksheet.Cell(1, 24).Value = "11h30";
                worksheet.Cell(1, 25).Value = "12h";
                worksheet.Cell(1, 26).Value = "12h30";
                worksheet.Cell(1, 27).Value = "13h";
                worksheet.Cell(1, 28).Value = "13h30";
                worksheet.Cell(1, 29).Value = "14h";
                worksheet.Cell(1, 30).Value = "14h30";
                worksheet.Cell(1, 31).Value = "15h";
                worksheet.Cell(1, 32).Value = "15h30";
                worksheet.Cell(1, 33).Value = "16h";
                worksheet.Cell(1, 34).Value = "16h30";
                worksheet.Cell(1, 35).Value = "17h";
                worksheet.Cell(1, 36).Value = "17h30";
                worksheet.Cell(1, 37).Value = "18h";
                worksheet.Cell(1, 38).Value = "18h30";
                worksheet.Cell(1, 39).Value = "19h";
                worksheet.Cell(1, 40).Value = "19h30";
                worksheet.Cell(1, 41).Value = "20h";
                worksheet.Cell(1, 42).Value = "20h30";
                worksheet.Cell(1, 43).Value = "21h";
                worksheet.Cell(1, 44).Value = "21h30";
                worksheet.Cell(1, 45).Value = "22h";
                worksheet.Cell(1, 46).Value = "22h30";
                worksheet.Cell(1, 47).Value = "23h";
                worksheet.Cell(1, 48).Value = "23h30";
                worksheet.Cell(1, 49).Value = "24h";
                worksheet.Cell(1, 50).Value = "Tổng";

                // Style the header row
                var headerRow = worksheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;

                // Add data rows
                int row = 2;
                foreach (var item in cfdData)
                {
                    worksheet.Cell(row, 1).Value = item.Ngay;
                    worksheet.Cell(row, 2).Value = item.ChuKy0h30 ?? 0;
                    worksheet.Cell(row, 3).Value = item.ChuKy1h ?? 0;
                    worksheet.Cell(row, 4).Value = item.ChuKy1h30 ?? 0;
                    worksheet.Cell(row, 5).Value = item.ChuKy2h ?? 0;
                    worksheet.Cell(row, 6).Value = item.ChuKy2h30 ?? 0;
                    worksheet.Cell(row, 7).Value = item.ChuKy3h ?? 0;
                    worksheet.Cell(row, 8).Value = item.ChuKy3h30 ?? 0;
                    worksheet.Cell(row, 9).Value = item.ChuKy4h ?? 0;
                    worksheet.Cell(row, 10).Value = item.ChuKy4h30 ?? 0;
                    worksheet.Cell(row, 11).Value = item.ChuKy5h ?? 0;
                    worksheet.Cell(row, 12).Value = item.ChuKy5h30 ?? 0;
                    worksheet.Cell(row, 13).Value = item.ChuKy6h ?? 0;
                    worksheet.Cell(row, 14).Value = item.ChuKy6h30 ?? 0;
                    worksheet.Cell(row, 15).Value = item.ChuKy7h ?? 0;
                    worksheet.Cell(row, 16).Value = item.ChuKy7h30 ?? 0;
                    worksheet.Cell(row, 17).Value = item.ChuKy8h ?? 0;
                    worksheet.Cell(row, 18).Value = item.ChuKy8h30 ?? 0;
                    worksheet.Cell(row, 19).Value = item.ChuKy9h ?? 0;
                    worksheet.Cell(row, 20).Value = item.ChuKy9h30 ?? 0;
                    worksheet.Cell(row, 21).Value = item.ChuKy10h ?? 0;
                    worksheet.Cell(row, 22).Value = item.ChuKy10h30 ?? 0;
                    worksheet.Cell(row, 23).Value = item.ChuKy11h ?? 0;
                    worksheet.Cell(row, 24).Value = item.ChuKy11h30 ?? 0;
                    worksheet.Cell(row, 25).Value = item.ChuKy12h ?? 0;
                    worksheet.Cell(row, 26).Value = item.ChuKy12h30 ?? 0;
                    worksheet.Cell(row, 27).Value = item.ChuKy13h ?? 0;
                    worksheet.Cell(row, 28).Value = item.ChuKy13h30 ?? 0;
                    worksheet.Cell(row, 29).Value = item.ChuKy14h ?? 0;
                    worksheet.Cell(row, 30).Value = item.ChuKy14h30 ?? 0;
                    worksheet.Cell(row, 31).Value = item.ChuKy15h ?? 0;
                    worksheet.Cell(row, 32).Value = item.ChuKy15h30 ?? 0;
                    worksheet.Cell(row, 33).Value = item.ChuKy16h ?? 0;
                    worksheet.Cell(row, 34).Value = item.ChuKy16h30 ?? 0;
                    worksheet.Cell(row, 35).Value = item.ChuKy17h ?? 0;
                    worksheet.Cell(row, 36).Value = item.ChuKy17h30 ?? 0;
                    worksheet.Cell(row, 37).Value = item.ChuKy18h ?? 0;
                    worksheet.Cell(row, 38).Value = item.ChuKy18h30 ?? 0;
                    worksheet.Cell(row, 39).Value = item.ChuKy19h ?? 0;
                    worksheet.Cell(row, 40).Value = item.ChuKy19h30 ?? 0;
                    worksheet.Cell(row, 41).Value = item.ChuKy20h ?? 0;
                    worksheet.Cell(row, 42).Value = item.ChuKy20h30 ?? 0;
                    worksheet.Cell(row, 43).Value = item.ChuKy21h ?? 0;
                    worksheet.Cell(row, 44).Value = item.ChuKy21h30 ?? 0;
                    worksheet.Cell(row, 45).Value = item.ChuKy22h ?? 0;
                    worksheet.Cell(row, 46).Value = item.ChuKy22h30 ?? 0;
                    worksheet.Cell(row, 47).Value = item.ChuKy23h ?? 0;
                    worksheet.Cell(row, 48).Value = item.ChuKy23h30 ?? 0;
                    worksheet.Cell(row, 49).Value = item.ChuKy24h ?? 0;
                    worksheet.Cell(row, 50).Value = item.Tong ?? 0;
                    row++;
                }

                // Add totals row
                worksheet.Cell(row, 1).Value = "Tổng cộng";
                worksheet.Cell(row, 1).Style.Font.Bold = true;

                // Calculate totals for each column
                for (int col = 2; col <= 50; col++)
                {
                    var columnLetter = worksheet.Column(col).ColumnLetter();
                    worksheet.Cell(row, col).FormulaA1 = $"SUM({columnLetter}2:{columnLetter}{row - 1})";
                    worksheet.Cell(row, col).Style.Font.Bold = true;
                }

                // Style the totals row
                worksheet.Row(row).Style.Fill.BackgroundColor = XLColor.LightGray;

                // Auto-fit columns
                worksheet.Columns().AdjustToContents();

                // Create a memory stream to save the workbook
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    // Return the Excel file
                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"CfdTb1_{DateTime.Now:yyyyMMdd}.xlsx");
                }
            }
        }


        //DH3MR Actions
        public async Task<IActionResult> DH3MRIndex()
        {
            var cfdData = await _cfdCalculationService.GetCfdDh3mrDataAsync();
            return View(cfdData);
        }
        [HttpPost]
        public async Task<IActionResult> CalculateDH3MR()
        {
            try
            {
                await _cfdCalculationService.CalculateAndSaveCfdDh3mrAsync();
                TempData["SuccessMessage"] = "CFD DH3MR data has been calculated and saved successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error calculating CFD DH3MR data: {ex.Message}";
            }
            return RedirectToAction(nameof(DH3MRIndex));
        }
        public async Task<IActionResult> ExportDH3MRToExcel()
        {
            var cfdData = await _cfdCalculationService.GetCfdDh3mrDataAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CFD DH3MR");

                // Add headers
                worksheet.Cell(1, 1).Value = "Ngày";
                worksheet.Cell(1, 2).Value = "0h30";
                worksheet.Cell(1, 3).Value = "1h";
                worksheet.Cell(1, 4).Value = "1h30";
                worksheet.Cell(1, 5).Value = "2h";
                worksheet.Cell(1, 6).Value = "2h30";
                worksheet.Cell(1, 7).Value = "3h";
                worksheet.Cell(1, 8).Value = "3h30";
                worksheet.Cell(1, 9).Value = "4h";
                worksheet.Cell(1, 10).Value = "4h30";
                worksheet.Cell(1, 11).Value = "5h";
                worksheet.Cell(1, 12).Value = "5h30";
                worksheet.Cell(1, 13).Value = "6h";
                worksheet.Cell(1, 14).Value = "6h30";
                worksheet.Cell(1, 15).Value = "7h";
                worksheet.Cell(1, 16).Value = "7h30";
                worksheet.Cell(1, 17).Value = "8h";
                worksheet.Cell(1, 18).Value = "8h30";
                worksheet.Cell(1, 19).Value = "9h";
                worksheet.Cell(1, 20).Value = "9h30";
                worksheet.Cell(1, 21).Value = "10h";
                worksheet.Cell(1, 22).Value = "10h30";
                worksheet.Cell(1, 23).Value = "11h";
                worksheet.Cell(1, 24).Value = "11h30";
                worksheet.Cell(1, 25).Value = "12h";
                worksheet.Cell(1, 26).Value = "12h30";
                worksheet.Cell(1, 27).Value = "13h";
                worksheet.Cell(1, 28).Value = "13h30";
                worksheet.Cell(1, 29).Value = "14h";
                worksheet.Cell(1, 30).Value = "14h30";
                worksheet.Cell(1, 31).Value = "15h";
                worksheet.Cell(1, 32).Value = "15h30";
                worksheet.Cell(1, 33).Value = "16h";
                worksheet.Cell(1, 34).Value = "16h30";
                worksheet.Cell(1, 35).Value = "17h";
                worksheet.Cell(1, 36).Value = "17h30";
                worksheet.Cell(1, 37).Value = "18h";
                worksheet.Cell(1, 38).Value = "18h30";
                worksheet.Cell(1, 39).Value = "19h";
                worksheet.Cell(1, 40).Value = "19h30";
                worksheet.Cell(1, 41).Value = "20h";
                worksheet.Cell(1, 42).Value = "20h30";
                worksheet.Cell(1, 43).Value = "21h";
                worksheet.Cell(1, 44).Value = "21h30";
                worksheet.Cell(1, 45).Value = "22h";
                worksheet.Cell(1, 46).Value = "22h30";
                worksheet.Cell(1, 47).Value = "23h";
                worksheet.Cell(1, 48).Value = "23h30";
                worksheet.Cell(1, 49).Value = "24h";
                worksheet.Cell(1, 50).Value = "Tổng";

                // Style the header row
                var headerRow = worksheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;

                // Add data rows
                int row = 2;
                foreach (var item in cfdData)
                {
                    worksheet.Cell(row, 1).Value = item.Ngay;
                    worksheet.Cell(row, 2).Value = item.ChuKy0h30 ?? 0;
                    worksheet.Cell(row, 3).Value = item.ChuKy1h ?? 0;
                    worksheet.Cell(row, 4).Value = item.ChuKy1h30 ?? 0;
                    worksheet.Cell(row, 5).Value = item.ChuKy2h ?? 0;
                    worksheet.Cell(row, 6).Value = item.ChuKy2h30 ?? 0;
                    worksheet.Cell(row, 7).Value = item.ChuKy3h ?? 0;
                    worksheet.Cell(row, 8).Value = item.ChuKy3h30 ?? 0;
                    worksheet.Cell(row, 9).Value = item.ChuKy4h ?? 0;
                    worksheet.Cell(row, 10).Value = item.ChuKy4h30 ?? 0;
                    worksheet.Cell(row, 11).Value = item.ChuKy5h ?? 0;
                    worksheet.Cell(row, 12).Value = item.ChuKy5h30 ?? 0;
                    worksheet.Cell(row, 13).Value = item.ChuKy6h ?? 0;
                    worksheet.Cell(row, 14).Value = item.ChuKy6h30 ?? 0;
                    worksheet.Cell(row, 15).Value = item.ChuKy7h ?? 0;
                    worksheet.Cell(row, 16).Value = item.ChuKy7h30 ?? 0;
                    worksheet.Cell(row, 17).Value = item.ChuKy8h ?? 0;
                    worksheet.Cell(row, 18).Value = item.ChuKy8h30 ?? 0;
                    worksheet.Cell(row, 19).Value = item.ChuKy9h ?? 0;
                    worksheet.Cell(row, 20).Value = item.ChuKy9h30 ?? 0;
                    worksheet.Cell(row, 21).Value = item.ChuKy10h ?? 0;
                    worksheet.Cell(row, 22).Value = item.ChuKy10h30 ?? 0;
                    worksheet.Cell(row, 23).Value = item.ChuKy11h ?? 0;
                    worksheet.Cell(row, 24).Value = item.ChuKy11h30 ?? 0;
                    worksheet.Cell(row, 25).Value = item.ChuKy12h ?? 0;
                    worksheet.Cell(row, 26).Value = item.ChuKy12h30 ?? 0;
                    worksheet.Cell(row, 27).Value = item.ChuKy13h ?? 0;
                    worksheet.Cell(row, 28).Value = item.ChuKy13h30 ?? 0;
                    worksheet.Cell(row, 29).Value = item.ChuKy14h ?? 0;
                    worksheet.Cell(row, 30).Value = item.ChuKy14h30 ?? 0;
                    worksheet.Cell(row, 31).Value = item.ChuKy15h ?? 0;
                    worksheet.Cell(row, 32).Value = item.ChuKy15h30 ?? 0;
                    worksheet.Cell(row, 33).Value = item.ChuKy16h ?? 0;
                    worksheet.Cell(row, 34).Value = item.ChuKy16h30 ?? 0;
                    worksheet.Cell(row, 35).Value = item.ChuKy17h ?? 0;
                    worksheet.Cell(row, 36).Value = item.ChuKy17h30 ?? 0;
                    worksheet.Cell(row, 37).Value = item.ChuKy18h ?? 0;
                    worksheet.Cell(row, 38).Value = item.ChuKy18h30 ?? 0;
                    worksheet.Cell(row, 39).Value = item.ChuKy19h ?? 0;
                    worksheet.Cell(row, 40).Value = item.ChuKy19h30 ?? 0;
                    worksheet.Cell(row, 41).Value = item.ChuKy20h ?? 0;
                    worksheet.Cell(row, 42).Value = item.ChuKy20h30 ?? 0;
                    worksheet.Cell(row, 43).Value = item.ChuKy21h ?? 0;
                    worksheet.Cell(row, 44).Value = item.ChuKy21h30 ?? 0;
                    worksheet.Cell(row, 45).Value = item.ChuKy22h ?? 0;
                    worksheet.Cell(row, 46).Value = item.ChuKy22h30 ?? 0;
                    worksheet.Cell(row, 47).Value = item.ChuKy23h ?? 0;
                    worksheet.Cell(row, 48).Value = item.ChuKy23h30 ?? 0;
                    worksheet.Cell(row, 49).Value = item.ChuKy24h ?? 0;
                    worksheet.Cell(row, 50).Value = item.Tong ?? 0;
                    row++;
                }

                // Add totals row
                worksheet.Cell(row, 1).Value = "Tổng cộng";
                worksheet.Cell(row, 1).Style.Font.Bold = true;

                // Calculate totals for each column
                for (int col = 2; col <= 50; col++)
                {
                    var columnLetter = worksheet.Column(col).ColumnLetter();
                    worksheet.Cell(row, col).FormulaA1 = $"SUM({columnLetter}2:{columnLetter}{row - 1})";
                    worksheet.Cell(row, col).Style.Font.Bold = true;
                }

                // Style the totals row
                worksheet.Row(row).Style.Fill.BackgroundColor = XLColor.LightGray;

                // Auto-fit columns
                worksheet.Columns().AdjustToContents();

                // Create a memory stream to save the workbook
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    // Return the Excel file
                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"CfdDh3mr_{DateTime.Now:yyyyMMdd}.xlsx");
                }
            }
        }

        //VT4&4MR Actions
        public async Task<IActionResult> VT4n4MRIndex()
        {
            var cfdData = await _cfdCalculationService.GetCfdVt4n4MrDataAsync();
            return View(cfdData);
        }
        [HttpPost]
        public async Task<IActionResult> CalculateVT4n4MR()
        {
            try
            {
                await _cfdCalculationService.CalculateAndSaveCfdVt4n4MrAsync();
                TempData["SuccessMessage"] = "CFD VT4MR data has been calculated and saved successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error calculating CFD VT4MR data: {ex.Message}";
            }
            return RedirectToAction(nameof(VT4n4MRIndex));
        }
        public async Task<IActionResult> ExportVT4n4MRToExcel()
        {
            var cfdData = await _cfdCalculationService.GetCfdVt4n4MrDataAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CFD VT4&4MR");

                // Add headers
                worksheet.Cell(1, 1).Value = "Ngày";
                worksheet.Cell(1, 2).Value = "0h30";
                worksheet.Cell(1, 3).Value = "1h";
                worksheet.Cell(1, 4).Value = "1h30";
                worksheet.Cell(1, 5).Value = "2h";
                worksheet.Cell(1, 6).Value = "2h30";
                worksheet.Cell(1, 7).Value = "3h";
                worksheet.Cell(1, 8).Value = "3h30";
                worksheet.Cell(1, 9).Value = "4h";
                worksheet.Cell(1, 10).Value = "4h30";
                worksheet.Cell(1, 11).Value = "5h";
                worksheet.Cell(1, 12).Value = "5h30";
                worksheet.Cell(1, 13).Value = "6h";
                worksheet.Cell(1, 14).Value = "6h30";
                worksheet.Cell(1, 15).Value = "7h";
                worksheet.Cell(1, 16).Value = "7h30";
                worksheet.Cell(1, 17).Value = "8h";
                worksheet.Cell(1, 18).Value = "8h30";
                worksheet.Cell(1, 19).Value = "9h";
                worksheet.Cell(1, 20).Value = "9h30";
                worksheet.Cell(1, 21).Value = "10h";
                worksheet.Cell(1, 22).Value = "10h30";
                worksheet.Cell(1, 23).Value = "11h";
                worksheet.Cell(1, 24).Value = "11h30";
                worksheet.Cell(1, 25).Value = "12h";
                worksheet.Cell(1, 26).Value = "12h30";
                worksheet.Cell(1, 27).Value = "13h";
                worksheet.Cell(1, 28).Value = "13h30";
                worksheet.Cell(1, 29).Value = "14h";
                worksheet.Cell(1, 30).Value = "14h30";
                worksheet.Cell(1, 31).Value = "15h";
                worksheet.Cell(1, 32).Value = "15h30";
                worksheet.Cell(1, 33).Value = "16h";
                worksheet.Cell(1, 34).Value = "16h30";
                worksheet.Cell(1, 35).Value = "17h";
                worksheet.Cell(1, 36).Value = "17h30";
                worksheet.Cell(1, 37).Value = "18h";
                worksheet.Cell(1, 38).Value = "18h30";
                worksheet.Cell(1, 39).Value = "19h";
                worksheet.Cell(1, 40).Value = "19h30";
                worksheet.Cell(1, 41).Value = "20h";
                worksheet.Cell(1, 42).Value = "20h30";
                worksheet.Cell(1, 43).Value = "21h";
                worksheet.Cell(1, 44).Value = "21h30";
                worksheet.Cell(1, 45).Value = "22h";
                worksheet.Cell(1, 46).Value = "22h30";
                worksheet.Cell(1, 47).Value = "23h";
                worksheet.Cell(1, 48).Value = "23h30";
                worksheet.Cell(1, 49).Value = "24h";
                worksheet.Cell(1, 50).Value = "Tổng";

                // Style the header row
                var headerRow = worksheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;

                // Add data rows
                int row = 2;
                foreach (var item in cfdData)
                {
                    worksheet.Cell(row, 1).Value = item.Ngay;
                    worksheet.Cell(row, 2).Value = item.ChuKy0h30 ?? 0;
                    worksheet.Cell(row, 3).Value = item.ChuKy1h ?? 0;
                    worksheet.Cell(row, 4).Value = item.ChuKy1h30 ?? 0;
                    worksheet.Cell(row, 5).Value = item.ChuKy2h ?? 0;
                    worksheet.Cell(row, 6).Value = item.ChuKy2h30 ?? 0;
                    worksheet.Cell(row, 7).Value = item.ChuKy3h ?? 0;
                    worksheet.Cell(row, 8).Value = item.ChuKy3h30 ?? 0;
                    worksheet.Cell(row, 9).Value = item.ChuKy4h ?? 0;
                    worksheet.Cell(row, 10).Value = item.ChuKy4h30 ?? 0;
                    worksheet.Cell(row, 11).Value = item.ChuKy5h ?? 0;
                    worksheet.Cell(row, 12).Value = item.ChuKy5h30 ?? 0;
                    worksheet.Cell(row, 13).Value = item.ChuKy6h ?? 0;
                    worksheet.Cell(row, 14).Value = item.ChuKy6h30 ?? 0;
                    worksheet.Cell(row, 15).Value = item.ChuKy7h ?? 0;
                    worksheet.Cell(row, 16).Value = item.ChuKy7h30 ?? 0;
                    worksheet.Cell(row, 17).Value = item.ChuKy8h ?? 0;
                    worksheet.Cell(row, 18).Value = item.ChuKy8h30 ?? 0;
                    worksheet.Cell(row, 19).Value = item.ChuKy9h ?? 0;
                    worksheet.Cell(row, 20).Value = item.ChuKy9h30 ?? 0;
                    worksheet.Cell(row, 21).Value = item.ChuKy10h ?? 0;
                    worksheet.Cell(row, 22).Value = item.ChuKy10h30 ?? 0;
                    worksheet.Cell(row, 23).Value = item.ChuKy11h ?? 0;
                    worksheet.Cell(row, 24).Value = item.ChuKy11h30 ?? 0;
                    worksheet.Cell(row, 25).Value = item.ChuKy12h ?? 0;
                    worksheet.Cell(row, 26).Value = item.ChuKy12h30 ?? 0;
                    worksheet.Cell(row, 27).Value = item.ChuKy13h ?? 0;
                    worksheet.Cell(row, 28).Value = item.ChuKy13h30 ?? 0;
                    worksheet.Cell(row, 29).Value = item.ChuKy14h ?? 0;
                    worksheet.Cell(row, 30).Value = item.ChuKy14h30 ?? 0;
                    worksheet.Cell(row, 31).Value = item.ChuKy15h ?? 0;
                    worksheet.Cell(row, 32).Value = item.ChuKy15h30 ?? 0;
                    worksheet.Cell(row, 33).Value = item.ChuKy16h ?? 0;
                    worksheet.Cell(row, 34).Value = item.ChuKy16h30 ?? 0;
                    worksheet.Cell(row, 35).Value = item.ChuKy17h ?? 0;
                    worksheet.Cell(row, 36).Value = item.ChuKy17h30 ?? 0;
                    worksheet.Cell(row, 37).Value = item.ChuKy18h ?? 0;
                    worksheet.Cell(row, 38).Value = item.ChuKy18h30 ?? 0;
                    worksheet.Cell(row, 39).Value = item.ChuKy19h ?? 0;
                    worksheet.Cell(row, 40).Value = item.ChuKy19h30 ?? 0;
                    worksheet.Cell(row, 41).Value = item.ChuKy20h ?? 0;
                    worksheet.Cell(row, 42).Value = item.ChuKy20h30 ?? 0;
                    worksheet.Cell(row, 43).Value = item.ChuKy21h ?? 0;
                    worksheet.Cell(row, 44).Value = item.ChuKy21h30 ?? 0;
                    worksheet.Cell(row, 45).Value = item.ChuKy22h ?? 0;
                    worksheet.Cell(row, 46).Value = item.ChuKy22h30 ?? 0;
                    worksheet.Cell(row, 47).Value = item.ChuKy23h ?? 0;
                    worksheet.Cell(row, 48).Value = item.ChuKy23h30 ?? 0;
                    worksheet.Cell(row, 49).Value = item.ChuKy24h ?? 0;
                    worksheet.Cell(row, 50).Value = item.Tong ?? 0;
                    row++;
                }

                // Add totals row
                worksheet.Cell(row, 1).Value = "Tổng cộng";
                worksheet.Cell(row, 1).Style.Font.Bold = true;

                // Calculate totals for each column
                for (int col = 2; col <= 50; col++)
                {
                    var columnLetter = worksheet.Column(col).ColumnLetter();
                    worksheet.Cell(row, col).FormulaA1 = $"SUM({columnLetter}2:{columnLetter}{row - 1})";
                    worksheet.Cell(row, col).Style.Font.Bold = true;
                }

                // Style the totals row
                worksheet.Row(row).Style.Fill.BackgroundColor = XLColor.LightGray;

                // Auto-fit columns
                worksheet.Columns().AdjustToContents();

                // Create a memory stream to save the workbook
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    // Return the Excel file
                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"CfdVt4n4Mr_{DateTime.Now:yyyyMMdd}.xlsx");
                }
            }
        }
    }
}