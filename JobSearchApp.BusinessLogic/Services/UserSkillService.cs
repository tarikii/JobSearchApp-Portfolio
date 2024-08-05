using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

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
            if (userSkillId != updateUserSkillDto.UserSkillId)
            {
                return null;
            }

            var userSkill = _mapper.Map<UserSkill>(updateUserSkillDto);
            var updatedUserSkill = await _userSkillRepository.UpdateUserSkillAsync(userSkill);
            return _mapper.Map<UserSkillDto>(updatedUserSkill);
        }

        public async Task<bool> DeleteUserSkillAsync(int userSkillId)
        {
            return await _userSkillRepository.DeleteUserSkillAsync(userSkillId);
        }
    }
}
