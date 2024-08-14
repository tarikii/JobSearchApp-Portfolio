namespace Swipe4Work.Domain.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public int JobOfferId { get; set; }
        public DateTimeOffset ApplicationDate { get; set; }
        public string? Status { get; set; }
        public decimal SalaryExpected { get; set; }

        public User? User { get; set; }
        public JobOffer? JobOffer { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
