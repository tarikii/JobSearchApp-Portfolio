using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ISkillService
{
    Task<IEnumerable<SkillDto>> GetAllSkillsAsync();
    Task<SkillDto> GetSkillByIdAsync(int skillId);
    Task<SkillDto> CreateSkillAsync(CreateSkillDto createSkillDto);
    Task<SkillDto> UpdateSkillAsync(int skillId, UpdateSkillDto updateSkillDto);
    Task<bool> DeleteSkillAsync(int skillId);
}