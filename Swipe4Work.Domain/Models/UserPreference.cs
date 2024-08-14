namespace Swipe4Work.Domain.Models
{
    public class UserPreference
    {
        public int PreferenceId { get; set; }
        public int UserId { get; set; }
        public string? Category { get; set; }
        public string? Value { get; set; }

        public User? User { get; set; }
    }
}
