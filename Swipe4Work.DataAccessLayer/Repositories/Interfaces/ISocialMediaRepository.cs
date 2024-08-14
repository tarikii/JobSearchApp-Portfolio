using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataAccessLayer.Interfaces
{
    public interface ISocialMediaRepository
    {
        Task<IEnumerable<SocialMedia>> GetAllSocialMediasAsync();
        Task<SocialMedia> GetSocialMediaByIdAsync(int socialMediaId);
        Task<SocialMedia> CreateSocialMediaAsync(SocialMedia socialMedia);
        Task<SocialMedia> UpdateSocialMediaAsync(SocialMedia socialMedia);
        Task<bool> DeleteSocialMediaAsync(int socialMediaId);
    }
}