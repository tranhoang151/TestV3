using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestV3.Models.CSPOT;
using TestV3.Data;

namespace TestV3.Services
{
    public class CspotCalculationService : ICspotCalculationService
    {
        private readonly TestV3Context _context;

        public CspotCalculationService(TestV3Context context)
        {
            _context = context;
        }

        public async Task CalculateAndSaveTongHopCspotAsync()
        {
            // Xóa dữ liệu cũ trong bảng TongHopCspot
            _context.TongHopCspots.RemoveRange(_context.TongHopCspots);
            await _context.SaveChangesAsync();

            // Lấy danh sách ngày duy nhất từ các bảng liên quan
            var distinctDates = await _context.Qm1Cspot1s.Select(q => q.Ngày)
                .Union(_context.Qm2TbCspot2s.Select(q => q.Ngày))
                .Where(d => d.HasValue)
                .Distinct()
                .ToListAsync();

            foreach (var date in distinctDates)
            {
                if (date.HasValue)
                {
                    var tongHop = new TongHopCspot
                    {
                        Ngay = date.Value,

                        // Sản lượng Qm1 (Phú Mỹ)
                        SanLuongQm1 = (long?)await _context.Qm1Cspot1s
                            .Where(q => q.Ngày == date)
                            .SumAsync(q => q.Tổng) ?? 0,

                        // Sản lượng chi tiết của Qm2
                        SanLuongTb = (long?)await _context.Qm2TbCspot2s
                            .Where(q => q.Ngày == date)
                            .SumAsync(q => q.Tổng) ?? 0,

                        SanLuongVt4 = (long?)await _context.Qm2Vt4Cspot2s
                            .Where(q => q.Ngày == date)
                            .SumAsync(q => q.Tổng) ?? 0,

                        SanLuongVt4Mr = (long?)await _context.Qm2Vt4mrcspot2s
                            .Where(q => q.Ngày == date)
                            .SumAsync(q => q.Tổng) ?? 0,

                        SanLuongDh3Mr = (long?)await _context.Qm2Dh3mrCspot2s
                            .Where(q => q.Ngày == date)
                            .SumAsync(q => q.Tổng) ?? 0,

                        // Chi phí Cm1 (Phú Mỹ)
                        ChiPhiCm1 = (long?)await _context.CspotPmCspot1s
                            .Where(p => p.Ngày == date)
                            .SumAsync(p => p.Tổng) ?? 0,

                        // Chi phí chi tiết của Cm2
                        ChiPhiTb = (long?)await _context.CspotTbCsport2s
                            .Where(c => c.Ngày == date)
                            .SumAsync(c => c.Tổng) ?? 0,

                        ChiPhiVt4 = (long?)await _context.CspotVt4Cspot2s
                            .Where(c => c.Ngày == date)
                            .SumAsync(c => c.Tổng) ?? 0,

                        ChiPhiVt4Mr = (long?)await _context.CspotVt4mrCspot2s
                            .Where(c => c.Ngày == date)
                            .SumAsync(c => c.Tổng) ?? 0,

                        ChiPhiDh3Mr = (long?)await _context.CspotDh3mrCspot2s
                            .Where(c => c.Ngày == date)
                            .SumAsync(c => c.Tổng) ?? 0
                    };

                    // Tính tổng Qm2 và Qm
                    tongHop.SanLuongQm2 = tongHop.SanLuongTb + tongHop.SanLuongVt4 + tongHop.SanLuongVt4Mr + tongHop.SanLuongDh3Mr;
                    tongHop.SanLuongQm = tongHop.SanLuongQm1 + tongHop.SanLuongQm2;

                    // Tính tổng Cm2 và tổng chi phí
                    tongHop.ChiPhiCm2 = tongHop.ChiPhiTb + tongHop.ChiPhiVt4 + tongHop.ChiPhiVt4Mr + tongHop.ChiPhiDh3Mr;
                    tongHop.TongChiPhi = tongHop.ChiPhiCm1 + tongHop.ChiPhiCm2;

                    _context.TongHopCspots.Add(tongHop);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<TongHopCspot>> GetTongHopCspotDataAsync()
        {
            return await _context.TongHopCspots
                .OrderBy(t => t.Ngay)
                .ToListAsync();
        }

        public async Task<List<CspotPmCspot1>> GetCspotPmCspot1DataAsync()
        {
            return await _context.CspotPmCspot1s.ToListAsync();
        }

        public async Task<List<CspotTbCsport2>> GetCspotTbCsport2DataAsync()
        {
            return await _context.CspotTbCsport2s.ToListAsync();
        }

        public async Task<List<CspotVt4Cspot2>> GetCspotVt4Cspot2DataAsync()
        {
            return await _context.CspotVt4Cspot2s.ToListAsync();
        }

        public async Task<List<CspotVt4mrCspot2>> GetCspotVt4mrCspot2DataAsync()
        {
            return await _context.CspotVt4mrCspot2s.ToListAsync();
        }

        public async Task<List<CspotDh3mrCspot2>> GetCspotDh3mrCspot2DataAsync()
        {
            return await _context.CspotDh3mrCspot2s.ToListAsync();
        }

        public async Task<List<Qm1Cspot1>> GetQm1Cspot1DataAsync()
        {
            return await _context.Qm1Cspot1s.ToListAsync();
        }

        public async Task<List<Qm2TbCspot2>> GetQm2TbCspot2DataAsync()
        {
            return await _context.Qm2TbCspot2s.ToListAsync();
        }

        public async Task<List<Qm2Vt4Cspot2>> GetQm2Vt4Cspot2DataAsync()
        {
            return await _context.Qm2Vt4Cspot2s.ToListAsync();
        }

        public async Task<List<Qm2Vt4mrcspot2>> GetQm2Vt4mrcspot2DataAsync()
        {
            return await _context.Qm2Vt4mrcspot2s.ToListAsync();
        }

        public async Task<List<Qm2Dh3mrCspot2>> GetQm2Dh3mrCspot2DataAsync()
        {
            return await _context.Qm2Dh3mrCspot2s.ToListAsync();
        }

        public async Task<List<TongHopCspot>> GetTongHopCspotByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.TongHopCspots
                .Where(t => t.Ngay >= startDate && t.Ngay <= endDate)
                .OrderBy(t => t.Ngay)
                .ToListAsync();
        }

        public async Task<TongHopCspot> GetTongHopCspotByDateAsync(DateTime date)
        {
            return await _context.TongHopCspots
                .FirstOrDefaultAsync(t => t.Ngay.HasValue && t.Ngay.Value.Date == date.Date);
        }
    }
}