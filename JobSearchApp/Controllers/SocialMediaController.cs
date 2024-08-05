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
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocialMediaDto>>> GetAllSocialMedias()
        {
            var socialMedias = await _socialMediaService.GetAllSocialMediasAsync();
            var socialMediaDtos = _mapper.Map<IEnumerable<SocialMediaDto>>(socialMedias);

            return Ok(socialMediaDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SocialMediaDto>> GetSocialMediaById(int id)
        {
            var socialMedia = await _socialMediaService.GetSocialMediaByIdAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }
            var socialMediaDto = _mapper.Map<SocialMediaDto>(socialMedia);
            return Ok(socialMediaDto);
        }

        [HttpPost]
        public async Task<ActionResult<SocialMediaDto>> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var createdSocialMedia = await _socialMediaService.CreateSocialMediaAsync(createSocialMediaDto);

            return CreatedAtAction(nameof(GetSocialMediaById), new { id = createdSocialMedia.SocialMediaId }, createdSocialMedia);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SocialMediaDto>> UpdateSocialMedia(int id, UpdateSocialMediaDto updateSocialMediaDto)
        {
            if (id != updateSocialMediaDto.SocialMediaId)
            {
                return BadRequest();
            }

            var updatedSocialMedia = await _socialMediaService.UpdateSocialMediaAsync(id, updateSocialMediaDto);
            if (updatedSocialMedia == null)
            {
                return NotFound();
            }

            var socialMediaDto = _mapper.Map<SocialMediaDto>(updatedSocialMedia);
            return Ok(socialMediaDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSocialMedia(int id)
        {
            var result = await _socialMediaService.DeleteSocialMediaAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
