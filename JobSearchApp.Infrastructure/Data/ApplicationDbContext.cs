using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using JobSearchApp.Domain.Models;
using Microsoft.Data.SqlClient;

namespace JobSearchApp.Infrastructure.Data
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

            modelBuilder.Entity<User>()
                .HasOne(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(c => c.Company)
                .WithMany(u => u.Users)
                .HasForeignKey(c => c.CompanyId)
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


            // Seed para Company
            modelBuilder.Entity<Company>().HasData(
      new Company
      {
          CompanyId = 1,
          Name = "Fundación Esplai",
          WebsiteUrl = "https://fundacionesplai.org/",
          Industry = "ONG",
          Size = "Mediana",
          Headquarters = "El Prat de Llobregat, España",
          FoundedYear = 1999,
          Description = "Fundación Esplai promueve la inclusión social, el voluntariado, y el uso de tecnologías de la información para la ciudadanía.",
          Location = "El Prat de Llobregat, España"
      },
      new Company
      {
          CompanyId = 2,
          Name = "Innovación Verde S.L.",
          WebsiteUrl = "https://www.innovacionverde.com",
          Industry = "Energía Renovable",
          Size = "Mediana",
          Headquarters = "Barcelona, España",
          FoundedYear = 2015,
          Description = "Empresa dedicada a la investigación y desarrollo de energías renovables y sostenibilidad ambiental.",
          Location = "Barcelona, España"
      },
      new Company
      {
          CompanyId = 3,
          Name = "CiberSeguridad Total S.A.",
          WebsiteUrl = "https://www.ciberseguridadtotal.com",
          Industry = "Seguridad Informática",
          Size = "Pequeña",
          Headquarters = "Madrid, España",
          FoundedYear = 2018,
          Description = "Especialistas en protección de datos y ciberseguridad para empresas.",
          Location = "Madrid, España"
      },
      new Company
      {
          CompanyId = 4,
          Name = "Desarrollos Móviles SL",
          WebsiteUrl = "https://www.desarrollosmoviles.com",
          Industry = "Desarrollo de Software",
          Size = "Mediana",
          Headquarters = "Valencia, España",
          FoundedYear = 2010,
          Description = "Empresa especializada en el desarrollo de aplicaciones móviles innovadoras.",
          Location = "Valencia, España"
      },
      new Company
      {
          CompanyId = 5,
          Name = "Turismo Inteligente S.A.",
          WebsiteUrl = "https://www.turismo-inteligente.com",
          Industry = "Turismo",
          Size = "Grande",
          Headquarters = "Sevilla, España",
          FoundedYear = 2005,
          Description = "Líder en la creación de experiencias turísticas personalizadas y tecnológicas.",
          Location = "Sevilla, España"
      },
      new Company
      {
          CompanyId = 6,
          Name = "Agua Pura S.L.",
          WebsiteUrl = "https://www.aguapura.com",
          Industry = "Agua y Saneamiento",
          Size = "Mediana",
          Headquarters = "Málaga, España",
          FoundedYear = 2012,
          Description = "Proporciona soluciones de tratamiento y purificación de agua para uso doméstico e industrial.",
          Location = "Málaga, España"
      },
      new Company
      {
          CompanyId = 7,
          Name = "Alimentos Ecológicos S.A.",
          WebsiteUrl = "https://www.alimentosecologicos.com",
          Industry = "Alimentación",
          Size = "Grande",
          Headquarters = "Bilbao, España",
          FoundedYear = 2000,
          Description = "Productores y distribuidores de alimentos ecológicos y orgánicos en España.",
          Location = "Bilbao, España"
      },
      new Company
      {
          CompanyId = 8,
          Name = "Construcciones Modernas SL",
          WebsiteUrl = "https://www.construccionesmodernas.com",
          Industry = "Construcción",
          Size = "Grande",
          Headquarters = "Madrid, España",
          FoundedYear = 1995,
          Description = "Empresa constructora líder en proyectos residenciales y comerciales.",
          Location = "Madrid, España"
      },
      new Company
      {
          CompanyId = 9,
          Name = "Transporte Eficiente S.A.",
          WebsiteUrl = "https://www.transporteeficiente.com",
          Industry = "Logística y Transporte",
          Size = "Mediana",
          Headquarters = "Zaragoza, España",
          FoundedYear = 2010,
          Description = "Especialistas en logística y transporte de mercancías de manera eficiente y sostenible.",
          Location = "Zaragoza, España"
      },
      new Company
      {
          CompanyId = 10,
          Name = "Tecnología Médica Avanzada S.L.",
          WebsiteUrl = "https://www.tecnologiamedica.com",
          Industry = "Salud",
          Size = "Mediana",
          Headquarters = "Granada, España",
          FoundedYear = 2015,
          Description = "Innovación en tecnología médica para mejorar la calidad de vida.",
          Location = "Granada, España"
      }
  );



            // Seed para CompensationBenefit
            modelBuilder.Entity<CompensationBenefit>().HasData(
    new CompensationBenefit
    {
        BenefitId = 1,
        CompanyId = 1,
        BenefitType = "Seguro de Salud",
        Description = "Cobertura completa de seguro médico para empleados y sus familias."
    },
    new CompensationBenefit
    {
        BenefitId = 2,
        CompanyId = 1,
        BenefitType = "Bonificación Anual",
        Description = "Bonificación basada en el rendimiento anual del empleado."
    },
    new CompensationBenefit
    {
        BenefitId = 3,
        CompanyId = 2,
        BenefitType = "Estudio y Capacitación",
        Description = "Reembolsos para cursos de desarrollo profesional y capacitación continua."
    },
    new CompensationBenefit
    {
        BenefitId = 4,
        CompanyId = 2,
        BenefitType = "Tiempo de Vacaciones",
        Description = "Tiempo adicional de vacaciones por antigüedad y desempeño."
    },
    new CompensationBenefit
    {
        BenefitId = 5,
        CompanyId = 3,
        BenefitType = "Plan de Pensiones",
        Description = "Contribuciones a un plan de pensiones privado para empleados."
    },
    new CompensationBenefit
    {
        BenefitId = 6,
        CompanyId = 3,
        BenefitType = "Seguro de Vida",
        Description = "Cobertura de seguro de vida para empleados y sus familias."
    },
    new CompensationBenefit
    {
        BenefitId = 7,
        CompanyId = 4,
        BenefitType = "Trabajo Remoto",
        Description = "Posibilidad de trabajar de forma remota varios días a la semana."
    },
    new CompensationBenefit
    {
        BenefitId = 8,
        CompanyId = 4,
        BenefitType = "Gimnasio en la Empresa",
        Description = "Acceso gratuito a gimnasio dentro de las instalaciones de la empresa."
    },
    new CompensationBenefit
    {
        BenefitId = 9,
        CompanyId = 5,
        BenefitType = "Descuentos en Viajes",
        Description = "Descuentos exclusivos en paquetes de viajes y alojamientos."
    },
    new CompensationBenefit
    {
        BenefitId = 10,
        CompanyId = 5,
        BenefitType = "Días de Vacaciones Adicionales",
        Description = "Días adicionales de vacaciones por cada año de servicio."
    },
    new CompensationBenefit
    {
        BenefitId = 11,
        CompanyId = 6,
        BenefitType = "Seguro Dental",
        Description = "Cobertura completa de seguro dental para empleados."
    },
    new CompensationBenefit
    {
        BenefitId = 12,
        CompanyId = 6,
        BenefitType = "Horario Flexible",
        Description = "Flexibilidad en los horarios de entrada y salida del trabajo."
    },
    new CompensationBenefit
    {
        BenefitId = 13,
        CompanyId = 7,
        BenefitType = "Vales de Comida",
        Description = "Vales mensuales para comida en restaurantes y supermercados."
    },
    new CompensationBenefit
    {
        BenefitId = 14,
        CompanyId = 7,
        BenefitType = "Seguro de Viaje",
        Description = "Cobertura de seguro de viaje para empleados en viajes de negocios."
    },
    new CompensationBenefit
    {
        BenefitId = 15,
        CompanyId = 8,
        BenefitType = "Bono de Rendimiento",
        Description = "Bonificación mensual basada en el rendimiento individual."
    },
    new CompensationBenefit
    {
        BenefitId = 16,
        CompanyId = 8,
        BenefitType = "Desarrollo Profesional",
        Description = "Oportunidades para participar en talleres y seminarios profesionales."
    },
    new CompensationBenefit
    {
        BenefitId = 17,
        CompanyId = 9,
        BenefitType = "Transporte Gratis",
        Description = "Servicio de transporte gratuito para empleados desde puntos clave de la ciudad."
    },
    new CompensationBenefit
    {
        BenefitId = 18,
        CompanyId = 9,
        BenefitType = "Cobertura de Guardería",
        Description = "Cobertura total o parcial de los gastos de guardería para hijos de empleados."
    },
    new CompensationBenefit
    {
        BenefitId = 19,
        CompanyId = 10,
        BenefitType = "Seguro Médico Privado",
        Description = "Acceso a seguro médico privado con cobertura total para empleados."
    },
    new CompensationBenefit
    {
        BenefitId = 20,
        CompanyId = 10,
        BenefitType = "Plan de Ahorro",
        Description = "Plan de ahorro con aportaciones de la empresa y del empleado."
    }
);


            // Seed para JobOffer
            modelBuilder.Entity<JobOffer>().HasData(
     // Job offers for Company 1 - Fundación Esplai
     new JobOffer
     {
         JobOfferId = 1,
         CompanyId = 1,
         Title = "Coordinador de Proyectos Sociales",
         Description = "Responsable de la coordinación de proyectos sociales y educativos con enfoque en inclusión digital.",
         Location = "El Prat de Llobregat, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Senior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 3, 1)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 7, 1)),
         IsActive = true,
         EstimatedDurationDays = 120,
         MinSalary = 40000m,
         MaxSalary = 50000m
     },
     new JobOffer
     {
         JobOfferId = 2,
         CompanyId = 1,
         Title = "Especialista en Comunicación Digital",
         Description = "Encargado de gestionar las comunicaciones digitales y redes sociales de la fundación.",
         Location = "El Prat de Llobregat, España",
         JobType = "Medio tiempo",
         ExperienceLevel = "Mid",
         PostedDate = new DateTimeOffset(new DateTime(2024, 3, 5)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 6, 5)),
         IsActive = true,
         EstimatedDurationDays = 90,
         MinSalary = 25000m,
         MaxSalary = 35000m
     },
     new JobOffer
     {
         JobOfferId = 3,
         CompanyId = 1,
         Title = "Formador TIC",
         Description = "Buscamos formador para impartir talleres de tecnología a colectivos en riesgo de exclusión.",
         Location = "El Prat de Llobregat, España",
         JobType = "Tiempo parcial",
         ExperienceLevel = "Junior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 4, 10)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 7, 10)),
         IsActive = true,
         EstimatedDurationDays = 60,
         MinSalary = 20000m,
         MaxSalary = 25000m
     },
     new JobOffer
     {
         JobOfferId = 4,
         CompanyId = 1,
         Title = "Técnico en Soporte Informático",
         Description = "Soporte técnico y mantenimiento de sistemas para proyectos educativos y sociales.",
         Location = "El Prat de Llobregat, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Mid",
         PostedDate = new DateTimeOffset(new DateTime(2024, 2, 20)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 6, 20)),
         IsActive = true,
         EstimatedDurationDays = 100,
         MinSalary = 30000m,
         MaxSalary = 40000m
     },
     new JobOffer
     {
         JobOfferId = 5,
         CompanyId = 1,
         Title = "Responsable de Voluntariado",
         Description = "Gestión de programas de voluntariado y coordinación de actividades.",
         Location = "El Prat de Llobregat, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Senior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 1, 15)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 5, 15)),
         IsActive = true,
         EstimatedDurationDays = 120,
         MinSalary = 45000m,
         MaxSalary = 55000m
     },

     // Job offers for Company 2 - Innovación Verde S.L.
     new JobOffer
     {
         JobOfferId = 6,
         CompanyId = 2,
         Title = "Ingeniero en Energías Renovables",
         Description = "Desarrollo y supervisión de proyectos de energía renovable.",
         Location = "Barcelona, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Senior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 2, 1)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 7, 1)),
         IsActive = true,
         EstimatedDurationDays = 150,
         MinSalary = 60000m,
         MaxSalary = 75000m
     },
     new JobOffer
     {
         JobOfferId = 7,
         CompanyId = 2,
         Title = "Analista de Datos Energéticos",
         Description = "Análisis de datos y optimización de procesos energéticos.",
         Location = "Barcelona, España",
         JobType = "Medio tiempo",
         ExperienceLevel = "Mid",
         PostedDate = new DateTimeOffset(new DateTime(2024, 3, 10)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 6, 10)),
         IsActive = true,
         EstimatedDurationDays = 90,
         MinSalary = 35000m,
         MaxSalary = 45000m
     },
     new JobOffer
     {
         JobOfferId = 8,
         CompanyId = 2,
         Title = "Técnico en Instalaciones Solares",
         Description = "Instalación y mantenimiento de paneles solares y sistemas de energía renovable.",
         Location = "Barcelona, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Junior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 4, 1)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 8, 1)),
         IsActive = true,
         EstimatedDurationDays = 120,
         MinSalary = 28000m,
         MaxSalary = 35000m
     },
     new JobOffer
     {
         JobOfferId = 9,
         CompanyId = 2,
         Title = "Consultor en Sostenibilidad",
         Description = "Asesoría en sostenibilidad ambiental y reducción de huella de carbono.",
         Location = "Barcelona, España",
         JobType = "Tiempo parcial",
         ExperienceLevel = "Senior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 1, 20)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 5, 20)),
         IsActive = true,
         EstimatedDurationDays = 100,
         MinSalary = 40000m,
         MaxSalary = 50000m
     },
     new JobOffer
     {
         JobOfferId = 10,
         CompanyId = 2,
         Title = "Especialista en Energía Eólica",
         Description = "Desarrollo y mantenimiento de proyectos de energía eólica.",
         Location = "Barcelona, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Mid",
         PostedDate = new DateTimeOffset(new DateTime(2024, 2, 15)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 6, 15)),
         IsActive = true,
         EstimatedDurationDays = 120,
         MinSalary = 45000m,
         MaxSalary = 55000m
     },

     // Job offers for Company 3 - CiberSeguridad Total S.A.
     new JobOffer
     {
         JobOfferId = 11,
         CompanyId = 3,
         Title = "Especialista en Ciberseguridad",
         Description = "Monitorización y protección de sistemas informáticos contra amenazas.",
         Location = "Madrid, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Senior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 1, 10)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 5, 10)),
         IsActive = true,
         EstimatedDurationDays = 120,
         MinSalary = 55000m,
         MaxSalary = 70000m
     },
     new JobOffer
     {
         JobOfferId = 12,
         CompanyId = 3,
         Title = "Analista de Seguridad Informática",
         Description = "Análisis y reporte de vulnerabilidades en sistemas informáticos.",
         Location = "Madrid, España",
         JobType = "Medio tiempo",
         ExperienceLevel = "Mid",
         PostedDate = new DateTimeOffset(new DateTime(2024, 2, 20)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 6, 20)),
         IsActive = true,
         EstimatedDurationDays = 90,
         MinSalary = 40000m,
         MaxSalary = 50000m
     },
     new JobOffer
     {
         JobOfferId = 13,
         CompanyId = 3,
         Title = "Consultor en Protección de Datos",
         Description = "Asesoría en cumplimiento de normativas de protección de datos.",
         Location = "Madrid, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Senior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 3, 1)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 7, 1)),
         IsActive = true,
         EstimatedDurationDays = 120,
         MinSalary = 60000m,
         MaxSalary = 75000m
     },
     new JobOffer
     {
         JobOfferId = 14,
         CompanyId = 3,
         Title = "Administrador de Seguridad de Redes",
         Description = "Mantenimiento y protección de la seguridad en redes corporativas.",
         Location = "Madrid, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Mid",
         PostedDate = new DateTimeOffset(new DateTime(2024, 2, 5)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 6, 5)),
         IsActive = true,
         EstimatedDurationDays = 100,
         MinSalary = 50000m,
         MaxSalary = 60000m
     },
     new JobOffer
     {
         JobOfferId = 15,
         CompanyId = 3,
         Title = "Investigador de Ciberamenazas",
         Description = "Investigación y análisis de nuevas ciberamenazas emergentes.",
         Location = "Madrid, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Junior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 4, 10)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 8, 10)),
         IsActive = true,
         EstimatedDurationDays = 150,
         MinSalary = 35000m,
         MaxSalary = 45000m
     },

     // Continue for other companies in a similar fashion...

     // Job offers for Company 10 - Analítica Avanzada S.L.
     new JobOffer
     {
         JobOfferId = 16,
         CompanyId = 10,
         Title = "Data Scientist Senior",
         Description = "Desarrollo de modelos predictivos y análisis de grandes volúmenes de datos.",
         Location = "Zaragoza, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Senior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 2, 10)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 6, 10)),
         IsActive = true,
         EstimatedDurationDays = 120,
         MinSalary = 60000m,
         MaxSalary = 75000m
     },
     new JobOffer
     {
         JobOfferId = 17,
         CompanyId = 10,
         Title = "Analista de Big Data",
         Description = "Análisis de datos masivos y generación de insights estratégicos.",
         Location = "Zaragoza, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Mid",
         PostedDate = new DateTimeOffset(new DateTime(2024, 3, 5)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 7, 5)),
         IsActive = true,
         EstimatedDurationDays = 120,
         MinSalary = 50000m,
         MaxSalary = 60000m
     },
     new JobOffer
     {
         JobOfferId = 18,
         CompanyId = 10,
         Title = "Desarrollador de Machine Learning",
         Description = "Implementación de algoritmos de machine learning en proyectos de análisis de datos.",
         Location = "Zaragoza, España",
         JobType = "Medio tiempo",
         ExperienceLevel = "Junior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 1, 20)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 5, 20)),
         IsActive = true,
         EstimatedDurationDays = 90,
         MinSalary = 40000m,
         MaxSalary = 50000m
     },
     new JobOffer
     {
         JobOfferId = 19,
         CompanyId = 10,
         Title = "Ingeniero de Datos",
         Description = "Diseño y mantenimiento de pipelines de datos eficientes.",
         Location = "Zaragoza, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Mid",
         PostedDate = new DateTimeOffset(new DateTime(2024, 2, 15)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 6, 15)),
         IsActive = true,
         EstimatedDurationDays = 120,
         MinSalary = 50000m,
         MaxSalary = 65000m
     },
     new JobOffer
     {
         JobOfferId = 20,
         CompanyId = 10,
         Title = "Administrador de Bases de Datos",
         Description = "Gestión y mantenimiento de bases de datos empresariales.",
         Location = "Zaragoza, España",
         JobType = "Tiempo completo",
         ExperienceLevel = "Junior",
         PostedDate = new DateTimeOffset(new DateTime(2024, 4, 1)),
         ExpiredDate = new DateTimeOffset(new DateTime(2024, 8, 1)),
         IsActive = true,
         EstimatedDurationDays = 120,
         MinSalary = 40000m,
         MaxSalary = 50000m
     }
 );


            // Seed para Permission
            modelBuilder.Entity<Permission>().HasData(
                new Permission { Name = "Leer" },
                new Permission { Name = "Escribir" },
                new Permission { Name = "Eliminar" }
            );

            // Seed para Question
            modelBuilder.Entity<Question>().HasData(
    new Question { QuestionId = 1, QuestionText = "¿Cómo manejas el estrés en el trabajo?" },
    new Question { QuestionId = 2, QuestionText = "¿Cuál es tu enfoque para resolver problemas complejos?" },
    new Question { QuestionId = 3, QuestionText = "¿Cómo priorizas tus tareas cuando tienes múltiples proyectos?" },
    new Question { QuestionId = 4, QuestionText = "¿Cómo te mantienes actualizado con las últimas tendencias en tu campo?" },
    new Question { QuestionId = 5, QuestionText = "Describe una vez en la que tuviste que aprender una nueva habilidad rápidamente. ¿Cómo lo lograste?" },
    new Question { QuestionId = 6, QuestionText = "¿Cómo te aseguras de que tu trabajo sea preciso y de alta calidad?" },
    new Question { QuestionId = 7, QuestionText = "¿Qué estrategias utilizas para mejorar la comunicación en tu equipo?" },
    new Question { QuestionId = 8, QuestionText = "¿Cómo te enfrentas a la retroalimentación negativa?" },
    new Question { QuestionId = 9, QuestionText = "¿Qué aspectos de tu trabajo consideras más motivadores?" },
    new Question { QuestionId = 10, QuestionText = "¿Cómo gestionas los conflictos con colegas o miembros del equipo?" }
);


            // Seed para Resource
            modelBuilder.Entity<Resource>().HasData(
        new Resource
        {
            ResourceId = 1,
            Name = "API de Autenticación",
            Description = "Un recurso que proporciona servicios de autenticación para usuarios en la plataforma."
        },
        new Resource
        {
            ResourceId = 2,
            Name = "Servicio de Notificaciones",
            Description = "Un servicio que gestiona las notificaciones en la aplicación."
        },
        new Resource
        {
            ResourceId = 3,
            Name = "Gestión de Datos de Usuario",
            Description = "Recurso que maneja las operaciones relacionadas con los datos de usuario."
        },
        new Resource
        {
            ResourceId = 4,
            Name = "API de Búsqueda de Empleos",
            Description = "Recurso que permite la búsqueda y filtrado de ofertas de empleo en la plataforma."
        }
    );

            // Seed para Role
            modelBuilder.Entity<Role>().HasData(
      new Role
      {
          RoleId = 1,
          Name = "Administrador",
          Description = "Rol con acceso completo a todas las funcionalidades y configuraciones del sistema."
      },
      new Role
      {
          RoleId = 2,
          Name = "Reclutador",
          Description = "Rol encargado de gestionar las ofertas de empleo, aplicaciones y procesos de contratación."
      },
      new Role
      {
          RoleId = 3,
          Name = "Candidato",
          Description = "Rol que representa a los usuarios que buscan empleo y postulan a ofertas."
      },
      new Role
      {
          RoleId = 4,
          Name = "Empresa",
          Description = "Rol que gestiona los recursos y herramientas disponibles en la plataforma."
      }
  );



            // Seed para Skill
            // Habilidades para el usuario 1 (Carlos Martínez)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 1, SkillName = "Gestión de Proyectos", SkillType = "Hard" },
                new Skill { SkillId = 2, SkillName = "Infraestructura TI", SkillType = "Hard" },
                new Skill { SkillId = 3, SkillName = "Liderazgo de Equipos", SkillType = "Soft" },
                new Skill { SkillId = 4, SkillName = "Comunicación Efectiva", SkillType = "Soft" }
            );

            // Habilidades para el usuario 2 (Jane Doe)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 5, SkillName = "Análisis Estadístico", SkillType = "Hard" },
                new Skill { SkillId = 6, SkillName = "Machine Learning", SkillType = "Hard" },
                new Skill { SkillId = 7, SkillName = "Trabajo en Equipo", SkillType = "Soft" },
                new Skill { SkillId = 8, SkillName = "Resolución de Problemas", SkillType = "Soft" }
            );

            // Habilidades para el usuario 3 (John Smith)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 9, SkillName = "Desarrollo Web", SkillType = "Hard" },
                new Skill { SkillId = 10, SkillName = "Desarrollo Móvil", SkillType = "Hard" },
                new Skill { SkillId = 11, SkillName = "Creatividad", SkillType = "Soft" },
                new Skill { SkillId = 12, SkillName = "Gestión del Tiempo", SkillType = "Soft" }
            );

            // Habilidades para el usuario 4 (Maria Garcia)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 13, SkillName = "Análisis Financiero", SkillType = "Hard" },
                new Skill { SkillId = 14, SkillName = "Gestión de Riesgos", SkillType = "Hard" },
                new Skill { SkillId = 15, SkillName = "Negociación", SkillType = "Soft" },
                new Skill { SkillId = 16, SkillName = "Pensamiento Crítico", SkillType = "Soft" }
            );

            // Habilidades para el usuario 5 (Michael Brown)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 17, SkillName = "Arquitectura de Sistemas", SkillType = "Hard" },
                new Skill { SkillId = 18, SkillName = "Escalabilidad", SkillType = "Hard" },
                new Skill { SkillId = 19, SkillName = "Adaptabilidad", SkillType = "Soft" },
                new Skill { SkillId = 20, SkillName = "Resolución de Conflictos", SkillType = "Soft" }
            );

            // Habilidades para el usuario 6 (Sophia Wilson)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 21, SkillName = "Gestión de Proyectos", SkillType = "Hard" },
                new Skill { SkillId = 22, SkillName = "Planificación Estratégica", SkillType = "Hard" },
                new Skill { SkillId = 23, SkillName = "Comunicación Intercultural", SkillType = "Soft" },
                new Skill { SkillId = 24, SkillName = "Habilidades Organizativas", SkillType = "Soft" }
            );

            // Habilidades para el usuario 7 (James Johnson)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 25, SkillName = "Automatización de Despliegue", SkillType = "Hard" },
                new Skill { SkillId = 26, SkillName = "Integración Continua", SkillType = "Hard" },
                new Skill { SkillId = 27, SkillName = "Trabajo en Equipo", SkillType = "Soft" },
                new Skill { SkillId = 28, SkillName = "Gestión de Proyectos Ágiles", SkillType = "Soft" }
            );

            // Habilidades para el usuario 8 (Emma Davis)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 29, SkillName = "Investigación Biomédica", SkillType = "Hard" },
                new Skill { SkillId = 30, SkillName = "Desarrollo de Terapias", SkillType = "Hard" },
                new Skill { SkillId = 31, SkillName = "Colaboración", SkillType = "Soft" },
                new Skill { SkillId = 32, SkillName = "Pensamiento Analítico", SkillType = "Soft" }
            );

            // Habilidades para el usuario 9 (William Miller)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 33, SkillName = "Análisis de Datos Financieros", SkillType = "Hard" },
                new Skill { SkillId = 34, SkillName = "Optimización de Procesos", SkillType = "Hard" },
                new Skill { SkillId = 35, SkillName = "Resolución de Problemas", SkillType = "Soft" },
                new Skill { SkillId = 36, SkillName = "Comunicación Eficaz", SkillType = "Soft" }
            );

            // Habilidades para el usuario 10 (Olivia Martinez)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 37, SkillName = "Diseño de Soluciones Ecológicas", SkillType = "Hard" },
                new Skill { SkillId = 38, SkillName = "Gestión Ambiental", SkillType = "Hard" },
                new Skill { SkillId = 39, SkillName = "Trabajo en Equipo", SkillType = "Soft" },
                new Skill { SkillId = 40, SkillName = "Creatividad", SkillType = "Soft" }
            );

            // Habilidades para el usuario 11 (John Smith) (Duplicado de Skills anteriores con RoleId = 3)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 41, SkillName = "Desarrollo Web", SkillType = "Hard" },
                new Skill { SkillId = 42, SkillName = "Desarrollo Móvil", SkillType = "Hard" },
                new Skill { SkillId = 43, SkillName = "Creatividad", SkillType = "Soft" },
                new Skill { SkillId = 44, SkillName = "Gestión del Tiempo", SkillType = "Soft" }
            );

            // Habilidades para el usuario 12 (Maria Garcia) (Duplicado de Skills anteriores con RoleId = 3)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 45, SkillName = "Análisis Financiero", SkillType = "Hard" },
                new Skill { SkillId = 46, SkillName = "Gestión de Riesgos", SkillType = "Hard" },
                new Skill { SkillId = 47, SkillName = "Negociación", SkillType = "Soft" },
                new Skill { SkillId = 48, SkillName = "Pensamiento Crítico", SkillType = "Soft" }
            );

            // Habilidades para el usuario 13 (Michael Brown) (Duplicado de Skills anteriores con RoleId = 3)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 49, SkillName = "Arquitectura de Sistemas", SkillType = "Hard" },
                new Skill { SkillId = 50, SkillName = "Escalabilidad", SkillType = "Hard" },
                new Skill { SkillId = 51, SkillName = "Adaptabilidad", SkillType = "Soft" },
                new Skill { SkillId = 52, SkillName = "Resolución de Conflictos", SkillType = "Soft" }
            );

            // Habilidades para el usuario 14 (Sophia Wilson) (Duplicado de Skills anteriores con RoleId = 3)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 53, SkillName = "Gestión de Proyectos", SkillType = "Hard" },
                new Skill { SkillId = 54, SkillName = "Planificación Estratégica", SkillType = "Hard" },
                new Skill { SkillId = 55, SkillName = "Comunicación Intercultural", SkillType = "Soft" },
                new Skill { SkillId = 56, SkillName = "Habilidades Organizativas", SkillType = "Soft" }
            );

            // Habilidades para el usuario 15 (James Johnson) (Duplicado de Skills anteriores con RoleId = 3)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 57, SkillName = "Automatización de Despliegue", SkillType = "Hard" },
                new Skill { SkillId = 58, SkillName = "Integración Continua", SkillType = "Hard" },
                new Skill { SkillId = 59, SkillName = "Trabajo en Equipo", SkillType = "Soft" },
                new Skill { SkillId = 60, SkillName = "Gestión de Proyectos Ágiles", SkillType = "Soft" }
            );

            // Habilidades para el usuario 16 (Emma Davis) (Duplicado de Skills anteriores con RoleId = 3)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 61, SkillName = "Investigación Biomédica", SkillType = "Hard" },
                new Skill { SkillId = 62, SkillName = "Desarrollo de Terapias", SkillType = "Hard" },
                new Skill { SkillId = 63, SkillName = "Colaboración", SkillType = "Soft" },
                new Skill { SkillId = 64, SkillName = "Pensamiento Analítico", SkillType = "Soft" }
            );

            // Habilidades para el usuario 17 (Lucas Anderson)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 65, SkillName = "Programación en Python", SkillType = "Hard" },
                new Skill { SkillId = 66, SkillName = "Desarrollo de APIs", SkillType = "Hard" },
                new Skill { SkillId = 67, SkillName = "Comunicación Efectiva", SkillType = "Soft" },
                new Skill { SkillId = 68, SkillName = "Trabajo en Equipo", SkillType = "Soft" }
            );

            // Habilidades para el usuario 18 (Isabella Johnson)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 69, SkillName = "Desarrollo de Aplicaciones Móviles", SkillType = "Hard" },
                new Skill { SkillId = 70, SkillName = "Arquitectura de Software", SkillType = "Hard" },
                new Skill { SkillId = 71, SkillName = "Resolución de Problemas", SkillType = "Soft" },
                new Skill { SkillId = 72, SkillName = "Liderazgo", SkillType = "Soft" }
            );

            // Habilidades para el usuario 19 (Ella Martinez)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 73, SkillName = "Investigación de Mercado", SkillType = "Hard" },
                new Skill { SkillId = 74, SkillName = "Estrategia Comercial", SkillType = "Hard" },
                new Skill { SkillId = 75, SkillName = "Adaptabilidad", SkillType = "Soft" },
                new Skill { SkillId = 76, SkillName = "Pensamiento Crítico", SkillType = "Soft" }
            );

            // Habilidades para el usuario 20 (Benjamin Clark)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 77, SkillName = "Seguridad Informática", SkillType = "Hard" },
                new Skill { SkillId = 78, SkillName = "Desarrollo de Software Seguro", SkillType = "Hard" },
                new Skill { SkillId = 79, SkillName = "Comunicación Interpersonal", SkillType = "Soft" },
                new Skill { SkillId = 80, SkillName = "Gestión del Tiempo", SkillType = "Soft" }
            );



            // Seed para Tag
            modelBuilder.Entity<Tag>().HasData(
     new Tag { TagId = 1, TagName = "Remoto", ImageUrl = "https://example.com/images/tag-remote.jpg" },
     new Tag { TagId = 2, TagName = "Tiempo completo", ImageUrl = "https://example.com/images/tag-fulltime.jpg" },
     new Tag { TagId = 3, TagName = "Freelance", ImageUrl = "https://example.com/images/tag-freelance.jpg" },
     new Tag { TagId = 4, TagName = "Contratista", ImageUrl = "https://example.com/images/tag-contractor.jpg" },
     new Tag { TagId = 5, TagName = "Medio tiempo", ImageUrl = "https://example.com/images/tag-parttime.jpg" },
     new Tag { TagId = 6, TagName = "Temporal", ImageUrl = "https://example.com/images/tag-temporary.jpg" },
     new Tag { TagId = 7, TagName = "Internship", ImageUrl = "https://example.com/images/tag-internship.jpg" },
     new Tag { TagId = 8, TagName = "Educación continua", ImageUrl = "https://example.com/images/tag-education.jpg" },
     new Tag { TagId = 9, TagName = "Trabajo en equipo", ImageUrl = "https://example.com/images/tag-teamwork.jpg" },
     new Tag { TagId = 10, TagName = "Liderazgo", ImageUrl = "https://example.com/images/tag-leadership.jpg" },
     new Tag { TagId = 11, TagName = "Trabajo remoto", ImageUrl = "https://example.com/images/tag-remote-work.jpg" },
     new Tag { TagId = 12, TagName = "Desarrollo profesional", ImageUrl = "https://example.com/images/tag-professional-development.jpg" },
     new Tag { TagId = 13, TagName = "Flexibilidad horaria", ImageUrl = "https://example.com/images/tag-flexible-hours.jpg" },
     new Tag { TagId = 14, TagName = "Oportunidades de crecimiento", ImageUrl = "https://example.com/images/tag-growth-opportunities.jpg" },
     new Tag { TagId = 15, TagName = "Trabajo bajo presión", ImageUrl = "https://example.com/images/tag-pressure.jpg" },
     new Tag { TagId = 16, TagName = "Beneficios", ImageUrl = "https://example.com/images/tag-benefits.jpg" },
     new Tag { TagId = 17, TagName = "Innovación", ImageUrl = "https://example.com/images/tag-innovation.jpg" },
     new Tag { TagId = 18, TagName = "Ambiente colaborativo", ImageUrl = "https://example.com/images/tag-collaborative-environment.jpg" },
     new Tag { TagId = 19, TagName = "Capacitación", ImageUrl = "https://example.com/images/tag-training.jpg" },
     new Tag { TagId = 20, TagName = "Equilibrio vida-trabajo", ImageUrl = "https://example.com/images/tag-work-life-balance.jpg" }
 );


            // Seed para CompanyTag
            modelBuilder.Entity<CompanyTag>().HasData(
    // Empresa 1
    new CompanyTag { CompanyId = 1, TagId = 1 },
    new CompanyTag { CompanyId = 1, TagId = 3 },
    new CompanyTag { CompanyId = 1, TagId = 5 },
    new CompanyTag { CompanyId = 1, TagId = 7 },
    new CompanyTag { CompanyId = 1, TagId = 9 },
    new CompanyTag { CompanyId = 1, TagId = 11 },
    new CompanyTag { CompanyId = 1, TagId = 13 },
    new CompanyTag { CompanyId = 1, TagId = 15 },

    // Empresa 2
    new CompanyTag { CompanyId = 2, TagId = 2 },
    new CompanyTag { CompanyId = 2, TagId = 4 },
    new CompanyTag { CompanyId = 2, TagId = 6 },
    new CompanyTag { CompanyId = 2, TagId = 8 },
    new CompanyTag { CompanyId = 2, TagId = 10 },
    new CompanyTag { CompanyId = 2, TagId = 12 },
    new CompanyTag { CompanyId = 2, TagId = 14 },
    new CompanyTag { CompanyId = 2, TagId = 16 },

    // Empresa 3
    new CompanyTag { CompanyId = 3, TagId = 3 },
    new CompanyTag { CompanyId = 3, TagId = 5 },
    new CompanyTag { CompanyId = 3, TagId = 7 },
    new CompanyTag { CompanyId = 3, TagId = 9 },
    new CompanyTag { CompanyId = 3, TagId = 11 },
    new CompanyTag { CompanyId = 3, TagId = 13 },
    new CompanyTag { CompanyId = 3, TagId = 15 },
    new CompanyTag { CompanyId = 3, TagId = 17 },

    // Empresa 4
    new CompanyTag { CompanyId = 4, TagId = 4 },
    new CompanyTag { CompanyId = 4, TagId = 6 },
    new CompanyTag { CompanyId = 4, TagId = 8 },
    new CompanyTag { CompanyId = 4, TagId = 10 },
    new CompanyTag { CompanyId = 4, TagId = 12 },
    new CompanyTag { CompanyId = 4, TagId = 14 },
    new CompanyTag { CompanyId = 4, TagId = 16 },
    new CompanyTag { CompanyId = 4, TagId = 18 },

    // Empresa 5
    new CompanyTag { CompanyId = 5, TagId = 5 },
    new CompanyTag { CompanyId = 5, TagId = 7 },
    new CompanyTag { CompanyId = 5, TagId = 9 },
    new CompanyTag { CompanyId = 5, TagId = 11 },
    new CompanyTag { CompanyId = 5, TagId = 13 },
    new CompanyTag { CompanyId = 5, TagId = 15 },
    new CompanyTag { CompanyId = 5, TagId = 17 },
    new CompanyTag { CompanyId = 5, TagId = 19 },

    // Empresa 6
    new CompanyTag { CompanyId = 6, TagId = 6 },
    new CompanyTag { CompanyId = 6, TagId = 8 },
    new CompanyTag { CompanyId = 6, TagId = 10 },
    new CompanyTag { CompanyId = 6, TagId = 12 },
    new CompanyTag { CompanyId = 6, TagId = 14 },
    new CompanyTag { CompanyId = 6, TagId = 16 },
    new CompanyTag { CompanyId = 6, TagId = 18 },
    new CompanyTag { CompanyId = 6, TagId = 20 },

    // Empresa 7
    new CompanyTag { CompanyId = 7, TagId = 7 },
    new CompanyTag { CompanyId = 7, TagId = 9 },
    new CompanyTag { CompanyId = 7, TagId = 11 },
    new CompanyTag { CompanyId = 7, TagId = 13 },
    new CompanyTag { CompanyId = 7, TagId = 15 },
    new CompanyTag { CompanyId = 7, TagId = 17 },
    new CompanyTag { CompanyId = 7, TagId = 19 },
    new CompanyTag { CompanyId = 7, TagId = 1 },

    // Empresa 8
    new CompanyTag { CompanyId = 8, TagId = 8 },
    new CompanyTag { CompanyId = 8, TagId = 10 },
    new CompanyTag { CompanyId = 8, TagId = 12 },
    new CompanyTag { CompanyId = 8, TagId = 14 },
    new CompanyTag { CompanyId = 8, TagId = 16 },
    new CompanyTag { CompanyId = 8, TagId = 18 },
    new CompanyTag { CompanyId = 8, TagId = 20 },
    new CompanyTag { CompanyId = 8, TagId = 2 },

    // Empresa 9
    new CompanyTag { CompanyId = 9, TagId = 9 },
    new CompanyTag { CompanyId = 9, TagId = 11 },
    new CompanyTag { CompanyId = 9, TagId = 13 },
    new CompanyTag { CompanyId = 9, TagId = 15 },
    new CompanyTag { CompanyId = 9, TagId = 17 },
    new CompanyTag { CompanyId = 9, TagId = 19 },
    new CompanyTag { CompanyId = 9, TagId = 1 },
    new CompanyTag { CompanyId = 9, TagId = 3 },

    // Empresa 10
    new CompanyTag { CompanyId = 10, TagId = 10 },
    new CompanyTag { CompanyId = 10, TagId = 12 },
    new CompanyTag { CompanyId = 10, TagId = 14 },
    new CompanyTag { CompanyId = 10, TagId = 16 },
    new CompanyTag { CompanyId = 10, TagId = 18 },
    new CompanyTag { CompanyId = 10, TagId = 20 },
    new CompanyTag { CompanyId = 10, TagId = 2 },
    new CompanyTag { CompanyId = 10, TagId = 4 }
);

            modelBuilder.Entity<User>().HasData(
     new User
     {
         UserId = 1,
         Email = "admin@techcorp.com",
         UserName = "admin",
         PasswordHash = "admin", // Hash de ejemplo
         UserType = "Administrador",
         FirstName = "Carlos",
         LastName = "Martínez",
         Headline = "Gerente de TI",
         Summary = "Profesional con más de 10 años de experiencia en la gestión de proyectos tecnológicos.",
         Location = "San Francisco, CA",
         DateJoined = DateTimeOffset.Now.AddYears(-5),
         LinkedInUrl = "https://www.linkedin.com/in/carlosmartinez",
         GenderIdentity = "Masculino",
         Pronoun = "Él",
         Ethnicity = "Latino",
         MobileNumber = "555-1234",
         RequireVisa = false,
         SearchStage = "Activo",
         ProfilePicture = "https://example.com/perfil1.jpg",
         ProfileUrl = "https://example.com/carlosmartinez",
         PortfolioUrl = "https://portfolio.com/carlosmartinez",
         RoleId = 2,
         CompanyId = 1,
         IsWorking = true
     },
     new User
     {
         UserId = 2,
         Email = "jane.doe@saludplus.com",
         UserName = "janedoe",
         PasswordHash = "jane", // Hash de ejemplo
         UserType = "Usuario",
         FirstName = "Jane",
         LastName = "Doe",
         Headline = "Científica de Datos",
         Summary = "Especialista en análisis de datos con un enfoque en el sector salud.",
         Location = "Nueva York, NY",
         DateJoined = DateTimeOffset.Now.AddYears(-3),
         LinkedInUrl = "https://www.linkedin.com/in/janedoe",
         GenderIdentity = "Femenino",
         Pronoun = "Ella",
         Ethnicity = "Caucásica",
         MobileNumber = "555-5678",
         RequireVisa = false,
         SearchStage = "En búsqueda",
         ProfilePicture = "https://example.com/perfil2.jpg",
         ProfileUrl = "https://example.com/janedoe",
         PortfolioUrl = "https://portfolio.com/janedoe",
         RoleId = 2,
         CompanyId = 2,
         IsWorking = false
     },
     new User
     {
         UserId = 3,
         Email = "john.smith@techtree.com",
         UserName = "johnsmithr",
         PasswordHash = "johnr", // Example hash
         UserType = "Usuario",
         FirstName = "John",
         LastName = "Smith",
         Headline = "Ingeniero de Software",
         Summary = "Desarrollador de software con experiencia en tecnologías web y móviles.",
         Location = "San Francisco, CA",
         DateJoined = DateTimeOffset.Now.AddYears(-4),
         LinkedInUrl = "https://www.linkedin.com/in/johnsmith",
         GenderIdentity = "Masculino",
         Pronoun = "Él",
         Ethnicity = "Afroamericano",
         MobileNumber = "555-1234",
         RequireVisa = false,
         SearchStage = "Abierto a nuevas oportunidades",
         ProfilePicture = "https://example.com/profile3.jpg",
         ProfileUrl = "https://example.com/johnsmith",
         PortfolioUrl = "https://portfolio.com/johnsmith",
         RoleId = 2,
         CompanyId = 3,
         IsWorking = true
     },

     new User
     {
         UserId = 4,
         Email = "maria.garcia@medex.com",
         UserName = "mariagarciar",
         PasswordHash = "maria", // Example hash
         UserType = "Usuarior",
         FirstName = "Maria",
         LastName = "Garcia",
         Headline = "Analista Financiero",
         Summary = "Profesional de finanzas con una sólida formación en análisis y gestión de riesgos.",
         Location = "Miami, FL",
         DateJoined = DateTimeOffset.Now.AddYears(-2),
         LinkedInUrl = "https://www.linkedin.com/in/mariagarcia",
         GenderIdentity = "Femenino",
         Pronoun = "Ella",
         Ethnicity = "Latina",
         MobileNumber = "555-2345",
         RequireVisa = false,
         SearchStage = "Explorando opciones",
         ProfilePicture = "https://example.com/profile4.jpg",
         ProfileUrl = "https://example.com/mariagarcia",
         PortfolioUrl = "https://portfolio.com/mariagarcia",
         RoleId = 2,
         CompanyId = 4,
         IsWorking = true
     },

     new User
     {
         UserId = 5,
         Email = "michael.brown@cybernet.com",
         UserName = "michaelbrownr",
         PasswordHash = "michaelr", // Example hash
         UserType = "Usuario",
         FirstName = "Michael",
         LastName = "Brown",
         Headline = "Arquitecto de Soluciones",
         Summary = "Arquitecto de soluciones especializado en la creación de infraestructuras escalables.",
         Location = "Austin, TX",
         DateJoined = DateTimeOffset.Now.AddYears(-5),
         LinkedInUrl = "https://www.linkedin.com/in/michaelbrown",
         GenderIdentity = "Masculino",
         Pronoun = "Él",
         Ethnicity = "Caucásico",
         MobileNumber = "555-3456",
         RequireVisa = false,
         SearchStage = "No en búsqueda activa",
         ProfilePicture = "https://example.com/profile5.jpg",
         ProfileUrl = "https://example.com/michaelbrown",
         PortfolioUrl = "https://portfolio.com/michaelbrown",
         RoleId = 2,
         CompanyId = 5,
         IsWorking = true
     },

    new User
    {
        UserId = 6,
        Email = "sophia.wilson@ecogreen.com",
        UserName = "sophiawilsonr",
        PasswordHash = "sophiar", // Example hash
        UserType = "Usuario",
        FirstName = "Sophia",
        LastName = "Wilson",
        Headline = "Gestora de Proyectos",
        Summary = "Gestora de proyectos con experiencia en proyectos de sostenibilidad y medio ambiente.",
        Location = "Seattle, WA",
        DateJoined = DateTimeOffset.Now.AddYears(-3),
        LinkedInUrl = "https://www.linkedin.com/in/sophiawilson",
        GenderIdentity = "Femenino",
        Pronoun = "Ella",
        Ethnicity = "Asiática",
        MobileNumber = "555-4567",
        RequireVisa = false,
        SearchStage = "Interesada en nuevas oportunidades",
        ProfilePicture = "https://example.com/profile6.jpg",
        ProfileUrl = "https://example.com/sophiawilson",
        PortfolioUrl = "https://portfolio.com/sophiawilson",
        RoleId = 2,
        CompanyId = 6,
        IsWorking = true
    },

    new User
    {
        UserId = 7,
        Email = "james.johnson@nextgen.com",
        UserName = "jamesjohnsonr",
        PasswordHash = "jamesr", // Example hash
        UserType = "Usuario",
        FirstName = "James",
        LastName = "Johnson",
        Headline = "Ingeniero DevOps",
        Summary = "Especialista en DevOps con experiencia en automatización y despliegue continuo.",
        Location = "Chicago, IL",
        DateJoined = DateTimeOffset.Now.AddYears(-6),
        LinkedInUrl = "https://www.linkedin.com/in/jamesjohnson",
        GenderIdentity = "Masculino",
        Pronoun = "Él",
        Ethnicity = "Hispano",
        MobileNumber = "555-5678",
        RequireVisa = false,
        SearchStage = "Abierto a nuevas posiciones",
        ProfilePicture = "https://example.com/profile7.jpg",
        ProfileUrl = "https://example.com/jamesjohnson",
        PortfolioUrl = "https://portfolio.com/jamesjohnson",
        RoleId = 2,
        CompanyId = 7,
        IsWorking = true
    },

    new User
    {
        UserId = 8,
        Email = "emma.davis@biomedic.com",
        UserName = "emmadavisr",
        PasswordHash = "emmar", // Example hash
        UserType = "Usuario",
        FirstName = "Emma",
        LastName = "Davis",
        Headline = "Investigadora Biomédica",
        Summary = "Investigadora con experiencia en el desarrollo de terapias innovadoras.",
        Location = "Los Ángeles, CA",
        DateJoined = DateTimeOffset.Now.AddYears(-4),
        LinkedInUrl = "https://www.linkedin.com/in/emmadavis",
        GenderIdentity = "Femenino",
        Pronoun = "Ella",
        Ethnicity = "Caucásica",
        MobileNumber = "555-6789",
        RequireVisa = false,
        SearchStage = "Interesada en nuevas investigaciones",
        ProfilePicture = "https://example.com/profile8.jpg",
        ProfileUrl = "https://example.com/emmadavis",
        PortfolioUrl = "https://portfolio.com/emmadavis",
        RoleId = 2,
        CompanyId = 8,
        IsWorking = true
    },

    new User
    {
        UserId = 9,
        Email = "william.miller@finserve.com",
        UserName = "williammillerr",
        PasswordHash = "williamr", // Example hash
        UserType = "Usuario",
        FirstName = "William",
        LastName = "Miller",
        Headline = "Analista de Datos",
        Summary = "Analista de datos con experiencia en finanzas y optimización de procesos.",
        Location = "Nueva York, NY",
        DateJoined = DateTimeOffset.Now.AddYears(-2),
        LinkedInUrl = "https://www.linkedin.com/in/williammiller",
        GenderIdentity = "Masculino",
        Pronoun = "Él",
        Ethnicity = "Caucásico",
        MobileNumber = "555-7890",
        RequireVisa = false,
        SearchStage = "Explorando oportunidades",
        ProfilePicture = "https://example.com/profile9.jpg",
        ProfileUrl = "https://example.com/williammiller",
        PortfolioUrl = "https://portfolio.com/williammiller",
        RoleId = 2,
        CompanyId = 9,
        IsWorking = true
    },

    new User
    {
        UserId = 10,
        Email = "olivia.martinez@greentech.com",
        UserName = "oliviamartinezr",
        PasswordHash = "oliviar", // Example hash
        UserType = "Usuario",
        FirstName = "Olivia",
        LastName = "Martinez",
        Headline = "Ingeniera Ambiental",
        Summary = "Ingeniera con un enfoque en soluciones ecológicas y sostenibles.",
        Location = "Denver, CO",
        DateJoined = DateTimeOffset.Now.AddYears(-3),
        LinkedInUrl = "https://www.linkedin.com/in/oliviamartinez",
        GenderIdentity = "Femenino",
        Pronoun = "Ella",
        Ethnicity = "Latina",
        MobileNumber = "555-8901",
        RequireVisa = false,
        SearchStage = "En búsqueda activa",
        ProfilePicture = "https://example.com/profile10.jpg",
        ProfileUrl = "https://example.com/oliviamartinez",
        PortfolioUrl = "https://portfolio.com/oliviamartinez",
        RoleId = 2,
        CompanyId = 10,
        IsWorking = true
    },
    new User
    {
        UserId = 11,
        Email = "john.smith@techtree.com",
        UserName = "johnsmith",
        PasswordHash = "john", // Example hash
        UserType = "Usuario",
        FirstName = "John",
        LastName = "Smith",
        Headline = "Ingeniero de Software",
        Summary = "Desarrollador de software con experiencia en tecnologías web y móviles.",
        Location = "San Francisco, CA",
        DateJoined = DateTimeOffset.Now.AddYears(-4),
        LinkedInUrl = "https://www.linkedin.com/in/johnsmith",
        GenderIdentity = "Masculino",
        Pronoun = "Él",
        Ethnicity = "Afroamericano",
        MobileNumber = "555-1234",
        RequireVisa = false,
        SearchStage = "Abierto a nuevas oportunidades",
        ProfilePicture = "https://example.com/profile3.jpg",
        ProfileUrl = "https://example.com/johnsmith",
        PortfolioUrl = "https://portfolio.com/johnsmith",
        RoleId = 3,
        CompanyId = 3,
        IsWorking = true
    },

    new User
    {
        UserId = 12,
        Email = "maria.garcia@medex.com",
        UserName = "mariagarcia",
        PasswordHash = "maria", // Example hash
        UserType = "Usuario",
        FirstName = "Maria",
        LastName = "Garcia",
        Headline = "Analista Financiero",
        Summary = "Profesional de finanzas con una sólida formación en análisis y gestión de riesgos.",
        Location = "Miami, FL",
        DateJoined = DateTimeOffset.Now.AddYears(-2),
        LinkedInUrl = "https://www.linkedin.com/in/mariagarcia",
        GenderIdentity = "Femenino",
        Pronoun = "Ella",
        Ethnicity = "Latina",
        MobileNumber = "555-2345",
        RequireVisa = false,
        SearchStage = "Explorando opciones",
        ProfilePicture = "https://example.com/profile4.jpg",
        ProfileUrl = "https://example.com/mariagarcia",
        PortfolioUrl = "https://portfolio.com/mariagarcia",
        RoleId = 3,
        CompanyId = 4,
        IsWorking = true
    },

    new User
    {
        UserId = 13,
        Email = "michael.brown@cybernet.com",
        UserName = "michaelbrown",
        PasswordHash = "michael", // Example hash
        UserType = "Usuario",
        FirstName = "Michael",
        LastName = "Brown",
        Headline = "Arquitecto de Soluciones",
        Summary = "Arquitecto de soluciones especializado en la creación de infraestructuras escalables.",
        Location = "Austin, TX",
        DateJoined = DateTimeOffset.Now.AddYears(-5),
        LinkedInUrl = "https://www.linkedin.com/in/michaelbrown",
        GenderIdentity = "Masculino",
        Pronoun = "Él",
        Ethnicity = "Caucásico",
        MobileNumber = "555-3456",
        RequireVisa = false,
        SearchStage = "No en búsqueda activa",
        ProfilePicture = "https://example.com/profile5.jpg",
        ProfileUrl = "https://example.com/michaelbrown",
        PortfolioUrl = "https://portfolio.com/michaelbrown",
        RoleId = 3,
        CompanyId = 5,
        IsWorking = false
    },

    new User
    {
        UserId = 14,
        Email = "sophia.wilson@ecogreen.com",
        UserName = "sophiawilson",
        PasswordHash = "sophia", // Example hash
        UserType = "Usuario",
        FirstName = "Sophia",
        LastName = "Wilson",
        Headline = "Gestora de Proyectos",
        Summary = "Gestora de proyectos con experiencia en proyectos de sostenibilidad y medio ambiente.",
        Location = "Seattle, WA",
        DateJoined = DateTimeOffset.Now.AddYears(-3),
        LinkedInUrl = "https://www.linkedin.com/in/sophiawilson",
        GenderIdentity = "Femenino",
        Pronoun = "Ella",
        Ethnicity = "Asiática",
        MobileNumber = "555-4567",
        RequireVisa = false,
        SearchStage = "Interesada en nuevas oportunidades",
        ProfilePicture = "https://example.com/profile6.jpg",
        ProfileUrl = "https://example.com/sophiawilson",
        PortfolioUrl = "https://portfolio.com/sophiawilson",
        RoleId = 3,
        CompanyId = 6,
        IsWorking = false
    },

    new User
    {
        UserId = 15,
        Email = "james.johnson@nextgen.com",
        UserName = "jamesjohnson",
        PasswordHash = "james", // Example hash
        UserType = "Usuario",
        FirstName = "James",
        LastName = "Johnson",
        Headline = "Ingeniero DevOps",
        Summary = "Especialista en DevOps con experiencia en automatización y despliegue continuo.",
        Location = "Chicago, IL",
        DateJoined = DateTimeOffset.Now.AddYears(-6),
        LinkedInUrl = "https://www.linkedin.com/in/jamesjohnson",
        GenderIdentity = "Masculino",
        Pronoun = "Él",
        Ethnicity = "Hispano",
        MobileNumber = "555-5678",
        RequireVisa = false,
        SearchStage = "Abierto a nuevas posiciones",
        ProfilePicture = "https://example.com/profile7.jpg",
        ProfileUrl = "https://example.com/jamesjohnson",
        PortfolioUrl = "https://portfolio.com/jamesjohnson",
        RoleId = 3,
        CompanyId = 7,
        IsWorking = false
    },

    new User
    {
        UserId = 16,
        Email = "emma.davis@biomedic.com",
        UserName = "emmadavis",
        PasswordHash = "emma", // Example hash
        UserType = "Usuario",
        FirstName = "Emma",
        LastName = "Davis",
        Headline = "Investigadora Biomédica",
        Summary = "Investigadora con experiencia en el desarrollo de terapias innovadoras.",
        Location = "Los Ángeles, CA",
        DateJoined = DateTimeOffset.Now.AddYears(-4),
        LinkedInUrl = "https://www.linkedin.com/in/emmadavis",
        GenderIdentity = "Femenino",
        Pronoun = "Ella",
        Ethnicity = "Caucásica",
        MobileNumber = "555-6789",
        RequireVisa = false,
        SearchStage = "Interesada en nuevas investigaciones",
        ProfilePicture = "https://example.com/profile8.jpg",
        ProfileUrl = "https://example.com/emmadavis",
        PortfolioUrl = "https://portfolio.com/emmadavis",
        RoleId = 3,
        CompanyId = 8,
        IsWorking = false
    },

    new User
    {
        UserId = 17,
        Email = "william.miller@finserve.com",
        UserName = "williammiller",
        PasswordHash = "william", // Example hash
        UserType = "Usuario",
        FirstName = "William",
        LastName = "Miller",
        Headline = "Analista de Datos",
        Summary = "Analista de datos con experiencia en finanzas y optimización de procesos.",
        Location = "Nueva York, NY",
        DateJoined = DateTimeOffset.Now.AddYears(-2),
        LinkedInUrl = "https://www.linkedin.com/in/williammiller",
        GenderIdentity = "Masculino",
        Pronoun = "Él",
        Ethnicity = "Caucásico",
        MobileNumber = "555-7890",
        RequireVisa = false,
        SearchStage = "Explorando oportunidades",
        ProfilePicture = "https://example.com/profile9.jpg",
        ProfileUrl = "https://example.com/williammiller",
        PortfolioUrl = "https://portfolio.com/williammiller",
        RoleId = 3,
        CompanyId = 9,
        IsWorking = true
    },

    new User
    {
        UserId = 18,
        Email = "olivia.martinez@greentech.com",
        UserName = "oliviamartinez",
        PasswordHash = "olivia", // Example hash
        UserType = "Usuario",
        FirstName = "Olivia",
        LastName = "Martinez",
        Headline = "Ingeniera Ambiental",
        Summary = "Ingeniera con un enfoque en soluciones ecológicas y sostenibles.",
        Location = "Denver, CO",
        DateJoined = DateTimeOffset.Now.AddYears(-3),
        LinkedInUrl = "https://www.linkedin.com/in/oliviamartinez",
        GenderIdentity = "Femenino",
        Pronoun = "Ella",
        Ethnicity = "Latina",
        MobileNumber = "555-8901",
        RequireVisa = false,
        SearchStage = "En búsqueda activa",
        ProfilePicture = "https://example.com/profile10.jpg",
        ProfileUrl = "https://example.com/oliviamartinez",
        PortfolioUrl = "https://portfolio.com/oliviamartinez",
        RoleId = 2,
        CompanyId = 10,
        IsWorking = false
    },

    new User
    {
        UserId = 19,
        Email = "liam.harris@urbanhealth.com",
        UserName = "liamharris",
        PasswordHash = "liam", // Example hash
        UserType = "Usuario",
        FirstName = "Liam",
        LastName = "Harris",
        Headline = "Gerente de Recursos Humanos",
        Summary = "Gerente de RRHH con experiencia en reclutamiento y desarrollo de talento.",
        Location = "Nueva York, NY",
        DateJoined = DateTimeOffset.Now.AddYears(-7),
        LinkedInUrl = "https://www.linkedin.com/in/liamharris",
        GenderIdentity = "Masculino",
        Pronoun = "Él",
        Ethnicity = "Afroamericano",
        MobileNumber = "555-9999",
        RequireVisa = false,
        SearchStage = "No en búsqueda activa",
        ProfilePicture = "https://example.com/profile19.jpg",
        ProfileUrl = "https://example.com/liamharris",
        PortfolioUrl = "https://portfolio.com/liamharris",
        RoleId = 3,
        CompanyId = 7,
        IsWorking = false
    },

    new User
    {
        UserId = 20,
        Email = "ava.walker@medtech.com",
        UserName = "avawalker",
        PasswordHash = "ava", // Example hash
        UserType = "Usuario",
        FirstName = "Ava",
        LastName = "Walker",
        Headline = "Directora de Estrategia",
        Summary = "Especialista en estrategias de negocio y desarrollo organizacional.",
        Location = "Denver, CO",
        DateJoined = DateTimeOffset.Now.AddYears(-6),
        LinkedInUrl = "https://www.linkedin.com/in/avawalker",
        GenderIdentity = "Femenino",
        Pronoun = "Ella",
        Ethnicity = "Caucásica",
        MobileNumber = "555-0000",
        RequireVisa = false,
        SearchStage = "Explorando nuevas iniciativas",
        ProfilePicture = "https://example.com/profile20.jpg",
        ProfileUrl = "https://example.com/avawalker",
        PortfolioUrl = "https://portfolio.com/avawalker",
        RoleId = 3,
        CompanyId = 8,
        IsWorking = false
    }

 // Agrega más usuarios aquí si es necesario
 );


            // Seed para Answer
            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    AnswerId = 1,
                    UserId = 1,
                    QuestionId = 1,
                    AnswerText = "Manejo el estrés organizando mi tiempo y estableciendo prioridades claras. También me aseguro de tomar breves descansos para despejar la mente.",
                    IsFeatured = true
                },
                new Answer
                {
                    AnswerId = 2,
                    UserId = 2,
                    QuestionId = 2,
                    AnswerText = "Divido los problemas complejos en partes más pequeñas y abordo cada una de manera sistemática, buscando diferentes perspectivas para llegar a una solución.",
                    IsFeatured = true
                },
                new Answer
                {
                    AnswerId = 3,
                    UserId = 3,
                    QuestionId = 3,
                    AnswerText = "Priorizo mis tareas utilizando una matriz de urgencia e importancia, lo que me permite enfocarme en lo que realmente importa y gestionar el tiempo eficientemente.",
                    IsFeatured = true
                },
                new Answer
                {
                    AnswerId = 4,
                    UserId = 4,
                    QuestionId = 4,
                    AnswerText = "Me mantengo actualizado participando en cursos en línea, asistiendo a conferencias y leyendo publicaciones relevantes en mi campo.",
                    IsFeatured = true
                },
                new Answer
                {
                    AnswerId = 5,
                    UserId = 5,
                    QuestionId = 5,
                    AnswerText = "Aprendí rápidamente una nueva habilidad cuando me pidieron que liderara un proyecto de análisis de datos, dedicando tiempo extra y solicitando retroalimentación constante.",
                    IsFeatured = true
                },
                new Answer
                {
                    AnswerId = 6,
                    UserId = 6,
                    QuestionId = 6,
                    AnswerText = "Reviso mi trabajo varias veces y utilizo herramientas de verificación antes de presentarlo. Además, pido a un colega que lo revise para asegurarme de su precisión.",
                    IsFeatured = true
                },
                new Answer
                {
                    AnswerId = 7,
                    UserId = 7,
                    QuestionId = 7,
                    AnswerText = "Fomento la comunicación abierta en mi equipo organizando reuniones periódicas y utilizando herramientas de colaboración para asegurarnos de que todos estén alineados.",
                    IsFeatured = true
                },
                new Answer
                {
                    AnswerId = 8,
                    UserId = 8,
                    QuestionId = 8,
                    AnswerText = "Veo la retroalimentación negativa como una oportunidad para mejorar. Escucho atentamente, analizo la crítica y hago los cambios necesarios.",
                    IsFeatured = true
                },
                new Answer
                {
                    AnswerId = 9,
                    UserId = 9,
                    QuestionId = 9,
                    AnswerText = "Lo que más me motiva es ver el impacto positivo de mi trabajo y el reconocimiento por parte de mis colegas y superiores.",
                    IsFeatured = true
                },
                new Answer
                {
                    AnswerId = 10,
                    UserId = 10,
                    QuestionId = 10,
                    AnswerText = "Gestiono los conflictos abordando los problemas de manera directa y honesta, buscando soluciones que beneficien a ambas partes.",
                    IsFeatured = true
                }
     );



            var random = new Random();

            modelBuilder.Entity<Application>().HasData(
                new Application
                {
                    ApplicationId = 1,
                    UserId = 11,
                    JobOfferId = random.Next(1, 21),
                    ApplicationDate = new DateTimeOffset(new DateTime(2024, 1, 5)),
                    Status = "Pendiente",
                    SalaryExpected = 60000
                },
                new Application
                {
                    ApplicationId = 2,
                    UserId = 12,
                    JobOfferId = random.Next(1, 21),
                    ApplicationDate = new DateTimeOffset(new DateTime(2024, 2, 20)),
                    Status = "Aceptado",
                    SalaryExpected = 50000
                },
                new Application
                {
                    ApplicationId = 3,
                    UserId = 13,
                    JobOfferId = random.Next(1, 21),
                    ApplicationDate = new DateTimeOffset(new DateTime(2024, 3, 15)),
                    Status = "Pendiente",
                    SalaryExpected = 55000
                },
                new Application
                {
                    ApplicationId = 4,
                    UserId = 14,
                    JobOfferId = random.Next(1, 21),
                    ApplicationDate = new DateTimeOffset(new DateTime(2024, 4, 10)),
                    Status = "Rechazado",
                    SalaryExpected = 52000
                },
                new Application
                {
                    ApplicationId = 5,
                    UserId = 15,
                    JobOfferId = random.Next(1, 21),
                    ApplicationDate = new DateTimeOffset(new DateTime(2024, 5, 18)),
                    Status = "Pendiente",
                    SalaryExpected = 58000
                },
                new Application
                {
                    ApplicationId = 6,
                    UserId = 16,
                    JobOfferId = random.Next(1, 21),
                    ApplicationDate = new DateTimeOffset(new DateTime(2024, 6, 22)),
                    Status = "Aceptado",
                    SalaryExpected = 61000
                },
                new Application
                {
                    ApplicationId = 7,
                    UserId = 17,
                    JobOfferId = random.Next(1, 21),
                    ApplicationDate = new DateTimeOffset(new DateTime(2024, 7, 25)),
                    Status = "Rechazado",
                    SalaryExpected = 59000
                },
                new Application
                {
                    ApplicationId = 8,
                    UserId = 18,
                    JobOfferId = random.Next(1, 21),
                    ApplicationDate = new DateTimeOffset(new DateTime(2024, 8, 15)),
                    Status = "Pendiente",
                    SalaryExpected = 62000
                },
                new Application
                {
                    ApplicationId = 9,
                    UserId = 19,
                    JobOfferId = random.Next(1, 21),
                    ApplicationDate = new DateTimeOffset(new DateTime(2024, 9, 5)),
                    Status = "Aceptado",
                    SalaryExpected = 53000
                },
                new Application
                {
                    ApplicationId = 10,
                    UserId = 20,
                    JobOfferId = random.Next(1, 21),
                    ApplicationDate = new DateTimeOffset(new DateTime(2024, 10, 12)),
                    Status = "Rechazado",
                    SalaryExpected = 56000
                }
            );


            modelBuilder.Entity<Education>().HasData(
    new Education
    {
        EducationId = 1,
        UserId = 3,
        SchoolName = "Universidad Nacional",
        Degree = "Licenciatura",
        FieldOfStudy = "Administración de Empresas",
        StartDate = new DateTimeOffset(new DateTime(2016, 9, 1)),
        EndDate = new DateTimeOffset(new DateTime(2020, 6, 15)),
        Grade = "Sobresaliente",
        ActivitiesAndSocieties = "Asociación de Empresarios",
        Description = "Enfoque en gestión empresarial y emprendimiento."
    },
    new Education
    {
        EducationId = 2,
        UserId = 4,
        SchoolName = "Instituto Tecnológico Superior",
        Degree = "Diplomado",
        FieldOfStudy = "Marketing Digital",
        StartDate = new DateTimeOffset(new DateTime(2018, 3, 10)),
        EndDate = new DateTimeOffset(new DateTime(2019, 12, 20)),
        Grade = "A",
        ActivitiesAndSocieties = "Club de Marketing",
        Description = "Diplomado en estrategias de marketing digital y redes sociales."
    },
    new Education
    {
        EducationId = 3,
        UserId = 5,
        SchoolName = "Escuela de Negocios Internacional",
        Degree = "MBA",
        FieldOfStudy = "Finanzas",
        StartDate = new DateTimeOffset(new DateTime(2017, 1, 15)),
        EndDate = new DateTimeOffset(new DateTime(2019, 6, 30)),
        Grade = "Excelente",
        ActivitiesAndSocieties = "Foro de Finanzas",
        Description = "Máster en administración de negocios con especialización en finanzas corporativas."
    },
    new Education
    {
        EducationId = 4,
        UserId = 6,
        SchoolName = "Universidad de Tecnología",
        Degree = "Ingeniería",
        FieldOfStudy = "Ingeniería de Sistemas",
        StartDate = new DateTimeOffset(new DateTime(2014, 8, 1)),
        EndDate = new DateTimeOffset(new DateTime(2018, 5, 15)),
        Grade = "Muy Bueno",
        ActivitiesAndSocieties = "Sociedad de Ingenieros",
        Description = "Especialización en desarrollo de software y sistemas integrados."
    },
    new Education
    {
        EducationId = 5,
        UserId = 7,
        SchoolName = "Colegio de Artes y Ciencias",
        Degree = "Doctorado",
        FieldOfStudy = "Ciencias Ambientales",
        StartDate = new DateTimeOffset(new DateTime(2015, 9, 1)),
        EndDate = new DateTimeOffset(new DateTime(2021, 12, 15)),
        Grade = "A+",
        ActivitiesAndSocieties = "Investigación en Cambio Climático",
        Description = "Doctorado en ciencias ambientales con investigación en sostenibilidad y cambio climático."
    },
    new Education
    {
        EducationId = 6,
        UserId = 11,
        SchoolName = "Universidad de Ciencias Aplicadas",
        Degree = "Licenciatura",
        FieldOfStudy = "Biotecnología",
        StartDate = new DateTimeOffset(new DateTime(2013, 9, 1)),
        EndDate = new DateTimeOffset(new DateTime(2017, 6, 15)),
        Grade = "Sobresaliente",
        ActivitiesAndSocieties = "Club de Investigación Biotecnológica",
        Description = "Enfoque en desarrollo de tecnologías para la salud y el medio ambiente."
    },
    new Education
    {
        EducationId = 7,
        UserId = 12,
        SchoolName = "Instituto Superior de Artes",
        Degree = "Licenciatura",
        FieldOfStudy = "Diseño Gráfico",
        StartDate = new DateTimeOffset(new DateTime(2015, 9, 1)),
        EndDate = new DateTimeOffset(new DateTime(2019, 6, 15)),
        Grade = "Excelente",
        ActivitiesAndSocieties = "Club de Diseño",
        Description = "Especialización en diseño gráfico y comunicación visual."
    },
    new Education
    {
        EducationId = 8,
        UserId = 13,
        SchoolName = "Escuela Politécnica Nacional",
        Degree = "Máster",
        FieldOfStudy = "Ingeniería Civil",
        StartDate = new DateTimeOffset(new DateTime(2017, 1, 10)),
        EndDate = new DateTimeOffset(new DateTime(2021, 12, 20)),
        Grade = "A",
        ActivitiesAndSocieties = "Sociedad de Ingenieros Civiles",
        Description = "Máster en ingeniería civil con especialización en estructuras."
    },
    new Education
    {
        EducationId = 9,
        UserId = 14,
        SchoolName = "Academia Internacional de Ciencias",
        Degree = "Diplomado",
        FieldOfStudy = "Ciencia de Datos",
        StartDate = new DateTimeOffset(new DateTime(2019, 3, 15)),
        EndDate = new DateTimeOffset(new DateTime(2020, 12, 10)),
        Grade = "Muy Bueno",
        ActivitiesAndSocieties = "Asociación de Científicos de Datos",
        Description = "Diplomado en ciencia de datos con enfoque en análisis y modelado predictivo."
    },
    new Education
    {
        EducationId = 10,
        UserId = 15,
        SchoolName = "Escuela de Artes Visuales",
        Degree = "Licenciatura",
        FieldOfStudy = "Fotografía",
        StartDate = new DateTimeOffset(new DateTime(2016, 9, 1)),
        EndDate = new DateTimeOffset(new DateTime(2020, 6, 15)),
        Grade = "Excelente",
        ActivitiesAndSocieties = "Club de Fotografía",
        Description = "Especialización en fotografía artística y comercial."
    }
);



            // Seed para Feedback
            modelBuilder.Entity<Feedback>().HasData(
      new Feedback
      {
          FeedbackId = 1,
          ApplicationId = 1,
          RecruiterId = 1,
          FeedbackText = "Gracias por tu tiempo y esfuerzo en la entrevista. Mostraste un buen entendimiento técnico, pero podrías mejorar en la claridad de tus respuestas.",
          FeedbackDate = new DateTimeOffset(new DateTime(2024, 5, 10))
      },
      new Feedback
      {
          FeedbackId = 2,
          ApplicationId = 2,
          RecruiterId = 2,
          FeedbackText = "Impresionante experiencia en gestión de proyectos. Tus habilidades en resolución de problemas destacaron. Considera practicar más entrevistas para pulir tu presentación.",
          FeedbackDate = new DateTimeOffset(new DateTime(2024, 6, 15))
      },
      new Feedback
      {
          FeedbackId = 3,
          ApplicationId = 3,
          RecruiterId = 3,
          FeedbackText = "Demostraste un excelente conocimiento en desarrollo de software. Sin embargo, te recomendaría trabajar en la forma en que comunicas tus ideas durante entrevistas.",
          FeedbackDate = new DateTimeOffset(new DateTime(2024, 7, 20))
      },
      new Feedback
      {
          FeedbackId = 4,
          ApplicationId = 4,
          RecruiterId = 4,
          FeedbackText = "Tu experiencia en finanzas es notable. Sin embargo, podrías beneficiarte al mejorar tus habilidades en la presentación y comunicación de informes.",
          FeedbackDate = new DateTimeOffset(new DateTime(2024, 8, 25))
      },
      new Feedback
      {
          FeedbackId = 5,
          ApplicationId = 5,
          RecruiterId = 5,
          FeedbackText = "Tienes un enfoque innovador en soluciones. Para fortalecer tu perfil, te recomendaría mejorar en la gestión de equipos y coordinación de proyectos.",
          FeedbackDate = new DateTimeOffset(new DateTime(2024, 9, 30))
      },
      new Feedback
      {
          FeedbackId = 6,
          ApplicationId = 6,
          RecruiterId = 6,
          FeedbackText = "Tus conocimientos en sostenibilidad son valiosos. Para futuros procesos, trabaja en la articulación clara de tus logros y experiencias.",
          FeedbackDate = new DateTimeOffset(new DateTime(2024, 10, 15))
      },
      new Feedback
      {
          FeedbackId = 7,
          ApplicationId = 7,
          RecruiterId = 7,
          FeedbackText = "Tienes una sólida base en DevOps. Para mejorar, considera enfocarte más en la documentación técnica y en la comunicación de tu trabajo.",
          FeedbackDate = new DateTimeOffset(new DateTime(2024, 11, 5))
      },
      new Feedback
      {
          FeedbackId = 8,
          ApplicationId = 8,
          RecruiterId = 8,
          FeedbackText = "Tu experiencia en investigación biomédica es destacable. Te sugiero trabajar en cómo presentar tus hallazgos de manera más efectiva en futuras entrevistas.",
          FeedbackDate = new DateTimeOffset(new DateTime(2024, 12, 1))
      },
      new Feedback
      {
          FeedbackId = 9,
          ApplicationId = 9,
          RecruiterId = 9,
          FeedbackText = "Mostraste habilidades fuertes en análisis de datos. Te recomendaría enfocarte en la presentación visual de tus resultados y en cómo comunicar tus conclusiones.",
          FeedbackDate = new DateTimeOffset(new DateTime(2024, 12, 15))
      },
      new Feedback
      {
          FeedbackId = 10,
          ApplicationId = 10,
          RecruiterId = 10,
          FeedbackText = "Tienes una visión estratégica impresionante. Para mejorar tu perfil, trabaja en el desarrollo de habilidades de liderazgo y gestión de equipos.",
          FeedbackDate = new DateTimeOffset(new DateTime(2024, 12, 30))
      }
  );

            // Seed para Interest
            modelBuilder.Entity<Interest>().HasData(
    new Interest
    {
        InterestId = 1,
        UserId = 11,
        InterestText = "Viajes y aventuras"
    },
    new Interest
    {
        InterestId = 2,
        UserId = 12,
        InterestText = "Cocina y gastronomía"
    },
    new Interest
    {
        InterestId = 3,
        UserId = 13,
        InterestText = "Lectura y escritura"
    },
    new Interest
    {
        InterestId = 4,
        UserId = 14,
        InterestText = "Fotografía y video"
    },
    new Interest
    {
        InterestId = 5,
        UserId = 15,
        InterestText = "Música y conciertos"
    },
    new Interest
    {
        InterestId = 6,
        UserId = 16,
        InterestText = "Deportes y fitness"
    },
    new Interest
    {
        InterestId = 7,
        UserId = 17,
        InterestText = "Jardinería y naturaleza"
    },
    new Interest
    {
        InterestId = 8,
        UserId = 18,
        InterestText = "Tecnología y gadgets"
    },
    new Interest
    {
        InterestId = 9,
        UserId = 19,
        InterestText = "Artes y manualidades"
    },
    new Interest
    {
        InterestId = 10,
        UserId = 20,
        InterestText = "Voluntariado y causas sociales"
    }
);




            // Seed para Match
            modelBuilder.Entity<Match>().HasData(
    // Coincidencias para usuarios con UserId del 1 al 10
    new Match
    {
        MatchId = 1,
        JobOfferId = 3,  // Asegúrate de que JobOfferId 3 exista
        UserId = 1,
        MatchDate = new DateTimeOffset(new DateTime(2024, 8, 15), TimeSpan.Zero),
        IsAccepted = true
    },
    new Match
    {
        MatchId = 2,
        JobOfferId = 4,  // Asegúrate de que JobOfferId 4 exista
        UserId = 2,
        MatchDate = new DateTimeOffset(new DateTime(2024, 8, 17), TimeSpan.Zero),
        IsAccepted = false
    },
    new Match
    {
        MatchId = 3,
        JobOfferId = 5,  // Asegúrate de que JobOfferId 5 exista
        UserId = 3,
        MatchDate = new DateTimeOffset(new DateTime(2024, 8, 20), TimeSpan.Zero),
        IsAccepted = true
    },
    new Match
    {
        MatchId = 4,
        JobOfferId = 6,  // Asegúrate de que JobOfferId 6 exista
        UserId = 4,
        MatchDate = new DateTimeOffset(new DateTime(2024, 8, 22), TimeSpan.Zero),
        IsAccepted = true
    },
    new Match
    {
        MatchId = 5,
        JobOfferId = 7,  // Asegúrate de que JobOfferId 7 exista
        UserId = 5,
        MatchDate = new DateTimeOffset(new DateTime(2024, 8, 25), TimeSpan.Zero),
        IsAccepted = false
    },

    // Coincidencias para usuarios con UserId del 11 al 20
    new Match
    {
        MatchId = 6,
        JobOfferId = 8,  // Asegúrate de que JobOfferId 8 exista
        UserId = 11,
        MatchDate = new DateTimeOffset(new DateTime(2024, 8, 30), TimeSpan.Zero),
        IsAccepted = true
    },
    new Match
    {
        MatchId = 7,
        JobOfferId = 9,  // Asegúrate de que JobOfferId 9 exista
        UserId = 12,
        MatchDate = new DateTimeOffset(new DateTime(2024, 8, 31), TimeSpan.Zero),
        IsAccepted = false
    },
    new Match
    {
        MatchId = 8,
        JobOfferId = 10,  // Asegúrate de que JobOfferId 10 exista
        UserId = 13,
        MatchDate = new DateTimeOffset(new DateTime(2024, 9, 2), TimeSpan.Zero),
        IsAccepted = true
    },
    new Match
    {
        MatchId = 9,
        JobOfferId = 11,  // Asegúrate de que JobOfferId 11 exista
        UserId = 14,
        MatchDate = new DateTimeOffset(new DateTime(2024, 9, 5), TimeSpan.Zero),
        IsAccepted = true
    },
    new Match
    {
        MatchId = 10,
        JobOfferId = 12,  // Asegúrate de que JobOfferId 12 exista
        UserId = 15,
        MatchDate = new DateTimeOffset(new DateTime(2024, 9, 7), TimeSpan.Zero),
        IsAccepted = false
    }
);



            // Seed para SocialMedia
            modelBuilder.Entity<SocialMedia>().HasData(
                new SocialMedia { SocialMediaId = 1, UserId = 1, Platform = "LinkedIn", Url = "https://www.linkedin.com/in/admin" },
                new SocialMedia { SocialMediaId = 2, UserId = 2, Platform = "Twitter", Url = "https://twitter.com/usuario" }
            );

            // Seed para UserPreference
            modelBuilder.Entity<UserPreference>().HasData(
    // Preferencias para usuarios con UserId del 11 al 20
    new UserPreference
    {
        PreferenceId = 1,
        UserId = 11,
        Category = "Tipo de Trabajo",
        Value = "Tipo de Trabajo - Freelance"
    },
    new UserPreference
    {
        PreferenceId = 2,
        UserId = 12,
        Category = "Salario",
        Value = "Salario - Competitivo"
    },
    new UserPreference
    {
        PreferenceId = 3,
        UserId = 13,
        Category = "Horario",
        Value = "Horario - Tiempo Parcial"
    },
    new UserPreference
    {
        PreferenceId = 4,
        UserId = 14,
        Category = "Ubicación",
        Value = "Ubicación - Ciudad Principal"
    },
    new UserPreference
    {
        PreferenceId = 5,
        UserId = 15,
        Category = "Oportunidades",
        Value = "Oportunidades - Liderazgo"
    },
    new UserPreference
    {
        PreferenceId = 6,
        UserId = 16,
        Category = "Tipo de Trabajo",
        Value = "Tipo de Trabajo - Contrato"
    },
    new UserPreference
    {
        PreferenceId = 7,
        UserId = 17,
        Category = "Salario",
        Value = "Salario - Basado en Experiencia"
    },
    new UserPreference
    {
        PreferenceId = 8,
        UserId = 18,
        Category = "Horario",
        Value = "Horario - Tiempo Completo"
    },
    new UserPreference
    {
        PreferenceId = 9,
        UserId = 19,
        Category = "Ubicación",
        Value = "Ubicación - Remoto"
    },
    new UserPreference
    {
        PreferenceId = 10,
        UserId = 20,
        Category = "Oportunidades",
        Value = "Oportunidades - Internacionales"
    }
);

            // Seed para UserSkill
            modelBuilder.Entity<UserSkill>().HasData(
    // UserSkills para UserId 11
    new UserSkill
    {
        UserSkillId = 1,
        UserId = 11,
        SkillId = 1, // Supone que existe una habilidad con ID 1
        ProficiencyLevel = "Experto",
        RelatedTo = "Certificación",
        RelatedId = 101
    },
    new UserSkill
    {
        UserSkillId = 2,
        UserId = 11,
        SkillId = 2, // Supone que existe una habilidad con ID 2
        ProficiencyLevel = "Avanzado",
        RelatedTo = "Curso",
        RelatedId = 202
    },
    new UserSkill
    {
        UserSkillId = 3,
        UserId = 11,
        SkillId = 3, // Supone que existe una habilidad con ID 3
        ProficiencyLevel = "Intermedio",
        RelatedTo = "Proyecto",
        RelatedId = 303
    },
    new UserSkill
    {
        UserSkillId = 4,
        UserId = 11,
        SkillId = 4, // Supone que existe una habilidad con ID 4
        ProficiencyLevel = "Básico",
        RelatedTo = "Certificación",
        RelatedId = 404
    },

    // UserSkills para UserId 12
    new UserSkill
    {
        UserSkillId = 5,
        UserId = 12,
        SkillId = 5, // Supone que existe una habilidad con ID 5
        ProficiencyLevel = "Experto",
        RelatedTo = "Curso",
        RelatedId = 505
    },
    new UserSkill
    {
        UserSkillId = 6,
        UserId = 12,
        SkillId = 6, // Supone que existe una habilidad con ID 6
        ProficiencyLevel = "Avanzado",
        RelatedTo = "Proyecto",
        RelatedId = 606
    },
    new UserSkill
    {
        UserSkillId = 7,
        UserId = 12,
        SkillId = 7, // Supone que existe una habilidad con ID 7
        ProficiencyLevel = "Intermedio",
        RelatedTo = "Certificación",
        RelatedId = 707
    },
    new UserSkill
    {
        UserSkillId = 8,
        UserId = 12,
        SkillId = 8, // Supone que existe una habilidad con ID 8
        ProficiencyLevel = "Básico",
        RelatedTo = "Curso",
        RelatedId = 808
    },

    // UserSkills para UserId 13
    new UserSkill
    {
        UserSkillId = 9,
        UserId = 13,
        SkillId = 9, // Supone que existe una habilidad con ID 9
        ProficiencyLevel = "Experto",
        RelatedTo = "Proyecto",
        RelatedId = 909
    },
    new UserSkill
    {
        UserSkillId = 10,
        UserId = 13,
        SkillId = 10, // Supone que existe una habilidad con ID 10
        ProficiencyLevel = "Avanzado",
        RelatedTo = "Certificación",
        RelatedId = 1010
    },
    new UserSkill
    {
        UserSkillId = 11,
        UserId = 13,
        SkillId = 11, // Supone que existe una habilidad con ID 11
        ProficiencyLevel = "Intermedio",
        RelatedTo = "Curso",
        RelatedId = 1111
    },
    new UserSkill
    {
        UserSkillId = 12,
        UserId = 13,
        SkillId = 12, // Supone que existe una habilidad con ID 12
        ProficiencyLevel = "Básico",
        RelatedTo = "Proyecto",
        RelatedId = 1212
    },

    // UserSkills para UserId 14
    new UserSkill
    {
        UserSkillId = 13,
        UserId = 14,
        SkillId = 13, // Supone que existe una habilidad con ID 13
        ProficiencyLevel = "Experto",
        RelatedTo = "Certificación",
        RelatedId = 1313
    },
    new UserSkill
    {
        UserSkillId = 14,
        UserId = 14,
        SkillId = 14, // Supone que existe una habilidad con ID 14
        ProficiencyLevel = "Avanzado",
        RelatedTo = "Curso",
        RelatedId = 1414
    },
    new UserSkill
    {
        UserSkillId = 15,
        UserId = 14,
        SkillId = 15, // Supone que existe una habilidad con ID 15
        ProficiencyLevel = "Intermedio",
        RelatedTo = "Proyecto",
        RelatedId = 1515
    },
    new UserSkill
    {
        UserSkillId = 16,
        UserId = 14,
        SkillId = 16, // Supone que existe una habilidad con ID 16
        ProficiencyLevel = "Básico",
        RelatedTo = "Certificación",
        RelatedId = 1616
    },

    // UserSkills para UserId 15
    new UserSkill
    {
        UserSkillId = 17,
        UserId = 15,
        SkillId = 17, // Supone que existe una habilidad con ID 17
        ProficiencyLevel = "Experto",
        RelatedTo = "Curso",
        RelatedId = 1717
    },
    new UserSkill
    {
        UserSkillId = 18,
        UserId = 15,
        SkillId = 18, // Supone que existe una habilidad con ID 18
        ProficiencyLevel = "Avanzado",
        RelatedTo = "Certificación",
        RelatedId = 1818
    },
    new UserSkill
    {
        UserSkillId = 19,
        UserId = 15,
        SkillId = 19, // Supone que existe una habilidad con ID 19
        ProficiencyLevel = "Intermedio",
        RelatedTo = "Proyecto",
        RelatedId = 1919
    },
    new UserSkill
    {
        UserSkillId = 20,
        UserId = 15,
        SkillId = 20, // Supone que existe una habilidad con ID 20
        ProficiencyLevel = "Básico",
        RelatedTo = "Curso",
        RelatedId = 2020
    },

    // UserSkills para UserId 16
    new UserSkill
    {
        UserSkillId = 21,
        UserId = 16,
        SkillId = 21, // Supone que existe una habilidad con ID 21
        ProficiencyLevel = "Experto",
        RelatedTo = "Certificación",
        RelatedId = 2121
    },
    new UserSkill
    {
        UserSkillId = 22,
        UserId = 16,
        SkillId = 22, // Supone que existe una habilidad con ID 22
        ProficiencyLevel = "Avanzado",
        RelatedTo = "Curso",
        RelatedId = 2222
    },
    new UserSkill
    {
        UserSkillId = 23,
        UserId = 16,
        SkillId = 23, // Supone que existe una habilidad con ID 23
        ProficiencyLevel = "Intermedio",
        RelatedTo = "Proyecto",
        RelatedId = 2323
    },
    new UserSkill
    {
        UserSkillId = 24,
        UserId = 16,
        SkillId = 24, // Supone que existe una habilidad con ID 24
        ProficiencyLevel = "Básico",
        RelatedTo = "Certificación",
        RelatedId = 2424
    },

    // UserSkills para UserId 17
    new UserSkill
    {
        UserSkillId = 25,
        UserId = 17,
        SkillId = 25, // Supone que existe una habilidad con ID 25
        ProficiencyLevel = "Experto",
        RelatedTo = "Curso",
        RelatedId = 2525
    },
    new UserSkill
    {
        UserSkillId = 26,
        UserId = 17,
        SkillId = 26, // Supone que existe una habilidad con ID 26
        ProficiencyLevel = "Avanzado",
        RelatedTo = "Certificación",
        RelatedId = 2626
    },
    new UserSkill
    {
        UserSkillId = 27,
        UserId = 17,
        SkillId = 27, // Supone que existe una habilidad con ID 27
        ProficiencyLevel = "Intermedio",
        RelatedTo = "Proyecto",
        RelatedId = 2727
    },
    new UserSkill
    {
        UserSkillId = 28,
        UserId = 17,
        SkillId = 28, // Supone que existe una habilidad con ID 28
        ProficiencyLevel = "Básico",
        RelatedTo = "Curso",
        RelatedId = 2828
    },

    // UserSkills para UserId 18
    new UserSkill
    {
        UserSkillId = 29,
        UserId = 18,
        SkillId = 29, // Supone que existe una habilidad con ID 29
        ProficiencyLevel = "Experto",
        RelatedTo = "Certificación",
        RelatedId = 2929
    },
    new UserSkill
    {
        UserSkillId = 30,
        UserId = 18,
        SkillId = 30, // Supone que existe una habilidad con ID 30
        ProficiencyLevel = "Avanzado",
        RelatedTo = "Curso",
        RelatedId = 3030
    },
    new UserSkill
    {
        UserSkillId = 31,
        UserId = 18,
        SkillId = 31, // Supone que existe una habilidad con ID 31
        ProficiencyLevel = "Intermedio",
        RelatedTo = "Proyecto",
        RelatedId = 3131
    },
    new UserSkill
    {
        UserSkillId = 32,
        UserId = 18,
        SkillId = 32, // Supone que existe una habilidad con ID 32
        ProficiencyLevel = "Básico",
        RelatedTo = "Certificación",
        RelatedId = 3232
    },

    // UserSkills para UserId 19
    new UserSkill
    {
        UserSkillId = 33,
        UserId = 19,
        SkillId = 33, // Supone que existe una habilidad con ID 33
        ProficiencyLevel = "Experto",
        RelatedTo = "Curso",
        RelatedId = 3333
    },
    new UserSkill
    {
        UserSkillId = 34,
        UserId = 19,
        SkillId = 34, // Supone que existe una habilidad con ID 34
        ProficiencyLevel = "Avanzado",
        RelatedTo = "Certificación",
        RelatedId = 3434
    },
    new UserSkill
    {
        UserSkillId = 35,
        UserId = 19,
        SkillId = 35, // Supone que existe una habilidad con ID 35
        ProficiencyLevel = "Intermedio",
        RelatedTo = "Proyecto",
        RelatedId = 3535
    },
    new UserSkill
    {
        UserSkillId = 36,
        UserId = 19,
        SkillId = 36, // Supone que existe una habilidad con ID 36
        ProficiencyLevel = "Básico",
        RelatedTo = "Curso",
        RelatedId = 3636
    },

    // UserSkills para UserId 20
    new UserSkill
    {
        UserSkillId = 37,
        UserId = 20,
        SkillId = 37, // Supone que existe una habilidad con ID 37
        ProficiencyLevel = "Experto",
        RelatedTo = "Certificación",
        RelatedId = 3737
    },
    new UserSkill
    {
        UserSkillId = 38,
        UserId = 20,
        SkillId = 38, // Supone que existe una habilidad con ID 38
        ProficiencyLevel = "Avanzado",
        RelatedTo = "Curso",
        RelatedId = 3838
    },
    new UserSkill
    {
        UserSkillId = 39,
        UserId = 20,
        SkillId = 39, // Supone que existe una habilidad con ID 39
        ProficiencyLevel = "Intermedio",
        RelatedTo = "Proyecto",
        RelatedId = 3939
    },
    new UserSkill
    {
        UserSkillId = 40,
        UserId = 20,
        SkillId = 40, // Supone que existe una habilidad con ID 40
        ProficiencyLevel = "Básico",
        RelatedTo = "Certificación",
        RelatedId = 4040
    }
);


            // Seed para WorkExperience
            modelBuilder.Entity<WorkExperience>().HasData(
    // WorkExperience para UserId 1
    new WorkExperience
    {
        WorkExperienceId = 1,
        UserId = 1,
        CompanyName = "Tech Innovations",
        JobTitle = "Desarrollador Frontend",
        StartDate = new DateTimeOffset(new DateTime(2018, 7, 1)),
        EndDate = new DateTimeOffset(new DateTime(2020, 5, 31)),
        Description = "Desarrollo de interfaces web utilizando React y CSS.",
        Location = "Ciudad de México"
    },
    new WorkExperience
    {
        WorkExperienceId = 2,
        UserId = 8,
        CompanyName = "SoftTech",
        JobTitle = "Analista de Sistemas",
        StartDate = new DateTimeOffset(new DateTime(2016, 3, 1)),
        EndDate = new DateTimeOffset(new DateTime(2018, 6, 30)),
        Description = "Análisis de requerimientos y diseño de soluciones tecnológicas.",
        Location = "Puebla"
    },
    // WorkExperience para UserId 3
    new WorkExperience
    {
        WorkExperienceId = 3,
        UserId = 3,
        CompanyName = "Creative Labs",
        JobTitle = "Diseñador UX/UI",
        StartDate = new DateTimeOffset(new DateTime(2021, 1, 5)),
        EndDate = new DateTimeOffset(new DateTime(2024, 5, 30)),
        Description = "Diseño de interfaces de usuario y experiencias de usuario para aplicaciones móviles.",
        Location = "Monterrey"
    },
    // WorkExperience para UserId 5
    new WorkExperience
    {
        WorkExperienceId = 4,
        UserId = 5,
        CompanyName = "Data Insights",
        JobTitle = "Analista de Datos",
        StartDate = new DateTimeOffset(new DateTime(2020, 2, 1)),
        EndDate = new DateTimeOffset(new DateTime(2023, 8, 31)),
        Description = "Análisis y visualización de datos utilizando herramientas como R y Tableau.",
        Location = "Seattle"
    },
    // WorkExperience para UserId 7
    new WorkExperience
    {
        WorkExperienceId = 5,
        UserId = 7,
        CompanyName = "AppDev Inc.",
        JobTitle = "Desarrollador de Aplicaciones",
        StartDate = new DateTimeOffset(new DateTime(2018, 3, 1)),
        EndDate = new DateTimeOffset(new DateTime(2022, 6, 30)),
        Description = "Desarrollo de aplicaciones móviles y de escritorio.",
        Location = "San José"
    },

    // WorkExperience para UserId 11
    new WorkExperience
    {
        WorkExperienceId = 6,
        UserId = 11,
        CompanyName = "BioHealth",
        JobTitle = "Especialista en Biotecnología",
        StartDate = new DateTimeOffset(new DateTime(2019, 5, 1)),
        EndDate = new DateTimeOffset(new DateTime(2022, 4, 30)),
        Description = "Investigación y desarrollo de productos biotecnológicos.",
        Location = "San Francisco"
    },
    // WorkExperience para UserId 12
    new WorkExperience
    {
        WorkExperienceId = 7,
        UserId = 12,
        CompanyName = "Creative Design Co.",
        JobTitle = "Diseñador Gráfico",
        StartDate = new DateTimeOffset(new DateTime(2020, 3, 1)),
        EndDate = new DateTimeOffset(new DateTime(2022, 2, 28)),
        Description = "Creación de material visual y diseño de campañas publicitarias.",
        Location = "Los Ángeles"
    },
    // WorkExperience para UserId 14
    new WorkExperience
    {
        WorkExperienceId = 8,
        UserId = 14,
        CompanyName = "Data Insights",
        JobTitle = "Analista de Datos",
        StartDate = new DateTimeOffset(new DateTime(2020, 2, 1)),
        EndDate = new DateTimeOffset(new DateTime(2023, 8, 31)),
        Description = "Análisis y visualización de datos utilizando herramientas como R y Tableau.",
        Location = "Seattle"
    },
    // WorkExperience para UserId 16
    new WorkExperience
    {
        WorkExperienceId = 9,
        UserId = 16,
        CompanyName = "Cloud Solutions",
        JobTitle = "Arquitecto de Soluciones",
        StartDate = new DateTimeOffset(new DateTime(2021, 7, 1)),
        EndDate = new DateTimeOffset(new DateTime(2024, 8, 31)),
        Description = "Diseño e implementación de soluciones en la nube.",
        Location = "Austin"
    },
    // WorkExperience para UserId 18
    new WorkExperience
    {
        WorkExperienceId = 10,
        UserId = 18,
        CompanyName = "Global HR",
        JobTitle = "Gerente de Recursos Humanos",
        StartDate = new DateTimeOffset(new DateTime(2017, 9, 1)),
        EndDate = new DateTimeOffset(new DateTime(2021, 12, 31)),
        Description = "Gestión de equipos y desarrollo de estrategias de recursos humanos.",
        Location = "Miami"
    }
);
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
}