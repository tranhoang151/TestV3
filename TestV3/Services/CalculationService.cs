using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestV3.Data;
using TestV3.Models.PmQL;
using TestV3.Services;

namespace TestV3.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ApplicationDbContext _context;

        public CalculationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public double CustomRound(double value)
        {
            return (value > -1 && value < 1) ? 0 : Math.Round(value, 0, MidpointRounding.AwayFromZero);
        }

        public async Task CalculateAndSaveFmpEvnAsync()
        {
            // Lấy dữ liệu SMP và CAN trong một truy vấn duy nhất
            var data = await _context.NhậpgíaNM
                .Where(n => n.Giá == "SMP" || n.Giá == "CAN")
                .GroupBy(n => n.Ngày)
                .ToListAsync();

            var fmpEvnList = new List<FmpEvn>();

            // Danh sách các chu kỳ
            var chuKys = new[]
            {
                "_0h30", "_1h", "_1h30", "_2h", "_2h30", "_3h", "_3h30", "_4h", "_4h30", "_5h",
                "_5h30", "_6h", "_6h30", "_7h", "_7h30", "_8h", "_8h30", "_9h", "_9h30", "_10h",
                "_10h30", "_11h", "_11h30", "_12h", "_12h30", "_13h", "_13h30", "_14h", "_14h30",
                "_15h", "_15h30", "_16h", "_16h30", "_17h", "_17h30", "_18h", "_18h30", "_19h",
                "_19h30", "_20h", "_20h30", "_21h", "_21h30", "_22h", "_22h30", "_23h", "_23h30", "_24h"
            };

            foreach (var group in data)
            {
                var smp = group.FirstOrDefault(n => n.Giá == "SMP");
                var can = group.FirstOrDefault(n => n.Giá == "CAN");

                if (smp != null && can != null)
                {
                    var fmpEvn = new FmpEvn
                    {
                        Ngay = (int?)smp.Ngày,
                        Gia = "FMP",
                        Tong = Math.Round((smp.Tổng + can.Tổng).GetValueOrDefault(), 1, MidpointRounding.AwayFromZero)
                    };

                    // Sử dụng vòng lặp để tính toán các chu kỳ
                    foreach (var chuKy in chuKys)
                    {
                        var smpValue = typeof(NhapGiaNm).GetProperty(chuKy)?.GetValue(smp) as double?;
                        var canValue = typeof(NhapGiaNm).GetProperty(chuKy)?.GetValue(can) as double?;
                        var fmpValue = Math.Round((smpValue.GetValueOrDefault() + canValue.GetValueOrDefault()), 1, MidpointRounding.AwayFromZero);

                        typeof(FmpEvn).GetProperty($"ChuKy{chuKy}")?.SetValue(fmpEvn, fmpValue);
                    }

                    fmpEvnList.Add(fmpEvn);
                }
            }

            // Xóa dữ liệu cũ và lưu dữ liệu mới
            _context.FMP_EVN.RemoveRange(_context.FMP_EVN);
            await _context.SaveChangesAsync();

            await _context.FMP_EVN.AddRangeAsync(fmpEvnList);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FmpEvn>> GetFmpEvnDataAsync()
        {
            return await _context.FMP_EVN.ToListAsync();
        }

        public async Task CalculateAndSavePmEvnAsync()
        {
            // Lấy dữ liệu FMP_EVN và k trong một truy vấn duy nhất
            var fmpEvnData = await _context.FMP_EVN.ToListAsync();
            var kData = await _context.NhậpgíaNM
                .Where(n => n.Giá == "k")
                .ToListAsync();

            var pmEvnList = new List<PmEvn>();

            // Danh sách các chu kỳ
            var chuKys = new[]
            {
                "_0h30", "_1h", "_1h30", "_2h", "_2h30", "_3h", "_3h30", "_4h", "_4h30", "_5h",
                "_5h30", "_6h", "_6h30", "_7h", "_7h30", "_8h", "_8h30", "_9h", "_9h30", "_10h",
                "_10h30", "_11h", "_11h30", "_12h", "_12h30", "_13h", "_13h30", "_14h", "_14h30",
                "_15h", "_15h30", "_16h", "_16h30", "_17h", "_17h30", "_18h", "_18h30", "_19h",
                "_19h30", "_20h", "_20h30", "_21h", "_21h30", "_22h", "_22h30", "_23h", "_23h30", "_24h"
            };

            foreach (var fmpEvn in fmpEvnData)
            {
                var k = kData.FirstOrDefault(k => k.Ngày == fmpEvn.Ngay);
                if (k != null)
                {
                    var pmEvn = new PmEvn
                    {
                        Ngay = fmpEvn.Ngay,
                        Gia = "Pm",
                        Tong = Math.Round(new double?[]
                        {
                            fmpEvn.ChuKy0h30 * k._0h30, fmpEvn.ChuKy1h * k._1h, fmpEvn.ChuKy1h30 * k._1h30,
                            fmpEvn.ChuKy2h * k._2h, fmpEvn.ChuKy2h30 * k._2h30, fmpEvn.ChuKy3h * k._3h,
                            fmpEvn.ChuKy3h30 * k._3h30, fmpEvn.ChuKy4h * k._4h, fmpEvn.ChuKy4h30 * k._4h30,
                            fmpEvn.ChuKy5h * k._5h, fmpEvn.ChuKy5h30 * k._5h30, fmpEvn.ChuKy6h * k._6h,
                            fmpEvn.ChuKy6h30 * k._6h30, fmpEvn.ChuKy7h * k._7h, fmpEvn.ChuKy7h30 * k._7h30,
                            fmpEvn.ChuKy8h * k._8h, fmpEvn.ChuKy8h30 * k._8h30, fmpEvn.ChuKy9h * k._9h,
                            fmpEvn.ChuKy9h30 * k._9h30, fmpEvn.ChuKy10h * k._10h, fmpEvn.ChuKy10h30 * k._10h30,
                            fmpEvn.ChuKy11h * k._11h, fmpEvn.ChuKy11h30 * k._11h30, fmpEvn.ChuKy12h * k._12h,
                            fmpEvn.ChuKy12h30 * k._12h30, fmpEvn.ChuKy13h * k._13h, fmpEvn.ChuKy13h30 * k._13h30,
                            fmpEvn.ChuKy14h * k._14h, fmpEvn.ChuKy14h30 * k._14h30, fmpEvn.ChuKy15h * k._15h,
                            fmpEvn.ChuKy15h30 * k._15h30, fmpEvn.ChuKy16h * k._16h, fmpEvn.ChuKy16h30 * k._16h30,
                            fmpEvn.ChuKy17h * k._17h, fmpEvn.ChuKy17h30 * k._17h30, fmpEvn.ChuKy18h * k._18h,
                            fmpEvn.ChuKy18h30 * k._18h30, fmpEvn.ChuKy19h * k._19h, fmpEvn.ChuKy19h30 * k._19h30,
                            fmpEvn.ChuKy20h * k._20h, fmpEvn.ChuKy20h30 * k._20h30, fmpEvn.ChuKy21h * k._21h,
                            fmpEvn.ChuKy21h30 * k._21h30, fmpEvn.ChuKy22h * k._22h, fmpEvn.ChuKy22h30 * k._22h30,
                            fmpEvn.ChuKy23h * k._23h, fmpEvn.ChuKy23h30 * k._23h30, fmpEvn.ChuKy24h * k._24h
                        }.Where(x => x.HasValue).Sum().GetValueOrDefault(), 0, MidpointRounding.AwayFromZero)
                    };

                    // Sử dụng vòng lặp để tính toán các chu kỳ
                    foreach (var chuKy in chuKys)
                    {
                        var fmpValue = typeof(FmpEvn).GetProperty($"ChuKy{chuKy}")?.GetValue(fmpEvn) as double?;
                        var kValue = typeof(NhapGiaNm).GetProperty(chuKy)?.GetValue(k) as double?;
                        var pmValue = Math.Round(fmpValue.GetValueOrDefault() * kValue.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero);

                        typeof(PmEvn).GetProperty($"ChuKy{chuKy}")?.SetValue(pmEvn, pmValue);
                    }

                    pmEvnList.Add(pmEvn);
                }
            }

            // Xóa dữ liệu cũ và lưu dữ liệu mới
            _context.Pm_EVN.RemoveRange(_context.Pm_EVN);
            await _context.SaveChangesAsync();

            await _context.Pm_EVN.AddRangeAsync(pmEvnList);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PmEvn>> GetPmEvnDataAsync()
        {
            return await _context.Pm_EVN.ToListAsync();
        }

        public async Task CalculateAndSaveFmpSaiAsync()
        {
            // Lấy dữ liệu FMP_EVN và FMP_A0
            var fmpEvnData = await _context.FMP_EVN.ToListAsync();
            var fmpA0Data = await _context.FMP_A0.ToListAsync();

            var fmpSaiList = new List<FmpSai>();

            // Danh sách các chu kỳ
            var chuKys = new[]
            {
                "ChuKy0h30", "ChuKy1h", "ChuKy1h30", "ChuKy2h", "ChuKy2h30", "ChuKy3h", "ChuKy3h30",
                "ChuKy4h", "ChuKy4h30", "ChuKy5h", "ChuKy5h30", "ChuKy6h", "ChuKy6h30", "ChuKy7h",
                "ChuKy7h30", "ChuKy8h", "ChuKy8h30", "ChuKy9h", "ChuKy9h30", "ChuKy10h", "ChuKy10h30",
                "ChuKy11h", "ChuKy11h30", "ChuKy12h", "ChuKy12h30", "ChuKy13h", "ChuKy13h30", "ChuKy14h",
                "ChuKy14h30", "ChuKy15h", "ChuKy15h30", "ChuKy16h", "ChuKy16h30", "ChuKy17h", "ChuKy17h30",
                "ChuKy18h", "ChuKy18h30", "ChuKy19h", "ChuKy19h30", "ChuKy20h", "ChuKy20h30", "ChuKy21h",
                "ChuKy21h30", "ChuKy22h", "ChuKy22h30", "ChuKy23h", "ChuKy23h30", "ChuKy24h"
            };

            foreach (var fmpEvn in fmpEvnData)
            {
                // Tìm bản ghi FMP_A0 tương ứng
                var fmpA0 = fmpA0Data.FirstOrDefault(a =>
                    int.TryParse(a.Ngày, out int ngayValue) && ngayValue == fmpEvn.Ngay);

                if (fmpA0 != null)
                {
                    var fmpSai = new FmpSai
                    {
                        Ngay = fmpEvn.Ngay,
                        Gia = "FMP"
                    };

                    // Sử dụng vòng lặp để tính toán các chu kỳ
                    foreach (var chuKy in chuKys)
                    {
                        var fmpEvnValue = typeof(FmpEvn).GetProperty(chuKy)?.GetValue(fmpEvn) as double?;
                        var fmpA0Value = typeof(FmpA0).GetProperty($"Column{chuKy.Substring(5)}")?.GetValue(fmpA0) as string;

                        var parsedFmpA0Value = double.TryParse(fmpA0Value, out double result) ? result : 0;
                        var fmpSaiValue = Math.Round((fmpEvnValue.GetValueOrDefault() - parsedFmpA0Value), 1, MidpointRounding.AwayFromZero);

                        typeof(FmpSai).GetProperty(chuKy)?.SetValue(fmpSai, fmpSaiValue);
                    }

                    // Tính tổng của 48 chu kỳ
                    fmpSai.Tong = chuKys
                        .Select(chuKy => typeof(FmpSai).GetProperty(chuKy)?.GetValue(fmpSai) as double?)
                        .Where(x => x.HasValue)
                        .Sum(x => x.GetValueOrDefault());

                    fmpSaiList.Add(fmpSai);
                }
            }

            // Xóa dữ liệu cũ và lưu dữ liệu mới
            _context.FMP_Sai.RemoveRange(_context.FMP_Sai);
            await _context.SaveChangesAsync();

            await _context.FMP_Sai.AddRangeAsync(fmpSaiList);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FmpSai>> GetFmpSaiDataAsync()
        {
            return await _context.FMP_Sai.ToListAsync();
        }

        public async Task CalculateAndSavePmSaiAsync()
        {
            // Lấy dữ liệu Pm_EVN và Pm_A0
            var pmEvnData = await _context.Pm_EVN.ToListAsync();
            var pmA0Data = await _context.Pm_A0.ToListAsync();

            var pmSaiList = new List<PmSai>();

            // Danh sách các chu kỳ
            var chuKys = new[]
            {
                "ChuKy0h30", "ChuKy1h", "ChuKy1h30", "ChuKy2h", "ChuKy2h30", "ChuKy3h", "ChuKy3h30",
                "ChuKy4h", "ChuKy4h30", "ChuKy5h", "ChuKy5h30", "ChuKy6h", "ChuKy6h30", "ChuKy7h",
                "ChuKy7h30", "ChuKy8h", "ChuKy8h30", "ChuKy9h", "ChuKy9h30", "ChuKy10h", "ChuKy10h30",
                "ChuKy11h", "ChuKy11h30", "ChuKy12h", "ChuKy12h30", "ChuKy13h", "ChuKy13h30", "ChuKy14h",
                "ChuKy14h30", "ChuKy15h", "ChuKy15h30", "ChuKy16h", "ChuKy16h30", "ChuKy17h", "ChuKy17h30",
                "ChuKy18h", "ChuKy18h30", "ChuKy19h", "ChuKy19h30", "ChuKy20h", "ChuKy20h30", "ChuKy21h",
                "ChuKy21h30", "ChuKy22h", "ChuKy22h30", "ChuKy23h", "ChuKy23h30", "ChuKy24h"
            };

            foreach (var pmEvn in pmEvnData)
            {
                // Tìm bản ghi Pm_A0 tương ứng
                var pmA0 = pmA0Data.FirstOrDefault(a =>
                    int.TryParse(a.Ngày, out int ngayValue) &&
                    ngayValue == pmEvn.Ngay &&
                    a.Giá == pmEvn.Gia);

                if (pmA0 != null)
                {
                    var pmSai = new PmSai
                    {
                        Ngay = pmEvn.Ngay,
                        Gia = pmEvn.Gia
                    };

                    // Sử dụng vòng lặp để tính toán các chu kỳ
                    foreach (var chuKy in chuKys)
                    {
                        var pmEvnValue = typeof(PmEvn).GetProperty(chuKy)?.GetValue(pmEvn) as double?;
                        var pmA0Value = typeof(PmA0).GetProperty($"Column{chuKy.Substring(5)}")?.GetValue(pmA0) as string;

                        var parsedPmA0Value = double.TryParse(pmA0Value, out double result) ? result : 0;
                        var pmSaiValue = Math.Round((pmEvnValue.GetValueOrDefault() - parsedPmA0Value), 1, MidpointRounding.AwayFromZero);

                        typeof(PmSai).GetProperty(chuKy)?.SetValue(pmSai, pmSaiValue);
                    }

                    // Tính tổng của 48 chu kỳ
                    pmSai.Tong = chuKys
                        .Select(chuKy => typeof(PmSai).GetProperty(chuKy)?.GetValue(pmSai) as double?)
                        .Where(x => x.HasValue)
                        .Sum(x => x.GetValueOrDefault());

                    pmSaiList.Add(pmSai);
                }
            }

            // Xóa dữ liệu cũ và lưu dữ liệu mới
            _context.Pm_Sai.RemoveRange(_context.Pm_Sai);
            await _context.SaveChangesAsync();

            await _context.Pm_Sai.AddRangeAsync(pmSaiList);
            await _context.SaveChangesAsync();
        }


        //Tính chênh lệch và làm tròn
        private double? CalculateDifference(double? pmEvnValue, double? pmA0Value)
        {
            if (!pmEvnValue.HasValue || !pmA0Value.HasValue) return null;

            var diff = pmEvnValue.Value - pmA0Value.Value;
            return (diff >= -0.9 && diff <= 0.9) ? 0 : Math.Round(diff, 0, MidpointRounding.AwayFromZero);
        }

        public async Task<List<PmSai>> GetPmSaiDataAsync()
        {
            return await _context.Pm_Sai.ToListAsync();
        }
    }
}