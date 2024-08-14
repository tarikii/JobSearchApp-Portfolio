using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<CompanyDTO>> GetAllCompaniesAsync();
    Task<CompanyDTO> GetCompanyByIdAsync(int companyId);
    Task<CompanyDTO> CreateCompanyAsync(CreateCompanyDTO createCompanyDTO);
    Task<CompanyDTO> UpdateCompanyAsync(int companyId, UpdateCompanyDTO updateCompanyDTO);
    Task<bool> DeleteCompanyAsync(int companyId);
}