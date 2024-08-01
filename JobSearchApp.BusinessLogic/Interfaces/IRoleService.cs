using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    Task<RoleDto> GetRoleByIdAsync(int id);
    Task<RoleDto> CreateRoleAsync(RoleDto roleDto);
    Task<bool> UpdateRoleAsync(RoleDto roleDto);
    Task<bool> DeleteRoleAsync(int id);
}