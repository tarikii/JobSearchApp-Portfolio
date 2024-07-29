namespace JobSearchApp.Domain.Models;

public class Match
{
    public int MatchId { get; set; }
    public int JobOfferId { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset MatchDate { get; set; }
    public bool IsAccepted { get; set; }
}