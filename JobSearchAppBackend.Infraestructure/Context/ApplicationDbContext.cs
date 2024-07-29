using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JobSearchApp.Domain.Models;
using Microsoft.Data.SqlClient;

namespace JobSearchApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILogger<ApplicationDbContext> _logger;
        private readonly string _azureConnectionString;
        private readonly string _localConnectionString;
        private readonly string _localDbFilePath;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration, ILogger<ApplicationDbContext> logger)
            : base(options)
        {
            _logger = logger;
            _azureConnectionString = configuration.GetConnectionString("AzureConnection");
            // _localConnectionString = configuration.GetConnectionString("LocalConnection");
            // _localDbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JobSearchDb.mdf");

            // EnsureLocalDatabaseExists();
        }

        public DbSet<User> Users { get; set; }
        // public DbSet<CompensationBenefit> CompensationBenefits { get; set; }
        // public DbSet<Role> Roles { get; set; }
        // public DbSet<Permission> Permissions { get; set; }
        // public DbSet<Resource> Resources { get; set; }
        // public DbSet<RolePermissionPatent> RolePermissionPatents { get; set; }
        // public DbSet<Company> Companies { get; set; }
        // public DbSet<JobOffer> JobOffers { get; set; }
        // public DbSet<WorkExperience> WorkExperiences { get; set; }
        // public DbSet<Education> Educations { get; set; }
        // public DbSet<Application> Applications { get; set; }
        // public DbSet<Feedback> Feedbacks { get; set; }
        // public DbSet<SocialMedia> SocialMedias { get; set; }
        // public DbSet<Question> Questions { get; set; }
        // public DbSet<Answer> Answers { get; set; }
        // public DbSet<Interest> Interests { get; set; }
        // public DbSet<UserPreference> UserPreferences { get; set; }
        // public DbSet<Match> Matches { get; set; }
        // public DbSet<Skill> Skills { get; set; }
        // public DbSet<UserSkill> UserSkills { get; set; }
        // public DbSet<Tag> Tags { get; set; }
        // public DbSet<CompanyTag> CompanyTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<User>()
            //     .HasOne(u => u.Role)
            //     .WithMany(r => r.Users)
            //     .HasForeignKey(u => u.RoleId);
            //
            // modelBuilder.Entity<User>()
            //     .HasOne(u => u.Company)
            //     .WithMany(c => c.Users)
            //     .HasForeignKey(u => u.CompanyId);
            //
            // modelBuilder.Entity<CompensationBenefit>()
            //     .HasOne(cb => cb.Company)
            //     .WithMany(c => c.CompensationBenefits)
            //     .HasForeignKey(cb => cb.CompanyId);
            //
            // modelBuilder.Entity<RolePermissionPatent>()
            //     .HasKey(rp => new { rp.RoleId, rp.ResourceId, rp.Permission });
            //
            // modelBuilder.Entity<RolePermissionPatent>()
            //     .HasOne(rp => rp.Role)
            //     .WithMany(r => r.RolePermissionPatents)
            //     .HasForeignKey(rp => rp.RoleId);
            //
            // modelBuilder.Entity<RolePermissionPatent>()
            //     .HasOne(rp => rp.Resource)
            //     .WithMany(r => r.RolePermissionPatents)
            //     .HasForeignKey(rp => rp.ResourceId);
            //
            // modelBuilder.Entity<RolePermissionPatent>()
            //     .HasOne(rp => rp.PermissionEntity)
            //     .WithMany(p => p.RolePermissionPatents)
            //     .HasForeignKey(rp => rp.Permission);
            //
            // modelBuilder.Entity<JobOffer>()
            //     .HasOne(jo => jo.Company)
            //     .WithMany(c => c.JobOffers)
            //     .HasForeignKey(jo => jo.CompanyId);
            //
            // modelBuilder.Entity<WorkExperience>()
            //     .HasOne(we => we.User)
            //     .WithMany(u => u.WorkExperiences)
            //     .HasForeignKey(we => we.UserId);
            //
            // modelBuilder.Entity<Education>()
            //     .HasOne(e => e.User)
            //     .WithMany(u => u.Educations)
            //     .HasForeignKey(e => e.UserId);
            //
            // modelBuilder.Entity<Application>()
            //     .HasOne(a => a.User)
            //     .WithMany(u => u.Applications)
            //     .HasForeignKey(a => a.UserId);
            //
            // modelBuilder.Entity<Application>()
            //     .HasOne(a => a.JobOffer)
            //     .WithMany(jo => jo.Applications)
            //     .HasForeignKey(a => a.JobOfferId);
            //
            // modelBuilder.Entity<Feedback>()
            //     .HasOne(f => f.Application)
            //     .WithMany(a => a.Feedbacks)
            //     .HasForeignKey(f => f.ApplicationId);
            //
            // modelBuilder.Entity<Feedback>()
            //     .HasOne(f => f.Recruiter)
            //     .WithMany(u => u.Feedbacks)
            //     .HasForeignKey(f => f.RecruiterId);
            //
            // modelBuilder.Entity<SocialMedia>()
            //     .HasOne(sm => sm.User)
            //     .WithMany(u => u.SocialMedias)
            //     .HasForeignKey(sm => sm.UserId);
            //
            // modelBuilder.Entity<Answer>()
            //     .HasOne(a => a.User)
            //     .WithMany(u => u.Answers)
            //     .HasForeignKey(a => a.UserId);
            //
            // modelBuilder.Entity<Answer>()
            //     .HasOne(a => a.Question)
            //     .WithMany(q => q.Answers)
            //     .HasForeignKey(a => a.QuestionId);
            //
            // modelBuilder.Entity<Interest>()
            //     .HasOne(i => i.User)
            //     .WithMany(u => u.Interests)
            //     .HasForeignKey(i => i.UserId);
            //
            // modelBuilder.Entity<UserPreference>()
            //     .HasOne(up => up.User)
            //     .WithMany(u => u.UserPreferences)
            //     .HasForeignKey(up => up.UserId);
            //
            // modelBuilder.Entity<Match>()
            //     .HasOne(m => m.JobOffer)
            //     .WithMany(jo => jo.Matches)
            //     .HasForeignKey(m => m.JobOfferId);
            //
            // modelBuilder.Entity<Match>()
            //     .HasOne(m => m.User)
            //     .WithMany(u => u.Matches)
            //     .HasForeignKey(m => m.UserId);
            //
            // modelBuilder.Entity<UserSkill>()
            //     .HasOne(us => us.User)
            //     .WithMany(u => u.UserSkills)
            //     .HasForeignKey(us => us.UserId);
            //
            // modelBuilder.Entity<UserSkill>()
            //     .HasOne(us => us.Skill)
            //     .WithMany(s => s.UserSkills)
            //     .HasForeignKey(us => us.SkillId);
            //
            // modelBuilder.Entity<CompanyTag>()
            //     .HasKey(ct => new { ct.CompanyId, ct.TagId });
            //
            // modelBuilder.Entity<CompanyTag>()
            //     .HasOne(ct => ct.Company)
            //     .WithMany(c => c.CompanyTags)
            //     .HasForeignKey(ct => ct.CompanyId);
            //
            // modelBuilder.Entity<CompanyTag>()
            //     .HasOne(ct => ct.Tag)
            //     .WithMany(t => t.CompanyTags)
            //     .HasForeignKey(ct => ct.TagId);
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
}
