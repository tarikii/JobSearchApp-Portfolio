using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
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

        public async Task<IEnumerable<SkillDto>> GetAllSkillsAsync()
        {
            var skills = await _skillRepository.GetAllSkillsAsync();
            return _mapper.Map<IEnumerable<SkillDto>>(skills);
        }

        public async Task<SkillDto> GetSkillByIdAsync(int skillId)
        {
            var skill = await _skillRepository.GetSkillByIdAsync(skillId);
            return skill == null ? null : _mapper.Map<SkillDto>(skill);
        }

        public async Task<SkillDto> CreateSkillAsync(CreateSkillDto createSkillDto)
        {
            var skill = _mapper.Map<Skill>(createSkillDto);
            var createdSkill = await _skillRepository.CreateSkillAsync(skill);
            return _mapper.Map<SkillDto>(createdSkill);
        }

        public async Task<SkillDto> UpdateSkillAsync(int skillId, UpdateSkillDto updateSkillDto)
        {
            if (skillId != updateSkillDto.SkillId)
            {
                return null;
            }

            var skill = _mapper.Map<Skill>(updateSkillDto);
            var updatedSkill = await _skillRepository.UpdateSkillAsync(skill);
            return _mapper.Map<SkillDto>(updatedSkill);
        }

        public async Task<bool> DeleteSkillAsync(int skillId)
        {
            return await _skillRepository.DeleteSkillAsync(skillId);
        }
    }
}