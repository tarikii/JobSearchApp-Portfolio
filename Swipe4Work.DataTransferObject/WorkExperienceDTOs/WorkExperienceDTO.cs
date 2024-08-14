using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject
{
    public class WorkExperienceDTO
    {
        public int WorkExperienceId { get; set; }
        public int UserId { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }

        public string? UserName { get; set; }

        //public WorkExperienceDTO(WorkExperience workExperience)
        //{
        //    WorkExperienceId = workExperience.WorkExperienceId;
        //    UserId = workExperience.UserId;
        //    CompanyName = workExperience.CompanyName;
        //    JobTitle = workExperience.JobTitle;
        //    StartDate = workExperience.StartDate;
        //    EndDate = workExperience.EndDate;
        //    Description = workExperience.Description;
        //    Location = workExperience.Location;
        //    UserName = workExperience.User?.UserName;
        //}
        //public WorkExperienceDTO() { }

    }
}
