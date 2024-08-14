using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataAccessLayer.Interfaces
{
    public interface ICompanyTagRepository
    {
        Task<IEnumerable<CompanyTag>> GetAllCompanyTagsAsync();
        Task<CompanyTag> GetCompanyTagByIdAsync(int companyTagId);
        Task<CompanyTag> CreateCompanyTagAsync(CompanyTag companyTag);
        Task<CompanyTag> UpdateCompanyTagAsync(CompanyTag companyTag);
        Task<bool> DeleteCompanyTagAsync(int companyTagId);
    }
}