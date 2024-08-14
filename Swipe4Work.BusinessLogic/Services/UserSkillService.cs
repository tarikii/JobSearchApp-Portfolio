using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<UserSkillDTO>> GetAllUserSkillsAsync()
        {
            var userSkills = await _userSkillRepository.GetAllUserSkillsAsync();
            return _mapper.Map<IEnumerable<UserSkillDTO>>(userSkills);
        }

        public async Task<UserSkillDTO> GetUserSkillByIdAsync(int userSkillId)
        {
            var userSkill = await _userSkillRepository.GetUserSkillByIdAsync(userSkillId);
            return userSkill == null ? null : _mapper.Map<UserSkillDTO>(userSkill);
        }

        public async Task<UserSkillDTO> CreateUserSkillAsync(CreateUserSkillDTO createUserSkillDTO)
        {
            var userSkill = _mapper.Map<UserSkill>(createUserSkillDTO);
            var createdUserSkill = await _userSkillRepository.CreateUserSkillAsync(userSkill);
            return _mapper.Map<UserSkillDTO>(createdUserSkill);
        }

        public async Task<UserSkillDTO> UpdateUserSkillAsync(int userSkillId, UpdateUserSkillDTO updateUserSkillDTO)
        {
            if (userSkillId != updateUserSkillDTO.UserSkillId)
            {
                return null;
            }

            var userSkill = _mapper.Map<UserSkill>(updateUserSkillDTO);
            var updatedUserSkill = await _userSkillRepository.UpdateUserSkillAsync(userSkill);
            return _mapper.Map<UserSkillDTO>(updatedUserSkill);
        }

        public async Task<bool> DeleteUserSkillAsync(int userSkillId)
        {
            return await _userSkillRepository.DeleteUserSkillAsync(userSkillId);
        }
    }
}
