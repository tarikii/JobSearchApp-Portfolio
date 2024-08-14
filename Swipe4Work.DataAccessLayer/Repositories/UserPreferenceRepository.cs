using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;
namespace Swipe4Work.DataAccessLayer
{
    public class UserPreferenceRepository : IUserPreferenceRepository
    {
        private readonly ApplicationDbContext _context;

        public UserPreferenceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserPreference>> GetAllUserPreferencesAsync()
        {
            return await _context.UserPreferences.ToListAsync();
        }

        public async Task<UserPreference> GetUserPreferenceByIdAsync(int preferenceId)
        {
            return await _context.UserPreferences.FindAsync(preferenceId);
        }

        public async Task<UserPreference> CreateUserPreferenceAsync(UserPreference userPreference)
        {
            _context.UserPreferences.Add(userPreference);
            await _context.SaveChangesAsync();
            return userPreference;
        }

        public async Task<UserPreference> UpdateUserPreferenceAsync(UserPreference userPreference)
        {
            _context.UserPreferences.Update(userPreference);
            await _context.SaveChangesAsync();
            return userPreference;
        }

        public async Task<bool> DeleteUserPreferenceAsync(int preferenceId)
        {
            var userPreference = await _context.UserPreferences.FindAsync(preferenceId);
            if (userPreference == null)
            {
                return false;
            }

            _context.UserPreferences.Remove(userPreference);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}