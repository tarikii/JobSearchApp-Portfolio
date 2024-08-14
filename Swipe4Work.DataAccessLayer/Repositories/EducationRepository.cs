using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;
namespace Swipe4Work.DataAccessLayer
{
    public class EducationRepository : IEducationRepository
    {
        private readonly ApplicationDbContext _context;

        public EducationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Education>> GetAllEducationsAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<Education> GetEducationByIdAsync(int educationId)
        {
            return await _context.Educations.FindAsync(educationId);
        }

        public async Task<Education> CreateEducationAsync(Education education)
        {
            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
            return education;
        }

        public async Task<Education> UpdateEducationAsync(Education education)
        {
            _context.Educations.Update(education);
            await _context.SaveChangesAsync();
            return education;
        }

        public async Task<bool> DeleteEducationAsync(int educationId)
        {
            var education = await _context.Educations.FindAsync(educationId);
            if (education == null)
            {
                return false;
            }

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}