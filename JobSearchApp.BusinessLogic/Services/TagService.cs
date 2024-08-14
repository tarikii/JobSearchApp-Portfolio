using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> GetAllTagsAsync()
        {
            var tags = await _tagRepository.GetAllTagsAsync();
            return _mapper.Map<IEnumerable<TagDto>>(tags);
        }

        public async Task<TagDto> GetTagByIdAsync(int tagId)
        {
            var tag = await _tagRepository.GetTagByIdAsync(tagId);
            return tag == null ? null : _mapper.Map<TagDto>(tag);
        }

        public async Task<TagDto> CreateTagAsync(CreateTagDto createTagDto)
        {
            var tag = _mapper.Map<Tag>(createTagDto);
            var createdTag = await _tagRepository.CreateTagAsync(tag);
            return _mapper.Map<TagDto>(createdTag);
        }

        public async Task<TagDto> UpdateTagAsync(int tagId, UpdateTagDto updateTagDto)
        {
            if (tagId != updateTagDto.TagId)
            {
                return null;
            }

            var tag = _mapper.Map<Tag>(updateTagDto);
            var updatedTag = await _tagRepository.UpdateTagAsync(tag);
            return _mapper.Map<TagDto>(updatedTag);
        }

        public async Task<bool> DeleteTagAsync(int tagId)
        {
            return await _tagRepository.DeleteTagAsync(tagId);
        }
    }
}