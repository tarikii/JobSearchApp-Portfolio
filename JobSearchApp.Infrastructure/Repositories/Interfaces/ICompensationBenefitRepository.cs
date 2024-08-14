using System.Collections.Generic;
using System.Threading.Tasks;
using JobSearchApp.Domain.Models;

namespace JobSearchApp.Infrastructure.Interfaces
{
    public interface ICompensationBenefitRepository
    {
        Task<IEnumerable<CompensationBenefit>> GetAllCompensationBenefitsAsync();
        Task<CompensationBenefit> GetCompensationBenefitByIdAsync(int benefitId);
        Task<CompensationBenefit> CreateCompensationBenefitAsync(CompensationBenefit compensationBenefit);
        Task<CompensationBenefit> UpdateCompensationBenefitAsync(CompensationBenefit compensationBenefit);
        Task<bool> DeleteCompensationBenefitAsync(int benefitId);
    }
}