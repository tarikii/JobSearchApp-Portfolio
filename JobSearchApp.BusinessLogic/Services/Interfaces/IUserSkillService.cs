using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;
    public interface IUserSkillService
    {
        Task<IEnumerable<UserSkillDto>> GetAllUserSkillsAsync();
        Task<UserSkillDto> GetUserSkillByIdAsync(int userSkillId);
        Task<UserSkillDto> CreateUserSkillAsync(CreateUserSkillDto createUserSkillDto);
        Task<UserSkillDto> UpdateUserSkillAsync(int userSkillId, UpdateUserSkillDto updateUserSkillDto);
        Task<bool> DeleteUserSkillAsync(int userSkillId);
}