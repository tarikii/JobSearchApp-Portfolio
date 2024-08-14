using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataAccessLayer.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int userId);
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<User> AuthenticateUserAsync(string username, string password);
    Task<bool> DeleteUserAsync(int userId);
}