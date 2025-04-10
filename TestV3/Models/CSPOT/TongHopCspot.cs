using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestV3.Models.CSPOT;

[Table("TongHopCspot")]
public partial class TongHopCspot
{
    public int Id { get; set; }

    public DateTime? Ngay { get; set; }

    public long? SanLuongQm { get; set; }

    public long? SanLuongQm1 { get; set; }

    public long? SanLuongQm2 { get; set; }

    public long? SanLuongTb { get; set; }

    public long? SanLuongVt4 { get; set; }

    public long? SanLuongVt4Mr { get; set; }

    public long? SanLuongDh3Mr { get; set; }

    public long? ChiPhiCm1 { get; set; }

    public long? ChiPhiCm2 { get; set; }

    public long? ChiPhiTb { get; set; }

    public long? ChiPhiVt4 { get; set; }

    public long? ChiPhiVt4Mr { get; set; }

    public long? ChiPhiDh3Mr { get; set; }

    public long? TongChiPhi { get; set; }
}
