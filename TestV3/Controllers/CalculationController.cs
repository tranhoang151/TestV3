using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestV3.Data;
using TestV3.Services;

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
    }
}