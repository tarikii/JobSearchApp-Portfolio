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
            Name = "Innovación Tecnológica S.A.",
            WebsiteUrl = "https://www.innovaciontecnologica.com",
            Industry = "Tecnología",
            Size = "Mediana",
            Headquarters = "Ciudad de México, México",
            FoundedYear = 2012,
            Description = "Una empresa dedicada a ofrecer soluciones tecnológicas avanzadas.",
            Location = "Ciudad de México, México"
        },
        new Company
        {
            CompanyId = 2,
            Name = "Servicios Creativos Ltda.",
            WebsiteUrl = "https://www.servicioscreativos.com",
            Industry = "Creatividad",
            Size = "Grande",
            Headquarters = "Buenos Aires, Argentina",
            FoundedYear = 2008,
            Description = "Expertos en diseño gráfico y desarrollo de estrategias creativas.",
            Location = "Buenos Aires, Argentina"
        },
        new Company
        {
            CompanyId = 3,
            Name = "Consultoría Global",
            WebsiteUrl = "https://www.consultoriaglobal.com",
            Industry = "Consultoría",
            Size = "Grande",
            Headquarters = "Madrid, España",
            FoundedYear = 2000,
            Description = "Proporciona servicios de consultoría en diversas áreas empresariales.",
            Location = "Madrid, España"
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
         }
     );

            // Seed para JobOffer
            modelBuilder.Entity<JobOffer>().HasData(
          new JobOffer
          {
              JobOfferId = 1,
              CompanyId = 1,
              Title = "Desarrollador de Software Senior",
              Description = "Buscamos un desarrollador de software senior para trabajar en proyectos innovadores en el área de tecnología.",
              Location = "Ciudad de México, México",
              JobType = "Tiempo completo",
              ExperienceLevel = "Senior",
              PostedDate = new DateTimeOffset(new DateTime(2024, 1, 10)),
              ExpiredDate = new DateTimeOffset(new DateTime(2024, 6, 10)),
              IsActive = true,
              EstimatedDurationDays = 30,
              MinSalary = 60000m,
              MaxSalary = 80000m
          },
          new JobOffer
          {
              JobOfferId = 2,
              CompanyId = 2,
              Title = "Diseñador Gráfico",
              Description = "Se busca diseñador gráfico con experiencia para crear material visual atractivo para nuestros clientes.",
              Location = "Buenos Aires, Argentina",
              JobType = "Medio tiempo",
              ExperienceLevel = "Junior",
              PostedDate = new DateTimeOffset(new DateTime(2024, 2, 15)),
              ExpiredDate = new DateTimeOffset(new DateTime(2024, 5, 15)),
              IsActive = true,
              EstimatedDurationDays = 45,
              MinSalary = 30000m,
              MaxSalary = 40000m
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
                new Question { QuestionId = 1, QuestionText = "¿Por qué quieres trabajar con nosotros?" },
                new Question { QuestionId = 2, QuestionText = "Describe un desafío que enfrentaste en tu trabajo anterior." }
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
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 1, SkillName = "C#", SkillType = "Tech" },
                new Skill { SkillId = 2, SkillName = "C#", SkillType = "Tech" },
                new Skill { SkillId = 3, SkillName = "C#", SkillType = "Tech" }
            );

            // Seed para Tag
            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagId = 1, TagName = "Remoto", ImageUrl = "URL" },
                new Tag { TagId = 2, TagName = "Tiempo completo", ImageUrl = "URL" }
            );

            // Seed para CompanyTag
            modelBuilder.Entity<CompanyTag>().HasData(
                new CompanyTag { CompanyId = 1, TagId = 1 },
                new CompanyTag { CompanyId = 2, TagId = 2 }
            );

            // Seed para User
            modelBuilder.Entity<User>().HasData(
     new User
     {
         UserId = 1,
         Email = "admin@techcorp.com",
         UserName = "admin",
         PasswordHash = "AQAAAAEAACcQAAAAEDu6ak/YXB+W7W0zY6jEjG5L8/lRxV9NkH5j2Jsfg==", // Hash de ejemplo
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
         RoleId = 1,
         CompanyId = 1,
         IsWorking = true
     },
     new User
     {
         UserId = 2,
         Email = "jane.doe@saludplus.com",
         UserName = "janedoe",
         PasswordHash = "AQAAAAEAACcQAAAAEBvD5Bb5FVJL/OoYNm4OE4bD81kFfgp1zB/gE4bZg==", // Hash de ejemplo
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
         AnswerText = "Creo que la tecnología blockchain transformará muchas industrias, especialmente las finanzas.",
         IsFeatured = true
     },
     new Answer
     {
         AnswerId = 2,
         UserId = 2,
         QuestionId = 2,
         AnswerText = "El aprendizaje automático ya está revolucionando el análisis de datos en el sector salud.",
         IsFeatured = false
     },
     new Answer
     {
         AnswerId = 3,
         UserId = 2,
         QuestionId = 1,
         AnswerText = "En mi opinión, la realidad aumentada cambiará la manera en que interactuamos con el mundo digital.",
         IsFeatured = false
     }
 // Agrega más respuestas aquí si es necesario
 );


            // Seed para Application
            modelBuilder.Entity<Application>().HasData(
         new Application
         {
             ApplicationId = 1,
             UserId = 1,  // Asegúrate de que UserId 1 existe
             JobOfferId = 1, // Asegúrate de que JobOfferId 1 existe
             ApplicationDate = new DateTimeOffset(new DateTime(2024, 1, 5)),
             Status = "Pendiente",
             SalaryExpected = 60000
         },
         new Application
         {
             ApplicationId = 2,
             UserId = 2,  // Asegúrate de que UserId 2 existe
             JobOfferId = 2, // Asegúrate de que JobOfferId 2 existe
             ApplicationDate = new DateTimeOffset(new DateTime(2024, 2, 20)),
             Status = "Aceptado",
             SalaryExpected = 50000
         }
     );

            // Seed para Education
            modelBuilder.Entity<Education>().HasData(
     new Education
     {
         EducationId = 1,
         UserId = 1, // Asegúrate de que UserId 1 exista en la tabla User
         SchoolName = "Universidad de Ejemplo",
         Degree = "Licenciatura",
         FieldOfStudy = "Ingeniería de Software",
         StartDate = new DateTimeOffset(new DateTime(2015, 9, 1)),
         EndDate = new DateTimeOffset(new DateTime(2019, 6, 15)),
         Grade = "Excelente",
         ActivitiesAndSocieties = "Club de Programación",
         Description = "Estudios de ingeniería de software con enfoque en desarrollo web y móvil."
     },
     new Education
     {
         EducationId = 2,
         UserId = 2, // Asegúrate de que UserId 2 exista en la tabla User
         SchoolName = "Instituto de Ejemplo",
         Degree = "Máster",
         FieldOfStudy = "Ciencias de Datos",
         StartDate = new DateTimeOffset(new DateTime(2020, 1, 10)),
         EndDate = new DateTimeOffset(new DateTime(2022, 12, 20)),
         Grade = "A",
         ActivitiesAndSocieties = "Data Science Club",
         Description = "Máster en ciencia de datos con especialización en análisis predictivo y aprendizaje automático."
     }
 );


            // Seed para Feedback
            modelBuilder.Entity<Feedback>().HasData(
     new Feedback
     {
         FeedbackId = 1,
         ApplicationId = 1,
         RecruiterId = 1,
         FeedbackText = "El candidato mostró un gran conocimiento en las tecnologías requeridas y una actitud muy positiva durante la entrevista. Sin embargo, sería beneficioso para él mejorar sus habilidades de comunicación.",
         FeedbackDate = new DateTimeOffset(new DateTime(2024, 5, 10))
     },
     new Feedback
     {
         FeedbackId = 2,
         ApplicationId = 2,
         RecruiterId = 2,
         FeedbackText = "El candidato tiene una experiencia impresionante en gestión de proyectos y ha demostrado habilidades excepcionales en la resolución de problemas. Recomiendo proceder con una segunda ronda de entrevistas.",
         FeedbackDate = new DateTimeOffset(new DateTime(2024, 6, 15))
     }
 // Agrega más registros de retroalimentación aquí si es necesario
 );

            // Seed para Interest
            modelBuilder.Entity<Interest>().HasData(
    new Interest
    {
        InterestId = 1,
        UserId = 1,
        InterestText = "Desarrollo de software y tecnologías emergentes"
    },
    new Interest
    {
        InterestId = 2,
        UserId = 2,
        InterestText = "Diseño de interfaces de usuario y experiencia de usuario (UI/UX)"
    },
    new Interest
    {
        InterestId = 3,
        UserId = 2,
        InterestText = "Gestión de proyectos y metodologías ágiles"
    },
    new Interest
    {
        InterestId = 4,
        UserId = 1,
        InterestText = "Inteligencia artificial y aprendizaje automático"
    },
    new Interest
    {
        InterestId = 5,
        UserId = 2,
        InterestText = "Ciberseguridad y protección de datos"
    }
    // Agrega más registros de interés aquí si es necesario
);


            // Seed para Match
            modelBuilder.Entity<Match>().HasData(
       new Match
       {
           MatchId = 1,
           JobOfferId = 1,
           UserId = 1,
           MatchDate = new DateTimeOffset(new DateTime(2024, 8, 10), TimeSpan.Zero),
           IsAccepted = true
       },
       new Match
       {
           MatchId = 2,
           JobOfferId = 2,
           UserId = 2,
           MatchDate = new DateTimeOffset(new DateTime(2024, 8, 12), TimeSpan.Zero),
           IsAccepted = false
       }
   // Agrega más registros de coincidencia aquí si es necesario
   );


            // Seed para SocialMedia
            modelBuilder.Entity<SocialMedia>().HasData(
                new SocialMedia { SocialMediaId = 1, UserId = 1, Platform = "LinkedIn", Url = "https://www.linkedin.com/in/admin" },
                new SocialMedia { SocialMediaId = 2, UserId = 2, Platform = "Twitter", Url = "https://twitter.com/usuario" }
            );

            // Seed para UserPreference
            modelBuilder.Entity<UserPreference>().HasData(
      new UserPreference
      {
          PreferenceId = 1,
          UserId = 1,
          Category = "Tipo de Trabajo",
          Value = "Trabajo Remoto"
      },
      new UserPreference
      {
          PreferenceId = 2,
          UserId = 2,
          Category = "Tipo de Trabajo",
          Value = "Posición de tiempo completo"
      },
      new UserPreference
      {
          PreferenceId = 3,
          UserId = 2,
          Category = "Salario",
          Value = "Salario Alto"
      },
      new UserPreference
      {
          PreferenceId = 4,
          UserId = 1,
          Category = "Horario",
          Value = "Horario Flexible"
      },
      new UserPreference
      {
          PreferenceId = 5,
          UserId = 2,
          Category = "Oportunidades",
          Value = "Oportunidades de Crecimiento"
      }
  // Agrega más preferencias según sea necesario
  );


            // Seed para UserSkill
            modelBuilder.Entity<UserSkill>().HasData(
       new UserSkill
       {
           UserSkillId = 1,
           UserId = 1, // Supone que existe un usuario con ID 1
           SkillId = 1, // Supone que existe una habilidad con ID 1
           ProficiencyLevel = "Experto",
           RelatedTo = "Certificación",
           RelatedId = 101 // Por ejemplo, una ID de certificación
       },
       new UserSkill
       {
           UserSkillId = 2,
           UserId = 2, // Supone que existe un usuario con ID 2
           SkillId = 2, // Supone que existe una habilidad con ID 2
           ProficiencyLevel = "Intermedio",
           RelatedTo = "Curso",
           RelatedId = 202 // Por ejemplo, una ID de curso
       },
       new UserSkill
       {
           UserSkillId = 3,
           UserId = 2, // Supone que existe un usuario con ID 3
           SkillId = 3, // Supone que existe una habilidad con ID 3
           ProficiencyLevel = "Básico",
           RelatedTo = "Proyecto",
           RelatedId = 303 // Por ejemplo, una ID de proyecto
       }
   );

            // Seed para WorkExperience
            modelBuilder.Entity<WorkExperience>().HasData(
        new WorkExperience
        {
            WorkExperienceId = 1,
            UserId = 1, // Supone que existe un usuario con ID 1
            CompanyName = "Tech Solutions",
            JobTitle = "Desarrollador de Software",
            StartDate = new DateTimeOffset(new DateTime(2020, 6, 1)),
            EndDate = new DateTimeOffset(new DateTime(2022, 8, 31)),
            Description = "Desarrollo de aplicaciones web utilizando .NET y JavaScript.",
            Location = "Ciudad de México"
        },
        new WorkExperience
        {
            WorkExperienceId = 2,
            UserId = 2, // Supone que existe un usuario con ID 2
            CompanyName = "Innovate Inc.",
            JobTitle = "Ingeniero de Datos",
            StartDate = new DateTimeOffset(new DateTime(2019, 3, 15)),
            EndDate = new DateTimeOffset(new DateTime(2023, 7, 10)),
            Description = "Gestión y análisis de grandes volúmenes de datos con Python y SQL.",
            Location = "Guadalajara"
        },
        new WorkExperience
        {
            WorkExperienceId = 3,
            UserId = 1, // Supone que existe un usuario con ID 3
            CompanyName = "Creative Labs",
            JobTitle = "Diseñador UX/UI",
            StartDate = new DateTimeOffset(new DateTime(2021, 1, 5)),
            EndDate = new DateTimeOffset(new DateTime(2024, 5, 30)),
            Description = "Diseño de interfaces de usuario y experiencias de usuario para aplicaciones móviles.",
            Location = "Monterrey"
        }
    );

            // Seed para RolePermissionPatent
            modelBuilder.Entity<RolePermissionPatent>().HasData(
                new RolePermissionPatent { RoleId = 1, ResourceId = 1, Permission = "Leer" },
                new RolePermissionPatent { RoleId = 1, ResourceId = 1, Permission = "Escribir" },
                new RolePermissionPatent { RoleId = 1, ResourceId = 1, Permission = "Eliminar" },
                new RolePermissionPatent { RoleId = 2, ResourceId = 2, Permission = "Leer" }
            );
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