using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject
{
    public class SocialMediaDTO
    {
        public int SocialMediaId { get; set; }
        public int UserId { get; set; }
        public string? Platform { get; set; }
        public string? Url { get; set; }

        public string? UserName { get; set; }

        //public SocialMediaDTO(SocialMedia socialMedia)
        //{
        //    SocialMediaId = socialMedia.SocialMediaId;
        //    UserId = socialMedia.UserId;
        //    Platform = socialMedia.Platform;
        //    Url = socialMedia.Url;
        //    UserName = socialMedia.User?.UserName;
        //}
        //public SocialMediaDTO() { }

    }
}
