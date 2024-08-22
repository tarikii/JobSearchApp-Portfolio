using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.DTOs;

public class MatchDto
{
    public int MatchId { get; set; }
    public int JobOfferId { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset MatchDate { get; set; }
    public bool IsAccepted { get; set; }
    public int? ApplicationId { get; set; }
    public string? JobTitle { get; set; }
    public string? UserName { get; set; }
    public JobOfferDto JobOffer { get; set; }

    public MatchDto(Match match, IApplicationService applicationService)
    {
        MatchId = match.MatchId;
        JobOfferId = match.JobOfferId;
        UserId = match.UserId;
        MatchDate = match.MatchDate;
        IsAccepted = match.IsAccepted;
        JobTitle = match.JobOffer?.Title;
        UserName = match.User?.UserName;

        JobOffer = new JobOfferDto(match.JobOffer);

        var applications = applicationService.GetAllApplicationsAsync().Result;
        var matchingApplication = applications.FirstOrDefault(a => a.JobOfferId == JobOfferId && 
        a.UserId == UserId);
        ApplicationId = matchingApplication?.ApplicationId;
    }
    
    public MatchDto() { }
}

public class CreateMatchDto
{
    public int JobOfferId { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset? MatchDate { get; set; } = DateTimeOffset.Now;
    public bool? IsAccepted { get; set; } = false;
}

public class UpdateMatchDto
{
    public int MatchId { get; set; }
    public bool IsAccepted { get; set; }
}