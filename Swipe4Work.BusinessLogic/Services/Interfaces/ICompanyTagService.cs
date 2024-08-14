using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface ICompanyTagService
{
    Task<IEnumerable<CompanyTagDTO>> GetAllCompanyTagsAsync();
    Task<CompanyTagDTO> GetCompanyTagByIdAsync(int companyTagId);
    Task<CompanyTagDTO> CreateCompanyTagAsync(CreateCompanyTagDTO createCompanyDTO);
    Task<CompanyTagDTO> UpdateCompanyTagAsync(int companyTagId, UpdateCompanyTagDTO updateCompanyDTO);
    Task<bool> DeleteCompanyTagAsync(int companyTagId);
}