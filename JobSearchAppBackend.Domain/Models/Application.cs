namespace JobSearchApp.Domain.Models;

public class Application
{
    public int ApplicationId { get; set; }
    public int UserId { get; set; }
    public int JobOfferId { get; set; }
    public DateTime ApplicationDate { get; set; }
    public string Status { get; set; }
    public decimal SalaryExpected { get; set; }
}