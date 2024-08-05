using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
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

        public async Task<IEnumerable<RolePermissionPatentDto>> GetAllRolePermissionPatentsAsync()
        {
            var rolePermissionPatents = await _rolePermissionPatentRepository.GetAllRolePermissionPatentsAsync();
            return _mapper.Map<IEnumerable<RolePermissionPatentDto>>(rolePermissionPatents);
        }

        public async Task<RolePermissionPatentDto> GetRolePermissionPatentByIdAsync(int roleId, int resourceId, string permission)
        {
            var rolePermissionPatent = await _rolePermissionPatentRepository.GetRolePermissionPatentByIdAsync(roleId, resourceId, permission);
            return rolePermissionPatent == null ? null : _mapper.Map<RolePermissionPatentDto>(rolePermissionPatent);
        }

        public async Task<RolePermissionPatentDto> CreateRolePermissionPatentAsync(CreateRolePermissionPatentDto createRolePermissionPatentDto)
        {
            var rolePermissionPatent = _mapper.Map<RolePermissionPatent>(createRolePermissionPatentDto);
            var createdRolePermissionPatent = await _rolePermissionPatentRepository.CreateRolePermissionPatentAsync(rolePermissionPatent);
            return _mapper.Map<RolePermissionPatentDto>(createdRolePermissionPatent);
        }

        public async Task<RolePermissionPatentDto> UpdateRolePermissionPatentAsync(int roleId, int resourceId, string permission, UpdateRolePermissionPatentDto updateRolePermissionPatentDto)
        {
            if (roleId != updateRolePermissionPatentDto.RoleId || resourceId != updateRolePermissionPatentDto.ResourceId || permission != updateRolePermissionPatentDto.Permission)
            {
                return null;
            }

            var rolePermissionPatent = _mapper.Map<RolePermissionPatent>(updateRolePermissionPatentDto);
            var updatedRolePermissionPatent = await _rolePermissionPatentRepository.UpdateRolePermissionPatentAsync(rolePermissionPatent);
            return _mapper.Map<RolePermissionPatentDto>(updatedRolePermissionPatent);
        }

        public async Task<bool> DeleteRolePermissionPatentAsync(int roleId, int resourceId, string permission)
        {
            return await _rolePermissionPatentRepository.DeleteRolePermissionPatentAsync(roleId, resourceId, permission);
        }
    }
}
