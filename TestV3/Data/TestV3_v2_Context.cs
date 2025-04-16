using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestV3.Models;

namespace TestV3.Data;

public partial class TestV3_v2_Context : DbContext
{
    public TestV3_v2_Context()
    {
    }

    public TestV3_v2_Context(DbContextOptions<TestV3_v2_Context> options)
        : base(options)
    {
    }
    //PM1
    public virtual DbSet<CfdPm1Pc> CfdPm1Pcs { get; set; }
    public virtual DbSet<CfdPm1Qc> CfdPm1Qcs { get; set; }
    public virtual DbSet<CfdPm1> CfdPm1s { get; set; }

    //PM4
    public virtual DbSet<CfdPm4> CfdPm4s { get; set; }
    public virtual DbSet<CfdPm4Pc> CfdPm4Pcs { get; set; }
    public virtual DbSet<CfdPm4Qc> CfdPm4Qcs { get; set; }

    //TB1
    public virtual DbSet<CfdTb1> CfdTb1s { get; set; }
    public virtual DbSet<CfdTb1Pc> CfdTb1Pcs { get; set; }
    public virtual DbSet<CfdTb1Qc> CfdTb1Qcs { get; set; }

    //DH3MR
    public virtual DbSet<CfdDh3mr> CfdDh3mrs { get; set; }
    public virtual DbSet<CfdDh3mrPc> CfdDh3mrPcs { get; set; }
    public virtual DbSet<CfdDh3mrQc> CfdDh3mrQcs { get; set; }

    //VT4n4MR
    public virtual DbSet<CfdVt4n4Mr> CfdVt4n4Mrs { get; set; }
    public virtual DbSet<CfdVt4n4MrPc> CfdVt4n4MrPcs { get; set; }
    public virtual DbSet<CfdVt4n4MrQc> CfdVt4n4MrQcs { get; set; }

    public virtual DbSet<TongHopRcdf> TongHopRcdfs { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-409OOSHC\\SQLEXPRESS;Initial Catalog=TestV3;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;Command Timeout=180;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //PM1
        modelBuilder.Entity<CfdPm1Pc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_PM1___3214EC07A0942672");

            entity.ToTable("Cfd_PM1_Pc");

            entity.Property(e => e.Column0h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_24h");
            entity.Property(e => e.Column2h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h30");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<CfdPm1Qc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_PM1___3214EC079FE27AE0");

            entity.ToTable("Cfd_PM1_Qc");

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

        modelBuilder.Entity<CfdPm1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_PM1__3214EC279B7376DA");

            entity.ToTable("Cfd_PM1");

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
        });

        //PM4
        modelBuilder.Entity<CfdPm4>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_PM4__3214EC27A38C5634");

            entity.ToTable("Cfd_PM4");

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
        });

        modelBuilder.Entity<CfdPm4Pc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_PM4___3214EC077B04F036");

            entity.ToTable("Cfd_PM4_Pc");

            entity.Property(e => e.Column0h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_24h");
            entity.Property(e => e.Column2h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h30");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<CfdPm4Qc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_PM4___3214EC077D2FE990");

            entity.ToTable("Cfd_PM4_Qc");

            entity.Property(e => e.Column0h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_24h");
            entity.Property(e => e.Column2h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h30");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        //TB1
        modelBuilder.Entity<CfdTb1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_TB1__3214EC27F307452E");

            entity.ToTable("Cfd_TB1");

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
        });

        modelBuilder.Entity<CfdTb1Pc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_TB1___3214EC071926DFAE");

            entity.ToTable("Cfd_TB1_Pc");

            entity.Property(e => e.Column0h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_24h");
            entity.Property(e => e.Column2h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h30");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<CfdTb1Qc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_TB1___3214EC07F833AD62");

            entity.ToTable("Cfd_TB1_Qc");

            entity.Property(e => e.Column0h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_24h");
            entity.Property(e => e.Column2h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h30");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        //DH3MR
        modelBuilder.Entity<CfdDh3mr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_DH3M__3214EC27D086E89B");

            entity.ToTable("Cfd_DH3MR");

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
        });

        modelBuilder.Entity<CfdDh3mrPc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_DH3M__3214EC0752D83B37");

            entity.ToTable("Cfd_DH3MR_Pc");

            entity.Property(e => e.Column0h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_24h");
            entity.Property(e => e.Column2h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h30");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<CfdDh3mrQc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_DH3M__3214EC070EA37349");

            entity.ToTable("Cfd_DH3MR_Qc");

            entity.Property(e => e.Column0h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_24h");
            entity.Property(e => e.Column2h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h30");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        //VT4n4MR
        modelBuilder.Entity<CfdVt4n4Mr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_VT4n__3214EC270B9E0682");

            entity.ToTable("Cfd_VT4n4MR");

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
        });

        modelBuilder.Entity<CfdVt4n4MrPc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_VT4n__3214EC07232E4EC0");

            entity.ToTable("Cfd_VT4n4MR_Pc");

            entity.Property(e => e.Column0h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_24h");
            entity.Property(e => e.Column2h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h30");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<CfdVt4n4MrQc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cfd_VT4n__3214EC07014B4CFA");

            entity.ToTable("Cfd_VT4n4MR_Qc");

            entity.Property(e => e.Column0h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_0h30");
            entity.Property(e => e.Column10h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h");
            entity.Property(e => e.Column10h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_10h30");
            entity.Property(e => e.Column11h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h");
            entity.Property(e => e.Column11h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_11h30");
            entity.Property(e => e.Column12h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h");
            entity.Property(e => e.Column12h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_12h30");
            entity.Property(e => e.Column13h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h");
            entity.Property(e => e.Column13h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_13h30");
            entity.Property(e => e.Column14h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h");
            entity.Property(e => e.Column14h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_14h30");
            entity.Property(e => e.Column15h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h");
            entity.Property(e => e.Column15h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_15h30");
            entity.Property(e => e.Column16h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h");
            entity.Property(e => e.Column16h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_16h30");
            entity.Property(e => e.Column17h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h");
            entity.Property(e => e.Column17h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_17h30");
            entity.Property(e => e.Column18h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h");
            entity.Property(e => e.Column18h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_18h30");
            entity.Property(e => e.Column19h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h");
            entity.Property(e => e.Column19h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_19h30");
            entity.Property(e => e.Column1h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h");
            entity.Property(e => e.Column1h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_1h30");
            entity.Property(e => e.Column20h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h");
            entity.Property(e => e.Column20h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_20h30");
            entity.Property(e => e.Column21h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h");
            entity.Property(e => e.Column21h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_21h30");
            entity.Property(e => e.Column22h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h");
            entity.Property(e => e.Column22h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_22h30");
            entity.Property(e => e.Column23h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h");
            entity.Property(e => e.Column23h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_23h30");
            entity.Property(e => e.Column24h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_24h");
            entity.Property(e => e.Column2h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h");
            entity.Property(e => e.Column2h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_2h30");
            entity.Property(e => e.Column3h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h");
            entity.Property(e => e.Column3h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_3h30");
            entity.Property(e => e.Column4h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h");
            entity.Property(e => e.Column4h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_4h30");
            entity.Property(e => e.Column5h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h");
            entity.Property(e => e.Column5h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_5h30");
            entity.Property(e => e.Column6h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h");
            entity.Property(e => e.Column6h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_6h30");
            entity.Property(e => e.Column7h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h");
            entity.Property(e => e.Column7h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_7h30");
            entity.Property(e => e.Column8h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h");
            entity.Property(e => e.Column8h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_8h30");
            entity.Property(e => e.Column9h)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h");
            entity.Property(e => e.Column9h30)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Column_9h30");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<TongHopRcdf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TongHopR__3214EC27AD37967E");

            entity.ToTable("TongHopRcdf");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChiPhiDh3Mr).HasColumnName("chi_phi_dh3_mr");
            entity.Property(e => e.ChiPhiPm1).HasColumnName("chi_phi_pm1");
            entity.Property(e => e.ChiPhiPm4).HasColumnName("chi_phi_pm4");
            entity.Property(e => e.ChiPhiTb1).HasColumnName("chi_phi_tb1");
            entity.Property(e => e.ChiPhiVt44mr).HasColumnName("chi_phi_vt4_4mr");
            entity.Property(e => e.Ngay).HasColumnName("ngay");
            entity.Property(e => e.SanLuongDh3Mr).HasColumnName("san_luong_dh3_mr");
            entity.Property(e => e.SanLuongPm1).HasColumnName("san_luong_pm1");
            entity.Property(e => e.SanLuongPm4).HasColumnName("san_luong_pm4");
            entity.Property(e => e.SanLuongTb1).HasColumnName("san_luong_tb1");
            entity.Property(e => e.SanLuongVt44mr).HasColumnName("san_luong_vt4_4mr");
            entity.Property(e => e.TongChiPhi).HasColumnName("tong_chi_phi");
            entity.Property(e => e.TongSanLuong).HasColumnName("tong_san_luong");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
