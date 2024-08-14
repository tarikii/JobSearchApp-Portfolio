using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface ISkillService
{
    Task<IEnumerable<SkillDTO>> GetAllSkillsAsync();
    Task<SkillDTO> GetSkillByIdAsync(int skillId);
    Task<SkillDTO> CreateSkillAsync(CreateSkillDTO createSkillDTO);
    Task<SkillDTO> UpdateSkillAsync(int skillId, UpdateSkillDTO updateSkillDTO);
    Task<bool> DeleteSkillAsync(int skillId);
}