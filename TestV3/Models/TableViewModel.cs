using System.Collections.Generic;
using System.Data;

namespace TestV3.Models
{
    public class TableViewerModel
    {
        public List<string> Tables { get; set; } = new List<string>();
        public string SelectedTable { get; set; }
        public DataTable Data { get; set; }
        public List<string> Columns { get; set; } = new List<string>();
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}