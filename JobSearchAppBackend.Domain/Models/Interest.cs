namespace JobSearchApp.Domain.Models;

public class Interest
{
    public int InterestId { get; set; }
    public int UserId { get; set; }
    public string InterestText { get; set; }
}