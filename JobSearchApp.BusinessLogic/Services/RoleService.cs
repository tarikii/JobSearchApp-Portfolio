using System.Collections.Generic;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
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

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetRoleByIdAsync(int roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);
            return role == null ? null : _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            var role = _mapper.Map<Role>(createRoleDto);
            var createdRole = await _roleRepository.CreateRoleAsync(role);
            return _mapper.Map<RoleDto>(createdRole);
        }

        public async Task<RoleDto> UpdateRoleAsync(int roleId, UpdateRoleDto updateRoleDto)
        {
            if (roleId != updateRoleDto.RoleId)
            {
                return null;
            }

            var role = _mapper.Map<Role>(updateRoleDto);
            var updatedRole = await _roleRepository.UpdateRoleAsync(role);
            return _mapper.Map<RoleDto>(updatedRole);
        }

        public async Task<bool> DeleteRoleAsync(int roleId)
        {
            return await _roleRepository.DeleteRoleAsync(roleId);
        }
    }
}