using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataAccessLayer.Interfaces;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllRolesAsync();
    Task<Role> GetRoleByIdAsync(int roleId);
    Task<Role> CreateRoleAsync(Role role);
    Task<Role> UpdateRoleAsync(Role role);
    Task<bool> DeleteRoleAsync(int roleId);
}