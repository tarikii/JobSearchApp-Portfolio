using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class UserPreferenceDto
    {
        public int PreferenceId { get; set; }
        public int UserId { get; set; }
        public string? Category { get; set; }
        public string? Value { get; set; }

        public string? UserName { get; set; }

        public UserPreferenceDto(UserPreference userPreference)
        {
            PreferenceId = userPreference.PreferenceId;
            UserId = userPreference.UserId;
            Category = userPreference.Category;
            Value = userPreference.Value;
            UserName = userPreference.User?.UserName;
        }

        public UserPreferenceDto() { }
    }
    public class CreateUserPreferenceDto
    {
        public int UserId { get; set; }
        public string? Category { get; set; }
        public string? Value { get; set; }
    }
    public class UpdateUserPreferenceDto
    {
        public int PreferenceId { get; set; }

        public string? Category { get; set; }
        public string? Value { get; set; }
    }
}