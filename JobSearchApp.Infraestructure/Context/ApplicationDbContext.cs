using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using JobSearchApp.Domain.Models;
using Microsoft.Data.SqlClient;

namespace JobSearchApp.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    private readonly ILogger<ApplicationDbContext> _logger;
    private readonly string _azureConnectionString;
    private readonly string _localConnectionString;
    private readonly string _localDbFilePath;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration,
        ILogger<ApplicationDbContext> logger)
        : base(options)
    {
        _logger = logger;
        _azureConnectionString = configuration.GetConnectionString("AzureConnection");
        // _localConnectionString = configuration.GetConnectionString("LocalConnection");
        // _localDbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JobSearchDb.mdf");

        // EnsureLocalDatabaseExists();
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<CompensationBenefit> CompensationBenefits { get; set; }
    public DbSet<JobOffer> JobOffers { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermissionPatent> RolePermissionPatents { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<CompanyTag> CompanyTags { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<UserPreference> UserPreferences { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>().ToTable("Company");
        modelBuilder.Entity<CompensationBenefit>().ToTable("CompensationBenefit");
        modelBuilder.Entity<JobOffer>().ToTable("JobOffer");
        modelBuilder.Entity<Permission>().ToTable("Permission");
        modelBuilder.Entity<Question>().ToTable("Question");
        modelBuilder.Entity<Resource>().ToTable("Resource");
        modelBuilder.Entity<Role>().ToTable("Role");
        modelBuilder.Entity<RolePermissionPatent>().ToTable("RolePermissionPatent");
        modelBuilder.Entity<Skill>().ToTable("Skill");
        modelBuilder.Entity<Tag>().ToTable("Tag");
        modelBuilder.Entity<CompanyTag>().ToTable("CompanyTag");
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<Answer>().ToTable("Answer");
        modelBuilder.Entity<Application>().ToTable("Application");
        modelBuilder.Entity<Education>().ToTable("Education");
        modelBuilder.Entity<Feedback>().ToTable("Feedback");
        modelBuilder.Entity<Interest>().ToTable("Interest");
        modelBuilder.Entity<Match>().ToTable("Match");
        modelBuilder.Entity<SocialMedia>().ToTable("SocialMedia");
        modelBuilder.Entity<UserPreference>().ToTable("UserPreference");
        modelBuilder.Entity<UserSkill>().ToTable("UserSkill");
        modelBuilder.Entity<WorkExperience>().ToTable("WorkExperience");

        modelBuilder.Entity<Company>()
            .HasMany(c => c.CompensationBenefits)
            .WithOne(cb => cb.Company)
            .HasForeignKey(cb => cb.CompanyId);

        modelBuilder.Entity<Company>()
            .HasMany(c => c.JobOffers)
            .WithOne(j => j.Company)
            .HasForeignKey(j => j.CompanyId);

        modelBuilder.Entity<Company>()
            .HasMany(c => c.CompanyTags)
            .WithOne(ct => ct.Company)
            .HasForeignKey(ct => ct.CompanyId);

        modelBuilder.Entity<Company>()
            .HasMany(c => c.Users)
            .WithOne(u => u.Company)
            .HasForeignKey(u => u.CompanyId);

        modelBuilder.Entity<JobOffer>()
            .HasMany(j => j.Applications)
            .WithOne(a => a.JobOffer)
            .HasForeignKey(a => a.JobOfferId);

        modelBuilder.Entity<JobOffer>()
            .HasMany(j => j.Matches)
            .WithOne(m => m.JobOffer)
            .HasForeignKey(m => m.JobOfferId);

        modelBuilder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId);

        modelBuilder.Entity<Resource>()
            .HasMany(r => r.RolePermissionPatents)
            .WithOne(rp => rp.Resource)
            .HasForeignKey(rp => rp.ResourceId);

        modelBuilder.Entity<Role>()
            .HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<Role>()
            .HasMany(r => r.RolePermissionPatents)
            .WithOne(rp => rp.Role)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<Skill>()
            .HasMany(s => s.UserSkills)
            .WithOne(us => us.Skill)
            .HasForeignKey(us => us.SkillId);

        modelBuilder.Entity<Tag>()
            .HasMany(t => t.CompanyTags)
            .WithOne(ct => ct.Tag)
            .HasForeignKey(ct => ct.TagId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Answers)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Applications)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Educations)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Feedbacks)
            .WithOne(f => f.Recruiter)
            .HasForeignKey(f => f.RecruiterId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Interests)
            .WithOne(i => i.User)
            .HasForeignKey(i => i.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Matches)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.SocialMedias)
            .WithOne(sm => sm.User)
            .HasForeignKey(sm => sm.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.UserPreferences)
            .WithOne(up => up.User)
            .HasForeignKey(up => up.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.UserSkills)
            .WithOne(us => us.User)
            .HasForeignKey(us => us.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.WorkExperiences)
            .WithOne(we => we.User)
            .HasForeignKey(we => we.UserId);
    }

    private void EnsureLocalDatabaseExists()
    {
        if (!File.Exists(_localDbFilePath))
        {
            try
            {
                var createDbFilePath = _localDbFilePath.Replace(".mdf", ".sql");
                File.WriteAllText(createDbFilePath, "");

                using (var connection = new SqlConnection(_localConnectionString))
                {
                    connection.Open();
                    var createTableCommand = new SqlCommand(File.ReadAllText("CreateTables.sql"), connection);
                    createTableCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the local database file.");
                throw;
            }
        }
    }

    public async Task<string> TestConnectionAsync()
    {
        try
        {
            using (var connection = new SqlConnection(_azureConnectionString))
            {
                await connection.OpenAsync();
                _logger.LogInformation("Connection to Azure SQL Database successful.");
            }

            return "Connection to Azure SQL Database successful.";
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to connect to Azure SQL Database, switching to local database.");

            try
            {
                using (var localConnection = new SqlConnection(_localConnectionString))
                {
                    await localConnection.OpenAsync();
                    _logger.LogInformation("Connection to local SQL Database successful.");
                }

                return "Connection to local SQL Database successful.";
            }
            catch (Exception localEx)
            {
                _logger.LogError(localEx, "An error occurred while testing the local database connection.");
                return "Connection test failed.";
            }
        }
    }
}