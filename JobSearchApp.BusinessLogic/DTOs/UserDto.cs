using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs;

public class UserDto
{
    public int UserId { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? UserType { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Headline { get; set; }
    public string? Summary { get; set; }
    public string? Location { get; set; }
    public DateTimeOffset DateJoined { get; set; } = DateTimeOffset.Now;
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
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public int CompanyId { get; set; }
    public bool IsWorking { get; set; }
    public List<Education> Educations { get; set; }
    public List<WorkExperience> WorkExperiences { get; set; }
    public List<Interest> Interests { get; set; }
    public List<UserPreference> UserPreferences { get; set; }

    public UserDto(User user)
    {
        UserId = user.UserId;
        Email = user.Email;
        UserName = user.UserName;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Headline = user.Headline;
        Summary = user.Summary;
        Location = user.Location;
        DateJoined = user.DateJoined;
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
        RoleId = user.RoleId;
        RoleName = user.Role.Name; // Assuming Role is a navigation property
        IsWorking = user.IsWorking;
        Educations = user.Educations.ToList();
        WorkExperiences = user.WorkExperiences.ToList();
        Interests = user.Interests.ToList();
        UserPreferences = user.UserPreferences.ToList();
    }


    public UserDto() { }
}

public class CreateUserDto
{
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? PasswordHash { get; set; }
    public string? UserType { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Headline { get; set; }
    public string? Summary { get; set; }
    public string? Location { get; set; }
    public DateTimeOffset DateJoined { get; set; } = DateTimeOffset.Now;
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
    public int RoleId { get; set; }
    public int? CompanyId { get; set; }
    public bool IsWorking { get; set; }
}

public class UpdateUserDto
{
    public int UserId { get; set; }
    public string? PasswordHash { get; set; }
    public string? UserType { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Headline { get; set; }
    public string? Summary { get; set; }
    public string? Location { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GenderIdentity { get; set; }
    public string? Pronoun { get; set; }
    public string? Ethnicity { get; set; }
    public string? MobileNumber { get; set; }
    public bool? RequireVisa { get; set; }
    public string? SearchStage { get; set; }
    public string? ProfilePicture { get; set; }
    public string? ProfileUrl { get; set; }
    public string? PortfolioUrl { get; set; }
    public int RoleId { get; set; }
    public int? CompanyId { get; set; }
    public bool IsWorking { get; set; }
}