using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ISocialMediaService
{
    Task<IEnumerable<SocialMediaDto>> GetAllSocialMediasAsync();
    Task<SocialMediaDto> GetSocialMediaByIdAsync(int id);
    Task<SocialMediaDto> CreateSocialMediaAsync(SocialMediaDto socialMediaDto);
    Task<bool> UpdateSocialMediaAsync(SocialMediaDto socialMediaDto);
    Task<bool> DeleteSocialMediaAsync(int id);
}