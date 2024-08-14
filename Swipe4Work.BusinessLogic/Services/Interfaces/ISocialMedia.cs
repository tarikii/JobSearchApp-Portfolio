using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface ISocialMediaService
{
    Task<IEnumerable<SocialMediaDTO>> GetAllSocialMediasAsync();
    Task<SocialMediaDTO> GetSocialMediaByIdAsync(int id);
    Task<SocialMediaDTO> CreateSocialMediaAsync(CreateSocialMediaDTO socialMediaDTO);
    Task<SocialMediaDTO> UpdateSocialMediaAsync(int id, UpdateSocialMediaDTO socialMediaDTO);
    Task<bool> DeleteSocialMediaAsync(int id);
}

