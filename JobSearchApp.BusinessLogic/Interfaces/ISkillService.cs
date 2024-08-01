using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ISkillService
{
    Task<IEnumerable<SkillDto>> GetAllSkillsAsync();
    Task<SkillDto> GetSkillByIdAsync(int id);
    Task<SkillDto> CreateSkillAsync(SkillDto skillDto);
    Task<bool> UpdateSkillAsync(SkillDto skillDto);
    Task<bool> DeleteSkillAsync(int id);
}