using JobSearchApp.Domain.Models;

namespace JobSearchApp.Domain.DTOs
{
    public class CompanyTagDto
    {
        public int CompanyId { get; set; }
        public int TagId { get; set; }
        public string CompanyName { get; set; }
        public string TagName { get; set; }

        public CompanyTagDto(CompanyTag companyTag)
        {
            CompanyId = companyTag.CompanyId;
            TagId = companyTag.TagId;
            CompanyName = companyTag.Company?.Name;
            TagName = companyTag.Tag?.TagName;
        }
    }
}