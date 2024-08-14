using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ICompanyTagService
{
    Task<IEnumerable<CompanyTagDto>> GetAllCompanyTagsAsync();
    Task<CompanyTagDto> GetCompanyTagByIdAsync(int companyTagId);
    Task<CompanyTagDto> CreateCompanyTagAsync(CreateCompanyTagDto createCompanyDto);
    Task<CompanyTagDto> UpdateCompanyTagAsync(int companyTagId, UpdateCompanyTagDto updateCompanyDto);
    Task<bool> DeleteCompanyTagAsync(int companyTagId);
}