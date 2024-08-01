using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ITagService
{
    Task<IEnumerable<TagDto>> GetAllTagsAsync();
    Task<TagDto> GetTagByIdAsync(int id);
    Task<TagDto> CreateTagAsync(TagDto tagDto);
    Task<bool> UpdateTagAsync(TagDto tagDto);
    Task<bool> DeleteTagAsync(int id);
}