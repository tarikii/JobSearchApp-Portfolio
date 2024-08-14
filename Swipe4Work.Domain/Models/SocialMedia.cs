namespace Swipe4Work.Domain.Models
{
    public class SocialMedia
    {

        public int SocialMediaId { get; set; }
        public int UserId { get; set; }
        public string? Platform { get; set; }
        public string? Url { get; set; }

        public User? User { get; set; }
    }
}
