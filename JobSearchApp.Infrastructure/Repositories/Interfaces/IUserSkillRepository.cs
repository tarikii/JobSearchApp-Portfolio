using JobSearchApp.Domain.Models;

namespace JobSearchApp.Infrastructure.Interfaces;

public interface IUserSkillRepository
{
    Task<IEnumerable<UserSkill>> GetAllUserSkillsAsync();
    Task<UserSkill> GetUserSkillByIdAsync(int userSkillId);
    Task<UserSkill> CreateUserSkillAsync(UserSkill userSkill);
    Task<UserSkill> UpdateUserSkillAsync(UserSkill userSkill);
    Task<bool> DeleteUserSkillAsync(int userSkillId);
}