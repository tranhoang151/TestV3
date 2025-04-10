using System.Threading.Tasks;
using System.Collections.Generic;
using TestV3.Models.CSPOT;

namespace TestV3.Services
{
    public interface ICspotCalculationService
    {
        Task CalculateAndSaveTongHopCspotAsync();
        Task<List<TongHopCspot>> GetTongHopCspotDataAsync();
        Task<List<CspotPmCspot1>> GetCspotPmCspot1DataAsync();
        Task<List<CspotTbCsport2>> GetCspotTbCsport2DataAsync();
        Task<List<CspotVt4Cspot2>> GetCspotVt4Cspot2DataAsync();
        Task<List<CspotVt4mrCspot2>> GetCspotVt4mrCspot2DataAsync();
        Task<List<CspotDh3mrCspot2>> GetCspotDh3mrCspot2DataAsync();
        Task<List<Qm1Cspot1>> GetQm1Cspot1DataAsync();
        Task<List<Qm2TbCspot2>> GetQm2TbCspot2DataAsync();
        Task<List<Qm2Vt4Cspot2>> GetQm2Vt4Cspot2DataAsync();
        Task<List<Qm2Vt4mrcspot2>> GetQm2Vt4mrcspot2DataAsync();
        Task<List<Qm2Dh3mrCspot2>> GetQm2Dh3mrCspot2DataAsync();
        Task<List<TongHopCspot>> GetTongHopCspotByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<TongHopCspot> GetTongHopCspotByDateAsync(DateTime date);
    }
}
