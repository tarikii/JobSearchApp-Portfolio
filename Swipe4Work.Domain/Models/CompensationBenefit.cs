namespace Swipe4Work.Domain.Models
{
    public class CompensationBenefit
    {
        public int BenefitId { get; set; }
        public int CompanyId { get; set; }
        public string? BenefitType { get; set; }
        public string? Description { get; set; }

        public Company? Company { get; set; }
    }
}
