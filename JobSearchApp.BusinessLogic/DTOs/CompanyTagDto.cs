using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class CompanyTagDto
    {
        public int CompanyId { get; set; }
        public int TagId { get; set; }
        public string? CompanyName { get; set; }
        public string? TagName { get; set; }

        public CompanyTagDto(CompanyTag companyTag)
        {
            CompanyId = companyTag.CompanyId;
            TagId = companyTag.TagId;
            CompanyName = companyTag.Company?.Name;
            TagName = companyTag.Tag?.TagName;
        }
      
    }
    public class CreateCompanyTagDto
    {
        public int TagId { get; set; }
        public string? CompayName { get; set; }
        public string? TagName { get; set; }
    }
        
    public class UpdateCompanyTagDto
    {
        public int CompanyTagId { get; set; }
        public string? TagId { get; set; }
        public string? CompayName { get; set; }
        public string? TagName { get; set; }
    }
}