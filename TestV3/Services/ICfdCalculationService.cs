using TestV3.Models.PmQL;
using TestV3.Models;

namespace TestV3.Services
{
    public interface ICfdCalculationService
    {
        // Existing PM1 methods
        Task<List<CfdPm1>> GetCfdPm1DataAsync();
        Task<List<CfdPm1Pc>> GetCfdPm1PcDataAsync();
        Task<List<CfdPm1Qc>> GetCfdPm1QcDataAsync();
        Task CalculateAndSaveCfdPm1Async();

        // New PM4 methods
        Task<List<CfdPm4>> GetCfdPm4DataAsync();
        Task<List<CfdPm4Pc>> GetCfdPm4PcDataAsync();
        Task<List<CfdPm4Qc>> GetCfdPm4QcDataAsync();
        Task CalculateAndSaveCfdPm4Async();

        // New TB1 methods
        Task<List<CfdTb1>> GetCfdTb1DataAsync();
        Task<List<CfdTb1Pc>> GetCfdTb1PcDataAsync();
        Task<List<CfdTb1Qc>> GetCfdTb1QcDataAsync();
        Task CalculateAndSaveCfdTb1Async();

        // New DH3MR methods
        Task<List<CfdDh3mr>> GetCfdDh3mrDataAsync();
        Task<List<CfdDh3mrPc>> GetCfdDh3mrPcDataAsync();
        Task<List<CfdDh3mrQc>> GetCfdDh3mrQcDataAsync();
        Task CalculateAndSaveCfdDh3mrAsync();

        // New DH3MR methods
        Task<List<CfdVt4n4Mr>> GetCfdVt4n4MrDataAsync();
        Task<List<CfdVt4n4MrPc>> GetCfdVt4n4MrPcDataAsync();
        Task<List<CfdVt4n4MrQc>> GetCfdVt4n4MrQcDataAsync();
        Task CalculateAndSaveCfdVt4n4MrAsync();

        // Common methods
        Task<List<FmpEvn>> GetFmpEvnDataAsync();
        Task<Dictionary<string, object>> GetSummaryDataAsync();
    }
}
