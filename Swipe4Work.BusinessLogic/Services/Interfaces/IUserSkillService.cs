using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;
public interface IUserSkillService
    {
        Task<IEnumerable<UserSkillDTO>> GetAllUserSkillsAsync();
        Task<UserSkillDTO> GetUserSkillByIdAsync(int userSkillId);
        Task<UserSkillDTO> CreateUserSkillAsync(CreateUserSkillDTO createUserSkillDTO);
        Task<UserSkillDTO> UpdateUserSkillAsync(int userSkillId, UpdateUserSkillDTO updateUserSkillDTO);
        Task<bool> DeleteUserSkillAsync(int userSkillId);
}