using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject { 
    public class CompanyTagDTO
    {
        public int CompanyId { get; set; }
        public int TagId { get; set; }
        public string? CompanyName { get; set; }
        public string? TagName { get; set; }

        public CompanyTagDTO(CompanyTag companyTag)
        {
            CompanyId = companyTag.CompanyId;
            TagId = companyTag.TagId;
            CompanyName = companyTag.Company?.Name;
            TagName = companyTag.Tag?.TagName;
        }

        public CompanyTagDTO() { }

    }
}
