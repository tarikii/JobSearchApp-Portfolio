using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;
namespace Swipe4Work.DataAccessLayer
{
    public class SocialMediaRepository : ISocialMediaRepository
    {
        private readonly ApplicationDbContext _context;

        public SocialMediaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SocialMedia>> GetAllSocialMediasAsync()
        {
            return await _context.SocialMedias.ToListAsync();
        }

        public async Task<SocialMedia> GetSocialMediaByIdAsync(int socialMediaId)
        {
            return await _context.SocialMedias.FindAsync(socialMediaId);
        }

        public async Task<SocialMedia> CreateSocialMediaAsync(SocialMedia socialMedia)
        {
            _context.SocialMedias.Add(socialMedia);
            await _context.SaveChangesAsync();
            return socialMedia;
        }

        public async Task<SocialMedia> UpdateSocialMediaAsync(SocialMedia socialMedia)
        {
            _context.SocialMedias.Update(socialMedia);
            await _context.SaveChangesAsync();
            return socialMedia;
        }

        public async Task<bool> DeleteSocialMediaAsync(int socialMediaId)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(socialMediaId);
            if (socialMedia == null)
            {
                return false;
            }

            _context.SocialMedias.Remove(socialMedia);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}