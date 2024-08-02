using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ICompensationBenefitService
{
    Task<IEnumerable<CompensationBenefitDto>> GetAllCompensationBenefitsAsync();
    Task<CompensationBenefitDto> GetCompensationBenefitByIdAsync(int id);
    Task<CompensationBenefitDto> CreateCompensationBenefitAsync(CompensationBenefit compensationBenefit);
    Task<bool> UpdateCompensationBenefitAsync(CompensationBenefit compensationBenefit);
    Task<bool> DeleteCompensationBenefitAsync(int id);
}