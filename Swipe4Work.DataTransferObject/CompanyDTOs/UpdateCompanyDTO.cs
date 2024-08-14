namespace Swipe4Work.DataTransferObject
{
    public class UpdateCompanyDTO
    {
        public int CompanyId { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Industry { get; set; }
        public string? Size { get; set; }
        public string? Headquarters { get; set; }
        public int FoundedYear { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
    }
}
