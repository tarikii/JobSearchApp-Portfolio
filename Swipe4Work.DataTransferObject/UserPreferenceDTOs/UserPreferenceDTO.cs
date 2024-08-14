using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject
{
    public class UserPreferenceDTO
    {
        public int PreferenceId { get; set; }
        public int UserId { get; set; }
        public string? Category { get; set; }
        public string? Value { get; set; }

        public string? UserName { get; set; }

        public UserPreferenceDTO(UserPreference userPreference)
        {
            PreferenceId = userPreference.PreferenceId;
            UserId = userPreference.UserId;
            Category = userPreference.Category;
            Value = userPreference.Value;
            UserName = userPreference.User?.UserName;
        }
        public UserPreferenceDTO() { }

    }
}
