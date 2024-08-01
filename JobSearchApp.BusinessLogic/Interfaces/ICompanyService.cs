using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync();
    Task<CompanyDto> GetCompanyByIdAsync(int id);
    Task<CompanyDto> CreateCompanyAsync(CompanyDto companyDto);
    Task<bool> UpdateCompanyAsync(CompanyDto companyDto);
    Task<bool> DeleteCompanyAsync(int id);
}