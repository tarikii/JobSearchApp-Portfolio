using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IUserPreferenceService
{
    Task<IEnumerable<UserPreferenceDTO>> GetAllUserPreferencesAsync();
    Task<UserPreferenceDTO> GetUserPreferenceByIdAsync(int preferenceId);
    Task<UserPreferenceDTO> CreateUserPreferenceAsync(CreateUserPreferenceDTO createUserPreferenceDTO);

    Task<UserPreferenceDTO>
        UpdateUserPreferenceAsync(int preferenceId, UpdateUserPreferenceDTO updateUserPreferenceDTO);

    Task<bool> DeleteUserPreferenceAsync(int preferenceId);
}