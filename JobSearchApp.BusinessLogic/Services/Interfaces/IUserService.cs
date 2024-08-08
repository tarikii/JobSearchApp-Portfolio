using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(int userId);
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
    Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto);
    Task<User> AuthenticateUserAsync(string username, string password);
    Task<bool> DeleteUserAsync(int userId);
}