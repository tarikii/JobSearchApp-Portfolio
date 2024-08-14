using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public async Task<RoleDTO> GetRoleByIdAsync(int roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);
            return role == null ? null : _mapper.Map<RoleDTO>(role);
        }

        public async Task<RoleDTO> CreateRoleAsync(CreateRoleDTO createRoleDTO)
        {
            var role = _mapper.Map<Role>(createRoleDTO);
            var createdRole = await _roleRepository.CreateRoleAsync(role);
            return _mapper.Map<RoleDTO>(createdRole);
        }

        public async Task<RoleDTO> UpdateRoleAsync(int roleId, UpdateRoleDTO updateRoleDTO)
        {
            if (roleId != updateRoleDTO.RoleId)
            {
                return null;
            }

            var role = _mapper.Map<Role>(updateRoleDTO);
            var updatedRole = await _roleRepository.UpdateRoleAsync(role);
            return _mapper.Map<RoleDTO>(updatedRole);
        }

        public async Task<bool> DeleteRoleAsync(int roleId)
        {
            return await _roleRepository.DeleteRoleAsync(roleId);
        }
    }
}