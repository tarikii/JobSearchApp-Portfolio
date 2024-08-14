using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;

        public PermissionService(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync()
        {
            var permissions = await _permissionRepository.GetAllPermissionsAsync();
            return _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
        }

        public async Task<PermissionDTO> GetPermissionByNameAsync(string name)
        {
            var permission = await _permissionRepository.GetPermissionByNameAsync(name);
            return permission == null ? null : _mapper.Map<PermissionDTO>(permission);
        }

        public async Task<PermissionDTO> CreatePermissionAsync(CreatePermissionDTO createPermissionDTO)
        {
            var permission = _mapper.Map<Permission>(createPermissionDTO);
            var createdPermission = await _permissionRepository.CreatePermissionAsync(permission);
            return _mapper.Map<PermissionDTO>(createdPermission);
        }

        public async Task<PermissionDTO> UpdatePermissionAsync(string name, UpdatePermissionDTO updatePermissionDTO)
        {
            if (name != updatePermissionDTO.Name)
            {
                return null;
            }

            var permission = _mapper.Map<Permission>(updatePermissionDTO);
            var updatedPermission = await _permissionRepository.UpdatePermissionAsync(permission);
            return _mapper.Map<PermissionDTO>(updatedPermission);
        }

        public async Task<bool> DeletePermissionAsync(string name)
        {
            return await _permissionRepository.DeletePermissionAsync(name);
        }
    }
}
