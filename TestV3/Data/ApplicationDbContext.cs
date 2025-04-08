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

        public DbSet<FmpA0> FMP_A0 { get; set; }
        public DbSet<NhapGiaNm> NhậpgíaNM { get; set; }
        public DbSet<PmA0> Pm_A0 { get; set; }
        public DbSet<PmEvn> Pm_EVN { get; set; }
        public DbSet<PmSai> Pm_Sai { get; set; }
        public DbSet<FmpEvn> FMP_EVN { get; set; }
        public DbSet<FmpSai> FMP_Sai { get; set; }

        public DbSet<DynamicExcelData> DynamicExcelData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure NhapGiaNm as a keyless entity
            modelBuilder.Entity<NhapGiaNm>().HasNoKey();

            modelBuilder.Entity<FmpA0>().ToTable("FMP_A0");
            modelBuilder.Entity<PmA0>().ToTable("PM_A0");
            modelBuilder.Entity<FmpEvn>().ToTable("FMP_EVN");
            modelBuilder.Entity<PmEvn>().ToTable("PM_EVN");
            modelBuilder.Entity<FmpSai>().ToTable("FMP_Sai");
            modelBuilder.Entity<PmSai>().ToTable("PM_Sai");
            modelBuilder.Entity<NhapGiaNm>().ToTable("NhâpgíaNM");
        }
    }
}