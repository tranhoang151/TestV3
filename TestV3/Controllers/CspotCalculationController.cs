using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestV3.Models.CSPOT;
using TestV3.Services;

namespace TestV3.Controllers
{
    public class CspotCalculationController : Controller
    {
        private readonly ICspotCalculationService _cspotCalculationService;

        public CspotCalculationController(ICspotCalculationService cspotCalculationService)
        {
            _cspotCalculationService = cspotCalculationService;
        }

        public async Task<IActionResult> Index()
        {
            var tongHopData = await _cspotCalculationService.GetTongHopCspotDataAsync();
            return View(tongHopData);
        }

        [HttpPost]
        public async Task<IActionResult> CalculateTongHopCspot()
        {
            try
            {
                await _cspotCalculationService.CalculateAndSaveTongHopCspotAsync();
                TempData["SuccessMessage"] = "Dữ liệu tổng hợp CSPOT đã được tính toán và lưu thành công.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Lỗi khi tính toán dữ liệu tổng hợp CSPOT: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(DateTime date)
        {
            var tongHopData = await _cspotCalculationService.GetTongHopCspotByDateAsync(date);
            if (tongHopData == null)
            {
                return NotFound();
            }

            return View(tongHopData);
        }

        public async Task<IActionResult> Report(DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue)
            {
                startDate = DateTime.Today.AddDays(-30);
            }

            if (!endDate.HasValue)
            {
                endDate = DateTime.Today;
            }

            var reportData = await _cspotCalculationService.GetTongHopCspotByDateRangeAsync(startDate.Value, endDate.Value);

            ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");

            return View(reportData);
        }
        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            var tongHopData = await _cspotCalculationService.GetTongHopCspotDataAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Tổng hợp CSPOT");

                // Add headers
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Ngày";
                worksheet.Cell(1, 3).Value = "Sản lượng QM";
                worksheet.Cell(1, 4).Value = "Sản lượng QM1";
                worksheet.Cell(1, 5).Value = "Sản lượng QM2";
                worksheet.Cell(1, 6).Value = "Sản lượng TB";
                worksheet.Cell(1, 7).Value = "Sản lượng VT4";
                worksheet.Cell(1, 8).Value = "Sản lượng VT4 MR";
                worksheet.Cell(1, 9).Value = "Sản lượng DH3 MR";
                worksheet.Cell(1, 10).Value = "Chi phí CM1";
                worksheet.Cell(1, 11).Value = "Chi phí CM2";
                worksheet.Cell(1, 12).Value = "Chi phí TB";
                worksheet.Cell(1, 13).Value = "Chi phí VT4";
                worksheet.Cell(1, 14).Value = "Chi phí VT4 MR";
                worksheet.Cell(1, 15).Value = "Chi phí DH3 MR";
                worksheet.Cell(1, 16).Value = "Tổng chi phí";

                // Style the header row
                var headerRow = worksheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;

                // Add data rows
                int row = 2;
                foreach (var item in tongHopData)
                {
                    worksheet.Cell(row, 1).Value = item.Id;
                    worksheet.Cell(row, 2).Value = item.Ngay;
                    worksheet.Cell(row, 2).Style.DateFormat.Format = "dd/MM/yyyy";
                    worksheet.Cell(row, 3).Value = item.SanLuongQm ?? 0;
                    worksheet.Cell(row, 4).Value = item.SanLuongQm1 ?? 0;
                    worksheet.Cell(row, 5).Value = item.SanLuongQm2 ?? 0;
                    worksheet.Cell(row, 6).Value = item.SanLuongTb ?? 0;
                    worksheet.Cell(row, 7).Value = item.SanLuongVt4 ?? 0;
                    worksheet.Cell(row, 8).Value = item.SanLuongVt4Mr ?? 0;
                    worksheet.Cell(row, 9).Value = item.SanLuongDh3Mr ?? 0;
                    worksheet.Cell(row, 10).Value = item.ChiPhiCm1 ?? 0;
                    worksheet.Cell(row, 11).Value = item.ChiPhiCm2 ?? 0;
                    worksheet.Cell(row, 12).Value = item.ChiPhiTb ?? 0;
                    worksheet.Cell(row, 13).Value = item.ChiPhiVt4 ?? 0;
                    worksheet.Cell(row, 14).Value = item.ChiPhiVt4Mr ?? 0;
                    worksheet.Cell(row, 15).Value = item.ChiPhiDh3Mr ?? 0;
                    worksheet.Cell(row, 16).Value = item.TongChiPhi ?? 0;
                    row++;
                }

                // Add totals row
                worksheet.Cell(row, 1).Value = "Tổng cộng";
                worksheet.Cell(row, 1).Style.Font.Bold = true;
                worksheet.Range(row, 1, row, 2).Merge();
                worksheet.Cell(row, 3).Value = tongHopData.Sum(x => x.SanLuongQm ?? 0);
                worksheet.Cell(row, 4).Value = tongHopData.Sum(x => x.SanLuongQm1 ?? 0);
                worksheet.Cell(row, 5).Value = tongHopData.Sum(x => x.SanLuongQm2 ?? 0);
                worksheet.Cell(row, 6).Value = tongHopData.Sum(x => x.SanLuongTb ?? 0);
                worksheet.Cell(row, 7).Value = tongHopData.Sum(x => x.SanLuongVt4 ?? 0);
                worksheet.Cell(row, 8).Value = tongHopData.Sum(x => x.SanLuongVt4Mr ?? 0);
                worksheet.Cell(row, 9).Value = tongHopData.Sum(x => x.SanLuongDh3Mr ?? 0);
                worksheet.Cell(row, 10).Value = tongHopData.Sum(x => x.ChiPhiCm1 ?? 0);
                worksheet.Cell(row, 11).Value = tongHopData.Sum(x => x.ChiPhiCm2 ?? 0);
                worksheet.Cell(row, 12).Value = tongHopData.Sum(x => x.ChiPhiTb ?? 0);
                worksheet.Cell(row, 13).Value = tongHopData.Sum(x => x.ChiPhiVt4 ?? 0);
                worksheet.Cell(row, 14).Value = tongHopData.Sum(x => x.ChiPhiVt4Mr ?? 0);
                worksheet.Cell(row, 15).Value = tongHopData.Sum(x => x.ChiPhiDh3Mr ?? 0);
                worksheet.Cell(row, 16).Value = tongHopData.Sum(x => x.TongChiPhi ?? 0);

                // Style the totals row
                worksheet.Row(row).Style.Font.Bold = true;
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
                        $"TongHopCspot_{DateTime.Now:yyyyMMdd}.xlsx");
                }
            }
        }
    }
}