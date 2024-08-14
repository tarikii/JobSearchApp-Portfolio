using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionPatentController : ControllerBase
    {
        private readonly IRolePermissionPatentService _rolePermissionPatentService;
        private readonly IMapper _mapper;

        public RolePermissionPatentController(IRolePermissionPatentService rolePermissionPatentService, IMapper mapper)
        {
            _rolePermissionPatentService = rolePermissionPatentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolePermissionPatentDto>>> GetAllRolePermissionPatents()
        {
            var patents = await _rolePermissionPatentService.GetAllRolePermissionPatentsAsync();
            var patentDtos = _mapper.Map<IEnumerable<RolePermissionPatentDto>>(patents);

            return Ok(patentDtos);
        }

        [HttpGet("{roleId}/{resourceId}/{permission}")]
        public async Task<ActionResult<RolePermissionPatentDto>> GetRolePermissionPatentById(int roleId, int resourceId, string permission)
        {
            var patent = await _rolePermissionPatentService.GetRolePermissionPatentByIdAsync(roleId, resourceId, permission);
            if (patent == null)
            {
                return NotFound();
            }
            var patentDto = _mapper.Map<RolePermissionPatentDto>(patent);
            return Ok(patentDto);
        }

        [HttpPost]
        public async Task<ActionResult<RolePermissionPatentDto>> CreateRolePermissionPatent(CreateRolePermissionPatentDto createPatentDto)
        {
            var createdPatent = await _rolePermissionPatentService.CreateRolePermissionPatentAsync(createPatentDto);

            return CreatedAtAction(nameof(GetRolePermissionPatentById), new { roleId = createdPatent.RoleId, resourceId = createdPatent.ResourceId, permission = createdPatent.Permission }, createdPatent);
        }

        [HttpPut("{roleId}/{resourceId}/{permission}")]
        public async Task<ActionResult<RolePermissionPatentDto>> UpdateRolePermissionPatent(int roleId, int resourceId, string permission, UpdateRolePermissionPatentDto updatePatentDto)
        {
            if (roleId != updatePatentDto.RoleId || resourceId != updatePatentDto.ResourceId || permission != updatePatentDto.Permission)
            {
                return BadRequest();
            }

            var updatedPatent = await _rolePermissionPatentService.UpdateRolePermissionPatentAsync(roleId, resourceId, permission, updatePatentDto);
            if (updatedPatent == null)
            {
                return NotFound();
            }

            var patentDto = _mapper.Map<RolePermissionPatentDto>(updatedPatent);
            return Ok(patentDto);
        }

        [HttpDelete("{roleId}/{resourceId}/{permission}")]
        public async Task<ActionResult> DeleteRolePermissionPatent(int roleId, int resourceId, string permission)
        {
            var result = await _rolePermissionPatentService.DeleteRolePermissionPatentAsync(roleId, resourceId, permission);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
