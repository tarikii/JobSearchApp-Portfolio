using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;


namespace Swipe4Work.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO> GetUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDTO)
    {
        var user = _mapper.Map<User>(createUserDTO);
        var createdUser = await _userRepository.CreateUserAsync(user);
        return _mapper.Map<UserDTO>(createdUser);
    }

    public async Task<UserDTO> UpdateUserAsync(int userId, UpdateUserDTO updateUserDTO)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null)
        {
            return null;
        }

        _mapper.Map(updateUserDTO, user);
        var updatedUser = await _userRepository.UpdateUserAsync(user);
        return _mapper.Map<UserDTO>(updatedUser);
    }

    public async Task<User> AuthenticateUserAsync(string username, string password)
    {
        return await _userRepository.AuthenticateUserAsync(username, password);
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        return await _userRepository.DeleteUserAsync(userId);
    }
}