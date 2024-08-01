using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class EducationDto
    {
        public int EducationId { get; set; }
        public int UserId { get; set; }
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Grade { get; set; }
        public string ActivitiesAndSocieties { get; set; }
        public string Description { get; set; }

        public string UserName { get; set; }

        public EducationDto(Education education)
        {
            EducationId = education.EducationId;
            UserId = education.UserId;
            SchoolName = education.SchoolName;
            Degree = education.Degree;
            FieldOfStudy = education.FieldOfStudy;
            StartDate = education.StartDate;
            EndDate = education.EndDate;
            Grade = education.Grade;
            ActivitiesAndSocieties = education.ActivitiesAndSocieties;
            Description = education.Description;
            UserName = education.User?.UserName;
        }
    }
    public class CreateEducationDto
    {
        public int UserId { get; set; }
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Grade { get; set; }
        public string ActivitiesAndSocieties { get; set; }
        public string Description { get; set; }
    }
    public class UpdateEducationDto
    {
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Grade { get; set; }
        public string ActivitiesAndSocieties { get; set; }
        public string Description { get; set; }
    }
}