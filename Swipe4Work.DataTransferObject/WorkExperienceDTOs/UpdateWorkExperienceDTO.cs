
namespace Swipe4Work.DataTransferObject
{
    public class UpdateWorkExperienceDTO
    {
        public int WorkExperienceId { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
    }
}
