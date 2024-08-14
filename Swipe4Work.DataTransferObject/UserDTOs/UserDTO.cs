namespace Swipe4Work.DataTransferObject
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Headline { get; set; }
        public string? Summary { get; set; }
        public string? Location { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GenderIdentity { get; set; }
        public string? Pronoun { get; set; }
        public string? Ethnicity { get; set; }
        public string? MobileNumber { get; set; }
        public bool RequireVisa { get; set; }
        public string? SearchStage { get; set; }
        public string? ProfilePicture { get; set; }
        public string? ProfileUrl { get; set; }
        public string? PortfolioUrl { get; set; }
        public string? RoleName { get; set; }
        public string? CompanyName { get; set; }
        public bool IsWorking { get; set; }

    }
}
