using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;
using JobSearchApp.Infrastructure.Repositories;

namespace JobSearchApp.BusinessLogic.Services
{
    public class UserSkillService : IUserSkillService
    {
        private readonly IUserSkillRepository _userSkillRepository;
        private readonly IMapper _mapper;

        public UserSkillService(IUserSkillRepository userSkillRepository, IMapper mapper)
        {
            _userSkillRepository = userSkillRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserSkillDto>> GetAllUserSkillsAsync()
        {
            var userSkills = await _userSkillRepository.GetAllUserSkillsAsync();
            return _mapper.Map<IEnumerable<UserSkillDto>>(userSkills);
        }

        public async Task<UserSkillDto> GetUserSkillByIdAsync(int userSkillId)
        {
            var userSkill = await _userSkillRepository.GetUserSkillByIdAsync(userSkillId);
            return userSkill == null ? null : _mapper.Map<UserSkillDto>(userSkill);
        }

        public async Task<UserSkillDto> CreateUserSkillAsync(CreateUserSkillDto createUserSkillDto)
        {
            var userSkill = _mapper.Map<UserSkill>(createUserSkillDto);
            var createdUserSkill = await _userSkillRepository.CreateUserSkillAsync(userSkill);
            return _mapper.Map<UserSkillDto>(createdUserSkill);
        }

        public async Task<UserSkillDto> UpdateUserSkillAsync(int userSkillId, UpdateUserSkillDto updateUserSkillDto)
        {
            var existingUserSkill = await _userSkillRepository.GetUserSkillByIdAsync(userSkillId);

            if (existingUserSkill == null)
            {
                // Handle the case where the interest does not exist
                throw new Exception($"User Skill with ID {userSkillId} not found.");
            }

            // Update properties on the existing user skill
            _mapper.Map(updateUserSkillDto, existingUserSkill);

            // Save the updated user skill entity
            var updatedUserSkill = await _userSkillRepository.UpdateUserSkillAsync(existingUserSkill);

            // Map the updated entity back to a DTO
            return _mapper.Map<UserSkillDto>(updatedUserSkill);
        }

        public async Task<bool> DeleteUserSkillAsync(int userSkillId)
        {
            return await _userSkillRepository.DeleteUserSkillAsync(userSkillId);
        }
    }
}
