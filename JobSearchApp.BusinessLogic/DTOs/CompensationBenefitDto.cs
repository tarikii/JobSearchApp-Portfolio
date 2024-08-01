using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class CompensationBenefitDto
    {
        public int BenefitId { get; set; }
        public int CompanyId { get; set; }
        public string BenefitType { get; set; }
        public string Description { get; set; }

        public string CompanyName { get; set; }

        public CompensationBenefitDto(CompensationBenefit compensationBenefit)
        {
            BenefitId = compensationBenefit.BenefitId;
            CompanyId = compensationBenefit.CompanyId;
            BenefitType = compensationBenefit.BenefitType;
            Description = compensationBenefit.Description;
            CompanyName = compensationBenefit.Company?.Name;
        }
    }
    public class CreateCompensationBenefitDto
    {
        public int CompanyId { get; set; }
        public string BenefitType { get; set; }
        public string Description { get; set; }
    }
    
    public class UpdateCompensationBenefitDto
    {
        public string BenefitType { get; set; }
        public string Description { get; set; }
    }
}