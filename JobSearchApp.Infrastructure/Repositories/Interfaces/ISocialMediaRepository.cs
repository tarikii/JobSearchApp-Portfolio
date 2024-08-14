using System.Collections.Generic;
using System.Threading.Tasks;
using JobSearchApp.Domain.Models;

namespace JobSearchApp.Infrastructure.Interfaces
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