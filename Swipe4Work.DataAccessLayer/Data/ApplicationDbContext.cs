using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Swipe4Work.Domain.Models;


namespace Swipe4Work.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILogger<ApplicationDbContext> _logger;
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration = null,
            ILogger<ApplicationDbContext> logger = null)
            : base(options)
        {
            _logger = logger;
            _configuration = configuration;

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

            // Configuración de tablas
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

            // Configuración de claves primarias
            modelBuilder.Entity<Company>().HasKey(c => c.CompanyId);
            modelBuilder.Entity<CompensationBenefit>().HasKey(cb => cb.BenefitId);
            modelBuilder.Entity<JobOffer>().HasKey(j => j.JobOfferId);
            modelBuilder.Entity<Permission>().HasKey(p => p.Name);
            modelBuilder.Entity<Question>().HasKey(q => q.QuestionId);
            modelBuilder.Entity<Resource>().HasKey(r => r.ResourceId);
            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Skill>().HasKey(s => s.SkillId);
            modelBuilder.Entity<Tag>().HasKey(t => t.TagId);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Answer>().HasKey(a => a.AnswerId);
            modelBuilder.Entity<Application>().HasKey(a => a.ApplicationId);
            modelBuilder.Entity<Education>().HasKey(e => e.EducationId);
            modelBuilder.Entity<Feedback>().HasKey(f => f.FeedbackId);
            modelBuilder.Entity<Interest>().HasKey(i => i.InterestId);
            modelBuilder.Entity<Match>().HasKey(m => m.MatchId);
            modelBuilder.Entity<SocialMedia>().HasKey(sm => sm.SocialMediaId);
            modelBuilder.Entity<UserPreference>().HasKey(up => up.PreferenceId);
            modelBuilder.Entity<UserSkill>().HasKey(us => us.UserSkillId);
            modelBuilder.Entity<WorkExperience>().HasKey(we => we.WorkExperienceId);
            modelBuilder.Entity<CompanyTag>().HasKey(ct => new { ct.CompanyId, ct.TagId });
            modelBuilder.Entity<RolePermissionPatent>().HasKey(rp => new { rp.RoleId, rp.ResourceId, rp.Permission });

            // Configuración de propiedades decimales
            modelBuilder.Entity<Application>()
                .Property(a => a.SalaryExpected)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<JobOffer>()
                .Property(j => j.MaxSalary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<JobOffer>()
                .Property(j => j.MinSalary)
                .HasColumnType("decimal(18,2)");

            // Configuración de relaciones
            modelBuilder.Entity<Company>()
                .HasMany(c => c.CompensationBenefits)
                .WithOne(cb => cb.Company)
                .HasForeignKey(cb => cb.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.JobOffers)
                .WithOne(j => j.Company)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.CompanyTags)
                .WithOne(ct => ct.Company)
                .HasForeignKey(ct => ct.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Users)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobOffer>()
                .HasMany(j => j.Applications)
                .WithOne(a => a.JobOffer)
                .HasForeignKey(a => a.JobOfferId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobOffer>()
                .HasMany(j => j.Matches)
                .WithOne(m => m.JobOffer)
                .HasForeignKey(m => m.JobOfferId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Resource>()
                .HasMany(r => r.RolePermissionPatents)
                .WithOne(rp => rp.Resource)
                .HasForeignKey(rp => rp.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.RolePermissionPatents)
                .WithOne(rp => rp.Role)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Skill>()
                .HasMany(s => s.UserSkills)
                .WithOne(us => us.Skill)
                .HasForeignKey(us => us.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.CompanyTags)
                .WithOne(ct => ct.Tag)
                .HasForeignKey(ct => ct.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Answers)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Applications)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Educations)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Feedbacks)
                .WithOne(f => f.Recruiter)
                .HasForeignKey(f => f.RecruiterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Interests)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Matches)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SocialMedias)
                .WithOne(sm => sm.User)
                .HasForeignKey(sm => sm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserPreferences)
                .WithOne(up => up.User)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserSkills)
                .WithOne(us => us.User)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.WorkExperiences)
                .WithOne(we => we.User)
                .HasForeignKey(we => we.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Editado Jmarc
            modelBuilder.Entity<User>()
                .HasOne(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolePermissionPatent>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissionPatents)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolePermissionPatent>()
                .HasOne(rp => rp.Resource)
                .WithMany(r => r.RolePermissionPatents)
                .HasForeignKey(rp => rp.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolePermissionPatent>()
                .HasOne(rp => rp.PermissionEntity)
                .WithMany()
                .HasForeignKey(rp => rp.Permission)
                .HasPrincipalKey(p => p.Name)
                .OnDelete(DeleteBehavior.Cascade);
        }
        //
        // private void EnsureLocalDatabaseExists()
        // {
        //     if (!File.Exists(_localDbFilePath))
        //     {
        //         try
        //         {
        //             var createDbFilePath = _localDbFilePath.Replace(".mdf", ".sql");
        //             File.WriteAllText(createDbFilePath, "");
        //
        //             using (var connection = new SqlConnection(_localConnectionString))
        //             {
        //                 connection.Open();
        //                 var createTableCommand = new SqlCommand(File.ReadAllText("CreateTables.sql"), connection);
        //                 createTableCommand.ExecuteNonQuery();
        //             }
        //         }
        //         catch (Exception ex)
        //         {
        //             _logger.LogError(ex, "An error occurred while creating the local database file.");
        //             throw;
        //         }
        //     }
        // }
    }
}