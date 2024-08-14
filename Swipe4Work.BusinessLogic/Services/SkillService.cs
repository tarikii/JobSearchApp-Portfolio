using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillDTO>> GetAllSkillsAsync()
        {
            var skills = await _skillRepository.GetAllSkillsAsync();
            return _mapper.Map<IEnumerable<SkillDTO>>(skills);
        }

        public async Task<SkillDTO> GetSkillByIdAsync(int skillId)
        {
            var skill = await _skillRepository.GetSkillByIdAsync(skillId);
            return skill == null ? null : _mapper.Map<SkillDTO>(skill);
        }

        public async Task<SkillDTO> CreateSkillAsync(CreateSkillDTO createSkillDTO)
        {
            var skill = _mapper.Map<Skill>(createSkillDTO);
            var createdSkill = await _skillRepository.CreateSkillAsync(skill);
            return _mapper.Map<SkillDTO>(createdSkill);
        }

        public async Task<SkillDTO> UpdateSkillAsync(int skillId, UpdateSkillDTO updateSkillDTO)
        {
            if (skillId != updateSkillDTO.SkillId)
            {
                return null;
            }

            var skill = _mapper.Map<Skill>(updateSkillDTO);
            var updatedSkill = await _skillRepository.UpdateSkillAsync(skill);
            return _mapper.Map<SkillDTO>(updatedSkill);
        }

        public async Task<bool> DeleteSkillAsync(int skillId)
        {
            return await _skillRepository.DeleteSkillAsync(skillId);
        }
    }
}