using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestV3.Models
{
    public class DynamicExcelData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SheetName { get; set; }

        [Required]
        public string RowData { get; set; } // Lưu dữ liệu dưới dạng JSON

        public string FileName { get; set; }

        public DateTime ImportDate { get; set; } = DateTime.Now;
    }
}