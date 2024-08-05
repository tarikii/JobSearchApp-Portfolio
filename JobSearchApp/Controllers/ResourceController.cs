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
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        private readonly IMapper _mapper;

        public ResourceController(IResourceService resourceService, IMapper mapper)
        {
            _resourceService = resourceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetAllResources()
        {
            var resources = await _resourceService.GetAllResourcesAsync();
            var resourceDtos = _mapper.Map<IEnumerable<ResourceDto>>(resources);

            return Ok(resourceDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResourceDto>> GetResourceById(int id)
        {
            var resource = await _resourceService.GetResourceByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            var resourceDto = _mapper.Map<ResourceDto>(resource);
            return Ok(resourceDto);
        }

        [HttpPost]
        public async Task<ActionResult<ResourceDto>> CreateResource(CreateResourceDto createResourceDto)
        {
            var createdResource = await _resourceService.CreateResourceAsync(createResourceDto);

            return CreatedAtAction(nameof(GetResourceById), new { id = createdResource.ResourceId }, createdResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResourceDto>> UpdateResource(int id, UpdateResourceDto updateResourceDto)
        {
            if (id != updateResourceDto.ResourceId)
            {
                return BadRequest();
            }

            var updatedResource = await _resourceService.UpdateResourceAsync(id, updateResourceDto);
            if (updatedResource == null)
            {
                return NotFound();
            }

            var resourceDto = _mapper.Map<ResourceDto>(updatedResource);
            return Ok(resourceDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteResource(int id)
        {
            var result = await _resourceService.DeleteResourceAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
