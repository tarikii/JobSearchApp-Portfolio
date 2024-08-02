using JobSearchApp.Domain.Models;

namespace JobSearchApp.Infrastructure.Interfaces
{
    public interface IUserPreferenceRepository
    {
        Task<IEnumerable<UserPreference>> GetAllUserPreferencesAsync();
        Task<UserPreference> GetUserPreferenceByIdAsync(int preferenceId);
        Task<UserPreference> CreateUserPreferenceAsync(UserPreference userPreference);
        Task<UserPreference> UpdateUserPreferenceAsync(UserPreference userPreference);
        Task<bool> DeleteUserPreferenceAsync(int preferenceId);
    }
}