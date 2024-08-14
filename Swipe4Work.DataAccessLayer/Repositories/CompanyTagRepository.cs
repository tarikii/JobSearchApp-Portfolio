using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;

namespace Swipe4Work.DataAccessLayer
{
    public class CompanyTagRepository : ICompanyTagRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyTagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyTag>> GetAllCompanyTagsAsync()
        {
            return await _context.CompanyTags.ToListAsync();
        }

        public async Task<CompanyTag> GetCompanyTagByIdAsync(int companyTagId)
        {
            return await _context.CompanyTags.FindAsync(companyTagId);
        }

        public async Task<CompanyTag> CreateCompanyTagAsync(CompanyTag companyTag)
        {
            _context.CompanyTags.Add(companyTag);
            await _context.SaveChangesAsync();
            return companyTag;
        }

        public async Task<CompanyTag> UpdateCompanyTagAsync(CompanyTag companyTag)
        {
            _context.CompanyTags.Update(companyTag);
            await _context.SaveChangesAsync();
            return companyTag;
        }

        public async Task<bool> DeleteCompanyTagAsync(int companyTagId)
        {
            var companyTag = await _context.CompanyTags.FindAsync(companyTagId);
            if (companyTag == null)
            {
                return false;
            }

            _context.CompanyTags.Remove(companyTag);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}