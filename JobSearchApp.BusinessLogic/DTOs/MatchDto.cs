using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs;

public class MatchDto
{
    public int MatchId { get; set; }
    public int JobOfferId { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset MatchDate { get; set; }
    public bool IsAccepted { get; set; }

    public string? JobTitle { get; set; }
    public string? UserName { get; set; }

    public MatchDto(Match match)
    {
        MatchId = match.MatchId;
        JobOfferId = match.JobOfferId;
        UserId = match.UserId;
        MatchDate = match.MatchDate;
        IsAccepted = match.IsAccepted;
        JobTitle = match.JobOffer?.Title;
        UserName = match.User?.UserName;
    }
}

public class CreateMatchDto
{
    public int JobOfferId { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset MatchDate { get; set; } = DateTimeOffset.Now;
    public bool IsAccepted { get; set; } = false;
}

public class UpdateMatchDto
{
    public int MatchId { get; set; }
    public bool IsAccepted { get; set; }
}