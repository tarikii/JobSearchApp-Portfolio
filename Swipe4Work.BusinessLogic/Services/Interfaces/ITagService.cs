using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface ITagService
{
    Task<IEnumerable<TagDTO>> GetAllTagsAsync();
    Task<TagDTO> GetTagByIdAsync(int tagId);
    Task<TagDTO> CreateTagAsync(CreateTagDTO createTagDTO);
    Task<TagDTO> UpdateTagAsync(int tagId, UpdateTagDTO updateTagDTO);
    Task<bool> DeleteTagAsync(int tagId);
}