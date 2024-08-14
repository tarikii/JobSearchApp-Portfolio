using Swipe4Work.Domain.Models;


namespace Swipe4Work.DataTransferObject
{
    public class CompensationBenefitDTO
    {
        public int BenefitId { get; set; }
        public int CompanyId { get; set; }
        public string? BenefitType { get; set; }
        public string? Description { get; set; }

        public string? CompanyName { get; set; }

        //public CompensationBenefitDTO(CompensationBenefit compensationBenefit)
        //{
        //    BenefitId = compensationBenefit.BenefitId;
        //    CompanyId = compensationBenefit.CompanyId;
        //    BenefitType = compensationBenefit.BenefitType;
        //    Description = compensationBenefit.Description;
        //    CompanyName = compensationBenefit.Company?.Name;
        //}
        //public CompensationBenefitDTO() { }

    }
}
