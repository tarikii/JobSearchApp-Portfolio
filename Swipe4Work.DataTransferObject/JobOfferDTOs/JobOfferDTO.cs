using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject
{
    public class JobOfferDTO
    {
        public int JobOfferId { get; set; }
        public int CompanyId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? JobType { get; set; }
        public string? ExperienceLevel { get; set; }
        public DateTimeOffset PostedDate { get; set; }
        public DateTimeOffset? ExpiredDate { get; set; }
        public bool IsActive { get; set; }
        public int EstimatedDurationDays { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }

        public string? CompanyName { get; set; }

        //public JobOfferDTO(JobOffer jobOffer)
        //{
        //    JobOfferId = jobOffer.JobOfferId;
        //    CompanyId = jobOffer.CompanyId;
        //    Title = jobOffer.Title;
        //    Description = jobOffer.Description;
        //    Location = jobOffer.Location;
        //    JobType = jobOffer.JobType;
        //    ExperienceLevel = jobOffer.ExperienceLevel;
        //    PostedDate = jobOffer.PostedDate;
        //    ExpiredDate = jobOffer.ExpiredDate;
        //    IsActive = jobOffer.IsActive;
        //    EstimatedDurationDays = jobOffer.EstimatedDurationDays;
        //    MinSalary = jobOffer.MinSalary;
        //    MaxSalary = jobOffer.MaxSalary;
        //    CompanyName = jobOffer.Company?.Name;
        //}


    }
}
