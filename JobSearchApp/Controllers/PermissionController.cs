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
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetAllPermissions()
        {
            var permissions = await _permissionService.GetAllPermissionsAsync();
            var permissionDtos = _mapper.Map<IEnumerable<PermissionDto>>(permissions);

            return Ok(permissionDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionDto>> GetPermissionById(string name)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(name);
            if (permission == null)
            {
                return NotFound();
            }
            var permissionDto = _mapper.Map<PermissionDto>(permission);
            return Ok(permissionDto);
        }

        [HttpPost]
        public async Task<ActionResult<PermissionDto>> CreatePermission(CreatePermissionDto createPermissionDto)
        {
            var createdPermission = await _permissionService.CreatePermissionAsync(createPermissionDto);

            return CreatedAtAction(nameof(GetPermissionById), new { id = createdPermission.Name }, createdPermission);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PermissionDto>> UpdatePermission(string name, UpdatePermissionDto updatePermissionDto)
        {
            if (name != updatePermissionDto.Name)
            {
                return BadRequest();
            }

            var updatedPermission = await _permissionService.UpdatePermissionAsync(name, updatePermissionDto);
            if (updatedPermission == null)
            {
                return NotFound();
            }

            var permissionDto = _mapper.Map<PermissionDto>(updatedPermission);
            return Ok(permissionDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePermission(string name)
        {
            var result = await _permissionService.DeletePermissionAsync(name);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
