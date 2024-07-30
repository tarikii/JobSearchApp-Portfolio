using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs;

public class UserDto
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Headline { get; set; }
    public string Summary { get; set; }
    public string Location { get; set; }
    public string LinkedInUrl { get; set; }
    public string GenderIdentity { get; set; }
    public string Pronoun { get; set; }
    public string Ethnicity { get; set; }
    public string MobileNumber { get; set; }
    public bool RequireVisa { get; set; }
    public string SearchStage { get; set; }
    public string ProfilePicture { get; set; }
    public string ProfileUrl { get; set; }
    public string PortfolioUrl { get; set; }
    public string RoleName { get; set; }
    public string CompanyName { get; set; }
    public bool IsWorking { get; set; }

    public UserDto(User user)
    {
        UserId = user.UserId;
        Email = user.Email;
        UserName = user.UserName;
        FullName = $"{user.FirstName} {user.LastName}";
        Headline = user.Headline;
        Summary = user.Summary;
        Location = user.Location;
        LinkedInUrl = user.LinkedInUrl;
        GenderIdentity = user.GenderIdentity;
        Pronoun = user.Pronoun;
        Ethnicity = user.Ethnicity;
        MobileNumber = user.MobileNumber;
        RequireVisa = user.RequireVisa;
        SearchStage = user.SearchStage;
        ProfilePicture = user.ProfilePicture;
        ProfileUrl = user.ProfileUrl;
        PortfolioUrl = user.PortfolioUrl;
        RoleName = user.Role?.Name;
        CompanyName = user.Company?.Name;
        IsWorking = user.IsWorking;
    }
}