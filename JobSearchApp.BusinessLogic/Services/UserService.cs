using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto, int companyId, int roleId)
    {
        CreateUserDto newUser = createUserDto;
        newUser.CompanyId = companyId;
        newUser.RoleId = roleId;

        var user = _mapper.Map<User>(newUser);
        var createdUser = await _userRepository.CreateUserAsync(user);
        return _mapper.Map<UserDto>(createdUser);
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto, int roleId)
    {
        CreateUserDto newUser = createUserDto;
        newUser.RoleId = roleId;

        var user = _mapper.Map<User>(newUser);
        var createdUser = await _userRepository.CreateUserAsync(user);
        return _mapper.Map<UserDto>(createdUser);
    }

    public async Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null)
        {
            return null;
        }

        user.FirstName = updateUserDto.FirstName;
        user.LastName = updateUserDto.LastName; 
        user.GenderIdentity = updateUserDto.GenderIdentity;
        user.Location = updateUserDto.Location;
        user.LinkedInUrl = updateUserDto.LinkedInUrl;
        user.Headline = updateUserDto.Headline;
        user.MobileNumber = updateUserDto.MobileNumber;
        user.Summary = updateUserDto.Summary;   

        var updatedUser = await _userRepository.UpdateUserAsync(user);
        return _mapper.Map<UserDto>(updatedUser);
    }

    public async Task<UserDto> AuthenticateUserAsync(string username, string password)
    {
        var user = await _userRepository.AuthenticateUserAsync(username, password);
        if (user == null)
        {
            return null;
        }

        return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        return await _userRepository.DeleteUserAsync(userId);
    }
}