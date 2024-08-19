using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;
using JobSearchApp.Infrastructure.Repositories;

namespace JobSearchApp.BusinessLogic.Services
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

        public async Task<IEnumerable<UserPreferenceDto>> GetAllUserPreferencesAsync()
        {
            var userPreferences = await _userPreferenceRepository.GetAllUserPreferencesAsync();
            return _mapper.Map<IEnumerable<UserPreferenceDto>>(userPreferences);
        }

        public async Task<UserPreferenceDto> GetUserPreferenceByIdAsync(int preferenceId)
        {
            var userPreference = await _userPreferenceRepository.GetUserPreferenceByIdAsync(preferenceId);
            return userPreference == null ? null : _mapper.Map<UserPreferenceDto>(userPreference);
        }

        public async Task<UserPreferenceDto> CreateUserPreferenceAsync(CreateUserPreferenceDto createUserPreferenceDto, int userId)
        {
            CreateUserPreferenceDto newPreference = createUserPreferenceDto;
            newPreference.UserId = userId;

            var userPreference = _mapper.Map<UserPreference>(createUserPreferenceDto);
            var createdUserPreference = await _userPreferenceRepository.CreateUserPreferenceAsync(userPreference);
            return _mapper.Map<UserPreferenceDto>(createdUserPreference);
        }

        public async Task<UserPreferenceDto> UpdateUserPreferenceAsync(int preferenceId, UpdateUserPreferenceDto updateUserPreferenceDto)
        {
            var existingPreference = 
                await _userPreferenceRepository.GetUserPreferenceByIdAsync(preferenceId);
            if (existingPreference == null)
            {
                // Handle the case where the interest does not exist
                throw new Exception($"Preference with ID {preferenceId} not found.");
            }

            // Update properties on the existing interest
            _mapper.Map(updateUserPreferenceDto, existingPreference);

            // Save the updated interest entity
            var updatedPreference = 
                await _userPreferenceRepository.UpdateUserPreferenceAsync(existingPreference);

            // Map the updated entity back to a DTO
            return _mapper.Map<UserPreferenceDto>(updatedPreference);
        }

        public async Task<bool> DeleteUserPreferenceAsync(int preferenceId)
        {
            return await _userPreferenceRepository.DeleteUserPreferenceAsync(preferenceId);
        }
    }
}
