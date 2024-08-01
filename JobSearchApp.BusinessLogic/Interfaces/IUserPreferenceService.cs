using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;
    public interface IUserPreferenceService
    {
        Task<IEnumerable<UserPreferenceDto>> GetAllUserPreferencesAsync();
        Task<UserPreferenceDto> GetUserPreferenceByIdAsync(int id);
        Task<UserPreferenceDto> CreateUserPreferenceAsync(UserPreferenceDto userPreferenceDto);
        Task<bool> UpdateUserPreferenceAsync(UserPreferenceDto userPreferenceDto);
        Task<bool> DeleteUserPreferenceAsync(int id);
    }
