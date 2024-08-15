using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class SocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public int UserId { get; set; }
        public string? Platform { get; set; }
        public string? Url { get; set; }

        public string? UserName { get; set; }

        public SocialMediaDto(SocialMedia socialMedia)
        {
            SocialMediaId = socialMedia.SocialMediaId;
            UserId = socialMedia.UserId;
            Platform = socialMedia.Platform;
            Url = socialMedia.Url;
            UserName = socialMedia.User?.UserName;
        }
    }
    public class CreateSocialMediaDto
    {
        public int UserId { get; set; }
        public string? Platform { get; set; }
        public string? Url { get; set; }
    }
    public class UpdateSocialMediaDto
    {
        public int SocialMediaId { get; set; }

        public string? Platform { get; set; }
        public string? Url { get; set; }
    }
}