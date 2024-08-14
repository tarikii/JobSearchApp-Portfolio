using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
{
    public class RolePermissionPatentService : IRolePermissionPatentService
    {
        private readonly IRolePermissionPatentRepository _rolePermissionPatentRepository;
        private readonly IMapper _mapper;

        public RolePermissionPatentService(IRolePermissionPatentRepository rolePermissionPatentRepository, IMapper mapper)
        {
            _rolePermissionPatentRepository = rolePermissionPatentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolePermissionPatentDTO>> GetAllRolePermissionPatentsAsync()
        {
            var rolePermissionPatents = await _rolePermissionPatentRepository.GetAllRolePermissionPatentsAsync();
            return _mapper.Map<IEnumerable<RolePermissionPatentDTO>>(rolePermissionPatents);
        }

        public async Task<RolePermissionPatentDTO> GetRolePermissionPatentByIdAsync(int roleId, int resourceId, string permission)
        {
            var rolePermissionPatent = await _rolePermissionPatentRepository.GetRolePermissionPatentByIdAsync(roleId, resourceId, permission);
            return rolePermissionPatent == null ? null : _mapper.Map<RolePermissionPatentDTO>(rolePermissionPatent);
        }

        public async Task<RolePermissionPatentDTO> CreateRolePermissionPatentAsync(CreateRolePermissionPatentDTO createRolePermissionPatentDTO)
        {
            var rolePermissionPatent = _mapper.Map<RolePermissionPatent>(createRolePermissionPatentDTO);
            var createdRolePermissionPatent = await _rolePermissionPatentRepository.CreateRolePermissionPatentAsync(rolePermissionPatent);
            return _mapper.Map<RolePermissionPatentDTO>(createdRolePermissionPatent);
        }

        public async Task<RolePermissionPatentDTO> UpdateRolePermissionPatentAsync(int roleId, int resourceId, string permission, UpdateRolePermissionPatentDTO updateRolePermissionPatentDTO)
        {
            if (roleId != updateRolePermissionPatentDTO.RoleId || resourceId != updateRolePermissionPatentDTO.ResourceId || permission != updateRolePermissionPatentDTO.Permission)
            {
                return null;
            }

            var rolePermissionPatent = _mapper.Map<RolePermissionPatent>(updateRolePermissionPatentDTO);
            var updatedRolePermissionPatent = await _rolePermissionPatentRepository.UpdateRolePermissionPatentAsync(rolePermissionPatent);
            return _mapper.Map<RolePermissionPatentDTO>(updatedRolePermissionPatent);
        }

        public async Task<bool> DeleteRolePermissionPatentAsync(int roleId, int resourceId, string permission)
        {
            return await _rolePermissionPatentRepository.DeleteRolePermissionPatentAsync(roleId, resourceId, permission);
        }
    }
}
