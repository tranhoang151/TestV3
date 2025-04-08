using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestV3.Models;

namespace TestV3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DynamicExcelData> DynamicExcelData { get; set; }
    }
}