using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IUserPreferenceService
{
    Task<IEnumerable<UserPreferenceDto>> GetAllUserPreferencesAsync();
    Task<UserPreferenceDto> GetUserPreferenceByIdAsync(int preferenceId);
    Task<UserPreferenceDto> CreateUserPreferenceAsync(CreateUserPreferenceDto createUserPreferenceDto, int userId);

    Task<UserPreferenceDto>
        UpdateUserPreferenceAsync(int preferenceId, UpdateUserPreferenceDto updateUserPreferenceDto);

    Task<bool> DeleteUserPreferenceAsync(int preferenceId);
}