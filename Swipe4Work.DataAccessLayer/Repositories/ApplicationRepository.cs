using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;

namespace Swipe4Work.DataAccessLayer
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application> GetApplicationByIdAsync(int applicationId)
        {
            return await _context.Applications.FindAsync(applicationId);
        }

        public async Task<Application> CreateApplicationAsync(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<Application> UpdateApplicationAsync(Application application)
        {
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<bool> DeleteApplicationAsync(int applicationId)
        {
            var application = await _context.Applications.FindAsync(applicationId);
            if (application == null)
            {
                return false;
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}