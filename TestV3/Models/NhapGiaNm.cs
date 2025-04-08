using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestV3.Models;

[Table("NhâpgíaNM")]
public partial class NhapGiaNm
{
    public double? Ngay { get; set; }

    [StringLength(255)]
    public string? Gia { get; set; }

    [Column("[0h30]")]
    public double? Column0h30 { get; set; }

    [Column("[1h]")]
    public double? Column1h { get; set; }

    [Column("[1h30]")]
    public double? Column1h30 { get; set; }

    [Column("[2h]")]
    public double? Column2h { get; set; }

    [Column("[2h30]")]
    public double? Column2h30 { get; set; }

    [Column("[3h]")]
    public double? Column3h { get; set; }

    [Column("[3h30]")]
    public double? Column3h30 { get; set; }

    [Column("[4h]")]
    public double? Column4h { get; set; }

    [Column("[4h30]")]
    public double? Column4h30 { get; set; }

    [Column("[5h]")]
    public double? Column5h { get; set; }

    [Column("[5h30]")]
    public double? Column5h30 { get; set; }

    [Column("[6h]")]
    public double? Column6h { get; set; }

    [Column("[6h30]")]
    public double? Column6h30 { get; set; }

    [Column("[7h]")]
    public double? Column7h { get; set; }

    [Column("[7h30]")]
    public double? Column7h30 { get; set; }

    [Column("[8h]")]
    public double? Column8h { get; set; }

    [Column("[8h30]")]
    public double? Column8h30 { get; set; }

    [Column("[9h]")]
    public double? Column9h { get; set; }

    [Column("[9h30]")]
    public double? Column9h30 { get; set; }

    [Column("[10h]")]
    public double? Column10h { get; set; }

    [Column("[10h30]")]
    public double? Column10h30 { get; set; }

    [Column("[11h]")]
    public double? Column11h { get; set; }

    [Column("[11h30]")]
    public double? Column11h30 { get; set; }

    [Column("[12h]")]
    public double? Column12h { get; set; }

    [Column("[12h30]")]
    public double? Column12h30 { get; set; }

    [Column("[13h]")]
    public double? Column13h { get; set; }

    [Column("[13h30]")]
    public double? Column13h30 { get; set; }

    [Column("[14h]")]
    public double? Column14h { get; set; }

    [Column("[14h30]")]
    public double? Column14h30 { get; set; }

    [Column("[15h]")]
    public double? Column15h { get; set; }

    [Column("[15h30]")]
    public double? Column15h30 { get; set; }

    [Column("[16h]")]
    public double? Column16h { get; set; }

    [Column("[16h30]")]
    public double? Column16h30 { get; set; }

    [Column("[17h]")]
    public double? Column17h { get; set; }

    [Column("[17h30]")]
    public double? Column17h30 { get; set; }

    [Column("[18h]")]
    public double? Column18h { get; set; }

    [Column("[18h30]")]
    public double? Column18h30 { get; set; }

    [Column("[19h]")]
    public double? Column19h { get; set; }

    [Column("[19h30]")]
    public double? Column19h30 { get; set; }

    [Column("[20h]")]
    public double? Column20h { get; set; }

    [Column("[20h30]")]
    public double? Column20h30 { get; set; }

    [Column("[21h]")]
    public double? Column21h { get; set; }

    [Column("[21h30]")]
    public double? Column21h30 { get; set; }

    [Column("[22h]")]
    public double? Column22h { get; set; }

    [Column("[22h30]")]
    public double? Column22h30 { get; set; }

    [Column("[23h]")]
    public double? Column23h { get; set; }

    [Column("[23h30]")]
    public double? Column23h30 { get; set; }

    [Column("[24h]")]
    public double? Column24h { get; set; }

    [Column("Tổng")]
    public double? Tong { get; set; }
}
