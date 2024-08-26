using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<IEnumerable<UserDto>> GetAllUsersCandidateAsync();
    Task<UserDto> GetUserByIdAsync(int userId);
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto, int companyId, int roleId);
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto, int roleId);
    Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto);
    Task<UserDto> AuthenticateUserAsync(string username, string password);
    Task<bool> DeleteUserAsync(int userId);
}