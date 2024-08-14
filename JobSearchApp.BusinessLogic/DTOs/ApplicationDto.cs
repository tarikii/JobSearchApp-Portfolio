using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class ApplicationDto
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public int JobOfferId { get; set; }
        public DateTimeOffset ApplicationDate { get; set; }
        public string Status { get; set; }
        public decimal SalaryExpected { get; set; }

        public string UserName { get; set; }
        public string JobTitle { get; set; }

        public ApplicationDto(Application application)
        {
            ApplicationId = application.ApplicationId;
            UserId = application.UserId;
            JobOfferId = application.JobOfferId;
            ApplicationDate = application.ApplicationDate;
            Status = application.Status;
            SalaryExpected = application.SalaryExpected;
            UserName = application.User?.UserName;
            JobTitle = application.JobOffer?.Title;
        }
    }
    public class CreateApplicationDto
    {
        public int UserId { get; set; }
        public int JobOfferId { get; set; }
        public DateTimeOffset ApplicationDate { get; set; } = DateTimeOffset.Now;
        public string Status { get; set; } = "Pending";
        public decimal SalaryExpected { get; set; }
    }
    
    public class UpdateApplicationDto
    {
        public int ApplicationId { get; set; }
        public string Status { get; set; }
        public decimal SalaryExpected { get; set; }
    }
}