using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ICompensationBenefitService
{
    Task<IEnumerable<CompensationBenefitDto>> GetAllCompensationBenefitsAsync();
    Task<CompensationBenefitDto> GetCompensationBenefitByIdAsync(int id);
    Task<CompensationBenefitDto> CreateCompensationBenefitAsync(CompensationBenefitDto compensationBenefitDto);
    Task<bool> UpdateCompensationBenefitAsync(CompensationBenefitDto compensationBenefitDto);
    Task<bool> DeleteCompensationBenefitAsync(int id);
}