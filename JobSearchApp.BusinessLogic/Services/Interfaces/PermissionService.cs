using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
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

        public async Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync()
        {
            var permissions = await _permissionRepository.GetAllPermissionsAsync();
            return _mapper.Map<IEnumerable<PermissionDto>>(permissions);
        }

        public async Task<PermissionDto> GetPermissionByNameAsync(string name)
        {
            var permission = await _permissionRepository.GetPermissionByNameAsync(name);
            return permission == null ? null : _mapper.Map<PermissionDto>(permission);
        }

        public async Task<PermissionDto> CreatePermissionAsync(CreatePermissionDto createPermissionDto)
        {
            var permission = _mapper.Map<Permission>(createPermissionDto);
            var createdPermission = await _permissionRepository.CreatePermissionAsync(permission);
            return _mapper.Map<PermissionDto>(createdPermission);
        }

        public async Task<PermissionDto> UpdatePermissionAsync(string name, UpdatePermissionDto updatePermissionDto)
        {
            if (name != updatePermissionDto.Name)
            {
                return null;
            }

            var permission = _mapper.Map<Permission>(updatePermissionDto);
            var updatedPermission = await _permissionRepository.UpdatePermissionAsync(permission);
            return _mapper.Map<PermissionDto>(updatedPermission);
        }

        public async Task<bool> DeletePermissionAsync(string name)
        {
            return await _permissionRepository.DeletePermissionAsync(name);
        }
    }
}
