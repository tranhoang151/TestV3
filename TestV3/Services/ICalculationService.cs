using System.Threading.Tasks;
using System.Collections.Generic;
using TestV3.Models.PmQL;

namespace TestV3.Services
{
    public interface ICalculationService
    {
        Task CalculateAndSaveFmpEvnAsync();
        Task<List<FmpEvn>> GetFmpEvnDataAsync();
        Task CalculateAndSavePmEvnAsync();
        Task<List<PmEvn>> GetPmEvnDataAsync();
        Task CalculateAndSaveFmpSaiAsync();
        Task<List<FmpSai>> GetFmpSaiDataAsync();
        Task CalculateAndSavePmSaiAsync();
        Task<List<PmSai>> GetPmSaiDataAsync();
        double CustomRound(double value);
    }
}