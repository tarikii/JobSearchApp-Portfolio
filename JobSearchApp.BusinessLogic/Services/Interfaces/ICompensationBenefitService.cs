using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ICompensationBenefitService
{
    Task<IEnumerable<CompensationBenefitDto>> GetAllCompensationBenefitsAsync();
    Task<CompensationBenefitDto> GetCompensationBenefitByIdAsync(int benefitId);

    Task<CompensationBenefitDto> CreateCompensationBenefitAsync(
        CreateCompensationBenefitDto createCompensationBenefitDto);

    Task<CompensationBenefitDto> UpdateCompensationBenefitAsync(int benefitId,
        UpdateCompensationBenefitDto updateCompensationBenefitDto);

    Task<bool> DeleteCompensationBenefitAsync(int benefitId);
}