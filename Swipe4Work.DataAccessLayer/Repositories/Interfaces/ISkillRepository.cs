using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataAccessLayer.Interfaces;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetAllSkillsAsync();
    Task<Skill> GetSkillByIdAsync(int skillId);
    Task<Skill> CreateSkillAsync(Skill skill);
    Task<Skill> UpdateSkillAsync(Skill skill);
    Task<bool> DeleteSkillAsync(int skillId);
}