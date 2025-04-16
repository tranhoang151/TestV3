using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestV3.Models;
using TestV3.Data;
using TestV3.Models.PmQL;
using TestV3.Services;

namespace TestV3.Services
{
    public class CfdCalculationService : ICfdCalculationService
    {
        private readonly ApplicationDbContext _appContext;
        private readonly TestV3_v2_Context _testContext;

        public CfdCalculationService(ApplicationDbContext appContext, TestV3_v2_Context testContext)
        {
            _appContext = appContext;
            _testContext = testContext;
        }

        // PM1 Methods
        public async Task<List<CfdPm1>> GetCfdPm1DataAsync()
        {
            return await _testContext.CfdPm1s.OrderBy(c => c.Ngay).ToListAsync();
        }
        public async Task<List<CfdPm1Pc>> GetCfdPm1PcDataAsync()
        {
            return await _testContext.CfdPm1Pcs.OrderBy(c => c.Ngày).ToListAsync();
        }
        public async Task<List<CfdPm1Qc>> GetCfdPm1QcDataAsync()
        {
            return await _testContext.CfdPm1Qcs.OrderBy(c => c.Ngày).ToListAsync();
        }

        // PM4 Methods
        public async Task<List<CfdPm4>> GetCfdPm4DataAsync()
        {
            return await _testContext.CfdPm4s.OrderBy(c => c.Ngay).ToListAsync();
        }
        public async Task<List<CfdPm4Pc>> GetCfdPm4PcDataAsync()
        {
            return await _testContext.CfdPm4Pcs.OrderBy(c => c.Ngày).ToListAsync();
        }
        public async Task<List<CfdPm4Qc>> GetCfdPm4QcDataAsync()
        {
            return await _testContext.CfdPm4Qcs.OrderBy(c => c.Ngày).ToListAsync();
        }

        // FMP_EVN Method
        public async Task<List<FmpEvn>> GetFmpEvnDataAsync()
        {
            return await _appContext.FMP_EVN.OrderBy(f => f.Ngay).ToListAsync();
        }

        // TB1 Methods
        public async Task<List<CfdTb1>> GetCfdTb1DataAsync()
        {
            return await _testContext.CfdTb1s.OrderBy(c => c.Ngay).ToListAsync();
        }
        public async Task<List<CfdTb1Pc>> GetCfdTb1PcDataAsync()
        {
            return await _testContext.CfdTb1Pcs.OrderBy(c => c.Ngày).ToListAsync();
        }
        public async Task<List<CfdTb1Qc>> GetCfdTb1QcDataAsync()
        {
            return await _testContext.CfdTb1Qcs.OrderBy(c => c.Ngày).ToListAsync();
        }
        
        // DH3MR Methods
        public async Task<List<CfdDh3mr>> GetCfdDh3mrDataAsync()
        {
            return await _testContext.CfdDh3mrs.OrderBy(c => c.Ngay).ToListAsync();
        }
        public async Task<List<CfdDh3mrPc>> GetCfdDh3mrPcDataAsync()
        {
            return await _testContext.CfdDh3mrPcs.OrderBy(c => c.Ngày).ToListAsync();
        }
        public async Task<List<CfdDh3mrQc>> GetCfdDh3mrQcDataAsync()
        {
            return await _testContext.CfdDh3mrQcs.OrderBy(c => c.Ngày).ToListAsync();
        }

        // VT4n4MR Methods
        public async Task<List<CfdVt4n4Mr>> GetCfdVt4n4MrDataAsync()
        {
            return await _testContext.CfdVt4n4Mrs.OrderBy(c => c.Ngay).ToListAsync();
        }
        public async Task<List<CfdVt4n4MrPc>> GetCfdVt4n4MrPcDataAsync()
        {
            return await _testContext.CfdVt4n4MrPcs.OrderBy(c => c.Ngày).ToListAsync();
        }
        public async Task<List<CfdVt4n4MrQc>> GetCfdVt4n4MrQcDataAsync()
        {
            return await _testContext.CfdVt4n4MrQcs.OrderBy(c => c.Ngày).ToListAsync();
        }

        public async Task CalculateAndSaveCfdPm1Async()
        {
            // Get all unique dates from Pc and Qc tables
            var pcDates = await _testContext.CfdPm1Pcs.Select(p => p.Ngày).Distinct().ToListAsync();
            var qcDates = await _testContext.CfdPm1Qcs.Select(q => q.Ngày).Distinct().ToListAsync();
            var fmpDates = await _appContext.FMP_EVN.Select(f => f.Ngay).Distinct().ToListAsync();

            // Find dates that exist in all three tables
            var commonDates = pcDates.Intersect(qcDates).ToList();
            var allDates = commonDates.Where(d => fmpDates.Contains(d))
                .Where(d => d.HasValue).OrderBy(d => d).ToList();

            // Remove existing data
            _testContext.CfdPm1s.RemoveRange(_testContext.CfdPm1s);
            await _testContext.SaveChangesAsync();

            // Prepare data for bulk processing
            var pcDataDict = await _testContext.CfdPm1Pcs
                .Where(p => allDates.Contains(p.Ngày))
                .ToDictionaryAsync(p => p.Ngày, p => p);

            var qcDataDict = await _testContext.CfdPm1Qcs
                .Where(q => allDates.Contains(q.Ngày))
                .ToDictionaryAsync(q => q.Ngày, q => q);

            var fmpDataDict = await _appContext.FMP_EVN
                .Where(f => allDates.Contains(f.Ngay))
                .ToDictionaryAsync(f => f.Ngay, f => f);

            // Create a list to hold all new CfdPm1 entities
            var newCfdEntities = new List<CfdPm1>();

            foreach (var date in allDates)
            {
                if (pcDataDict.TryGetValue(date, out var pcData) &&
                    qcDataDict.TryGetValue(date, out var qcData) &&
                    fmpDataDict.TryGetValue(date, out var fmpData))
                {
                    // Create a new entity with direct property mapping
                    var cfdPm1 = new CfdPm1
                    {
                        Ngay = date,
                        // Direct property mapping instead of reflection
                        ChuKy0h30 = CalculateCfd(qcData.Column0h30, pcData.Column0h30, (decimal?)fmpData.ChuKy0h30),
                        ChuKy1h = CalculateCfd(qcData.Column1h, pcData.Column1h, (decimal?)fmpData.ChuKy1h),
                        ChuKy1h30 = CalculateCfd(qcData.Column1h30, pcData.Column1h30, (decimal?)fmpData.ChuKy1h30),
                        ChuKy2h = CalculateCfd(qcData.Column2h, pcData.Column2h, (decimal?)fmpData.ChuKy2h),
                        ChuKy2h30 = CalculateCfd(qcData.Column2h30, pcData.Column2h30, (decimal?)fmpData.ChuKy2h30),
                        ChuKy3h = CalculateCfd(qcData.Column3h, pcData.Column3h, (decimal?)fmpData.ChuKy3h),
                        ChuKy3h30 = CalculateCfd(qcData.Column3h30, pcData.Column3h30, (decimal?)fmpData.ChuKy3h30),
                        ChuKy4h = CalculateCfd(qcData.Column4h, pcData.Column4h, (decimal?)fmpData.ChuKy4h),
                        ChuKy4h30 = CalculateCfd(qcData.Column4h30, pcData.Column4h30, (decimal?)fmpData.ChuKy4h30),
                        ChuKy5h = CalculateCfd(qcData.Column5h, pcData.Column5h, (decimal?)fmpData.ChuKy5h),
                        ChuKy5h30 = CalculateCfd(qcData.Column5h30, pcData.Column5h30, (decimal?)fmpData.ChuKy5h30),
                        ChuKy6h = CalculateCfd(qcData.Column6h, pcData.Column6h, (decimal?)fmpData.ChuKy6h),
                        ChuKy6h30 = CalculateCfd(qcData.Column6h30, pcData.Column6h30, (decimal?)fmpData.ChuKy6h30),
                        ChuKy7h = CalculateCfd(qcData.Column7h, pcData.Column7h, (decimal?)fmpData.ChuKy7h),
                        ChuKy7h30 = CalculateCfd(qcData.Column7h30, pcData.Column7h30, (decimal?)fmpData.ChuKy7h30),
                        ChuKy8h = CalculateCfd(qcData.Column8h, pcData.Column8h, (decimal?)fmpData.ChuKy8h),
                        ChuKy8h30 = CalculateCfd(qcData.Column8h30, pcData.Column8h30, (decimal?)fmpData.ChuKy8h30),
                        ChuKy9h = CalculateCfd(qcData.Column9h, pcData.Column9h, (decimal?)fmpData.ChuKy9h),
                        ChuKy9h30 = CalculateCfd(qcData.Column9h30, pcData.Column9h30, (decimal?)fmpData.ChuKy9h30),
                        ChuKy10h = CalculateCfd(qcData.Column10h, pcData.Column10h, (decimal?)fmpData.ChuKy10h),
                        ChuKy10h30 = CalculateCfd(qcData.Column10h30, pcData.Column10h30, (decimal?)fmpData.ChuKy10h30),
                        ChuKy11h = CalculateCfd(qcData.Column11h, pcData.Column11h, (decimal?)fmpData.ChuKy11h),
                        ChuKy11h30 = CalculateCfd(qcData.Column11h30, pcData.Column11h30, (decimal?)fmpData.ChuKy11h30),
                        ChuKy12h = CalculateCfd(qcData.Column12h, pcData.Column12h, (decimal?)fmpData.ChuKy12h),
                        ChuKy12h30 = CalculateCfd(qcData.Column12h30, pcData.Column12h30, (decimal?)fmpData.ChuKy12h30),
                        ChuKy13h = CalculateCfd(qcData.Column13h, pcData.Column13h, (decimal?)fmpData.ChuKy13h),
                        ChuKy13h30 = CalculateCfd(qcData.Column13h30, pcData.Column13h30, (decimal?)fmpData.ChuKy13h30),
                        ChuKy14h = CalculateCfd(qcData.Column14h, pcData.Column14h, (decimal?)fmpData.ChuKy14h),
                        ChuKy14h30 = CalculateCfd(qcData.Column14h30, pcData.Column14h30, (decimal?)fmpData.ChuKy14h30),
                        ChuKy15h = CalculateCfd(qcData.Column15h, pcData.Column15h, (decimal?)fmpData.ChuKy15h),
                        ChuKy15h30 = CalculateCfd(qcData.Column15h30, pcData.Column15h30, (decimal?)fmpData.ChuKy15h30),
                        ChuKy16h = CalculateCfd(qcData.Column16h, pcData.Column16h, (decimal?)fmpData.ChuKy16h),
                        ChuKy16h30 = CalculateCfd(qcData.Column16h30, pcData.Column16h30, (decimal?)fmpData.ChuKy16h30),
                        ChuKy17h = CalculateCfd(qcData.Column17h, pcData.Column17h, (decimal?)fmpData.ChuKy17h),
                        ChuKy17h30 = CalculateCfd(qcData.Column17h30, pcData.Column17h30, (decimal?)fmpData.ChuKy17h30),
                        ChuKy18h = CalculateCfd(qcData.Column18h, pcData.Column18h, (decimal?)fmpData.ChuKy18h),
                        ChuKy18h30 = CalculateCfd(qcData.Column18h30, pcData.Column18h30, (decimal?)fmpData.ChuKy18h30),
                        ChuKy19h = CalculateCfd(qcData.Column19h, pcData.Column19h, (decimal?)fmpData.ChuKy19h),
                        ChuKy19h30 = CalculateCfd(qcData.Column19h30, pcData.Column19h30, (decimal?)fmpData.ChuKy19h30),
                        ChuKy20h = CalculateCfd(qcData.Column20h, pcData.Column20h, (decimal?)fmpData.ChuKy20h),
                        ChuKy20h30 = CalculateCfd(qcData.Column20h30, pcData.Column20h30, (decimal?)fmpData.ChuKy20h30),
                        ChuKy21h = CalculateCfd(qcData.Column21h, pcData.Column21h, (decimal?)fmpData.ChuKy21h),
                        ChuKy21h30 = CalculateCfd(qcData.Column21h30, pcData.Column21h30, (decimal?)fmpData.ChuKy21h30),
                        ChuKy22h = CalculateCfd(qcData.Column22h, pcData.Column22h, (decimal?)fmpData.ChuKy22h),
                        ChuKy22h30 = CalculateCfd(qcData.Column22h30, pcData.Column22h30, (decimal?)fmpData.ChuKy22h30),
                        ChuKy23h = CalculateCfd(qcData.Column23h, pcData.Column23h, (decimal?)fmpData.ChuKy23h),
                        ChuKy23h30 = CalculateCfd(qcData.Column23h30, pcData.Column23h30, (decimal?)fmpData.ChuKy23h30),
                        ChuKy24h = CalculateCfd(qcData.Column24h, pcData.Column24h, (decimal?)fmpData.ChuKy24h)
                    };

                    // Calculate total
                    cfdPm1.Tong = CalculateTotal(cfdPm1);

                    newCfdEntities.Add(cfdPm1);
                }
            }

            // Add all entities at once
            if (newCfdEntities.Any())
            {
                await _testContext.CfdPm1s.AddRangeAsync(newCfdEntities);
                await _testContext.SaveChangesAsync();
                Console.WriteLine($"Added {newCfdEntities.Count} CFD PM1 records");
            }
            else
            {
                Console.WriteLine("No CFD PM1 records to add");
            }
        }


        private double? CalculateCfd(decimal? quantity, decimal? contractPrice, decimal? fmpPrice)
        {
            if (quantity.HasValue && contractPrice.HasValue && fmpPrice.HasValue)
            {
                try
                {
                    // Apply the formula: Cfd_PM4 = Cfd_PM4_Qc * (Cfd_PM4_Pc - FMP_EVN) / 1000
                    var result = (double)(quantity.Value * (contractPrice.Value - fmpPrice.Value) / 1000);

                    // Take absolute value to ensure it's always positive
                    //result = Math.Abs(result);

                    // Round to 2 decimal places
                    result = Math.Round(result, 6);

                    return Math.Round(result, 2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in calculation: {ex.Message}");
                    return null;
                }
            }
            return null;
        }

        private double? CalculateTotal<T>(T data) where T : class
        {
            decimal total = 0m;
            var properties = typeof(T).GetProperties()
                .Where(p => p.Name.StartsWith("ChuKy") && p.Name != "Tong");

            foreach (var prop in properties)
            {
                var value = prop.GetValue(data) as double?;
                if (value.HasValue)
                {
                    total += (decimal)value.Value;
                }
            }

            // Sử dụng MidpointRounding.ToEven (làm tròn ngân hàng)
            return (double?)total; //(double)Math.Round(total, 2, MidpointRounding.ToEven);
        }

        public async Task<Dictionary<string, object>> GetSummaryDataAsync()
        {
            var summary = new Dictionary<string, object>();

            // Get total CFD values
            summary["TotalCfdValue"] = await _testContext.CfdPm1s.SumAsync(c => c.Tong) ?? 0;

            // Get average contract price
            summary["AverageContractPrice"] = await _testContext.CfdPm1Pcs
                .Where(p => p.Tổng.HasValue && p.Tổng > 0)
                .AverageAsync(p => p.Tổng) ?? 0;

            // Get average FMP price
            summary["AverageFmpPrice"] = await _appContext.FMP_EVN
                .Where(f => f.Tong.HasValue && f.Tong > 0)
                .AverageAsync(f => f.Tong) ?? 0;

            // Get total quantity
            summary["TotalQuantity"] = await _testContext.CfdPm1Qcs.SumAsync(q => q.Tổng) ?? 0;

            // Get date range
            summary["StartDate"] = await _testContext.CfdPm1s.MinAsync(c => c.Ngay);
            summary["EndDate"] = await _testContext.CfdPm1s.MaxAsync(c => c.Ngay);

            return summary;
        }

        public async Task CalculateAndSaveCfdPm4Async()
        {
            // Get all unique dates from Pc and Qc tables
            var pcDates = await _testContext.CfdPm4Pcs.Select(p => p.Ngày).Distinct().ToListAsync();
            var qcDates = await _testContext.CfdPm4Qcs.Select(q => q.Ngày).Distinct().ToListAsync();
            var fmpDates = await _appContext.FMP_EVN.Select(f => f.Ngay).Distinct().ToListAsync();

            // Find dates that exist in all three tables
            var commonDates = pcDates.Intersect(qcDates).ToList();
            var allDates = commonDates.Where(d => fmpDates.Contains(d))
                .Where(d => d.HasValue).OrderBy(d => d).ToList();

            // Remove existing data
            _testContext.CfdPm4s.RemoveRange(_testContext.CfdPm4s);
            await _testContext.SaveChangesAsync();

            foreach (var date in allDates)
            {
                var pcData = await _testContext.CfdPm4Pcs.FirstOrDefaultAsync(p => p.Ngày == date);
                var qcData = await _testContext.CfdPm4Qcs.FirstOrDefaultAsync(q => q.Ngày == date);
                var fmpData = await _appContext.FMP_EVN.FirstOrDefaultAsync(f => f.Ngay == date);

                if (pcData != null && qcData != null && fmpData != null)
                {
                    var cfdPm4 = new CfdPm4
                    {
                        Ngay = date,
                        // Apply the formula: Cfd_PM4 = Cfd_PM4_Qc * (Cfd_PM4_Pc - FMP_EVN) / 1000
                        ChuKy0h30 = CalculateCfd(qcData.Column0h30, pcData.Column0h30, (decimal?)fmpData.ChuKy0h30),
                        ChuKy1h = CalculateCfd(qcData.Column1h, pcData.Column1h, (decimal?)fmpData.ChuKy1h),
                        ChuKy1h30 = CalculateCfd(qcData.Column1h30, pcData.Column1h30, (decimal?)fmpData.ChuKy1h30),
                        ChuKy2h = CalculateCfd(qcData.Column2h, pcData.Column2h, (decimal?)fmpData.ChuKy2h),
                        ChuKy2h30 = CalculateCfd(qcData.Column2h30, pcData.Column2h30, (decimal?)fmpData.ChuKy2h30),
                        ChuKy3h = CalculateCfd(qcData.Column3h, pcData.Column3h, (decimal?)fmpData.ChuKy3h),
                        ChuKy3h30 = CalculateCfd(qcData.Column3h30, pcData.Column3h30, (decimal?)fmpData.ChuKy3h30),
                        ChuKy4h = CalculateCfd(qcData.Column4h, pcData.Column4h, (decimal?)fmpData.ChuKy4h),
                        ChuKy4h30 = CalculateCfd(qcData.Column4h30, pcData.Column4h30, (decimal?)fmpData.ChuKy4h30),
                        ChuKy5h = CalculateCfd(qcData.Column5h, pcData.Column5h, (decimal?)fmpData.ChuKy5h),
                        ChuKy5h30 = CalculateCfd(qcData.Column5h30, pcData.Column5h30, (decimal?)fmpData.ChuKy5h30),
                        ChuKy6h = CalculateCfd(qcData.Column6h, pcData.Column6h, (decimal?)fmpData.ChuKy6h),
                        ChuKy6h30 = CalculateCfd(qcData.Column6h30, pcData.Column6h30, (decimal?)fmpData.ChuKy6h30),
                        ChuKy7h = CalculateCfd(qcData.Column7h, pcData.Column7h, (decimal?)fmpData.ChuKy7h),
                        ChuKy7h30 = CalculateCfd(qcData.Column7h30, pcData.Column7h30, (decimal?)fmpData.ChuKy7h30),
                        ChuKy8h = CalculateCfd(qcData.Column8h, pcData.Column8h, (decimal?)fmpData.ChuKy8h),
                        ChuKy8h30 = CalculateCfd(qcData.Column8h30, pcData.Column8h30, (decimal?)fmpData.ChuKy8h30),
                        ChuKy9h = CalculateCfd(qcData.Column9h, pcData.Column9h, (decimal?)fmpData.ChuKy9h),
                        ChuKy9h30 = CalculateCfd(qcData.Column9h30, pcData.Column9h30, (decimal?)fmpData.ChuKy9h30),
                        ChuKy10h = CalculateCfd(qcData.Column10h, pcData.Column10h, (decimal?)fmpData.ChuKy10h),
                        ChuKy10h30 = CalculateCfd(qcData.Column10h30, pcData.Column10h30, (decimal?)fmpData.ChuKy10h30),
                        ChuKy11h = CalculateCfd(qcData.Column11h, pcData.Column11h, (decimal?)fmpData.ChuKy11h),
                        ChuKy11h30 = CalculateCfd(qcData.Column11h30, pcData.Column11h30, (decimal?)fmpData.ChuKy11h30),
                        ChuKy12h = CalculateCfd(qcData.Column12h, pcData.Column12h, (decimal?)fmpData.ChuKy12h),
                        ChuKy12h30 = CalculateCfd(qcData.Column12h30, pcData.Column12h30, (decimal?)fmpData.ChuKy12h30),
                        ChuKy13h = CalculateCfd(qcData.Column13h, pcData.Column13h, (decimal?)fmpData.ChuKy13h),
                        ChuKy13h30 = CalculateCfd(qcData.Column13h30, pcData.Column13h30, (decimal?)fmpData.ChuKy13h30),
                        ChuKy14h = CalculateCfd(qcData.Column14h, pcData.Column14h, (decimal?)fmpData.ChuKy14h),
                        ChuKy14h30 = CalculateCfd(qcData.Column14h30, pcData.Column14h30, (decimal?)fmpData.ChuKy14h30),
                        ChuKy15h = CalculateCfd(qcData.Column15h, pcData.Column15h, (decimal?)fmpData.ChuKy15h),
                        ChuKy15h30 = CalculateCfd(qcData.Column15h30, pcData.Column15h30, (decimal?)fmpData.ChuKy15h30),
                        ChuKy16h = CalculateCfd(qcData.Column16h, pcData.Column16h, (decimal?)fmpData.ChuKy16h),
                        ChuKy16h30 = CalculateCfd(qcData.Column16h30, pcData.Column16h30, (decimal?)fmpData.ChuKy16h30),
                        ChuKy17h = CalculateCfd(qcData.Column17h, pcData.Column17h, (decimal?)fmpData.ChuKy17h),
                        ChuKy17h30 = CalculateCfd(qcData.Column17h30, pcData.Column17h30, (decimal?)fmpData.ChuKy17h30),
                        ChuKy18h = CalculateCfd(qcData.Column18h, pcData.Column18h, (decimal?)fmpData.ChuKy18h),
                        ChuKy18h30 = CalculateCfd(qcData.Column18h30, pcData.Column18h30, (decimal?)fmpData.ChuKy18h30),
                        ChuKy19h = CalculateCfd(qcData.Column19h, pcData.Column19h, (decimal?)fmpData.ChuKy19h),
                        ChuKy19h30 = CalculateCfd(qcData.Column19h30, pcData.Column19h30, (decimal?)fmpData.ChuKy19h30),
                        ChuKy20h = CalculateCfd(qcData.Column20h, pcData.Column20h, (decimal?)fmpData.ChuKy20h),
                        ChuKy20h30 = CalculateCfd(qcData.Column20h30, pcData.Column20h30, (decimal?)fmpData.ChuKy20h30),
                        ChuKy21h = CalculateCfd(qcData.Column21h, pcData.Column21h, (decimal?)fmpData.ChuKy21h),
                        ChuKy21h30 = CalculateCfd(qcData.Column21h30, pcData.Column21h30, (decimal?)fmpData.ChuKy21h30),
                        ChuKy22h = CalculateCfd(qcData.Column22h, pcData.Column22h, (decimal?)fmpData.ChuKy22h),
                        ChuKy22h30 = CalculateCfd(qcData.Column22h30, pcData.Column22h30, (decimal?)fmpData.ChuKy22h30),
                        ChuKy23h = CalculateCfd(qcData.Column23h, pcData.Column23h, (decimal?)fmpData.ChuKy23h),
                        ChuKy23h30 = CalculateCfd(qcData.Column23h30, pcData.Column23h30, (decimal?)fmpData.ChuKy23h30),
                        ChuKy24h = CalculateCfd(qcData.Column24h, pcData.Column24h, (decimal?)fmpData.ChuKy24h)
                    };

                    // Calculate total
                    cfdPm4.Tong = CalculateTotal(cfdPm4);

                    _testContext.CfdPm4s.Add(cfdPm4);
                }
            }

            await _testContext.SaveChangesAsync();
        }

        public async Task CalculateAndSaveCfdTb1Async()
        {
            // Get all unique dates from Pc and Qc tables
            var pcDates = await _testContext.CfdTb1Pcs.Select(p => p.Ngày).Distinct().ToListAsync();
            var qcDates = await _testContext.CfdTb1Qcs.Select(q => q.Ngày).Distinct().ToListAsync();
            var fmpDates = await _appContext.FMP_EVN.Select(f => f.Ngay).Distinct().ToListAsync();

            // Find dates that exist in all three tables
            var commonDates = pcDates.Intersect(qcDates).ToList();
            var allDates = commonDates.Where(d => fmpDates.Contains(d))
                .Where(d => d.HasValue).OrderBy(d => d).ToList();

            // Remove existing data
            _testContext.CfdPm4s.RemoveRange(_testContext.CfdPm4s);
            await _testContext.SaveChangesAsync();

            foreach (var date in allDates)
            {
                var pcData = await _testContext.CfdTb1Pcs.FirstOrDefaultAsync(p => p.Ngày == date);
                var qcData = await _testContext.CfdTb1Qcs.FirstOrDefaultAsync(q => q.Ngày == date);
                var fmpData = await _appContext.FMP_EVN.FirstOrDefaultAsync(f => f.Ngay == date);

                if (pcData != null && qcData != null && fmpData != null)
                {
                    var cfdTb1 = new CfdTb1
                    {
                        Ngay = date,
                        // Apply the formula: Cfd_PM4 = Cfd_PM4_Qc * (Cfd_PM4_Pc - FMP_EVN) / 1000
                        ChuKy0h30 = CalculateCfd(qcData.Column0h30, pcData.Column0h30, (decimal?)fmpData.ChuKy0h30),
                        ChuKy1h = CalculateCfd(qcData.Column1h, pcData.Column1h, (decimal?)fmpData.ChuKy1h),
                        ChuKy1h30 = CalculateCfd(qcData.Column1h30, pcData.Column1h30, (decimal?)fmpData.ChuKy1h30),
                        ChuKy2h = CalculateCfd(qcData.Column2h, pcData.Column2h, (decimal?)fmpData.ChuKy2h),
                        ChuKy2h30 = CalculateCfd(qcData.Column2h30, pcData.Column2h30, (decimal?)fmpData.ChuKy2h30),
                        ChuKy3h = CalculateCfd(qcData.Column3h, pcData.Column3h, (decimal?)fmpData.ChuKy3h),
                        ChuKy3h30 = CalculateCfd(qcData.Column3h30, pcData.Column3h30, (decimal?)fmpData.ChuKy3h30),
                        ChuKy4h = CalculateCfd(qcData.Column4h, pcData.Column4h, (decimal?)fmpData.ChuKy4h),
                        ChuKy4h30 = CalculateCfd(qcData.Column4h30, pcData.Column4h30, (decimal?)fmpData.ChuKy4h30),
                        ChuKy5h = CalculateCfd(qcData.Column5h, pcData.Column5h, (decimal?)fmpData.ChuKy5h),
                        ChuKy5h30 = CalculateCfd(qcData.Column5h30, pcData.Column5h30, (decimal?)fmpData.ChuKy5h30),
                        ChuKy6h = CalculateCfd(qcData.Column6h, pcData.Column6h, (decimal?)fmpData.ChuKy6h),
                        ChuKy6h30 = CalculateCfd(qcData.Column6h30, pcData.Column6h30, (decimal?)fmpData.ChuKy6h30),
                        ChuKy7h = CalculateCfd(qcData.Column7h, pcData.Column7h, (decimal?)fmpData.ChuKy7h),
                        ChuKy7h30 = CalculateCfd(qcData.Column7h30, pcData.Column7h30, (decimal?)fmpData.ChuKy7h30),
                        ChuKy8h = CalculateCfd(qcData.Column8h, pcData.Column8h, (decimal?)fmpData.ChuKy8h),
                        ChuKy8h30 = CalculateCfd(qcData.Column8h30, pcData.Column8h30, (decimal?)fmpData.ChuKy8h30),
                        ChuKy9h = CalculateCfd(qcData.Column9h, pcData.Column9h, (decimal?)fmpData.ChuKy9h),
                        ChuKy9h30 = CalculateCfd(qcData.Column9h30, pcData.Column9h30, (decimal?)fmpData.ChuKy9h30),
                        ChuKy10h = CalculateCfd(qcData.Column10h, pcData.Column10h, (decimal?)fmpData.ChuKy10h),
                        ChuKy10h30 = CalculateCfd(qcData.Column10h30, pcData.Column10h30, (decimal?)fmpData.ChuKy10h30),
                        ChuKy11h = CalculateCfd(qcData.Column11h, pcData.Column11h, (decimal?)fmpData.ChuKy11h),
                        ChuKy11h30 = CalculateCfd(qcData.Column11h30, pcData.Column11h30, (decimal?)fmpData.ChuKy11h30),
                        ChuKy12h = CalculateCfd(qcData.Column12h, pcData.Column12h, (decimal?)fmpData.ChuKy12h),
                        ChuKy12h30 = CalculateCfd(qcData.Column12h30, pcData.Column12h30, (decimal?)fmpData.ChuKy12h30),
                        ChuKy13h = CalculateCfd(qcData.Column13h, pcData.Column13h, (decimal?)fmpData.ChuKy13h),
                        ChuKy13h30 = CalculateCfd(qcData.Column13h30, pcData.Column13h30, (decimal?)fmpData.ChuKy13h30),
                        ChuKy14h = CalculateCfd(qcData.Column14h, pcData.Column14h, (decimal?)fmpData.ChuKy14h),
                        ChuKy14h30 = CalculateCfd(qcData.Column14h30, pcData.Column14h30, (decimal?)fmpData.ChuKy14h30),
                        ChuKy15h = CalculateCfd(qcData.Column15h, pcData.Column15h, (decimal?)fmpData.ChuKy15h),
                        ChuKy15h30 = CalculateCfd(qcData.Column15h30, pcData.Column15h30, (decimal?)fmpData.ChuKy15h30),
                        ChuKy16h = CalculateCfd(qcData.Column16h, pcData.Column16h, (decimal?)fmpData.ChuKy16h),
                        ChuKy16h30 = CalculateCfd(qcData.Column16h30, pcData.Column16h30, (decimal?)fmpData.ChuKy16h30),
                        ChuKy17h = CalculateCfd(qcData.Column17h, pcData.Column17h, (decimal?)fmpData.ChuKy17h),
                        ChuKy17h30 = CalculateCfd(qcData.Column17h30, pcData.Column17h30, (decimal?)fmpData.ChuKy17h30),
                        ChuKy18h = CalculateCfd(qcData.Column18h, pcData.Column18h, (decimal?)fmpData.ChuKy18h),
                        ChuKy18h30 = CalculateCfd(qcData.Column18h30, pcData.Column18h30, (decimal?)fmpData.ChuKy18h30),
                        ChuKy19h = CalculateCfd(qcData.Column19h, pcData.Column19h, (decimal?)fmpData.ChuKy19h),
                        ChuKy19h30 = CalculateCfd(qcData.Column19h30, pcData.Column19h30, (decimal?)fmpData.ChuKy19h30),
                        ChuKy20h = CalculateCfd(qcData.Column20h, pcData.Column20h, (decimal?)fmpData.ChuKy20h),
                        ChuKy20h30 = CalculateCfd(qcData.Column20h30, pcData.Column20h30, (decimal?)fmpData.ChuKy20h30),
                        ChuKy21h = CalculateCfd(qcData.Column21h, pcData.Column21h, (decimal?)fmpData.ChuKy21h),
                        ChuKy21h30 = CalculateCfd(qcData.Column21h30, pcData.Column21h30, (decimal?)fmpData.ChuKy21h30),
                        ChuKy22h = CalculateCfd(qcData.Column22h, pcData.Column22h, (decimal?)fmpData.ChuKy22h),
                        ChuKy22h30 = CalculateCfd(qcData.Column22h30, pcData.Column22h30, (decimal?)fmpData.ChuKy22h30),
                        ChuKy23h = CalculateCfd(qcData.Column23h, pcData.Column23h, (decimal?)fmpData.ChuKy23h),
                        ChuKy23h30 = CalculateCfd(qcData.Column23h30, pcData.Column23h30, (decimal?)fmpData.ChuKy23h30),
                        ChuKy24h = CalculateCfd(qcData.Column24h, pcData.Column24h, (decimal?)fmpData.ChuKy24h)
                    };

                    // Calculate total
                    cfdTb1.Tong = CalculateTotal(cfdTb1);

                    _testContext.CfdTb1s.Add(cfdTb1);
                }
            }

            await _testContext.SaveChangesAsync();
        }

        public async Task CalculateAndSaveCfdDh3mrAsync()
        {
            // Get all unique dates from Pc and Qc tables
            var pcDates = await _testContext.CfdDh3mrPcs.Select(p => p.Ngày).Distinct().ToListAsync();
            var qcDates = await _testContext.CfdDh3mrQcs.Select(q => q.Ngày).Distinct().ToListAsync();
            var fmpDates = await _appContext.FMP_EVN.Select(f => f.Ngay).Distinct().ToListAsync();

            // Find dates that exist in all three tables
            var commonDates = pcDates.Intersect(qcDates).ToList();
            var allDates = commonDates.Where(d => fmpDates.Contains(d))
                .Where(d => d.HasValue).OrderBy(d => d).ToList();

            // Remove existing data
            _testContext.CfdDh3mrs.RemoveRange(_testContext.CfdDh3mrs);
            await _testContext.SaveChangesAsync();

            foreach (var date in allDates)
            {
                var pcData = await _testContext.CfdDh3mrPcs.FirstOrDefaultAsync(p => p.Ngày == date);
                var qcData = await _testContext.CfdDh3mrQcs.FirstOrDefaultAsync(q => q.Ngày == date);
                var fmpData = await _appContext.FMP_EVN.FirstOrDefaultAsync(f => f.Ngay == date);

                if (pcData != null && qcData != null && fmpData != null)
                {
                    var cfdDh3mr = new CfdDh3mr
                    {
                        Ngay = date,
                        // Apply the formula: Cfd_PM4 = Cfd_PM4_Qc * (Cfd_PM4_Pc - FMP_EVN) / 1000
                        ChuKy0h30 = CalculateCfd(qcData.Column0h30, pcData.Column0h30, (decimal?)fmpData.ChuKy0h30),
                        ChuKy1h = CalculateCfd(qcData.Column1h, pcData.Column1h, (decimal?)fmpData.ChuKy1h),
                        ChuKy1h30 = CalculateCfd(qcData.Column1h30, pcData.Column1h30, (decimal?)fmpData.ChuKy1h30),
                        ChuKy2h = CalculateCfd(qcData.Column2h, pcData.Column2h, (decimal?)fmpData.ChuKy2h),
                        ChuKy2h30 = CalculateCfd(qcData.Column2h30, pcData.Column2h30, (decimal?)fmpData.ChuKy2h30),
                        ChuKy3h = CalculateCfd(qcData.Column3h, pcData.Column3h, (decimal?)fmpData.ChuKy3h),
                        ChuKy3h30 = CalculateCfd(qcData.Column3h30, pcData.Column3h30, (decimal?)fmpData.ChuKy3h30),
                        ChuKy4h = CalculateCfd(qcData.Column4h, pcData.Column4h, (decimal?)fmpData.ChuKy4h),
                        ChuKy4h30 = CalculateCfd(qcData.Column4h30, pcData.Column4h30, (decimal?)fmpData.ChuKy4h30),
                        ChuKy5h = CalculateCfd(qcData.Column5h, pcData.Column5h, (decimal?)fmpData.ChuKy5h),
                        ChuKy5h30 = CalculateCfd(qcData.Column5h30, pcData.Column5h30, (decimal?)fmpData.ChuKy5h30),
                        ChuKy6h = CalculateCfd(qcData.Column6h, pcData.Column6h, (decimal?)fmpData.ChuKy6h),
                        ChuKy6h30 = CalculateCfd(qcData.Column6h30, pcData.Column6h30, (decimal?)fmpData.ChuKy6h30),
                        ChuKy7h = CalculateCfd(qcData.Column7h, pcData.Column7h, (decimal?)fmpData.ChuKy7h),
                        ChuKy7h30 = CalculateCfd(qcData.Column7h30, pcData.Column7h30, (decimal?)fmpData.ChuKy7h30),
                        ChuKy8h = CalculateCfd(qcData.Column8h, pcData.Column8h, (decimal?)fmpData.ChuKy8h),
                        ChuKy8h30 = CalculateCfd(qcData.Column8h30, pcData.Column8h30, (decimal?)fmpData.ChuKy8h30),
                        ChuKy9h = CalculateCfd(qcData.Column9h, pcData.Column9h, (decimal?)fmpData.ChuKy9h),
                        ChuKy9h30 = CalculateCfd(qcData.Column9h30, pcData.Column9h30, (decimal?)fmpData.ChuKy9h30),
                        ChuKy10h = CalculateCfd(qcData.Column10h, pcData.Column10h, (decimal?)fmpData.ChuKy10h),
                        ChuKy10h30 = CalculateCfd(qcData.Column10h30, pcData.Column10h30, (decimal?)fmpData.ChuKy10h30),
                        ChuKy11h = CalculateCfd(qcData.Column11h, pcData.Column11h, (decimal?)fmpData.ChuKy11h),
                        ChuKy11h30 = CalculateCfd(qcData.Column11h30, pcData.Column11h30, (decimal?)fmpData.ChuKy11h30),
                        ChuKy12h = CalculateCfd(qcData.Column12h, pcData.Column12h, (decimal?)fmpData.ChuKy12h),
                        ChuKy12h30 = CalculateCfd(qcData.Column12h30, pcData.Column12h30, (decimal?)fmpData.ChuKy12h30),
                        ChuKy13h = CalculateCfd(qcData.Column13h, pcData.Column13h, (decimal?)fmpData.ChuKy13h),
                        ChuKy13h30 = CalculateCfd(qcData.Column13h30, pcData.Column13h30, (decimal?)fmpData.ChuKy13h30),
                        ChuKy14h = CalculateCfd(qcData.Column14h, pcData.Column14h, (decimal?)fmpData.ChuKy14h),
                        ChuKy14h30 = CalculateCfd(qcData.Column14h30, pcData.Column14h30, (decimal?)fmpData.ChuKy14h30),
                        ChuKy15h = CalculateCfd(qcData.Column15h, pcData.Column15h, (decimal?)fmpData.ChuKy15h),
                        ChuKy15h30 = CalculateCfd(qcData.Column15h30, pcData.Column15h30, (decimal?)fmpData.ChuKy15h30),
                        ChuKy16h = CalculateCfd(qcData.Column16h, pcData.Column16h, (decimal?)fmpData.ChuKy16h),
                        ChuKy16h30 = CalculateCfd(qcData.Column16h30, pcData.Column16h30, (decimal?)fmpData.ChuKy16h30),
                        ChuKy17h = CalculateCfd(qcData.Column17h, pcData.Column17h, (decimal?)fmpData.ChuKy17h),
                        ChuKy17h30 = CalculateCfd(qcData.Column17h30, pcData.Column17h30, (decimal?)fmpData.ChuKy17h30),
                        ChuKy18h = CalculateCfd(qcData.Column18h, pcData.Column18h, (decimal?)fmpData.ChuKy18h),
                        ChuKy18h30 = CalculateCfd(qcData.Column18h30, pcData.Column18h30, (decimal?)fmpData.ChuKy18h30),
                        ChuKy19h = CalculateCfd(qcData.Column19h, pcData.Column19h, (decimal?)fmpData.ChuKy19h),
                        ChuKy19h30 = CalculateCfd(qcData.Column19h30, pcData.Column19h30, (decimal?)fmpData.ChuKy19h30),
                        ChuKy20h = CalculateCfd(qcData.Column20h, pcData.Column20h, (decimal?)fmpData.ChuKy20h),
                        ChuKy20h30 = CalculateCfd(qcData.Column20h30, pcData.Column20h30, (decimal?)fmpData.ChuKy20h30),
                        ChuKy21h = CalculateCfd(qcData.Column21h, pcData.Column21h, (decimal?)fmpData.ChuKy21h),
                        ChuKy21h30 = CalculateCfd(qcData.Column21h30, pcData.Column21h30, (decimal?)fmpData.ChuKy21h30),
                        ChuKy22h = CalculateCfd(qcData.Column22h, pcData.Column22h, (decimal?)fmpData.ChuKy22h),
                        ChuKy22h30 = CalculateCfd(qcData.Column22h30, pcData.Column22h30, (decimal?)fmpData.ChuKy22h30),
                        ChuKy23h = CalculateCfd(qcData.Column23h, pcData.Column23h, (decimal?)fmpData.ChuKy23h),
                        ChuKy23h30 = CalculateCfd(qcData.Column23h30, pcData.Column23h30, (decimal?)fmpData.ChuKy23h30),
                        ChuKy24h = CalculateCfd(qcData.Column24h, pcData.Column24h, (decimal?)fmpData.ChuKy24h)
                    };

                    // Calculate total
                    cfdDh3mr.Tong = CalculateTotal(cfdDh3mr);

                    _testContext.CfdDh3mrs.Add(cfdDh3mr);
                }
            }

            await _testContext.SaveChangesAsync();
        }

        public async Task CalculateAndSaveCfdVt4n4MrAsync()
        {
            // Get all unique dates from Pc and Qc tables
            var pcDates = await _testContext.CfdVt4n4MrPcs.Select(p => p.Ngày).Distinct().ToListAsync();
            var qcDates = await _testContext.CfdVt4n4MrQcs.Select(q => q.Ngày).Distinct().ToListAsync();
            var fmpDates = await _appContext.FMP_EVN.Select(f => f.Ngay).Distinct().ToListAsync();

            // Find dates that exist in all three tables
            var commonDates = pcDates.Intersect(qcDates).ToList();
            var allDates = commonDates.Where(d => fmpDates.Contains(d))
                .Where(d => d.HasValue).OrderBy(d => d).ToList();

            // Remove existing data
            _testContext.CfdVt4n4Mrs.RemoveRange(_testContext.CfdVt4n4Mrs);
            await _testContext.SaveChangesAsync();

            foreach (var date in allDates)
            {
                var pcData = await _testContext.CfdVt4n4MrPcs.FirstOrDefaultAsync(p => p.Ngày == date);
                var qcData = await _testContext.CfdVt4n4MrQcs.FirstOrDefaultAsync(q => q.Ngày == date);
                var fmpData = await _appContext.FMP_EVN.FirstOrDefaultAsync(f => f.Ngay == date);

                if (pcData != null && qcData != null && fmpData != null)
                {
                    var cfdVt4n4Mr = new CfdVt4n4Mr
                    {
                        Ngay = date,
                        // Apply the formula: Cfd_PM4 = Cfd_PM4_Qc * (Cfd_PM4_Pc - FMP_EVN) / 1000
                        ChuKy0h30 = CalculateCfd(qcData.Column0h30, pcData.Column0h30, (decimal?)fmpData.ChuKy0h30),
                        ChuKy1h = CalculateCfd(qcData.Column1h, pcData.Column1h, (decimal?)fmpData.ChuKy1h),
                        ChuKy1h30 = CalculateCfd(qcData.Column1h30, pcData.Column1h30, (decimal?)fmpData.ChuKy1h30),
                        ChuKy2h = CalculateCfd(qcData.Column2h, pcData.Column2h, (decimal?)fmpData.ChuKy2h),
                        ChuKy2h30 = CalculateCfd(qcData.Column2h30, pcData.Column2h30, (decimal?)fmpData.ChuKy2h30),
                        ChuKy3h = CalculateCfd(qcData.Column3h, pcData.Column3h, (decimal?)fmpData.ChuKy3h),
                        ChuKy3h30 = CalculateCfd(qcData.Column3h30, pcData.Column3h30, (decimal?)fmpData.ChuKy3h30),
                        ChuKy4h = CalculateCfd(qcData.Column4h, pcData.Column4h, (decimal?)fmpData.ChuKy4h),
                        ChuKy4h30 = CalculateCfd(qcData.Column4h30, pcData.Column4h30, (decimal?)fmpData.ChuKy4h30),
                        ChuKy5h = CalculateCfd(qcData.Column5h, pcData.Column5h, (decimal?)fmpData.ChuKy5h),
                        ChuKy5h30 = CalculateCfd(qcData.Column5h30, pcData.Column5h30, (decimal?)fmpData.ChuKy5h30),
                        ChuKy6h = CalculateCfd(qcData.Column6h, pcData.Column6h, (decimal?)fmpData.ChuKy6h),
                        ChuKy6h30 = CalculateCfd(qcData.Column6h30, pcData.Column6h30, (decimal?)fmpData.ChuKy6h30),
                        ChuKy7h = CalculateCfd(qcData.Column7h, pcData.Column7h, (decimal?)fmpData.ChuKy7h),
                        ChuKy7h30 = CalculateCfd(qcData.Column7h30, pcData.Column7h30, (decimal?)fmpData.ChuKy7h30),
                        ChuKy8h = CalculateCfd(qcData.Column8h, pcData.Column8h, (decimal?)fmpData.ChuKy8h),
                        ChuKy8h30 = CalculateCfd(qcData.Column8h30, pcData.Column8h30, (decimal?)fmpData.ChuKy8h30),
                        ChuKy9h = CalculateCfd(qcData.Column9h, pcData.Column9h, (decimal?)fmpData.ChuKy9h),
                        ChuKy9h30 = CalculateCfd(qcData.Column9h30, pcData.Column9h30, (decimal?)fmpData.ChuKy9h30),
                        ChuKy10h = CalculateCfd(qcData.Column10h, pcData.Column10h, (decimal?)fmpData.ChuKy10h),
                        ChuKy10h30 = CalculateCfd(qcData.Column10h30, pcData.Column10h30, (decimal?)fmpData.ChuKy10h30),
                        ChuKy11h = CalculateCfd(qcData.Column11h, pcData.Column11h, (decimal?)fmpData.ChuKy11h),
                        ChuKy11h30 = CalculateCfd(qcData.Column11h30, pcData.Column11h30, (decimal?)fmpData.ChuKy11h30),
                        ChuKy12h = CalculateCfd(qcData.Column12h, pcData.Column12h, (decimal?)fmpData.ChuKy12h),
                        ChuKy12h30 = CalculateCfd(qcData.Column12h30, pcData.Column12h30, (decimal?)fmpData.ChuKy12h30),
                        ChuKy13h = CalculateCfd(qcData.Column13h, pcData.Column13h, (decimal?)fmpData.ChuKy13h),
                        ChuKy13h30 = CalculateCfd(qcData.Column13h30, pcData.Column13h30, (decimal?)fmpData.ChuKy13h30),
                        ChuKy14h = CalculateCfd(qcData.Column14h, pcData.Column14h, (decimal?)fmpData.ChuKy14h),
                        ChuKy14h30 = CalculateCfd(qcData.Column14h30, pcData.Column14h30, (decimal?)fmpData.ChuKy14h30),
                        ChuKy15h = CalculateCfd(qcData.Column15h, pcData.Column15h, (decimal?)fmpData.ChuKy15h),
                        ChuKy15h30 = CalculateCfd(qcData.Column15h30, pcData.Column15h30, (decimal?)fmpData.ChuKy15h30),
                        ChuKy16h = CalculateCfd(qcData.Column16h, pcData.Column16h, (decimal?)fmpData.ChuKy16h),
                        ChuKy16h30 = CalculateCfd(qcData.Column16h30, pcData.Column16h30, (decimal?)fmpData.ChuKy16h30),
                        ChuKy17h = CalculateCfd(qcData.Column17h, pcData.Column17h, (decimal?)fmpData.ChuKy17h),
                        ChuKy17h30 = CalculateCfd(qcData.Column17h30, pcData.Column17h30, (decimal?)fmpData.ChuKy17h30),
                        ChuKy18h = CalculateCfd(qcData.Column18h, pcData.Column18h, (decimal?)fmpData.ChuKy18h),
                        ChuKy18h30 = CalculateCfd(qcData.Column18h30, pcData.Column18h30, (decimal?)fmpData.ChuKy18h30),
                        ChuKy19h = CalculateCfd(qcData.Column19h, pcData.Column19h, (decimal?)fmpData.ChuKy19h),
                        ChuKy19h30 = CalculateCfd(qcData.Column19h30, pcData.Column19h30, (decimal?)fmpData.ChuKy19h30),
                        ChuKy20h = CalculateCfd(qcData.Column20h, pcData.Column20h, (decimal?)fmpData.ChuKy20h),
                        ChuKy20h30 = CalculateCfd(qcData.Column20h30, pcData.Column20h30, (decimal?)fmpData.ChuKy20h30),
                        ChuKy21h = CalculateCfd(qcData.Column21h, pcData.Column21h, (decimal?)fmpData.ChuKy21h),
                        ChuKy21h30 = CalculateCfd(qcData.Column21h30, pcData.Column21h30, (decimal?)fmpData.ChuKy21h30),
                        ChuKy22h = CalculateCfd(qcData.Column22h, pcData.Column22h, (decimal?)fmpData.ChuKy22h),
                        ChuKy22h30 = CalculateCfd(qcData.Column22h30, pcData.Column22h30, (decimal?)fmpData.ChuKy22h30),
                        ChuKy23h = CalculateCfd(qcData.Column23h, pcData.Column23h, (decimal?)fmpData.ChuKy23h),
                        ChuKy23h30 = CalculateCfd(qcData.Column23h30, pcData.Column23h30, (decimal?)fmpData.ChuKy23h30),
                        ChuKy24h = CalculateCfd(qcData.Column24h, pcData.Column24h, (decimal?)fmpData.ChuKy24h)
                    };

                    // Calculate total
                    cfdVt4n4Mr.Tong = CalculateTotal(cfdVt4n4Mr);

                    _testContext.CfdVt4n4Mrs.Add(cfdVt4n4Mr);
                }
            }

            await _testContext.SaveChangesAsync();
        }

    }
}