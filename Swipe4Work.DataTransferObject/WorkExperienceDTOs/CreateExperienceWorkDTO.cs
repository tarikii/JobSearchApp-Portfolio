namespace Swipe4Work.DataTransferObject
{
    public class CreateWorkExperienceDTO
    {
        public int UserId { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
    }
}
