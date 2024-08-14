using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface ICompensationBenefitService
{
    Task<IEnumerable<CompensationBenefitDTO>> GetAllCompensationBenefitsAsync();
    Task<CompensationBenefitDTO> GetCompensationBenefitByIdAsync(int benefitId);

    Task<CompensationBenefitDTO> CreateCompensationBenefitAsync(
        CreateCompensationBenefitDTO createCompensationBenefitDTO);

    Task<CompensationBenefitDTO> UpdateCompensationBenefitAsync(int benefitId,
        UpdateCompensationBenefitDTO updateCompensationBenefitDTO);

    Task<bool> DeleteCompensationBenefitAsync(int benefitId);
}