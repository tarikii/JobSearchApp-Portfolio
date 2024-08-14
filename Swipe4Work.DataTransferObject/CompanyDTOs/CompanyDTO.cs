using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Industry { get; set; }
        public string? Size { get; set; }
        public string? Headquarters { get; set; }
        public int FoundedYear { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }

        public CompanyDTO(Company company)
        {
            CompanyId = company.CompanyId;
            Name = company.Name;
            WebsiteUrl = company.WebsiteUrl;
            Industry = company.Industry;
            Size = company.Size;
            Headquarters = company.Headquarters;
            FoundedYear = company.FoundedYear;
            Description = company.Description;
            Location = company.Location;
        }

        public CompanyDTO() { }
    }
}
