namespace JobSearchApp.Domain.Models;

public class Education
{
    public int EducationId { get; set; }
    public int UserId { get; set; }
    public string SchoolName { get; set; }
    public string Degree { get; set; }
    public string FieldOfStudy { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Grade { get; set; }
    public string ActivitiesAndSocieties { get; set; }
    public string Description { get; set; }
}