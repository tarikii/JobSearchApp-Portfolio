using Swipe4Work.DataTransferObject;
namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
    Task<RoleDTO> GetRoleByIdAsync(int roleId);
    Task<RoleDTO> CreateRoleAsync(CreateRoleDTO createRoleDTO);
    Task<RoleDTO> UpdateRoleAsync(int roleId, UpdateRoleDTO updateRoleDTO);
    Task<bool> DeleteRoleAsync(int roleId);
}