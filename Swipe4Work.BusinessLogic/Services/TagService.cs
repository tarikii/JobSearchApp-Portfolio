using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<TagDTO>> GetAllTagsAsync()
        {
            var tags = await _tagRepository.GetAllTagsAsync();
            return _mapper.Map<IEnumerable<TagDTO>>(tags);
        }

        public async Task<TagDTO> GetTagByIdAsync(int tagId)
        {
            var tag = await _tagRepository.GetTagByIdAsync(tagId);
            return tag == null ? null : _mapper.Map<TagDTO>(tag);
        }

        public async Task<TagDTO> CreateTagAsync(CreateTagDTO createTagDTO)
        {
            var tag = _mapper.Map<Tag>(createTagDTO);
            var createdTag = await _tagRepository.CreateTagAsync(tag);
            return _mapper.Map<TagDTO>(createdTag);
        }

        public async Task<TagDTO> UpdateTagAsync(int tagId, UpdateTagDTO updateTagDTO)
        {
            if (tagId != updateTagDTO.TagId)
            {
                return null;
            }

            var tag = _mapper.Map<Tag>(updateTagDTO);
            var updatedTag = await _tagRepository.UpdateTagAsync(tag);
            return _mapper.Map<TagDTO>(updatedTag);
        }

        public async Task<bool> DeleteTagAsync(int tagId)
        {
            return await _tagRepository.DeleteTagAsync(tagId);
        }
    }
}