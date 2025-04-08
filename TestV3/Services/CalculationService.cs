using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestV3.Data;
using TestV3.Models;
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
            var smpData = await _context.NhậpgíaNM
                .Where(n => n.Gia == "SMP")
                .ToListAsync();

            var canData = await _context.NhậpgíaNM
                .Where(n => n.Gia == "CAN")
                .ToListAsync();

            var fmpEvnList = new List<FmpEvn>();

            foreach (var smp in smpData)
            {
                var can = canData.FirstOrDefault(c => c.Ngay == smp.Ngay);
                if (can != null)
                {
                    var fmpEvn = new FmpEvn
                    {
                        Ngay = (int?)smp.Ngay,
                        Gia = "FMP",
                        ChuKy0h30 = smp.Column0h30 + can.Column0h30,
                        ChuKy1h = smp.Column1h + can.Column1h,
                        ChuKy1h30 = smp.Column1h30 + can.Column1h30,
                        ChuKy2h = smp.Column2h + can.Column2h,
                        ChuKy2h30 = smp.Column2h30 + can.Column2h30,
                        ChuKy3h = smp.Column3h + can.Column3h,
                        ChuKy3h30 = smp.Column3h30 + can.Column3h30,
                        ChuKy4h = smp.Column4h + can.Column4h,
                        ChuKy4h30 = smp.Column4h30 + can.Column4h30,
                        ChuKy5h = smp.Column5h + can.Column5h,
                        ChuKy5h30 = smp.Column5h30 + can.Column5h30,
                        ChuKy6h = smp.Column6h + can.Column6h,
                        ChuKy6h30 = smp.Column6h30 + can.Column6h30,
                        ChuKy7h = smp.Column7h + can.Column7h,
                        ChuKy7h30 = smp.Column7h30 + can.Column7h30,
                        ChuKy8h = smp.Column8h + can.Column8h,
                        ChuKy8h30 = smp.Column8h30 + can.Column8h30,
                        ChuKy9h = smp.Column9h + can.Column9h,
                        ChuKy9h30 = smp.Column9h30 + can.Column9h30,
                        ChuKy10h = smp.Column10h + can.Column10h,
                        ChuKy10h30 = smp.Column10h30 + can.Column10h30,
                        ChuKy11h = smp.Column11h + can.Column11h,
                        ChuKy11h30 = smp.Column11h30 + can.Column11h30,
                        ChuKy12h = smp.Column12h + can.Column12h,
                        ChuKy12h30 = smp.Column12h30 + can.Column12h30,
                        ChuKy13h = smp.Column13h + can.Column13h,
                        ChuKy13h30 = smp.Column13h30 + can.Column13h30,
                        ChuKy14h = smp.Column14h + can.Column14h,
                        ChuKy14h30 = smp.Column14h30 + can.Column14h30,
                        ChuKy15h = smp.Column15h + can.Column15h,
                        ChuKy15h30 = smp.Column15h30 + can.Column15h30,
                        ChuKy16h = smp.Column16h + can.Column16h,
                        ChuKy16h30 = smp.Column16h30 + can.Column16h30,
                        ChuKy17h = smp.Column17h + can.Column17h,
                        ChuKy17h30 = smp.Column17h30 + can.Column17h30,
                        ChuKy18h = smp.Column18h + can.Column18h,
                        ChuKy18h30 = smp.Column18h30 + can.Column18h30,
                        ChuKy19h = smp.Column19h + can.Column19h,
                        ChuKy19h30 = smp.Column19h30 + can.Column19h30,
                        ChuKy20h = smp.Column20h + can.Column20h,
                        ChuKy20h30 = smp.Column20h30 + can.Column20h30,
                        ChuKy21h = smp.Column21h + can.Column21h,
                        ChuKy21h30 = smp.Column21h30 + can.Column21h30,
                        ChuKy22h = smp.Column22h + can.Column22h,
                        ChuKy22h30 = smp.Column22h30 + can.Column22h30,
                        ChuKy23h = smp.Column23h + can.Column23h,
                        ChuKy23h30 = smp.Column23h30 + can.Column23h30,
                        ChuKy24h = smp.Column24h + can.Column24h,
                        Tong = smp.Tong + can.Tong
                    };

                    fmpEvnList.Add(fmpEvn);
                }
            }

            // Remove existing data
            _context.FMP_EVN.RemoveRange(_context.FMP_EVN);
            await _context.SaveChangesAsync();

            // Add new data
            await _context.FMP_EVN.AddRangeAsync(fmpEvnList);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FmpEvn>> GetFmpEvnDataAsync()
        {
            return await _context.FMP_EVN.ToListAsync();
        }

        public async Task CalculateAndSavePmEvnAsync()
        {
            var fmpEvnData = await _context.FMP_EVN.ToListAsync();
            var kData = await _context.NhậpgíaNM
                .Where(n => n.Gia == "k")
                .ToListAsync();

            var pmEvnList = new List<PmEvn>();

            foreach (var fmpEvn in fmpEvnData)
            {
                var k = kData.FirstOrDefault(k => k.Ngay == fmpEvn.Ngay);
                if (k != null)
                {
                    var pmEvn = new PmEvn
                    {
                        Ngay = fmpEvn.Ngay,
                        Gia = "Pm",
                        ChuKy0h30 = Math.Round(fmpEvn.ChuKy0h30.GetValueOrDefault() * k.Column0h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy1h = Math.Round(fmpEvn.ChuKy1h.GetValueOrDefault() * k.Column1h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy1h30 = Math.Round(fmpEvn.ChuKy1h30.GetValueOrDefault() * k.Column1h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy2h = Math.Round(fmpEvn.ChuKy2h.GetValueOrDefault() * k.Column2h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy2h30 = Math.Round(fmpEvn.ChuKy2h30.GetValueOrDefault() * k.Column2h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy3h = Math.Round(fmpEvn.ChuKy3h.GetValueOrDefault() * k.Column3h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy3h30 = Math.Round(fmpEvn.ChuKy3h30.GetValueOrDefault() * k.Column3h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy4h = Math.Round(fmpEvn.ChuKy4h.GetValueOrDefault() * k.Column4h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy4h30 = Math.Round(fmpEvn.ChuKy4h30.GetValueOrDefault() * k.Column4h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy5h = Math.Round(fmpEvn.ChuKy5h.GetValueOrDefault() * k.Column5h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy5h30 = Math.Round(fmpEvn.ChuKy5h30.GetValueOrDefault() * k.Column5h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy6h = Math.Round(fmpEvn.ChuKy6h.GetValueOrDefault() * k.Column6h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy6h30 = Math.Round(fmpEvn.ChuKy6h30.GetValueOrDefault() * k.Column6h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy7h = Math.Round(fmpEvn.ChuKy7h.GetValueOrDefault() * k.Column7h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy7h30 = Math.Round(fmpEvn.ChuKy7h30.GetValueOrDefault() * k.Column7h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy8h = Math.Round(fmpEvn.ChuKy8h.GetValueOrDefault() * k.Column8h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy8h30 = Math.Round(fmpEvn.ChuKy8h30.GetValueOrDefault() * k.Column8h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy9h = Math.Round(fmpEvn.ChuKy9h.GetValueOrDefault() * k.Column9h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy9h30 = Math.Round(fmpEvn.ChuKy9h30.GetValueOrDefault() * k.Column9h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy10h = Math.Round(fmpEvn.ChuKy10h.GetValueOrDefault() * k.Column10h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy10h30 = Math.Round(fmpEvn.ChuKy10h30.GetValueOrDefault() * k.Column10h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy11h = Math.Round(fmpEvn.ChuKy11h.GetValueOrDefault() * k.Column11h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy11h30 = Math.Round(fmpEvn.ChuKy11h30.GetValueOrDefault() * k.Column11h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy12h = Math.Round(fmpEvn.ChuKy12h.GetValueOrDefault() * k.Column12h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy12h30 = Math.Round(fmpEvn.ChuKy12h30.GetValueOrDefault() * k.Column12h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy13h = Math.Round(fmpEvn.ChuKy13h.GetValueOrDefault() * k.Column13h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy13h30 = Math.Round(fmpEvn.ChuKy13h30.GetValueOrDefault() * k.Column13h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy14h = Math.Round(fmpEvn.ChuKy14h.GetValueOrDefault() * k.Column14h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy14h30 = Math.Round(fmpEvn.ChuKy14h30.GetValueOrDefault() * k.Column14h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy15h = Math.Round(fmpEvn.ChuKy15h.GetValueOrDefault() * k.Column15h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy15h30 = Math.Round(fmpEvn.ChuKy15h30.GetValueOrDefault() * k.Column15h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy16h = Math.Round(fmpEvn.ChuKy16h.GetValueOrDefault() * k.Column16h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy16h30 = Math.Round(fmpEvn.ChuKy16h30.GetValueOrDefault() * k.Column16h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy17h = Math.Round(fmpEvn.ChuKy17h.GetValueOrDefault() * k.Column17h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy17h30 = Math.Round(fmpEvn.ChuKy17h30.GetValueOrDefault() * k.Column17h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy18h = Math.Round(fmpEvn.ChuKy18h.GetValueOrDefault() * k.Column18h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy18h30 = Math.Round(fmpEvn.ChuKy18h30.GetValueOrDefault() * k.Column18h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy19h = Math.Round(fmpEvn.ChuKy19h.GetValueOrDefault() * k.Column19h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy19h30 = Math.Round(fmpEvn.ChuKy19h30.GetValueOrDefault() * k.Column19h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy20h = Math.Round(fmpEvn.ChuKy20h.GetValueOrDefault() * k.Column20h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy20h30 = Math.Round(fmpEvn.ChuKy20h30.GetValueOrDefault() * k.Column20h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy21h = Math.Round(fmpEvn.ChuKy21h.GetValueOrDefault() * k.Column21h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy21h30 = Math.Round(fmpEvn.ChuKy21h30.GetValueOrDefault() * k.Column21h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy22h = Math.Round(fmpEvn.ChuKy22h.GetValueOrDefault() * k.Column22h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy22h30 = Math.Round(fmpEvn.ChuKy22h30.GetValueOrDefault() * k.Column22h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy23h = Math.Round(fmpEvn.ChuKy23h.GetValueOrDefault() * k.Column23h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy23h30 = Math.Round(fmpEvn.ChuKy23h30.GetValueOrDefault() * k.Column23h30.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        ChuKy24h = Math.Round(fmpEvn.ChuKy24h.GetValueOrDefault() * k.Column24h.GetValueOrDefault(), 0, MidpointRounding.AwayFromZero),
                        Tong = Math.Round(new double?[]
                        {
                            fmpEvn.ChuKy0h30 * k.Column0h30, fmpEvn.ChuKy1h * k.Column1h, fmpEvn.ChuKy1h30 * k.Column1h30,
                            fmpEvn.ChuKy2h * k.Column2h, fmpEvn.ChuKy2h30 * k.Column2h30, fmpEvn.ChuKy3h * k.Column3h,
                            fmpEvn.ChuKy3h30 * k.Column3h30, fmpEvn.ChuKy4h * k.Column4h, fmpEvn.ChuKy4h30 * k.Column4h30,
                            fmpEvn.ChuKy5h * k.Column5h, fmpEvn.ChuKy5h30 * k.Column5h30, fmpEvn.ChuKy6h * k.Column6h,
                            fmpEvn.ChuKy6h30 * k.Column6h30, fmpEvn.ChuKy7h * k.Column7h, fmpEvn.ChuKy7h30 * k.Column7h30,
                            fmpEvn.ChuKy8h * k.Column8h, fmpEvn.ChuKy8h30 * k.Column8h30, fmpEvn.ChuKy9h * k.Column9h,
                            fmpEvn.ChuKy9h30 * k.Column9h30, fmpEvn.ChuKy10h * k.Column10h, fmpEvn.ChuKy10h30 * k.Column10h30,
                            fmpEvn.ChuKy11h * k.Column11h, fmpEvn.ChuKy11h30 * k.Column11h30, fmpEvn.ChuKy12h * k.Column12h,
                            fmpEvn.ChuKy12h30 * k.Column12h30, fmpEvn.ChuKy13h * k.Column13h, fmpEvn.ChuKy13h30 * k.Column13h30,
                            fmpEvn.ChuKy14h * k.Column14h, fmpEvn.ChuKy14h30 * k.Column14h30, fmpEvn.ChuKy15h * k.Column15h,
                            fmpEvn.ChuKy15h30 * k.Column15h30, fmpEvn.ChuKy16h * k.Column16h, fmpEvn.ChuKy16h30 * k.Column16h30,
                            fmpEvn.ChuKy17h * k.Column17h, fmpEvn.ChuKy17h30 * k.Column17h30, fmpEvn.ChuKy18h * k.Column18h,
                            fmpEvn.ChuKy18h30 * k.Column18h30, fmpEvn.ChuKy19h * k.Column19h, fmpEvn.ChuKy19h30 * k.Column19h30,
                            fmpEvn.ChuKy20h * k.Column20h, fmpEvn.ChuKy20h30 * k.Column20h30, fmpEvn.ChuKy21h * k.Column21h,
                            fmpEvn.ChuKy21h30 * k.Column21h30, fmpEvn.ChuKy22h * k.Column22h, fmpEvn.ChuKy22h30 * k.Column22h30,
                            fmpEvn.ChuKy23h * k.Column23h, fmpEvn.ChuKy23h30 * k.Column23h30, fmpEvn.ChuKy24h * k.Column24h
                        }.Where(x => x.HasValue).Sum().GetValueOrDefault(), 0, MidpointRounding.AwayFromZero)
                    };
                    pmEvnList.Add(pmEvn);
                }
            }

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
            var fmpEvnData = await _context.FMP_EVN.ToListAsync();
            var fmpA0Data = await _context.FMP_A0.ToListAsync();

            var fmpSaiList = new List<FmpSai>();

            foreach (var fmpEvn in fmpEvnData)
            {
                // Convert string Ngay to int for comparison
                int? fmpEvnNgay = fmpEvn.Ngay;

                // Find matching FmpA0 record
                var fmpA0 = fmpA0Data.FirstOrDefault(a =>
                    int.TryParse(a.Ngay, out int ngayValue) && ngayValue == fmpEvnNgay);

                if (fmpA0 != null)
                {
                    // Parse FmpA0 values to double for calculation
                    double TryParseDouble(string value)
                    {
                        if (double.TryParse(value, out double result))
                            return result;
                        return 0;
                    }

                    var fmpSai = new FmpSai
                    {
                        Ngay = fmpEvn.Ngay,
                        Gia = "FMP",
                        ChuKy0h30 = fmpEvn.ChuKy0h30 - TryParseDouble(fmpA0.Column0h30),
                        ChuKy1h = fmpEvn.ChuKy1h - TryParseDouble(fmpA0.Column1h),
                        ChuKy1h30 = fmpEvn.ChuKy1h30 - TryParseDouble(fmpA0.Column1h30),
                        ChuKy2h = fmpEvn.ChuKy2h - TryParseDouble(fmpA0.Column2h),
                        ChuKy2h30 = fmpEvn.ChuKy2h30 - TryParseDouble(fmpA0.Column2h30),
                        ChuKy3h = fmpEvn.ChuKy3h - TryParseDouble(fmpA0.Column3h),
                        ChuKy3h30 = fmpEvn.ChuKy3h30 - TryParseDouble(fmpA0.Column3h30),
                        ChuKy4h = fmpEvn.ChuKy4h - TryParseDouble(fmpA0.Column4h),
                        ChuKy4h30 = fmpEvn.ChuKy4h30 - TryParseDouble(fmpA0.Column4h30),
                        ChuKy5h = fmpEvn.ChuKy5h - TryParseDouble(fmpA0.Column5h),
                        ChuKy5h30 = fmpEvn.ChuKy5h30 - TryParseDouble(fmpA0.Column5h30),
                        ChuKy6h = fmpEvn.ChuKy6h - TryParseDouble(fmpA0.Column6h),
                        ChuKy6h30 = fmpEvn.ChuKy6h30 - TryParseDouble(fmpA0.Column6h30),
                        ChuKy7h = fmpEvn.ChuKy7h - TryParseDouble(fmpA0.Column7h),
                        ChuKy7h30 = fmpEvn.ChuKy7h30 - TryParseDouble(fmpA0.Column7h30),
                        ChuKy8h = fmpEvn.ChuKy8h - TryParseDouble(fmpA0.Column8h),
                        ChuKy8h30 = fmpEvn.ChuKy8h30 - TryParseDouble(fmpA0.Column8h30),
                        ChuKy9h = fmpEvn.ChuKy9h - TryParseDouble(fmpA0.Column9h),
                        ChuKy9h30 = fmpEvn.ChuKy9h30 - TryParseDouble(fmpA0.Column9h30),
                        ChuKy10h = fmpEvn.ChuKy10h - TryParseDouble(fmpA0.Column10h),
                        ChuKy10h30 = fmpEvn.ChuKy10h30 - TryParseDouble(fmpA0.Column10h30),
                        ChuKy11h = fmpEvn.ChuKy11h - TryParseDouble(fmpA0.Column11h),
                        ChuKy11h30 = fmpEvn.ChuKy11h30 - TryParseDouble(fmpA0.Column11h30),
                        ChuKy12h = fmpEvn.ChuKy12h - TryParseDouble(fmpA0.Column12h),
                        ChuKy12h30 = fmpEvn.ChuKy12h30 - TryParseDouble(fmpA0.Column12h30),
                        ChuKy13h = fmpEvn.ChuKy13h - TryParseDouble(fmpA0.Column13h),
                        ChuKy13h30 = fmpEvn.ChuKy13h30 - TryParseDouble(fmpA0.Column13h30),
                        ChuKy14h = fmpEvn.ChuKy14h - TryParseDouble(fmpA0.Column14h),
                        ChuKy14h30 = fmpEvn.ChuKy14h30 - TryParseDouble(fmpA0.Column14h30),
                        ChuKy15h = fmpEvn.ChuKy15h - TryParseDouble(fmpA0.Column15h),
                        ChuKy15h30 = fmpEvn.ChuKy15h30 - TryParseDouble(fmpA0.Column15h30),
                        ChuKy16h = fmpEvn.ChuKy16h - TryParseDouble(fmpA0.Column16h),
                        ChuKy16h30 = fmpEvn.ChuKy16h30 - TryParseDouble(fmpA0.Column16h30),
                        ChuKy17h = fmpEvn.ChuKy17h - TryParseDouble(fmpA0.Column17h),
                        ChuKy17h30 = fmpEvn.ChuKy17h30 - TryParseDouble(fmpA0.Column17h30),
                        ChuKy18h = fmpEvn.ChuKy18h - TryParseDouble(fmpA0.Column18h),
                        ChuKy18h30 = fmpEvn.ChuKy18h30 - TryParseDouble(fmpA0.Column18h30),
                        ChuKy19h = fmpEvn.ChuKy19h - TryParseDouble(fmpA0.Column19h),
                        ChuKy19h30 = fmpEvn.ChuKy19h30 - TryParseDouble(fmpA0.Column19h30),
                        ChuKy20h = fmpEvn.ChuKy20h - TryParseDouble(fmpA0.Column20h),
                        ChuKy20h30 = fmpEvn.ChuKy20h30 - TryParseDouble(fmpA0.Column20h30),
                        ChuKy21h = fmpEvn.ChuKy21h - TryParseDouble(fmpA0.Column21h),
                        ChuKy21h30 = fmpEvn.ChuKy21h30 - TryParseDouble(fmpA0.Column21h30),
                        ChuKy22h = fmpEvn.ChuKy22h - TryParseDouble(fmpA0.Column22h),
                        ChuKy22h30 = fmpEvn.ChuKy22h30 - TryParseDouble(fmpA0.Column22h30),
                        ChuKy23h = fmpEvn.ChuKy23h - TryParseDouble(fmpA0.Column23h),
                        ChuKy23h30 = fmpEvn.ChuKy23h30 - TryParseDouble(fmpA0.Column23h30),
                        ChuKy24h = fmpEvn.ChuKy24h - TryParseDouble(fmpA0.Column24h),
                        Tong = fmpEvn.Tong - TryParseDouble(fmpA0.Tong)
                    };
                    fmpSaiList.Add(fmpSai);
                }
            }

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
            // Lấy dữ liệu từ Pm_EVN và Pm_A0
            var pmEvnData = await _context.Pm_EVN.ToListAsync();
            var pmA0Data = await _context.Pm_A0.ToListAsync();

            var pmSaiList = new List<PmSai>();

            foreach (var pmEvn in pmEvnData)
            {
                // Convert string Ngay to int for comparison if needed
                int? pmEvnNgay = pmEvn.Ngay;

                // Find matching PmA0 record
                var pmA0 = pmA0Data.FirstOrDefault(a =>
                    int.TryParse(a.Ngay, out int ngayValue) &&
                    ngayValue == pmEvnNgay &&
                    a.Gia == pmEvn.Gia);

                if (pmA0 != null)
                {
                    // Parse PmA0 values to double for calculation
                    double? TryParseDouble(string value)
                    {
                        if (double.TryParse(value, out double result))
                            return result;
                        return null;
                    }

                    var pmSai = new PmSai
                    {
                        Ngay = pmEvn.Ngay,
                        Gia = pmEvn.Gia,
                        ChuKy0h30 = CalculateDifference(pmEvn.ChuKy0h30, TryParseDouble(pmA0.Column0h30)),
                        ChuKy1h = CalculateDifference(pmEvn.ChuKy1h, TryParseDouble(pmA0.Column1h)),
                        ChuKy1h30 = CalculateDifference(pmEvn.ChuKy1h30, TryParseDouble(pmA0.Column1h30)),
                        ChuKy2h = CalculateDifference(pmEvn.ChuKy2h, TryParseDouble(pmA0.Column2h)),
                        ChuKy2h30 = CalculateDifference(pmEvn.ChuKy2h30, TryParseDouble(pmA0.Column2h30)),
                        ChuKy3h = CalculateDifference(pmEvn.ChuKy3h, TryParseDouble(pmA0.Column3h)),
                        ChuKy3h30 = CalculateDifference(pmEvn.ChuKy3h30, TryParseDouble(pmA0.Column3h30)),
                        ChuKy4h = CalculateDifference(pmEvn.ChuKy4h, TryParseDouble(pmA0.Column4h)),
                        ChuKy4h30 = CalculateDifference(pmEvn.ChuKy4h30, TryParseDouble(pmA0.Column4h30)),
                        ChuKy5h = CalculateDifference(pmEvn.ChuKy5h, TryParseDouble(pmA0.Column5h)),
                        ChuKy5h30 = CalculateDifference(pmEvn.ChuKy5h30, TryParseDouble(pmA0.Column5h30)),
                        ChuKy6h = CalculateDifference(pmEvn.ChuKy6h, TryParseDouble(pmA0.Column6h)),
                        ChuKy6h30 = CalculateDifference(pmEvn.ChuKy6h30, TryParseDouble(pmA0.Column6h30)),
                        ChuKy7h = CalculateDifference(pmEvn.ChuKy7h, TryParseDouble(pmA0.Column7h)),
                        ChuKy7h30 = CalculateDifference(pmEvn.ChuKy7h30, TryParseDouble(pmA0.Column7h30)),
                        ChuKy8h = CalculateDifference(pmEvn.ChuKy8h, TryParseDouble(pmA0.Column8h)),
                        ChuKy8h30 = CalculateDifference(pmEvn.ChuKy8h30, TryParseDouble(pmA0.Column8h30)),
                        ChuKy9h = CalculateDifference(pmEvn.ChuKy9h, TryParseDouble(pmA0.Column9h)),
                        ChuKy9h30 = CalculateDifference(pmEvn.ChuKy9h30, TryParseDouble(pmA0.Column9h30)),
                        ChuKy10h = CalculateDifference(pmEvn.ChuKy10h, TryParseDouble(pmA0.Column10h)),
                        ChuKy10h30 = CalculateDifference(pmEvn.ChuKy10h30, TryParseDouble(pmA0.Column10h30)),
                        ChuKy11h = CalculateDifference(pmEvn.ChuKy11h, TryParseDouble(pmA0.Column11h)),
                        ChuKy11h30 = CalculateDifference(pmEvn.ChuKy11h30, TryParseDouble(pmA0.Column11h30)),
                        ChuKy12h = CalculateDifference(pmEvn.ChuKy12h, TryParseDouble(pmA0.Column12h)),
                        ChuKy12h30 = CalculateDifference(pmEvn.ChuKy12h30, TryParseDouble(pmA0.Column12h30)),
                        ChuKy13h = CalculateDifference(pmEvn.ChuKy13h, TryParseDouble(pmA0.Column13h)),
                        ChuKy13h30 = CalculateDifference(pmEvn.ChuKy13h30, TryParseDouble(pmA0.Column13h30)),
                        ChuKy14h = CalculateDifference(pmEvn.ChuKy14h, TryParseDouble(pmA0.Column14h)),
                        ChuKy14h30 = CalculateDifference(pmEvn.ChuKy14h30, TryParseDouble(pmA0.Column14h30)),
                        ChuKy15h = CalculateDifference(pmEvn.ChuKy15h, TryParseDouble(pmA0.Column15h)),
                        ChuKy15h30 = CalculateDifference(pmEvn.ChuKy15h30, TryParseDouble(pmA0.Column15h30)),
                        ChuKy16h = CalculateDifference(pmEvn.ChuKy16h, TryParseDouble(pmA0.Column16h)),
                        ChuKy16h30 = CalculateDifference(pmEvn.ChuKy16h30, TryParseDouble(pmA0.Column16h30)),
                        ChuKy17h = CalculateDifference(pmEvn.ChuKy17h, TryParseDouble(pmA0.Column17h)),
                        ChuKy17h30 = CalculateDifference(pmEvn.ChuKy17h30, TryParseDouble(pmA0.Column17h30)),
                        ChuKy18h = CalculateDifference(pmEvn.ChuKy18h, TryParseDouble(pmA0.Column18h)),
                        ChuKy18h30 = CalculateDifference(pmEvn.ChuKy18h30, TryParseDouble(pmA0.Column18h30)),
                        ChuKy19h = CalculateDifference(pmEvn.ChuKy19h, TryParseDouble(pmA0.Column19h)),
                        ChuKy19h30 = CalculateDifference(pmEvn.ChuKy19h30, TryParseDouble(pmA0.Column19h30)),
                        ChuKy20h = CalculateDifference(pmEvn.ChuKy20h, TryParseDouble(pmA0.Column20h)),
                        ChuKy20h30 = CalculateDifference(pmEvn.ChuKy20h30, TryParseDouble(pmA0.Column20h30)),
                        ChuKy21h = CalculateDifference(pmEvn.ChuKy21h, TryParseDouble(pmA0.Column21h)),
                        ChuKy21h30 = CalculateDifference(pmEvn.ChuKy21h30, TryParseDouble(pmA0.Column21h30)),
                        ChuKy22h = CalculateDifference(pmEvn.ChuKy22h, TryParseDouble(pmA0.Column22h)),
                        ChuKy22h30 = CalculateDifference(pmEvn.ChuKy22h30, TryParseDouble(pmA0.Column22h30)),
                        ChuKy23h = CalculateDifference(pmEvn.ChuKy23h, TryParseDouble(pmA0.Column23h)),
                        ChuKy23h30 = CalculateDifference(pmEvn.ChuKy23h30, TryParseDouble(pmA0.Column23h30)),
                        ChuKy24h = CalculateDifference(pmEvn.ChuKy24h, TryParseDouble(pmA0.Column24h)),
                    };

                    // Tính tổng của 48 chu kỳ
                    pmSai.Tong = new double?[]
                    {
                pmSai.ChuKy0h30, pmSai.ChuKy1h, pmSai.ChuKy1h30, pmSai.ChuKy2h, pmSai.ChuKy2h30,
                pmSai.ChuKy3h, pmSai.ChuKy3h30, pmSai.ChuKy4h, pmSai.ChuKy4h30, pmSai.ChuKy5h,
                pmSai.ChuKy5h30, pmSai.ChuKy6h, pmSai.ChuKy6h30, pmSai.ChuKy7h, pmSai.ChuKy7h30,
                pmSai.ChuKy8h, pmSai.ChuKy8h30, pmSai.ChuKy9h, pmSai.ChuKy9h30, pmSai.ChuKy10h,
                pmSai.ChuKy10h30, pmSai.ChuKy11h, pmSai.ChuKy11h30, pmSai.ChuKy12h, pmSai.ChuKy12h30,
                pmSai.ChuKy13h, pmSai.ChuKy13h30, pmSai.ChuKy14h, pmSai.ChuKy14h30, pmSai.ChuKy15h,
                pmSai.ChuKy15h30, pmSai.ChuKy16h, pmSai.ChuKy16h30, pmSai.ChuKy17h, pmSai.ChuKy17h30,
                pmSai.ChuKy18h, pmSai.ChuKy18h30, pmSai.ChuKy19h, pmSai.ChuKy19h30, pmSai.ChuKy20h,
                pmSai.ChuKy20h30, pmSai.ChuKy21h, pmSai.ChuKy21h30, pmSai.ChuKy22h, pmSai.ChuKy22h30,
                pmSai.ChuKy23h, pmSai.ChuKy23h30, pmSai.ChuKy24h
                    }.Where(x => x.HasValue).Sum().GetValueOrDefault();

                    pmSaiList.Add(pmSai);
                }
            }

            // Xóa dữ liệu cũ trong Pm_Sai và lưu dữ liệu mới
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