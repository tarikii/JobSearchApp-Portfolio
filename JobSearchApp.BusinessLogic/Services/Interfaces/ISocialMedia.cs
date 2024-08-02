using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface ISocialMediaService
{
    Task<IEnumerable<SocialMediaDto>> GetAllSocialMediasAsync();
    Task<SocialMediaDto> GetSocialMediaByIdAsync(int id);
    Task<SocialMediaDto> CreateSocialMediaAsync(CreateSocialMediaDto socialMediaDto);
    Task<bool> UpdateSocialMediaAsync(int id, UpdateSocialMediaDto socialMediaDto);
    Task<bool> DeleteSocialMediaAsync(int id);
}

