using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject
{
    public class ApplicationDTO
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public int JobOfferId { get; set; }
        public DateTimeOffset ApplicationDate { get; set; }
        public string? Status { get; set; }
        public decimal SalaryExpected { get; set; }

        public string? UserName { get; set; }
        public string? JobTitle { get; set; }

        public ApplicationDTO(Application application)
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
        public ApplicationDTO() { }

    }
}
