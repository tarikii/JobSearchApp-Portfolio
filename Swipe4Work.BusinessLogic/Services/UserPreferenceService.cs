using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
{
    public class UserPreferenceService : IUserPreferenceService
    {
        private readonly IUserPreferenceRepository _userPreferenceRepository;
        private readonly IMapper _mapper;

        public UserPreferenceService(IUserPreferenceRepository userPreferenceRepository, IMapper mapper)
        {
            _userPreferenceRepository = userPreferenceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserPreferenceDTO>> GetAllUserPreferencesAsync()
        {
            var userPreferences = await _userPreferenceRepository.GetAllUserPreferencesAsync();
            return _mapper.Map<IEnumerable<UserPreferenceDTO>>(userPreferences);
        }

        public async Task<UserPreferenceDTO> GetUserPreferenceByIdAsync(int preferenceId)
        {
            var userPreference = await _userPreferenceRepository.GetUserPreferenceByIdAsync(preferenceId);
            return userPreference == null ? null : _mapper.Map<UserPreferenceDTO>(userPreference);
        }

        public async Task<UserPreferenceDTO> CreateUserPreferenceAsync(CreateUserPreferenceDTO createUserPreferenceDTO)
        {
            var userPreference = _mapper.Map<UserPreference>(createUserPreferenceDTO);
            var createdUserPreference = await _userPreferenceRepository.CreateUserPreferenceAsync(userPreference);
            return _mapper.Map<UserPreferenceDTO>(createdUserPreference);
        }

        public async Task<UserPreferenceDTO> UpdateUserPreferenceAsync(int preferenceId, UpdateUserPreferenceDTO updateUserPreferenceDTO)
        {
            if (preferenceId != updateUserPreferenceDTO.PreferenceId)
            {
                return null;
            }

            var userPreference = _mapper.Map<UserPreference>(updateUserPreferenceDTO);
            var updatedUserPreference = await _userPreferenceRepository.UpdateUserPreferenceAsync(userPreference);
            return _mapper.Map<UserPreferenceDTO>(updatedUserPreference);
        }

        public async Task<bool> DeleteUserPreferenceAsync(int preferenceId)
        {
            return await _userPreferenceRepository.DeleteUserPreferenceAsync(preferenceId);
        }
    }
}
