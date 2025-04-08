using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestV3.Models;

[Table("Pm_A0")]
public partial class PmA0
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Column("Ngày")]
    public string? Ngay { get; set; }

    [Column("Giá")]
    public string? Gia { get; set; }

    [Column("Column_0h30")]
    public string? Column0h30 { get; set; }

    [Column("Column_1h")]
    public string? Column1h { get; set; }

    [Column("Column_1h30")]
    public string? Column1h30 { get; set; }

    [Column("Column_2h")]
    public string? Column2h { get; set; }

    [Column("Column_2h30")]
    public string? Column2h30 { get; set; }

    [Column("Column_3h")]
    public string? Column3h { get; set; }

    [Column("Column_3h30")]
    public string? Column3h30 { get; set; }

    [Column("Column_4h")]
    public string? Column4h { get; set; }

    [Column("Column_4h30")]
    public string? Column4h30 { get; set; }

    [Column("Column_5h")]
    public string? Column5h { get; set; }

    [Column("Column_5h30")]
    public string? Column5h30 { get; set; }

    [Column("Column_6h")]
    public string? Column6h { get; set; }

    [Column("Column_6h30")]
    public string? Column6h30 { get; set; }

    [Column("Column_7h")]
    public string? Column7h { get; set; }

    [Column("Column_7h30")]
    public string? Column7h30 { get; set; }

    [Column("Column_8h")]
    public string? Column8h { get; set; }

    [Column("Column_8h30")]
    public string? Column8h30 { get; set; }

    [Column("Column_9h")]
    public string? Column9h { get; set; }

    [Column("Column_9h30")]
    public string? Column9h30 { get; set; }

    [Column("Column_10h")]
    public string? Column10h { get; set; }

    [Column("Column_10h30")]
    public string? Column10h30 { get; set; }

    [Column("Column_11h")]
    public string? Column11h { get; set; }

    [Column("Column_11h30")]
    public string? Column11h30 { get; set; }

    [Column("Column_12h")]
    public string? Column12h { get; set; }

    [Column("Column_12h30")]
    public string? Column12h30 { get; set; }

    [Column("Column_13h")]
    public string? Column13h { get; set; }

    [Column("Column_13h30")]
    public string? Column13h30 { get; set; }

    [Column("Column_14h")]
    public string? Column14h { get; set; }

    [Column("Column_14h30")]
    public string? Column14h30 { get; set; }

    [Column("Column_15h")]
    public string? Column15h { get; set; }

    [Column("Column_15h30")]
    public string? Column15h30 { get; set; }

    [Column("Column_16h")]
    public string? Column16h { get; set; }

    [Column("Column_16h30")]
    public string? Column16h30 { get; set; }

    [Column("Column_17h")]
    public string? Column17h { get; set; }

    [Column("Column_17h30")]
    public string? Column17h30 { get; set; }

    [Column("Column_18h")]
    public string? Column18h { get; set; }

    [Column("Column_18h30")]
    public string? Column18h30 { get; set; }

    [Column("Column_19h")]
    public string? Column19h { get; set; }

    [Column("Column_19h30")]
    public string? Column19h30 { get; set; }

    [Column("Column_20h")]
    public string? Column20h { get; set; }

    [Column("Column_20h30")]
    public string? Column20h30 { get; set; }

    [Column("Column_21h")]
    public string? Column21h { get; set; }

    [Column("Column_21h30")]
    public string? Column21h30 { get; set; }

    [Column("Column_22h")]
    public string? Column22h { get; set; }

    [Column("Column_22h30")]
    public string? Column22h30 { get; set; }

    [Column("Column_23h")]
    public string? Column23h { get; set; }

    [Column("Column_23h30")]
    public string? Column23h30 { get; set; }

    [Column("Column_24h")]
    public string? Column24h { get; set; }

    [Column("Tổng")]
    public string? Tong { get; set; }
}
