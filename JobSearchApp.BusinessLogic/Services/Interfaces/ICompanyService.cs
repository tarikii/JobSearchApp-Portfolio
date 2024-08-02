using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync();
    Task<CompanyDto> GetCompanyByIdAsync(int companyId);
    Task<CompanyDto> CreateCompanyAsync(CreateCompanyDto createCompanyDto);
    Task<CompanyDto> UpdateCompanyAsync(int companyId, UpdateCompanyDto updateCompanyDto);
    Task<bool> DeleteCompanyAsync(int companyId);
}