using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ITagService
{
    Task<IEnumerable<TagDto>> GetAllTagsAsync();
    Task<TagDto> GetTagByIdAsync(int tagId);
    Task<TagDto> CreateTagAsync(CreateTagDto createTagDto);
    Task<TagDto> UpdateTagAsync(int tagId, UpdateTagDto updateTagDto);
    Task<bool> DeleteTagAsync(int tagId);
}