using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestV3.Models.PmQL;

namespace TestV3.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FmpA0> FMP_A0 { get; set; }

    public virtual DbSet<FmpEvn> FMP_EVN { get; set; }

    public virtual DbSet<FmpSai> FMP_Sai { get; set; }

    public virtual DbSet<PmA0> Pm_A0 { get; set; }

    public virtual DbSet<PmEvn> Pm_EVN { get; set; }

    public virtual DbSet<PmSai> Pm_Sai { get; set; }

    public virtual DbSet<NhapGiaNm> NhậpgíaNM { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-409OOSHC\\SQLEXPRESS;Initial Catalog=TestV3;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NhapGiaNm>().HasNoKey();
        modelBuilder.Entity<FmpA0>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FMP_A0__3214EC07FFE266CC");

            entity.ToTable("FMP_A0");

            entity.Property(e => e.Column0h30).HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h).HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30).HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h).HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30).HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h).HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30).HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h).HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30).HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h).HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30).HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h).HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30).HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h).HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30).HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h).HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30).HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h).HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30).HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h).HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30).HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h).HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30).HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h).HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30).HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h).HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30).HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h).HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30).HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h).HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30).HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h).HasColumnName("Column_24h");
            entity.Property(e => e.Column2h).HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30).HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h).HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30).HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h).HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30).HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h).HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30).HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h).HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30).HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h).HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30).HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h).HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30).HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h).HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30).HasColumnName("Column_9h30");
        });

        modelBuilder.Entity<FmpEvn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FMP_EVN__3214EC27F7A0AD91");

            entity.ToTable("FMP_EVN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChuKy0h30).HasColumnName("ChuKy_0h30");
            entity.Property(e => e.ChuKy10h).HasColumnName("ChuKy_10h");
            entity.Property(e => e.ChuKy10h30).HasColumnName("ChuKy_10h30");
            entity.Property(e => e.ChuKy11h).HasColumnName("ChuKy_11h");
            entity.Property(e => e.ChuKy11h30).HasColumnName("ChuKy_11h30");
            entity.Property(e => e.ChuKy12h).HasColumnName("ChuKy_12h");
            entity.Property(e => e.ChuKy12h30).HasColumnName("ChuKy_12h30");
            entity.Property(e => e.ChuKy13h).HasColumnName("ChuKy_13h");
            entity.Property(e => e.ChuKy13h30).HasColumnName("ChuKy_13h30");
            entity.Property(e => e.ChuKy14h).HasColumnName("ChuKy_14h");
            entity.Property(e => e.ChuKy14h30).HasColumnName("ChuKy_14h30");
            entity.Property(e => e.ChuKy15h).HasColumnName("ChuKy_15h");
            entity.Property(e => e.ChuKy15h30).HasColumnName("ChuKy_15h30");
            entity.Property(e => e.ChuKy16h).HasColumnName("ChuKy_16h");
            entity.Property(e => e.ChuKy16h30).HasColumnName("ChuKy_16h30");
            entity.Property(e => e.ChuKy17h).HasColumnName("ChuKy_17h");
            entity.Property(e => e.ChuKy17h30).HasColumnName("ChuKy_17h30");
            entity.Property(e => e.ChuKy18h).HasColumnName("ChuKy_18h");
            entity.Property(e => e.ChuKy18h30).HasColumnName("ChuKy_18h30");
            entity.Property(e => e.ChuKy19h).HasColumnName("ChuKy_19h");
            entity.Property(e => e.ChuKy19h30).HasColumnName("ChuKy_19h30");
            entity.Property(e => e.ChuKy1h).HasColumnName("ChuKy_1h");
            entity.Property(e => e.ChuKy1h30).HasColumnName("ChuKy_1h30");
            entity.Property(e => e.ChuKy20h).HasColumnName("ChuKy_20h");
            entity.Property(e => e.ChuKy20h30).HasColumnName("ChuKy_20h30");
            entity.Property(e => e.ChuKy21h).HasColumnName("ChuKy_21h");
            entity.Property(e => e.ChuKy21h30).HasColumnName("ChuKy_21h30");
            entity.Property(e => e.ChuKy22h).HasColumnName("ChuKy_22h");
            entity.Property(e => e.ChuKy22h30).HasColumnName("ChuKy_22h30");
            entity.Property(e => e.ChuKy23h).HasColumnName("ChuKy_23h");
            entity.Property(e => e.ChuKy23h30).HasColumnName("ChuKy_23h30");
            entity.Property(e => e.ChuKy24h).HasColumnName("ChuKy_24h");
            entity.Property(e => e.ChuKy2h).HasColumnName("ChuKy_2h");
            entity.Property(e => e.ChuKy2h30).HasColumnName("ChuKy_2h30");
            entity.Property(e => e.ChuKy3h).HasColumnName("ChuKy_3h");
            entity.Property(e => e.ChuKy3h30).HasColumnName("ChuKy_3h30");
            entity.Property(e => e.ChuKy4h).HasColumnName("ChuKy_4h");
            entity.Property(e => e.ChuKy4h30).HasColumnName("ChuKy_4h30");
            entity.Property(e => e.ChuKy5h).HasColumnName("ChuKy_5h");
            entity.Property(e => e.ChuKy5h30).HasColumnName("ChuKy_5h30");
            entity.Property(e => e.ChuKy6h).HasColumnName("ChuKy_6h");
            entity.Property(e => e.ChuKy6h30).HasColumnName("ChuKy_6h30");
            entity.Property(e => e.ChuKy7h).HasColumnName("ChuKy_7h");
            entity.Property(e => e.ChuKy7h30).HasColumnName("ChuKy_7h30");
            entity.Property(e => e.ChuKy8h).HasColumnName("ChuKy_8h");
            entity.Property(e => e.ChuKy8h30).HasColumnName("ChuKy_8h30");
            entity.Property(e => e.ChuKy9h).HasColumnName("ChuKy_9h");
            entity.Property(e => e.ChuKy9h30).HasColumnName("ChuKy_9h30");
            entity.Property(e => e.Gia).HasMaxLength(50);
        });

        modelBuilder.Entity<FmpSai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FMP_Sai__3214EC27170C2A0C");

            entity.ToTable("FMP_Sai");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChuKy0h30).HasColumnName("ChuKy_0h30");
            entity.Property(e => e.ChuKy10h).HasColumnName("ChuKy_10h");
            entity.Property(e => e.ChuKy10h30).HasColumnName("ChuKy_10h30");
            entity.Property(e => e.ChuKy11h).HasColumnName("ChuKy_11h");
            entity.Property(e => e.ChuKy11h30).HasColumnName("ChuKy_11h30");
            entity.Property(e => e.ChuKy12h).HasColumnName("ChuKy_12h");
            entity.Property(e => e.ChuKy12h30).HasColumnName("ChuKy_12h30");
            entity.Property(e => e.ChuKy13h).HasColumnName("ChuKy_13h");
            entity.Property(e => e.ChuKy13h30).HasColumnName("ChuKy_13h30");
            entity.Property(e => e.ChuKy14h).HasColumnName("ChuKy_14h");
            entity.Property(e => e.ChuKy14h30).HasColumnName("ChuKy_14h30");
            entity.Property(e => e.ChuKy15h).HasColumnName("ChuKy_15h");
            entity.Property(e => e.ChuKy15h30).HasColumnName("ChuKy_15h30");
            entity.Property(e => e.ChuKy16h).HasColumnName("ChuKy_16h");
            entity.Property(e => e.ChuKy16h30).HasColumnName("ChuKy_16h30");
            entity.Property(e => e.ChuKy17h).HasColumnName("ChuKy_17h");
            entity.Property(e => e.ChuKy17h30).HasColumnName("ChuKy_17h30");
            entity.Property(e => e.ChuKy18h).HasColumnName("ChuKy_18h");
            entity.Property(e => e.ChuKy18h30).HasColumnName("ChuKy_18h30");
            entity.Property(e => e.ChuKy19h).HasColumnName("ChuKy_19h");
            entity.Property(e => e.ChuKy19h30).HasColumnName("ChuKy_19h30");
            entity.Property(e => e.ChuKy1h).HasColumnName("ChuKy_1h");
            entity.Property(e => e.ChuKy1h30).HasColumnName("ChuKy_1h30");
            entity.Property(e => e.ChuKy20h).HasColumnName("ChuKy_20h");
            entity.Property(e => e.ChuKy20h30).HasColumnName("ChuKy_20h30");
            entity.Property(e => e.ChuKy21h).HasColumnName("ChuKy_21h");
            entity.Property(e => e.ChuKy21h30).HasColumnName("ChuKy_21h30");
            entity.Property(e => e.ChuKy22h).HasColumnName("ChuKy_22h");
            entity.Property(e => e.ChuKy22h30).HasColumnName("ChuKy_22h30");
            entity.Property(e => e.ChuKy23h).HasColumnName("ChuKy_23h");
            entity.Property(e => e.ChuKy23h30).HasColumnName("ChuKy_23h30");
            entity.Property(e => e.ChuKy24h).HasColumnName("ChuKy_24h");
            entity.Property(e => e.ChuKy2h).HasColumnName("ChuKy_2h");
            entity.Property(e => e.ChuKy2h30).HasColumnName("ChuKy_2h30");
            entity.Property(e => e.ChuKy3h).HasColumnName("ChuKy_3h");
            entity.Property(e => e.ChuKy3h30).HasColumnName("ChuKy_3h30");
            entity.Property(e => e.ChuKy4h).HasColumnName("ChuKy_4h");
            entity.Property(e => e.ChuKy4h30).HasColumnName("ChuKy_4h30");
            entity.Property(e => e.ChuKy5h).HasColumnName("ChuKy_5h");
            entity.Property(e => e.ChuKy5h30).HasColumnName("ChuKy_5h30");
            entity.Property(e => e.ChuKy6h).HasColumnName("ChuKy_6h");
            entity.Property(e => e.ChuKy6h30).HasColumnName("ChuKy_6h30");
            entity.Property(e => e.ChuKy7h).HasColumnName("ChuKy_7h");
            entity.Property(e => e.ChuKy7h30).HasColumnName("ChuKy_7h30");
            entity.Property(e => e.ChuKy8h).HasColumnName("ChuKy_8h");
            entity.Property(e => e.ChuKy8h30).HasColumnName("ChuKy_8h30");
            entity.Property(e => e.ChuKy9h).HasColumnName("ChuKy_9h");
            entity.Property(e => e.ChuKy9h30).HasColumnName("ChuKy_9h30");
            entity.Property(e => e.Gia).HasMaxLength(50);
        });

        modelBuilder.Entity<PmA0>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pm_A0__3214EC07AD44270A");

            entity.ToTable("Pm_A0");

            entity.Property(e => e.Column0h30).HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h).HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30).HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h).HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30).HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h).HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30).HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h).HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30).HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h).HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30).HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h).HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30).HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h).HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30).HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h).HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30).HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h).HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30).HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h).HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30).HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h).HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30).HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h).HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30).HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h).HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30).HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h).HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30).HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h).HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30).HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h).HasColumnName("Column_24h");
            entity.Property(e => e.Column2h).HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30).HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h).HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30).HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h).HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30).HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h).HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30).HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h).HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30).HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h).HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30).HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h).HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30).HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h).HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30).HasColumnName("Column_9h30");
        });

        modelBuilder.Entity<PmEvn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pm_EVN__3214EC2785F2DA27");

            entity.ToTable("Pm_EVN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChuKy0h30).HasColumnName("ChuKy_0h30");
            entity.Property(e => e.ChuKy10h).HasColumnName("ChuKy_10h");
            entity.Property(e => e.ChuKy10h30).HasColumnName("ChuKy_10h30");
            entity.Property(e => e.ChuKy11h).HasColumnName("ChuKy_11h");
            entity.Property(e => e.ChuKy11h30).HasColumnName("ChuKy_11h30");
            entity.Property(e => e.ChuKy12h).HasColumnName("ChuKy_12h");
            entity.Property(e => e.ChuKy12h30).HasColumnName("ChuKy_12h30");
            entity.Property(e => e.ChuKy13h).HasColumnName("ChuKy_13h");
            entity.Property(e => e.ChuKy13h30).HasColumnName("ChuKy_13h30");
            entity.Property(e => e.ChuKy14h).HasColumnName("ChuKy_14h");
            entity.Property(e => e.ChuKy14h30).HasColumnName("ChuKy_14h30");
            entity.Property(e => e.ChuKy15h).HasColumnName("ChuKy_15h");
            entity.Property(e => e.ChuKy15h30).HasColumnName("ChuKy_15h30");
            entity.Property(e => e.ChuKy16h).HasColumnName("ChuKy_16h");
            entity.Property(e => e.ChuKy16h30).HasColumnName("ChuKy_16h30");
            entity.Property(e => e.ChuKy17h).HasColumnName("ChuKy_17h");
            entity.Property(e => e.ChuKy17h30).HasColumnName("ChuKy_17h30");
            entity.Property(e => e.ChuKy18h).HasColumnName("ChuKy_18h");
            entity.Property(e => e.ChuKy18h30).HasColumnName("ChuKy_18h30");
            entity.Property(e => e.ChuKy19h).HasColumnName("ChuKy_19h");
            entity.Property(e => e.ChuKy19h30).HasColumnName("ChuKy_19h30");
            entity.Property(e => e.ChuKy1h).HasColumnName("ChuKy_1h");
            entity.Property(e => e.ChuKy1h30).HasColumnName("ChuKy_1h30");
            entity.Property(e => e.ChuKy20h).HasColumnName("ChuKy_20h");
            entity.Property(e => e.ChuKy20h30).HasColumnName("ChuKy_20h30");
            entity.Property(e => e.ChuKy21h).HasColumnName("ChuKy_21h");
            entity.Property(e => e.ChuKy21h30).HasColumnName("ChuKy_21h30");
            entity.Property(e => e.ChuKy22h).HasColumnName("ChuKy_22h");
            entity.Property(e => e.ChuKy22h30).HasColumnName("ChuKy_22h30");
            entity.Property(e => e.ChuKy23h).HasColumnName("ChuKy_23h");
            entity.Property(e => e.ChuKy23h30).HasColumnName("ChuKy_23h30");
            entity.Property(e => e.ChuKy24h).HasColumnName("ChuKy_24h");
            entity.Property(e => e.ChuKy2h).HasColumnName("ChuKy_2h");
            entity.Property(e => e.ChuKy2h30).HasColumnName("ChuKy_2h30");
            entity.Property(e => e.ChuKy3h).HasColumnName("ChuKy_3h");
            entity.Property(e => e.ChuKy3h30).HasColumnName("ChuKy_3h30");
            entity.Property(e => e.ChuKy4h).HasColumnName("ChuKy_4h");
            entity.Property(e => e.ChuKy4h30).HasColumnName("ChuKy_4h30");
            entity.Property(e => e.ChuKy5h).HasColumnName("ChuKy_5h");
            entity.Property(e => e.ChuKy5h30).HasColumnName("ChuKy_5h30");
            entity.Property(e => e.ChuKy6h).HasColumnName("ChuKy_6h");
            entity.Property(e => e.ChuKy6h30).HasColumnName("ChuKy_6h30");
            entity.Property(e => e.ChuKy7h).HasColumnName("ChuKy_7h");
            entity.Property(e => e.ChuKy7h30).HasColumnName("ChuKy_7h30");
            entity.Property(e => e.ChuKy8h).HasColumnName("ChuKy_8h");
            entity.Property(e => e.ChuKy8h30).HasColumnName("ChuKy_8h30");
            entity.Property(e => e.ChuKy9h).HasColumnName("ChuKy_9h");
            entity.Property(e => e.ChuKy9h30).HasColumnName("ChuKy_9h30");
            entity.Property(e => e.Gia).HasMaxLength(50);
        });

        modelBuilder.Entity<PmSai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pm_Sai__3214EC27AFA1BCFF");

            entity.ToTable("Pm_Sai");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChuKy0h30).HasColumnName("ChuKy_0h30");
            entity.Property(e => e.ChuKy10h).HasColumnName("ChuKy_10h");
            entity.Property(e => e.ChuKy10h30).HasColumnName("ChuKy_10h30");
            entity.Property(e => e.ChuKy11h).HasColumnName("ChuKy_11h");
            entity.Property(e => e.ChuKy11h30).HasColumnName("ChuKy_11h30");
            entity.Property(e => e.ChuKy12h).HasColumnName("ChuKy_12h");
            entity.Property(e => e.ChuKy12h30).HasColumnName("ChuKy_12h30");
            entity.Property(e => e.ChuKy13h).HasColumnName("ChuKy_13h");
            entity.Property(e => e.ChuKy13h30).HasColumnName("ChuKy_13h30");
            entity.Property(e => e.ChuKy14h).HasColumnName("ChuKy_14h");
            entity.Property(e => e.ChuKy14h30).HasColumnName("ChuKy_14h30");
            entity.Property(e => e.ChuKy15h).HasColumnName("ChuKy_15h");
            entity.Property(e => e.ChuKy15h30).HasColumnName("ChuKy_15h30");
            entity.Property(e => e.ChuKy16h).HasColumnName("ChuKy_16h");
            entity.Property(e => e.ChuKy16h30).HasColumnName("ChuKy_16h30");
            entity.Property(e => e.ChuKy17h).HasColumnName("ChuKy_17h");
            entity.Property(e => e.ChuKy17h30).HasColumnName("ChuKy_17h30");
            entity.Property(e => e.ChuKy18h).HasColumnName("ChuKy_18h");
            entity.Property(e => e.ChuKy18h30).HasColumnName("ChuKy_18h30");
            entity.Property(e => e.ChuKy19h).HasColumnName("ChuKy_19h");
            entity.Property(e => e.ChuKy19h30).HasColumnName("ChuKy_19h30");
            entity.Property(e => e.ChuKy1h).HasColumnName("ChuKy_1h");
            entity.Property(e => e.ChuKy1h30).HasColumnName("ChuKy_1h30");
            entity.Property(e => e.ChuKy20h).HasColumnName("ChuKy_20h");
            entity.Property(e => e.ChuKy20h30).HasColumnName("ChuKy_20h30");
            entity.Property(e => e.ChuKy21h).HasColumnName("ChuKy_21h");
            entity.Property(e => e.ChuKy21h30).HasColumnName("ChuKy_21h30");
            entity.Property(e => e.ChuKy22h).HasColumnName("ChuKy_22h");
            entity.Property(e => e.ChuKy22h30).HasColumnName("ChuKy_22h30");
            entity.Property(e => e.ChuKy23h).HasColumnName("ChuKy_23h");
            entity.Property(e => e.ChuKy23h30).HasColumnName("ChuKy_23h30");
            entity.Property(e => e.ChuKy24h).HasColumnName("ChuKy_24h");
            entity.Property(e => e.ChuKy2h).HasColumnName("ChuKy_2h");
            entity.Property(e => e.ChuKy2h30).HasColumnName("ChuKy_2h30");
            entity.Property(e => e.ChuKy3h).HasColumnName("ChuKy_3h");
            entity.Property(e => e.ChuKy3h30).HasColumnName("ChuKy_3h30");
            entity.Property(e => e.ChuKy4h).HasColumnName("ChuKy_4h");
            entity.Property(e => e.ChuKy4h30).HasColumnName("ChuKy_4h30");
            entity.Property(e => e.ChuKy5h).HasColumnName("ChuKy_5h");
            entity.Property(e => e.ChuKy5h30).HasColumnName("ChuKy_5h30");
            entity.Property(e => e.ChuKy6h).HasColumnName("ChuKy_6h");
            entity.Property(e => e.ChuKy6h30).HasColumnName("ChuKy_6h30");
            entity.Property(e => e.ChuKy7h).HasColumnName("ChuKy_7h");
            entity.Property(e => e.ChuKy7h30).HasColumnName("ChuKy_7h30");
            entity.Property(e => e.ChuKy8h).HasColumnName("ChuKy_8h");
            entity.Property(e => e.ChuKy8h30).HasColumnName("ChuKy_8h30");
            entity.Property(e => e.ChuKy9h).HasColumnName("ChuKy_9h");
            entity.Property(e => e.ChuKy9h30).HasColumnName("ChuKy_9h30");
            entity.Property(e => e.Gia).HasMaxLength(50);
        });

        modelBuilder.Entity<NhapGiaNm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NhapGiaNM");

            entity.Property(e => e.Giá).HasMaxLength(255);
            entity.Property(e => e._0h30).HasColumnName("0h30");
            entity.Property(e => e._10h).HasColumnName("10h");
            entity.Property(e => e._10h30).HasColumnName("10h30");
            entity.Property(e => e._11h).HasColumnName("11h");
            entity.Property(e => e._11h30).HasColumnName("11h30");
            entity.Property(e => e._12h).HasColumnName("12h");
            entity.Property(e => e._12h30).HasColumnName("12h30");
            entity.Property(e => e._13h).HasColumnName("13h");
            entity.Property(e => e._13h30).HasColumnName("13h30");
            entity.Property(e => e._14h).HasColumnName("14h");
            entity.Property(e => e._14h30).HasColumnName("14h30");
            entity.Property(e => e._15h).HasColumnName("15h");
            entity.Property(e => e._15h30).HasColumnName("15h30");
            entity.Property(e => e._16h).HasColumnName("16h");
            entity.Property(e => e._16h30).HasColumnName("16h30");
            entity.Property(e => e._17h).HasColumnName("17h");
            entity.Property(e => e._17h30).HasColumnName("17h30");
            entity.Property(e => e._18h).HasColumnName("18h");
            entity.Property(e => e._18h30).HasColumnName("18h30");
            entity.Property(e => e._19h).HasColumnName("19h");
            entity.Property(e => e._19h30).HasColumnName("19h30");
            entity.Property(e => e._1h).HasColumnName("1h");
            entity.Property(e => e._1h30).HasColumnName("1h30");
            entity.Property(e => e._20h).HasColumnName("20h");
            entity.Property(e => e._20h30).HasColumnName("20h30");
            entity.Property(e => e._21h).HasColumnName("21h");
            entity.Property(e => e._21h30).HasColumnName("21h30");
            entity.Property(e => e._22h).HasColumnName("22h");
            entity.Property(e => e._22h30).HasColumnName("22h30");
            entity.Property(e => e._23h).HasColumnName("23h");
            entity.Property(e => e._23h30).HasColumnName("23h30");
            entity.Property(e => e._24h).HasColumnName("24h");
            entity.Property(e => e._2h).HasColumnName("2h");
            entity.Property(e => e._2h30).HasColumnName("2h30");
            entity.Property(e => e._3h).HasColumnName("3h");
            entity.Property(e => e._3h30).HasColumnName("3h30");
            entity.Property(e => e._4h).HasColumnName("4h");
            entity.Property(e => e._4h30).HasColumnName("4h30");
            entity.Property(e => e._5h).HasColumnName("5h");
            entity.Property(e => e._5h30).HasColumnName("5h30");
            entity.Property(e => e._6h).HasColumnName("6h");
            entity.Property(e => e._6h30).HasColumnName("6h30");
            entity.Property(e => e._7h).HasColumnName("7h");
            entity.Property(e => e._7h30).HasColumnName("7h30");
            entity.Property(e => e._8h).HasColumnName("8h");
            entity.Property(e => e._8h30).HasColumnName("8h30");
            entity.Property(e => e._9h).HasColumnName("9h");
            entity.Property(e => e._9h30).HasColumnName("9h30");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
