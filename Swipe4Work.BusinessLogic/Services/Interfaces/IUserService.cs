using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    Task<UserDTO> GetUserByIdAsync(int userId);
    Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDTO);
    Task<UserDTO> UpdateUserAsync(int userId, UpdateUserDTO updateUserDTO);
    Task<User> AuthenticateUserAsync(string username, string password);
    Task<bool> DeleteUserAsync(int userId);
}