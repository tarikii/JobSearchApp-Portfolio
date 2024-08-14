using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;

namespace Swipe4Work.DataAccessLayer
{
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkExperienceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkExperience>> GetAllWorkExperiencesAsync()
        {
            return await _context.WorkExperiences.ToListAsync();
        }

        public async Task<WorkExperience> GetWorkExperienceByIdAsync(int workExperienceId)
        {
            return await _context.WorkExperiences.FindAsync(workExperienceId);
        }

        public async Task<WorkExperience> CreateWorkExperienceAsync(WorkExperience workExperience)
        {
            _context.WorkExperiences.Add(workExperience);
            await _context.SaveChangesAsync();
            return workExperience;
        }

        public async Task<WorkExperience> UpdateWorkExperienceAsync(WorkExperience workExperience)
        {
            _context.WorkExperiences.Update(workExperience);
            await _context.SaveChangesAsync();
            return workExperience;
        }

        public async Task<bool> DeleteWorkExperienceAsync(int workExperienceId)
        {
            var workExperience = await _context.WorkExperiences.FindAsync(workExperienceId);
            if (workExperience == null)
            {
                return false;
            }

            _context.WorkExperiences.Remove(workExperience);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}