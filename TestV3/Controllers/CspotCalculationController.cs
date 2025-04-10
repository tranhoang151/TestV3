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
    }
}