using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestV3.Models.CSPOT;

namespace TestV3.Data;

public partial class TestV3Context : DbContext
{
    public TestV3Context()
    {
    }

    public TestV3Context(DbContextOptions<TestV3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CspotDh3mrCspot2> CspotDh3mrCspot2s { get; set; }

    public virtual DbSet<CspotPmCspot1> CspotPmCspot1s { get; set; }

    public virtual DbSet<CspotTbCsport2> CspotTbCsport2s { get; set; }

    public virtual DbSet<CspotVt4Cspot2> CspotVt4Cspot2s { get; set; }

    public virtual DbSet<CspotVt4mrCspot2> CspotVt4mrCspot2s { get; set; }

    public virtual DbSet<PmCspot1> PmCspot1s { get; set; }

    public virtual DbSet<PmCspot2> PmCspot2s { get; set; }

    public virtual DbSet<Qm1Cspot1> Qm1Cspot1s { get; set; }

    public virtual DbSet<Qm2Dh3mrCspot2> Qm2Dh3mrCspot2s { get; set; }

    public virtual DbSet<Qm2TbCspot2> Qm2TbCspot2s { get; set; }

    public virtual DbSet<Qm2Vt4Cspot2> Qm2Vt4Cspot2s { get; set; }

    public virtual DbSet<Qm2Vt4mrcspot2> Qm2Vt4mrcspot2s { get; set; }

    public virtual DbSet<TongHopCspot> TongHopCspots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-409OOSHC\\SQLEXPRESS;Initial Catalog=TestV3;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CspotDh3mrCspot2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CspotDH3__3214EC07F6B635BE");

            entity.ToTable("CspotDH3MR_Cspot2");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
        });

        modelBuilder.Entity<CspotPmCspot1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CspotPM___3214EC0751E4B25C");

            entity.ToTable("CspotPM_Cspot1");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
        });

        modelBuilder.Entity<CspotTbCsport2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CspotTB___3214EC079AAC3998");

            entity.ToTable("CspotTB_Csport2");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<CspotVt4Cspot2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CspotVT4__3214EC0779F11630");

            entity.ToTable("CspotVT4_Cspot2");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
        });

        modelBuilder.Entity<CspotVt4mrCspot2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CspotVT4__3214EC075D397425");

            entity.ToTable("CspotVT4MR_Cspot2");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
        });

        modelBuilder.Entity<PmCspot1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pm_Cspot__3214EC0743E977AC");

            entity.ToTable("Pm_Cspot1");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<PmCspot2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pm_Cspot__3214EC07BEC82B1C");

            entity.ToTable("Pm_Cspot2");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
            entity.Property(e => e.Tổng).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<Qm1Cspot1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Qm1_Cspo__3214EC074C7E7AA4");

            entity.ToTable("Qm1_Cspot1");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
        });

        modelBuilder.Entity<Qm2Dh3mrCspot2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Qm2DH3MR__3214EC0780988142");

            entity.ToTable("Qm2DH3MR_Cspot2");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
        });

        modelBuilder.Entity<Qm2TbCspot2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Qm2TB_Cs__3214EC07496EFFDF");

            entity.ToTable("Qm2TB_Cspot2");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
        });

        modelBuilder.Entity<Qm2Vt4Cspot2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Qm2VT4_C__3214EC076AFD526B");

            entity.ToTable("Qm2VT4_Cspot2");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
        });

        modelBuilder.Entity<Qm2Vt4mrcspot2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Qm2VT4MR__3214EC071CFF0579");

            entity.ToTable("Qm2VT4MRCspot2");

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
            entity.Property(e => e.Ngày).HasColumnType("datetime");
        });

        modelBuilder.Entity<TongHopCspot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TongHopC__3214EC274A0BFC5D");

            entity.ToTable("TongHopCspot");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChiPhiCm1).HasColumnName("chi_phi_cm1");
            entity.Property(e => e.ChiPhiCm2).HasColumnName("chi_phi_cm2");
            entity.Property(e => e.ChiPhiDh3Mr).HasColumnName("chi_phi_dh3_mr");
            entity.Property(e => e.ChiPhiTb).HasColumnName("chi_phi_tb");
            entity.Property(e => e.ChiPhiVt4).HasColumnName("chi_phi_vt4");
            entity.Property(e => e.ChiPhiVt4Mr).HasColumnName("chi_phi_vt4_mr");
            entity.Property(e => e.Ngay)
                .HasColumnType("datetime")
                .HasColumnName("ngay");
            entity.Property(e => e.SanLuongDh3Mr).HasColumnName("san_luong_dh3_mr");
            entity.Property(e => e.SanLuongQm).HasColumnName("san_luong_qm");
            entity.Property(e => e.SanLuongQm1).HasColumnName("san_luong_qm1");
            entity.Property(e => e.SanLuongQm2).HasColumnName("san_luong_qm2");
            entity.Property(e => e.SanLuongTb).HasColumnName("san_luong_tb");
            entity.Property(e => e.SanLuongVt4).HasColumnName("san_luong_vt4");
            entity.Property(e => e.SanLuongVt4Mr).HasColumnName("san_luong_vt4_mr");
            entity.Property(e => e.TongChiPhi).HasColumnName("tong_chi_phi");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
