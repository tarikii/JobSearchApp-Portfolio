using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class WorkExperienceDto
    {
        public int WorkExperienceId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public string UserName { get; set; }

        public WorkExperienceDto(WorkExperience workExperience)
        {
            WorkExperienceId = workExperience.WorkExperienceId;
            UserId = workExperience.UserId;
            CompanyName = workExperience.CompanyName;
            JobTitle = workExperience.JobTitle;
            StartDate = workExperience.StartDate;
            EndDate = workExperience.EndDate;
            Description = workExperience.Description;
            Location = workExperience.Location;
            UserName = workExperience.User?.UserName;
        }
        public WorkExperienceDto(){}

    }
    public class CreateWorkExperienceDto
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
    public class UpdateWorkExperienceDto
    {
        public int WorkExperienceId { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}