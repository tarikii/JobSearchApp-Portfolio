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
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDto>>> GetAllTags()
        {
            var tags = await _tagService.GetAllTagsAsync();
            var tagDtos = _mapper.Map<IEnumerable<TagDto>>(tags);

            return Ok(tagDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagDto>> GetTagById(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            var tagDto = _mapper.Map<TagDto>(tag);
            return Ok(tagDto);
        }

        [HttpPost]
        public async Task<ActionResult<TagDto>> CreateTag(CreateTagDto createTagDto)
        {
            var createdTag = await _tagService.CreateTagAsync(createTagDto);

            return CreatedAtAction(nameof(GetTagById), new { id = createdTag.TagId }, createdTag);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TagDto>> UpdateTag(int id, UpdateTagDto updateTagDto)
        {
            if (id != updateTagDto.TagId)
            {
                return BadRequest();
            }

            var updatedTag = await _tagService.UpdateTagAsync(id, updateTagDto);
            if (updatedTag == null)
            {
                return NotFound();
            }

            var tagDto = _mapper.Map<TagDto>(updatedTag);
            return Ok(tagDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTag(int id)
        {
            var result = await _tagService.DeleteTagAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
