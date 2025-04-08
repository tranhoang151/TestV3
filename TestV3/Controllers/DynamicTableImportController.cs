using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using TestV3.Services;
using System.Collections.Generic;
using System.Text.Json;

namespace TestV3.Controllers
{
    public class DynamicTableImportController : Controller
    {
        private readonly DynamicTableImportService _importService;

        public DynamicTableImportController(DynamicTableImportService importService)
        {
            _importService = importService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "Please select an Excel file to import";
                return RedirectToAction("Index");
            }

            var fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension != ".xlsx" && fileExtension != ".xls")
            {
                TempData["Error"] = "Only Excel files (.xlsx, .xls) are supported";
                return RedirectToAction("Index");
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;

                var result = _importService.ImportExcel(stream);

                if (result.Success)
                {
                    TempData["Success"] = result.Message;
                    // Chuyển đổi Dictionary thành JSON string
                    TempData["ImportedCounts"] = JsonSerializer.Serialize(result.ImportedCounts);
                }
                else
                {
                    TempData["Error"] = result.Message;
                }
            }

            return RedirectToAction("Index");
        }

        // Thêm action mới để hiển thị danh sách sheet
        [HttpPost]
        public async Task<IActionResult> SelectSheet(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "Please select an Excel file";
                return RedirectToAction("Index");
            }

            var fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension != ".xlsx" && fileExtension != ".xls")
            {
                TempData["Error"] = "Only Excel files (.xlsx, .xls) are supported";
                return RedirectToAction("Index");
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;

                var sheets = _importService.GetExcelSheets(stream);

                if (sheets.Count == 0)
                {
                    TempData["Error"] = "No sheets found in the Excel file";
                    return RedirectToAction("Index");
                }

                // Lưu tên file vào TempData để sử dụng sau
                TempData["FileName"] = file.FileName;

                // Lưu nội dung file vào session để không phải upload lại
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    HttpContext.Session.Set("ExcelFile", ms.ToArray());
                }

                return View("SelectSheet", sheets);
            }
        }

        // Thêm action để import sheet đã chọn
        [HttpPost]
        public IActionResult ImportSelectedSheet(string selectedSheet)
        {
            if (string.IsNullOrEmpty(selectedSheet))
            {
                TempData["Error"] = "Please select a sheet to import";
                return RedirectToAction("Index");
            }

            var fileBytes = HttpContext.Session.Get("ExcelFile");
            if (fileBytes == null)
            {
                TempData["Error"] = "Session expired. Please upload the file again";
                return RedirectToAction("Index");
            }

            using (var stream = new MemoryStream(fileBytes))
            {
                stream.Position = 0; // Đảm bảo đọc từ đầu stream
                var result = _importService.ImportExcel(stream, selectedSheet);

                if (result.Success)
                {
                    TempData["Success"] = result.Message;
                    TempData["ImportedCounts"] = JsonSerializer.Serialize(result.ImportedCounts);
                }
                else
                {
                    TempData["Error"] = result.Message;
                }
            }

            // Xóa dữ liệu session sau khi import
            HttpContext.Session.Remove("ExcelFile");

            return RedirectToAction("Index");
        }
    }
}