using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataAccessLayer.Interfaces
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