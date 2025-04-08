using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestV3.Models;

[Table("FMP_Sai")]
public partial class FmpSai
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public int? Ngay { get; set; }

    [StringLength(50)]
    public string? Gia { get; set; }

    [Column("ChuKy_0h30")]
    public double? ChuKy0h30 { get; set; }

    [Column("ChuKy_1h")]
    public double? ChuKy1h { get; set; }

    [Column("ChuKy_1h30")]
    public double? ChuKy1h30 { get; set; }

    [Column("ChuKy_2h")]
    public double? ChuKy2h { get; set; }

    [Column("ChuKy_2h30")]
    public double? ChuKy2h30 { get; set; }

    [Column("ChuKy_3h")]
    public double? ChuKy3h { get; set; }

    [Column("ChuKy_3h30")]
    public double? ChuKy3h30 { get; set; }

    [Column("ChuKy_4h")]
    public double? ChuKy4h { get; set; }

    [Column("ChuKy_4h30")]
    public double? ChuKy4h30 { get; set; }

    [Column("ChuKy_5h")]
    public double? ChuKy5h { get; set; }

    [Column("ChuKy_5h30")]
    public double? ChuKy5h30 { get; set; }

    [Column("ChuKy_6h")]
    public double? ChuKy6h { get; set; }

    [Column("ChuKy_6h30")]
    public double? ChuKy6h30 { get; set; }

    [Column("ChuKy_7h")]
    public double? ChuKy7h { get; set; }

    [Column("ChuKy_7h30")]
    public double? ChuKy7h30 { get; set; }

    [Column("ChuKy_8h")]
    public double? ChuKy8h { get; set; }

    [Column("ChuKy_8h30")]
    public double? ChuKy8h30 { get; set; }

    [Column("ChuKy_9h")]
    public double? ChuKy9h { get; set; }

    [Column("ChuKy_9h30")]
    public double? ChuKy9h30 { get; set; }

    [Column("ChuKy_10h")]
    public double? ChuKy10h { get; set; }

    [Column("ChuKy_10h30")]
    public double? ChuKy10h30 { get; set; }

    [Column("ChuKy_11h")]
    public double? ChuKy11h { get; set; }

    [Column("ChuKy_11h30")]
    public double? ChuKy11h30 { get; set; }

    [Column("ChuKy_12h")]
    public double? ChuKy12h { get; set; }

    [Column("ChuKy_12h30")]
    public double? ChuKy12h30 { get; set; }

    [Column("ChuKy_13h")]
    public double? ChuKy13h { get; set; }

    [Column("ChuKy_13h30")]
    public double? ChuKy13h30 { get; set; }

    [Column("ChuKy_14h")]
    public double? ChuKy14h { get; set; }

    [Column("ChuKy_14h30")]
    public double? ChuKy14h30 { get; set; }

    [Column("ChuKy_15h")]
    public double? ChuKy15h { get; set; }

    [Column("ChuKy_15h30")]
    public double? ChuKy15h30 { get; set; }

    [Column("ChuKy_16h")]
    public double? ChuKy16h { get; set; }

    [Column("ChuKy_16h30")]
    public double? ChuKy16h30 { get; set; }

    [Column("ChuKy_17h")]
    public double? ChuKy17h { get; set; }

    [Column("ChuKy_17h30")]
    public double? ChuKy17h30 { get; set; }

    [Column("ChuKy_18h")]
    public double? ChuKy18h { get; set; }

    [Column("ChuKy_18h30")]
    public double? ChuKy18h30 { get; set; }

    [Column("ChuKy_19h")]
    public double? ChuKy19h { get; set; }

    [Column("ChuKy_19h30")]
    public double? ChuKy19h30 { get; set; }

    [Column("ChuKy_20h")]
    public double? ChuKy20h { get; set; }

    [Column("ChuKy_20h30")]
    public double? ChuKy20h30 { get; set; }

    [Column("ChuKy_21h")]
    public double? ChuKy21h { get; set; }

    [Column("ChuKy_21h30")]
    public double? ChuKy21h30 { get; set; }

    [Column("ChuKy_22h")]
    public double? ChuKy22h { get; set; }

    [Column("ChuKy_22h30")]
    public double? ChuKy22h30 { get; set; }

    [Column("ChuKy_23h")]
    public double? ChuKy23h { get; set; }

    [Column("ChuKy_23h30")]
    public double? ChuKy23h30 { get; set; }

    [Column("ChuKy_24h")]
    public double? ChuKy24h { get; set; }

    public double? Tong { get; set; }
}
