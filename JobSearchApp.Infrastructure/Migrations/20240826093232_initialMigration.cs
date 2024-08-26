using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobSearchApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundedYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "CompensationBenefit",
                columns: table => new
                {
                    BenefitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BenefitType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompensationBenefit", x => x.BenefitId);
                    table.ForeignKey(
                        name: "FK_CompensationBenefit_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOffer",
                columns: table => new
                {
                    JobOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpiredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EstimatedDurationDays = table.Column<int>(type: "int", nullable: false),
                    MinSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffer", x => x.JobOfferId);
                    table.ForeignKey(
                        name: "FK_JobOffer_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionPatent",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Permission = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionPatent", x => new { x.RoleId, x.ResourceId, x.Permission });
                    table.ForeignKey(
                        name: "FK_RolePermissionPatent_Permission_Permission",
                        column: x => x.Permission,
                        principalTable: "Permission",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionPatent_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionPatent_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateJoined = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LinkedInUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pronoun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ethnicity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequireVisa = table.Column<bool>(type: "bit", nullable: false),
                    SearchStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IsWorking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTag",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTag", x => new { x.CompanyId, x.TagId });
                    table.ForeignKey(
                        name: "FK_CompanyTag_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JobOfferId = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryExpected = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Application_JobOffer_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffer",
                        principalColumn: "JobOfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivitiesAndSocieties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Education_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InterestText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobOfferId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Match_JobOffer_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffer",
                        principalColumn: "JobOfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    SocialMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.SocialMediaId);
                    table.ForeignKey(
                        name: "FK_SocialMedia_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPreference",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreference", x => x.PreferenceId);
                    table.ForeignKey(
                        name: "FK_UserPreference_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    UserSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    ProficiencyLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => x.UserSkillId);
                    table.ForeignKey(
                        name: "FK_UserSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperience",
                columns: table => new
                {
                    WorkExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperience", x => x.WorkExperienceId);
                    table.ForeignKey(
                        name: "FK_WorkExperience_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    RecruiterId = table.Column<int>(type: "int", nullable: false),
                    FeedbackText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedback_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_User_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "Description", "FoundedYear", "Headquarters", "Industry", "Location", "Name", "Size", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1, "Fundación Esplai promueve la inclusión social, el voluntariado, y el uso de tecnologías de la información para la ciudadanía.", 1999, "El Prat de Llobregat, España", "ONG", "El Prat de Llobregat, España", "Fundación Esplai", "Mediana", "https://fundacionesplai.org/" },
                    { 2, "Empresa dedicada a la investigación y desarrollo de energías renovables y sostenibilidad ambiental.", 2015, "Barcelona, España", "Energía Renovable", "Barcelona, España", "Innovación Verde S.L.", "Mediana", "https://www.innovacionverde.com" },
                    { 3, "Especialistas en protección de datos y ciberseguridad para empresas.", 2018, "Madrid, España", "Seguridad Informática", "Madrid, España", "CiberSeguridad Total S.A.", "Pequeña", "https://www.ciberseguridadtotal.com" },
                    { 4, "Empresa especializada en el desarrollo de aplicaciones móviles innovadoras.", 2010, "Valencia, España", "Desarrollo de Software", "Valencia, España", "Desarrollos Móviles SL", "Mediana", "https://www.desarrollosmoviles.com" },
                    { 5, "Líder en la creación de experiencias turísticas personalizadas y tecnológicas.", 2005, "Sevilla, España", "Turismo", "Sevilla, España", "Turismo Inteligente S.A.", "Grande", "https://www.turismo-inteligente.com" },
                    { 6, "Proporciona soluciones de tratamiento y purificación de agua para uso doméstico e industrial.", 2012, "Málaga, España", "Agua y Saneamiento", "Málaga, España", "Agua Pura S.L.", "Mediana", "https://www.aguapura.com" },
                    { 7, "Productores y distribuidores de alimentos ecológicos y orgánicos en España.", 2000, "Bilbao, España", "Alimentación", "Bilbao, España", "Alimentos Ecológicos S.A.", "Grande", "https://www.alimentosecologicos.com" },
                    { 8, "Empresa constructora líder en proyectos residenciales y comerciales.", 1995, "Madrid, España", "Construcción", "Madrid, España", "Construcciones Modernas SL", "Grande", "https://www.construccionesmodernas.com" },
                    { 9, "Especialistas en logística y transporte de mercancías de manera eficiente y sostenible.", 2010, "Zaragoza, España", "Logística y Transporte", "Zaragoza, España", "Transporte Eficiente S.A.", "Mediana", "https://www.transporteeficiente.com" },
                    { 10, "Innovación en tecnología médica para mejorar la calidad de vida.", 2015, "Granada, España", "Salud", "Granada, España", "Tecnología Médica Avanzada S.L.", "Mediana", "https://www.tecnologiamedica.com" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                column: "Name",
                values: new object[]
                {
                    "Eliminar",
                    "Escribir",
                    "Leer"
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "QuestionId", "QuestionText" },
                values: new object[,]
                {
                    { 1, "¿Cómo manejas el estrés en el trabajo?" },
                    { 2, "¿Cuál es tu enfoque para resolver problemas complejos?" },
                    { 3, "¿Cómo priorizas tus tareas cuando tienes múltiples proyectos?" },
                    { 4, "¿Cómo te mantienes actualizado con las últimas tendencias en tu campo?" },
                    { 5, "Describe una vez en la que tuviste que aprender una nueva habilidad rápidamente. ¿Cómo lo lograste?" },
                    { 6, "¿Cómo te aseguras de que tu trabajo sea preciso y de alta calidad?" },
                    { 7, "¿Qué estrategias utilizas para mejorar la comunicación en tu equipo?" },
                    { 8, "¿Cómo te enfrentas a la retroalimentación negativa?" },
                    { 9, "¿Qué aspectos de tu trabajo consideras más motivadores?" },
                    { 10, "¿Cómo gestionas los conflictos con colegas o miembros del equipo?" }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ResourceId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Un recurso que proporciona servicios de autenticación para usuarios en la plataforma.", "API de Autenticación" },
                    { 2, "Un servicio que gestiona las notificaciones en la aplicación.", "Servicio de Notificaciones" },
                    { 3, "Recurso que maneja las operaciones relacionadas con los datos de usuario.", "Gestión de Datos de Usuario" },
                    { 4, "Recurso que permite la búsqueda y filtrado de ofertas de empleo en la plataforma.", "API de Búsqueda de Empleos" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Rol con acceso completo a todas las funcionalidades y configuraciones del sistema.", "Administrador" },
                    { 2, "Rol encargado de gestionar las ofertas de empleo, aplicaciones y procesos de contratación.", "Reclutador" },
                    { 3, "Rol que representa a los usuarios que buscan empleo y postulan a ofertas.", "Candidato" },
                    { 4, "Rol que gestiona los recursos y herramientas disponibles en la plataforma.", "Empresa" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "SkillId", "SkillName", "SkillType" },
                values: new object[,]
                {
                    { 1, "Gestión de Proyectos", "Hard" },
                    { 2, "Infraestructura TI", "Hard" },
                    { 3, "Liderazgo de Equipos", "Soft" },
                    { 4, "Comunicación Efectiva", "Soft" },
                    { 5, "Análisis Estadístico", "Hard" },
                    { 6, "Machine Learning", "Hard" },
                    { 7, "Trabajo en Equipo", "Soft" },
                    { 8, "Resolución de Problemas", "Soft" },
                    { 9, "Desarrollo Web", "Hard" },
                    { 10, "Desarrollo Móvil", "Hard" },
                    { 11, "Creatividad", "Soft" },
                    { 12, "Gestión del Tiempo", "Soft" },
                    { 13, "Análisis Financiero", "Hard" },
                    { 14, "Gestión de Riesgos", "Hard" },
                    { 15, "Negociación", "Soft" },
                    { 16, "Pensamiento Crítico", "Soft" },
                    { 17, "Arquitectura de Sistemas", "Hard" },
                    { 18, "Escalabilidad", "Hard" },
                    { 19, "Adaptabilidad", "Soft" },
                    { 20, "Resolución de Conflictos", "Soft" },
                    { 21, "Gestión de Proyectos", "Hard" },
                    { 22, "Planificación Estratégica", "Hard" },
                    { 23, "Comunicación Intercultural", "Soft" },
                    { 24, "Habilidades Organizativas", "Soft" },
                    { 25, "Automatización de Despliegue", "Hard" },
                    { 26, "Integración Continua", "Hard" },
                    { 27, "Trabajo en Equipo", "Soft" },
                    { 28, "Gestión de Proyectos Ágiles", "Soft" },
                    { 29, "Investigación Biomédica", "Hard" },
                    { 30, "Desarrollo de Terapias", "Hard" },
                    { 31, "Colaboración", "Soft" },
                    { 32, "Pensamiento Analítico", "Soft" },
                    { 33, "Análisis de Datos Financieros", "Hard" },
                    { 34, "Optimización de Procesos", "Hard" },
                    { 35, "Resolución de Problemas", "Soft" },
                    { 36, "Comunicación Eficaz", "Soft" },
                    { 37, "Diseño de Soluciones Ecológicas", "Hard" },
                    { 38, "Gestión Ambiental", "Hard" },
                    { 39, "Trabajo en Equipo", "Soft" },
                    { 40, "Creatividad", "Soft" },
                    { 41, "Desarrollo Web", "Hard" },
                    { 42, "Desarrollo Móvil", "Hard" },
                    { 43, "Creatividad", "Soft" },
                    { 44, "Gestión del Tiempo", "Soft" },
                    { 45, "Análisis Financiero", "Hard" },
                    { 46, "Gestión de Riesgos", "Hard" },
                    { 47, "Negociación", "Soft" },
                    { 48, "Pensamiento Crítico", "Soft" },
                    { 49, "Arquitectura de Sistemas", "Hard" },
                    { 50, "Escalabilidad", "Hard" },
                    { 51, "Adaptabilidad", "Soft" },
                    { 52, "Resolución de Conflictos", "Soft" },
                    { 53, "Gestión de Proyectos", "Hard" },
                    { 54, "Planificación Estratégica", "Hard" },
                    { 55, "Comunicación Intercultural", "Soft" },
                    { 56, "Habilidades Organizativas", "Soft" },
                    { 57, "Automatización de Despliegue", "Hard" },
                    { 58, "Integración Continua", "Hard" },
                    { 59, "Trabajo en Equipo", "Soft" },
                    { 60, "Gestión de Proyectos Ágiles", "Soft" },
                    { 61, "Investigación Biomédica", "Hard" },
                    { 62, "Desarrollo de Terapias", "Hard" },
                    { 63, "Colaboración", "Soft" },
                    { 64, "Pensamiento Analítico", "Soft" },
                    { 65, "Programación en Python", "Hard" },
                    { 66, "Desarrollo de APIs", "Hard" },
                    { 67, "Comunicación Efectiva", "Soft" },
                    { 68, "Trabajo en Equipo", "Soft" },
                    { 69, "Desarrollo de Aplicaciones Móviles", "Hard" },
                    { 70, "Arquitectura de Software", "Hard" },
                    { 71, "Resolución de Problemas", "Soft" },
                    { 72, "Liderazgo", "Soft" },
                    { 73, "Investigación de Mercado", "Hard" },
                    { 74, "Estrategia Comercial", "Hard" },
                    { 75, "Adaptabilidad", "Soft" },
                    { 76, "Pensamiento Crítico", "Soft" },
                    { 77, "Seguridad Informática", "Hard" },
                    { 78, "Desarrollo de Software Seguro", "Hard" },
                    { 79, "Comunicación Interpersonal", "Soft" },
                    { 80, "Gestión del Tiempo", "Soft" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagId", "ImageUrl", "TagName" },
                values: new object[,]
                {
                    { 1, "https://example.com/images/tag-remote.jpg", "Remoto" },
                    { 2, "https://example.com/images/tag-fulltime.jpg", "Tiempo completo" },
                    { 3, "https://example.com/images/tag-freelance.jpg", "Freelance" },
                    { 4, "https://example.com/images/tag-contractor.jpg", "Contratista" },
                    { 5, "https://example.com/images/tag-parttime.jpg", "Medio tiempo" },
                    { 6, "https://example.com/images/tag-temporary.jpg", "Temporal" },
                    { 7, "https://example.com/images/tag-internship.jpg", "Internship" },
                    { 8, "https://example.com/images/tag-education.jpg", "Educación continua" },
                    { 9, "https://example.com/images/tag-teamwork.jpg", "Trabajo en equipo" },
                    { 10, "https://example.com/images/tag-leadership.jpg", "Liderazgo" },
                    { 11, "https://example.com/images/tag-remote-work.jpg", "Trabajo remoto" },
                    { 12, "https://example.com/images/tag-professional-development.jpg", "Desarrollo profesional" },
                    { 13, "https://example.com/images/tag-flexible-hours.jpg", "Flexibilidad horaria" },
                    { 14, "https://example.com/images/tag-growth-opportunities.jpg", "Oportunidades de crecimiento" },
                    { 15, "https://example.com/images/tag-pressure.jpg", "Trabajo bajo presión" },
                    { 16, "https://example.com/images/tag-benefits.jpg", "Beneficios" },
                    { 17, "https://example.com/images/tag-innovation.jpg", "Innovación" },
                    { 18, "https://example.com/images/tag-collaborative-environment.jpg", "Ambiente colaborativo" },
                    { 19, "https://example.com/images/tag-training.jpg", "Capacitación" },
                    { 20, "https://example.com/images/tag-work-life-balance.jpg", "Equilibrio vida-trabajo" }
                });

            migrationBuilder.InsertData(
                table: "CompanyTag",
                columns: new[] { "CompanyId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 5 },
                    { 1, 7 },
                    { 1, 9 },
                    { 1, 11 },
                    { 1, 13 },
                    { 1, 15 },
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 6 },
                    { 2, 8 },
                    { 2, 10 },
                    { 2, 12 },
                    { 2, 14 },
                    { 2, 16 },
                    { 3, 3 },
                    { 3, 5 },
                    { 3, 7 },
                    { 3, 9 },
                    { 3, 11 },
                    { 3, 13 },
                    { 3, 15 },
                    { 3, 17 },
                    { 4, 4 },
                    { 4, 6 },
                    { 4, 8 },
                    { 4, 10 },
                    { 4, 12 },
                    { 4, 14 },
                    { 4, 16 },
                    { 4, 18 },
                    { 5, 5 },
                    { 5, 7 },
                    { 5, 9 },
                    { 5, 11 },
                    { 5, 13 },
                    { 5, 15 },
                    { 5, 17 },
                    { 5, 19 },
                    { 6, 6 },
                    { 6, 8 },
                    { 6, 10 },
                    { 6, 12 },
                    { 6, 14 },
                    { 6, 16 },
                    { 6, 18 },
                    { 6, 20 },
                    { 7, 1 },
                    { 7, 7 },
                    { 7, 9 },
                    { 7, 11 },
                    { 7, 13 },
                    { 7, 15 },
                    { 7, 17 },
                    { 7, 19 },
                    { 8, 2 },
                    { 8, 8 },
                    { 8, 10 },
                    { 8, 12 },
                    { 8, 14 },
                    { 8, 16 },
                    { 8, 18 },
                    { 8, 20 },
                    { 9, 1 },
                    { 9, 3 },
                    { 9, 9 },
                    { 9, 11 },
                    { 9, 13 },
                    { 9, 15 },
                    { 9, 17 },
                    { 9, 19 },
                    { 10, 2 },
                    { 10, 4 },
                    { 10, 10 },
                    { 10, 12 },
                    { 10, 14 },
                    { 10, 16 },
                    { 10, 18 },
                    { 10, 20 }
                });

            migrationBuilder.InsertData(
                table: "CompensationBenefit",
                columns: new[] { "BenefitId", "BenefitType", "CompanyId", "Description" },
                values: new object[,]
                {
                    { 1, "Seguro de Salud", 1, "Cobertura completa de seguro médico para empleados y sus familias." },
                    { 2, "Bonificación Anual", 1, "Bonificación basada en el rendimiento anual del empleado." },
                    { 3, "Estudio y Capacitación", 2, "Reembolsos para cursos de desarrollo profesional y capacitación continua." },
                    { 4, "Tiempo de Vacaciones", 2, "Tiempo adicional de vacaciones por antigüedad y desempeño." },
                    { 5, "Plan de Pensiones", 3, "Contribuciones a un plan de pensiones privado para empleados." },
                    { 6, "Seguro de Vida", 3, "Cobertura de seguro de vida para empleados y sus familias." },
                    { 7, "Trabajo Remoto", 4, "Posibilidad de trabajar de forma remota varios días a la semana." },
                    { 8, "Gimnasio en la Empresa", 4, "Acceso gratuito a gimnasio dentro de las instalaciones de la empresa." },
                    { 9, "Descuentos en Viajes", 5, "Descuentos exclusivos en paquetes de viajes y alojamientos." },
                    { 10, "Días de Vacaciones Adicionales", 5, "Días adicionales de vacaciones por cada año de servicio." },
                    { 11, "Seguro Dental", 6, "Cobertura completa de seguro dental para empleados." },
                    { 12, "Horario Flexible", 6, "Flexibilidad en los horarios de entrada y salida del trabajo." },
                    { 13, "Vales de Comida", 7, "Vales mensuales para comida en restaurantes y supermercados." },
                    { 14, "Seguro de Viaje", 7, "Cobertura de seguro de viaje para empleados en viajes de negocios." },
                    { 15, "Bono de Rendimiento", 8, "Bonificación mensual basada en el rendimiento individual." },
                    { 16, "Desarrollo Profesional", 8, "Oportunidades para participar en talleres y seminarios profesionales." },
                    { 17, "Transporte Gratis", 9, "Servicio de transporte gratuito para empleados desde puntos clave de la ciudad." },
                    { 18, "Cobertura de Guardería", 9, "Cobertura total o parcial de los gastos de guardería para hijos de empleados." },
                    { 19, "Seguro Médico Privado", 10, "Acceso a seguro médico privado con cobertura total para empleados." },
                    { 20, "Plan de Ahorro", 10, "Plan de ahorro con aportaciones de la empresa y del empleado." }
                });

            migrationBuilder.InsertData(
                table: "JobOffer",
                columns: new[] { "JobOfferId", "CompanyId", "Description", "EstimatedDurationDays", "ExperienceLevel", "ExpiredDate", "IsActive", "JobType", "Location", "MaxSalary", "MinSalary", "PostedDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Responsable de la coordinación de proyectos sociales y educativos con enfoque en inclusión digital.", 120, "Senior", new DateTimeOffset(new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "El Prat de Llobregat, España", 50000m, 40000m, new DateTimeOffset(new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Coordinador de Proyectos Sociales" },
                    { 2, 1, "Encargado de gestionar las comunicaciones digitales y redes sociales de la fundación.", 90, "Mid", new DateTimeOffset(new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Medio tiempo", "El Prat de Llobregat, España", 35000m, 25000m, new DateTimeOffset(new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Especialista en Comunicación Digital" },
                    { 3, 1, "Buscamos formador para impartir talleres de tecnología a colectivos en riesgo de exclusión.", 60, "Junior", new DateTimeOffset(new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo parcial", "El Prat de Llobregat, España", 25000m, 20000m, new DateTimeOffset(new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Formador TIC" },
                    { 4, 1, "Soporte técnico y mantenimiento de sistemas para proyectos educativos y sociales.", 100, "Mid", new DateTimeOffset(new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "El Prat de Llobregat, España", 40000m, 30000m, new DateTimeOffset(new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Técnico en Soporte Informático" },
                    { 5, 1, "Gestión de programas de voluntariado y coordinación de actividades.", 120, "Senior", new DateTimeOffset(new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "El Prat de Llobregat, España", 55000m, 45000m, new DateTimeOffset(new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Responsable de Voluntariado" },
                    { 6, 2, "Desarrollo y supervisión de proyectos de energía renovable.", 150, "Senior", new DateTimeOffset(new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Barcelona, España", 75000m, 60000m, new DateTimeOffset(new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Ingeniero en Energías Renovables" },
                    { 7, 2, "Análisis de datos y optimización de procesos energéticos.", 90, "Mid", new DateTimeOffset(new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Medio tiempo", "Barcelona, España", 45000m, 35000m, new DateTimeOffset(new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Analista de Datos Energéticos" },
                    { 8, 2, "Instalación y mantenimiento de paneles solares y sistemas de energía renovable.", 120, "Junior", new DateTimeOffset(new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Barcelona, España", 35000m, 28000m, new DateTimeOffset(new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Técnico en Instalaciones Solares" },
                    { 9, 2, "Asesoría en sostenibilidad ambiental y reducción de huella de carbono.", 100, "Senior", new DateTimeOffset(new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo parcial", "Barcelona, España", 50000m, 40000m, new DateTimeOffset(new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Consultor en Sostenibilidad" },
                    { 10, 2, "Desarrollo y mantenimiento de proyectos de energía eólica.", 120, "Mid", new DateTimeOffset(new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Barcelona, España", 55000m, 45000m, new DateTimeOffset(new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Especialista en Energía Eólica" },
                    { 11, 3, "Monitorización y protección de sistemas informáticos contra amenazas.", 120, "Senior", new DateTimeOffset(new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Madrid, España", 70000m, 55000m, new DateTimeOffset(new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Especialista en Ciberseguridad" },
                    { 12, 3, "Análisis y reporte de vulnerabilidades en sistemas informáticos.", 90, "Mid", new DateTimeOffset(new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Medio tiempo", "Madrid, España", 50000m, 40000m, new DateTimeOffset(new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Analista de Seguridad Informática" },
                    { 13, 3, "Asesoría en cumplimiento de normativas de protección de datos.", 120, "Senior", new DateTimeOffset(new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Madrid, España", 75000m, 60000m, new DateTimeOffset(new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Consultor en Protección de Datos" },
                    { 14, 3, "Mantenimiento y protección de la seguridad en redes corporativas.", 100, "Mid", new DateTimeOffset(new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Madrid, España", 60000m, 50000m, new DateTimeOffset(new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Administrador de Seguridad de Redes" },
                    { 15, 3, "Investigación y análisis de nuevas ciberamenazas emergentes.", 150, "Junior", new DateTimeOffset(new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Madrid, España", 45000m, 35000m, new DateTimeOffset(new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Investigador de Ciberamenazas" },
                    { 16, 10, "Desarrollo de modelos predictivos y análisis de grandes volúmenes de datos.", 120, "Senior", new DateTimeOffset(new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Zaragoza, España", 75000m, 60000m, new DateTimeOffset(new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Data Scientist Senior" },
                    { 17, 10, "Análisis de datos masivos y generación de insights estratégicos.", 120, "Mid", new DateTimeOffset(new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Zaragoza, España", 60000m, 50000m, new DateTimeOffset(new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Analista de Big Data" },
                    { 18, 10, "Implementación de algoritmos de machine learning en proyectos de análisis de datos.", 90, "Junior", new DateTimeOffset(new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Medio tiempo", "Zaragoza, España", 50000m, 40000m, new DateTimeOffset(new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Desarrollador de Machine Learning" },
                    { 19, 10, "Diseño y mantenimiento de pipelines de datos eficientes.", 120, "Mid", new DateTimeOffset(new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Zaragoza, España", 65000m, 50000m, new DateTimeOffset(new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Ingeniero de Datos" },
                    { 20, 10, "Gestión y mantenimiento de bases de datos empresariales.", 120, "Junior", new DateTimeOffset(new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Zaragoza, España", 50000m, 40000m, new DateTimeOffset(new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Administrador de Bases de Datos" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CompanyId", "DateJoined", "Email", "Ethnicity", "FirstName", "GenderIdentity", "Headline", "IsWorking", "LastName", "LinkedInUrl", "Location", "MobileNumber", "PasswordHash", "PortfolioUrl", "ProfilePicture", "ProfileUrl", "Pronoun", "RequireVisa", "RoleId", "SearchStage", "Summary", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2019, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9157), new TimeSpan(0, 2, 0, 0, 0)), "admin@techcorp.com", "Latino", "Carlos", "Masculino", "Gerente de TI", true, "Martínez", "https://www.linkedin.com/in/carlosmartinez", "San Francisco, CA", "555-1234", "admin", "https://portfolio.com/carlosmartinez", "https://example.com/perfil1.jpg", "https://example.com/carlosmartinez", "Él", false, 2, "Activo", "Profesional con más de 10 años de experiencia en la gestión de proyectos tecnológicos.", "admin", "Administrador" },
                    { 2, 2, new DateTimeOffset(new DateTime(2021, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9201), new TimeSpan(0, 2, 0, 0, 0)), "jane.doe@saludplus.com", "Caucásica", "Jane", "Femenino", "Científica de Datos", false, "Doe", "https://www.linkedin.com/in/janedoe", "Nueva York, NY", "555-5678", "jane", "https://portfolio.com/janedoe", "https://example.com/perfil2.jpg", "https://example.com/janedoe", "Ella", false, 2, "En búsqueda", "Especialista en análisis de datos con un enfoque en el sector salud.", "janedoe", "Usuario" },
                    { 3, 3, new DateTimeOffset(new DateTime(2020, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9214), new TimeSpan(0, 2, 0, 0, 0)), "john.smith@techtree.com", "Afroamericano", "John", "Masculino", "Ingeniero de Software", true, "Smith", "https://www.linkedin.com/in/johnsmith", "San Francisco, CA", "555-1234", "johnr", "https://portfolio.com/johnsmith", "https://example.com/profile3.jpg", "https://example.com/johnsmith", "Él", false, 2, "Abierto a nuevas oportunidades", "Desarrollador de software con experiencia en tecnologías web y móviles.", "johnsmithr", "Usuario" },
                    { 4, 4, new DateTimeOffset(new DateTime(2022, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9223), new TimeSpan(0, 2, 0, 0, 0)), "maria.garcia@medex.com", "Latina", "Maria", "Femenino", "Analista Financiero", true, "Garcia", "https://www.linkedin.com/in/mariagarcia", "Miami, FL", "555-2345", "maria", "https://portfolio.com/mariagarcia", "https://example.com/profile4.jpg", "https://example.com/mariagarcia", "Ella", false, 2, "Explorando opciones", "Profesional de finanzas con una sólida formación en análisis y gestión de riesgos.", "mariagarciar", "Usuarior" },
                    { 5, 5, new DateTimeOffset(new DateTime(2019, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 2, 0, 0, 0)), "michael.brown@cybernet.com", "Caucásico", "Michael", "Masculino", "Arquitecto de Soluciones", true, "Brown", "https://www.linkedin.com/in/michaelbrown", "Austin, TX", "555-3456", "michaelr", "https://portfolio.com/michaelbrown", "https://example.com/profile5.jpg", "https://example.com/michaelbrown", "Él", false, 2, "No en búsqueda activa", "Arquitecto de soluciones especializado en la creación de infraestructuras escalables.", "michaelbrownr", "Usuario" },
                    { 6, 6, new DateTimeOffset(new DateTime(2021, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9239), new TimeSpan(0, 2, 0, 0, 0)), "sophia.wilson@ecogreen.com", "Asiática", "Sophia", "Femenino", "Gestora de Proyectos", true, "Wilson", "https://www.linkedin.com/in/sophiawilson", "Seattle, WA", "555-4567", "sophiar", "https://portfolio.com/sophiawilson", "https://example.com/profile6.jpg", "https://example.com/sophiawilson", "Ella", false, 2, "Interesada en nuevas oportunidades", "Gestora de proyectos con experiencia en proyectos de sostenibilidad y medio ambiente.", "sophiawilsonr", "Usuario" },
                    { 7, 7, new DateTimeOffset(new DateTime(2018, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9247), new TimeSpan(0, 2, 0, 0, 0)), "james.johnson@nextgen.com", "Hispano", "James", "Masculino", "Ingeniero DevOps", true, "Johnson", "https://www.linkedin.com/in/jamesjohnson", "Chicago, IL", "555-5678", "jamesr", "https://portfolio.com/jamesjohnson", "https://example.com/profile7.jpg", "https://example.com/jamesjohnson", "Él", false, 2, "Abierto a nuevas posiciones", "Especialista en DevOps con experiencia en automatización y despliegue continuo.", "jamesjohnsonr", "Usuario" },
                    { 8, 8, new DateTimeOffset(new DateTime(2020, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9254), new TimeSpan(0, 2, 0, 0, 0)), "emma.davis@biomedic.com", "Caucásica", "Emma", "Femenino", "Investigadora Biomédica", true, "Davis", "https://www.linkedin.com/in/emmadavis", "Los Ángeles, CA", "555-6789", "emmar", "https://portfolio.com/emmadavis", "https://example.com/profile8.jpg", "https://example.com/emmadavis", "Ella", false, 2, "Interesada en nuevas investigaciones", "Investigadora con experiencia en el desarrollo de terapias innovadoras.", "emmadavisr", "Usuario" },
                    { 9, 9, new DateTimeOffset(new DateTime(2022, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9262), new TimeSpan(0, 2, 0, 0, 0)), "william.miller@finserve.com", "Caucásico", "William", "Masculino", "Analista de Datos", true, "Miller", "https://www.linkedin.com/in/williammiller", "Nueva York, NY", "555-7890", "williamr", "https://portfolio.com/williammiller", "https://example.com/profile9.jpg", "https://example.com/williammiller", "Él", false, 2, "Explorando oportunidades", "Analista de datos con experiencia en finanzas y optimización de procesos.", "williammillerr", "Usuario" },
                    { 10, 10, new DateTimeOffset(new DateTime(2021, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9269), new TimeSpan(0, 2, 0, 0, 0)), "olivia.martinez@greentech.com", "Latina", "Olivia", "Femenino", "Ingeniera Ambiental", true, "Martinez", "https://www.linkedin.com/in/oliviamartinez", "Denver, CO", "555-8901", "oliviar", "https://portfolio.com/oliviamartinez", "https://example.com/profile10.jpg", "https://example.com/oliviamartinez", "Ella", false, 2, "En búsqueda activa", "Ingeniera con un enfoque en soluciones ecológicas y sostenibles.", "oliviamartinezr", "Usuario" },
                    { 11, 3, new DateTimeOffset(new DateTime(2020, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9276), new TimeSpan(0, 2, 0, 0, 0)), "john.smith@techtree.com", "Afroamericano", "John", "Masculino", "Ingeniero de Software", true, "Smith", "https://www.linkedin.com/in/johnsmith", "San Francisco, CA", "555-1234", "john", "https://portfolio.com/johnsmith", "https://example.com/profile3.jpg", "https://example.com/johnsmith", "Él", false, 3, "Abierto a nuevas oportunidades", "Desarrollador de software con experiencia en tecnologías web y móviles.", "johnsmith", "Usuario" },
                    { 12, 4, new DateTimeOffset(new DateTime(2022, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9284), new TimeSpan(0, 2, 0, 0, 0)), "maria.garcia@medex.com", "Latina", "Maria", "Femenino", "Analista Financiero", true, "Garcia", "https://www.linkedin.com/in/mariagarcia", "Miami, FL", "555-2345", "maria", "https://portfolio.com/mariagarcia", "https://example.com/profile4.jpg", "https://example.com/mariagarcia", "Ella", false, 3, "Explorando opciones", "Profesional de finanzas con una sólida formación en análisis y gestión de riesgos.", "mariagarcia", "Usuario" },
                    { 13, 5, new DateTimeOffset(new DateTime(2019, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9292), new TimeSpan(0, 2, 0, 0, 0)), "michael.brown@cybernet.com", "Caucásico", "Michael", "Masculino", "Arquitecto de Soluciones", false, "Brown", "https://www.linkedin.com/in/michaelbrown", "Austin, TX", "555-3456", "michael", "https://portfolio.com/michaelbrown", "https://example.com/profile5.jpg", "https://example.com/michaelbrown", "Él", false, 3, "No en búsqueda activa", "Arquitecto de soluciones especializado en la creación de infraestructuras escalables.", "michaelbrown", "Usuario" },
                    { 14, 6, new DateTimeOffset(new DateTime(2021, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9299), new TimeSpan(0, 2, 0, 0, 0)), "sophia.wilson@ecogreen.com", "Asiática", "Sophia", "Femenino", "Gestora de Proyectos", false, "Wilson", "https://www.linkedin.com/in/sophiawilson", "Seattle, WA", "555-4567", "sophia", "https://portfolio.com/sophiawilson", "https://example.com/profile6.jpg", "https://example.com/sophiawilson", "Ella", false, 3, "Interesada en nuevas oportunidades", "Gestora de proyectos con experiencia en proyectos de sostenibilidad y medio ambiente.", "sophiawilson", "Usuario" },
                    { 15, 7, new DateTimeOffset(new DateTime(2018, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9307), new TimeSpan(0, 2, 0, 0, 0)), "james.johnson@nextgen.com", "Hispano", "James", "Masculino", "Ingeniero DevOps", false, "Johnson", "https://www.linkedin.com/in/jamesjohnson", "Chicago, IL", "555-5678", "james", "https://portfolio.com/jamesjohnson", "https://example.com/profile7.jpg", "https://example.com/jamesjohnson", "Él", false, 3, "Abierto a nuevas posiciones", "Especialista en DevOps con experiencia en automatización y despliegue continuo.", "jamesjohnson", "Usuario" },
                    { 16, 8, new DateTimeOffset(new DateTime(2020, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9314), new TimeSpan(0, 2, 0, 0, 0)), "emma.davis@biomedic.com", "Caucásica", "Emma", "Femenino", "Investigadora Biomédica", false, "Davis", "https://www.linkedin.com/in/emmadavis", "Los Ángeles, CA", "555-6789", "emma", "https://portfolio.com/emmadavis", "https://example.com/profile8.jpg", "https://example.com/emmadavis", "Ella", false, 3, "Interesada en nuevas investigaciones", "Investigadora con experiencia en el desarrollo de terapias innovadoras.", "emmadavis", "Usuario" },
                    { 17, 9, new DateTimeOffset(new DateTime(2022, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9321), new TimeSpan(0, 2, 0, 0, 0)), "william.miller@finserve.com", "Caucásico", "William", "Masculino", "Analista de Datos", true, "Miller", "https://www.linkedin.com/in/williammiller", "Nueva York, NY", "555-7890", "william", "https://portfolio.com/williammiller", "https://example.com/profile9.jpg", "https://example.com/williammiller", "Él", false, 3, "Explorando oportunidades", "Analista de datos con experiencia en finanzas y optimización de procesos.", "williammiller", "Usuario" },
                    { 18, 10, new DateTimeOffset(new DateTime(2021, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9330), new TimeSpan(0, 2, 0, 0, 0)), "olivia.martinez@greentech.com", "Latina", "Olivia", "Femenino", "Ingeniera Ambiental", false, "Martinez", "https://www.linkedin.com/in/oliviamartinez", "Denver, CO", "555-8901", "olivia", "https://portfolio.com/oliviamartinez", "https://example.com/profile10.jpg", "https://example.com/oliviamartinez", "Ella", false, 2, "En búsqueda activa", "Ingeniera con un enfoque en soluciones ecológicas y sostenibles.", "oliviamartinez", "Usuario" },
                    { 19, 7, new DateTimeOffset(new DateTime(2017, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9336), new TimeSpan(0, 2, 0, 0, 0)), "liam.harris@urbanhealth.com", "Afroamericano", "Liam", "Masculino", "Gerente de Recursos Humanos", false, "Harris", "https://www.linkedin.com/in/liamharris", "Nueva York, NY", "555-9999", "liam", "https://portfolio.com/liamharris", "https://example.com/profile19.jpg", "https://example.com/liamharris", "Él", false, 3, "No en búsqueda activa", "Gerente de RRHH con experiencia en reclutamiento y desarrollo de talento.", "liamharris", "Usuario" },
                    { 20, 8, new DateTimeOffset(new DateTime(2018, 8, 26, 11, 32, 32, 333, DateTimeKind.Unspecified).AddTicks(9344), new TimeSpan(0, 2, 0, 0, 0)), "ava.walker@medtech.com", "Caucásica", "Ava", "Femenino", "Directora de Estrategia", false, "Walker", "https://www.linkedin.com/in/avawalker", "Denver, CO", "555-0000", "ava", "https://portfolio.com/avawalker", "https://example.com/profile20.jpg", "https://example.com/avawalker", "Ella", false, 3, "Explorando nuevas iniciativas", "Especialista en estrategias de negocio y desarrollo organizacional.", "avawalker", "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "AnswerId", "AnswerText", "IsFeatured", "QuestionId", "UserId" },
                values: new object[,]
                {
                    { 1, "Manejo el estrés organizando mi tiempo y estableciendo prioridades claras. También me aseguro de tomar breves descansos para despejar la mente.", true, 1, 1 },
                    { 2, "Divido los problemas complejos en partes más pequeñas y abordo cada una de manera sistemática, buscando diferentes perspectivas para llegar a una solución.", true, 2, 2 },
                    { 3, "Priorizo mis tareas utilizando una matriz de urgencia e importancia, lo que me permite enfocarme en lo que realmente importa y gestionar el tiempo eficientemente.", true, 3, 3 },
                    { 4, "Me mantengo actualizado participando en cursos en línea, asistiendo a conferencias y leyendo publicaciones relevantes en mi campo.", true, 4, 4 },
                    { 5, "Aprendí rápidamente una nueva habilidad cuando me pidieron que liderara un proyecto de análisis de datos, dedicando tiempo extra y solicitando retroalimentación constante.", true, 5, 5 },
                    { 6, "Reviso mi trabajo varias veces y utilizo herramientas de verificación antes de presentarlo. Además, pido a un colega que lo revise para asegurarme de su precisión.", true, 6, 6 },
                    { 7, "Fomento la comunicación abierta en mi equipo organizando reuniones periódicas y utilizando herramientas de colaboración para asegurarnos de que todos estén alineados.", true, 7, 7 },
                    { 8, "Veo la retroalimentación negativa como una oportunidad para mejorar. Escucho atentamente, analizo la crítica y hago los cambios necesarios.", true, 8, 8 },
                    { 9, "Lo que más me motiva es ver el impacto positivo de mi trabajo y el reconocimiento por parte de mis colegas y superiores.", true, 9, 9 },
                    { 10, "Gestiono los conflictos abordando los problemas de manera directa y honesta, buscando soluciones que beneficien a ambas partes.", true, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Application",
                columns: new[] { "ApplicationId", "ApplicationDate", "JobOfferId", "SalaryExpected", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 12, 60000m, "Pendiente", 11 },
                    { 2, new DateTimeOffset(new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 8, 50000m, "Aceptado", 12 },
                    { 3, new DateTimeOffset(new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 19, 55000m, "Pendiente", 13 },
                    { 4, new DateTimeOffset(new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 14, 52000m, "Rechazado", 14 },
                    { 5, new DateTimeOffset(new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 13, 58000m, "Pendiente", 15 },
                    { 6, new DateTimeOffset(new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 3, 61000m, "Aceptado", 16 },
                    { 7, new DateTimeOffset(new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 20, 59000m, "Rechazado", 17 },
                    { 8, new DateTimeOffset(new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 16, 62000m, "Pendiente", 18 },
                    { 9, new DateTimeOffset(new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 16, 53000m, "Aceptado", 19 },
                    { 10, new DateTimeOffset(new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 18, 56000m, "Rechazado", 20 }
                });

            migrationBuilder.InsertData(
                table: "Education",
                columns: new[] { "EducationId", "ActivitiesAndSocieties", "Degree", "Description", "EndDate", "FieldOfStudy", "Grade", "SchoolName", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Asociación de Empresarios", "Licenciatura", "Enfoque en gestión empresarial y emprendimiento.", new DateTimeOffset(new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Administración de Empresas", "Sobresaliente", "Universidad Nacional", new DateTimeOffset(new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 3 },
                    { 2, "Club de Marketing", "Diplomado", "Diplomado en estrategias de marketing digital y redes sociales.", new DateTimeOffset(new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Marketing Digital", "A", "Instituto Tecnológico Superior", new DateTimeOffset(new DateTime(2018, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 4 },
                    { 3, "Foro de Finanzas", "MBA", "Máster en administración de negocios con especialización en finanzas corporativas.", new DateTimeOffset(new DateTime(2019, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Finanzas", "Excelente", "Escuela de Negocios Internacional", new DateTimeOffset(new DateTime(2017, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 5 },
                    { 4, "Sociedad de Ingenieros", "Ingeniería", "Especialización en desarrollo de software y sistemas integrados.", new DateTimeOffset(new DateTime(2018, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Ingeniería de Sistemas", "Muy Bueno", "Universidad de Tecnología", new DateTimeOffset(new DateTime(2014, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 6 },
                    { 5, "Investigación en Cambio Climático", "Doctorado", "Doctorado en ciencias ambientales con investigación en sostenibilidad y cambio climático.", new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Ciencias Ambientales", "A+", "Colegio de Artes y Ciencias", new DateTimeOffset(new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 7 },
                    { 6, "Club de Investigación Biotecnológica", "Licenciatura", "Enfoque en desarrollo de tecnologías para la salud y el medio ambiente.", new DateTimeOffset(new DateTime(2017, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Biotecnología", "Sobresaliente", "Universidad de Ciencias Aplicadas", new DateTimeOffset(new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 11 },
                    { 7, "Club de Diseño", "Licenciatura", "Especialización en diseño gráfico y comunicación visual.", new DateTimeOffset(new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Diseño Gráfico", "Excelente", "Instituto Superior de Artes", new DateTimeOffset(new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 12 },
                    { 8, "Sociedad de Ingenieros Civiles", "Máster", "Máster en ingeniería civil con especialización en estructuras.", new DateTimeOffset(new DateTime(2021, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Ingeniería Civil", "A", "Escuela Politécnica Nacional", new DateTimeOffset(new DateTime(2017, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 13 },
                    { 9, "Asociación de Científicos de Datos", "Diplomado", "Diplomado en ciencia de datos con enfoque en análisis y modelado predictivo.", new DateTimeOffset(new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Ciencia de Datos", "Muy Bueno", "Academia Internacional de Ciencias", new DateTimeOffset(new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 14 },
                    { 10, "Club de Fotografía", "Licenciatura", "Especialización en fotografía artística y comercial.", new DateTimeOffset(new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fotografía", "Excelente", "Escuela de Artes Visuales", new DateTimeOffset(new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 15 }
                });

            migrationBuilder.InsertData(
                table: "Interest",
                columns: new[] { "InterestId", "InterestText", "UserId" },
                values: new object[,]
                {
                    { 1, "Viajes y aventuras", 11 },
                    { 2, "Cocina y gastronomía", 12 },
                    { 3, "Lectura y escritura", 13 },
                    { 4, "Fotografía y video", 14 },
                    { 5, "Música y conciertos", 15 },
                    { 6, "Deportes y fitness", 16 },
                    { 7, "Jardinería y naturaleza", 17 },
                    { 8, "Tecnología y gadgets", 18 },
                    { 9, "Artes y manualidades", 19 },
                    { 10, "Voluntariado y causas sociales", 20 }
                });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "MatchId", "IsAccepted", "JobOfferId", "MatchDate", "UserId" },
                values: new object[,]
                {
                    { 1, true, 3, new DateTimeOffset(new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 2, false, 4, new DateTimeOffset(new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2 },
                    { 3, true, 5, new DateTimeOffset(new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3 },
                    { 4, true, 6, new DateTimeOffset(new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4 },
                    { 5, false, 7, new DateTimeOffset(new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5 },
                    { 6, true, 8, new DateTimeOffset(new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 11 },
                    { 7, false, 9, new DateTimeOffset(new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 12 },
                    { 8, true, 10, new DateTimeOffset(new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 13 },
                    { 9, true, 11, new DateTimeOffset(new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 14 },
                    { 10, false, 12, new DateTimeOffset(new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 15 }
                });

            migrationBuilder.InsertData(
                table: "SocialMedia",
                columns: new[] { "SocialMediaId", "Platform", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, "LinkedIn", "https://www.linkedin.com/in/admin", 1 },
                    { 2, "Twitter", "https://twitter.com/usuario", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserPreference",
                columns: new[] { "PreferenceId", "Category", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, "Tipo de Trabajo", 11, "Tipo de Trabajo - Freelance" },
                    { 2, "Salario", 12, "Salario - Competitivo" },
                    { 3, "Horario", 13, "Horario - Tiempo Parcial" },
                    { 4, "Ubicación", 14, "Ubicación - Ciudad Principal" },
                    { 5, "Oportunidades", 15, "Oportunidades - Liderazgo" },
                    { 6, "Tipo de Trabajo", 16, "Tipo de Trabajo - Contrato" },
                    { 7, "Salario", 17, "Salario - Basado en Experiencia" },
                    { 8, "Horario", 18, "Horario - Tiempo Completo" },
                    { 9, "Ubicación", 19, "Ubicación - Remoto" },
                    { 10, "Oportunidades", 20, "Oportunidades - Internacionales" }
                });

            migrationBuilder.InsertData(
                table: "UserSkill",
                columns: new[] { "UserSkillId", "ProficiencyLevel", "RelatedId", "RelatedTo", "SkillId", "UserId" },
                values: new object[,]
                {
                    { 1, "Experto", 101, "Certificación", 1, 11 },
                    { 2, "Avanzado", 202, "Curso", 2, 11 },
                    { 3, "Intermedio", 303, "Proyecto", 3, 11 },
                    { 4, "Básico", 404, "Certificación", 4, 11 },
                    { 5, "Experto", 505, "Curso", 5, 12 },
                    { 6, "Avanzado", 606, "Proyecto", 6, 12 },
                    { 7, "Intermedio", 707, "Certificación", 7, 12 },
                    { 8, "Básico", 808, "Curso", 8, 12 },
                    { 9, "Experto", 909, "Proyecto", 9, 13 },
                    { 10, "Avanzado", 1010, "Certificación", 10, 13 },
                    { 11, "Intermedio", 1111, "Curso", 11, 13 },
                    { 12, "Básico", 1212, "Proyecto", 12, 13 },
                    { 13, "Experto", 1313, "Certificación", 13, 14 },
                    { 14, "Avanzado", 1414, "Curso", 14, 14 },
                    { 15, "Intermedio", 1515, "Proyecto", 15, 14 },
                    { 16, "Básico", 1616, "Certificación", 16, 14 },
                    { 17, "Experto", 1717, "Curso", 17, 15 },
                    { 18, "Avanzado", 1818, "Certificación", 18, 15 },
                    { 19, "Intermedio", 1919, "Proyecto", 19, 15 },
                    { 20, "Básico", 2020, "Curso", 20, 15 },
                    { 21, "Experto", 2121, "Certificación", 21, 16 },
                    { 22, "Avanzado", 2222, "Curso", 22, 16 },
                    { 23, "Intermedio", 2323, "Proyecto", 23, 16 },
                    { 24, "Básico", 2424, "Certificación", 24, 16 },
                    { 25, "Experto", 2525, "Curso", 25, 17 },
                    { 26, "Avanzado", 2626, "Certificación", 26, 17 },
                    { 27, "Intermedio", 2727, "Proyecto", 27, 17 },
                    { 28, "Básico", 2828, "Curso", 28, 17 },
                    { 29, "Experto", 2929, "Certificación", 29, 18 },
                    { 30, "Avanzado", 3030, "Curso", 30, 18 },
                    { 31, "Intermedio", 3131, "Proyecto", 31, 18 },
                    { 32, "Básico", 3232, "Certificación", 32, 18 },
                    { 33, "Experto", 3333, "Curso", 33, 19 },
                    { 34, "Avanzado", 3434, "Certificación", 34, 19 },
                    { 35, "Intermedio", 3535, "Proyecto", 35, 19 },
                    { 36, "Básico", 3636, "Curso", 36, 19 },
                    { 37, "Experto", 3737, "Certificación", 37, 20 },
                    { 38, "Avanzado", 3838, "Curso", 38, 20 },
                    { 39, "Intermedio", 3939, "Proyecto", 39, 20 },
                    { 40, "Básico", 4040, "Certificación", 40, 20 }
                });

            migrationBuilder.InsertData(
                table: "WorkExperience",
                columns: new[] { "WorkExperienceId", "CompanyName", "Description", "EndDate", "JobTitle", "Location", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Tech Innovations", "Desarrollo de interfaces web utilizando React y CSS.", new DateTimeOffset(new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Desarrollador Frontend", "Ciudad de México", new DateTimeOffset(new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 },
                    { 2, "SoftTech", "Análisis de requerimientos y diseño de soluciones tecnológicas.", new DateTimeOffset(new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Analista de Sistemas", "Puebla", new DateTimeOffset(new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 8 },
                    { 3, "Creative Labs", "Diseño de interfaces de usuario y experiencias de usuario para aplicaciones móviles.", new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Diseñador UX/UI", "Monterrey", new DateTimeOffset(new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 3 },
                    { 4, "Data Insights", "Análisis y visualización de datos utilizando herramientas como R y Tableau.", new DateTimeOffset(new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Analista de Datos", "Seattle", new DateTimeOffset(new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 5 },
                    { 5, "AppDev Inc.", "Desarrollo de aplicaciones móviles y de escritorio.", new DateTimeOffset(new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Desarrollador de Aplicaciones", "San José", new DateTimeOffset(new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 7 },
                    { 6, "BioHealth", "Investigación y desarrollo de productos biotecnológicos.", new DateTimeOffset(new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Especialista en Biotecnología", "San Francisco", new DateTimeOffset(new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 11 },
                    { 7, "Creative Design Co.", "Creación de material visual y diseño de campañas publicitarias.", new DateTimeOffset(new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Diseñador Gráfico", "Los Ángeles", new DateTimeOffset(new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 12 },
                    { 8, "Data Insights", "Análisis y visualización de datos utilizando herramientas como R y Tableau.", new DateTimeOffset(new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Analista de Datos", "Seattle", new DateTimeOffset(new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 14 },
                    { 9, "Cloud Solutions", "Diseño e implementación de soluciones en la nube.", new DateTimeOffset(new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Arquitecto de Soluciones", "Austin", new DateTimeOffset(new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 16 },
                    { 10, "Global HR", "Gestión de equipos y desarrollo de estrategias de recursos humanos.", new DateTimeOffset(new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Gerente de Recursos Humanos", "Miami", new DateTimeOffset(new DateTime(2017, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 18 }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "ApplicationId", "FeedbackDate", "FeedbackText", "RecruiterId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Gracias por tu tiempo y esfuerzo en la entrevista. Mostraste un buen entendimiento técnico, pero podrías mejorar en la claridad de tus respuestas.", 1 },
                    { 2, 2, new DateTimeOffset(new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Impresionante experiencia en gestión de proyectos. Tus habilidades en resolución de problemas destacaron. Considera practicar más entrevistas para pulir tu presentación.", 2 },
                    { 3, 3, new DateTimeOffset(new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Demostraste un excelente conocimiento en desarrollo de software. Sin embargo, te recomendaría trabajar en la forma en que comunicas tus ideas durante entrevistas.", 3 },
                    { 4, 4, new DateTimeOffset(new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Tu experiencia en finanzas es notable. Sin embargo, podrías beneficiarte al mejorar tus habilidades en la presentación y comunicación de informes.", 4 },
                    { 5, 5, new DateTimeOffset(new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Tienes un enfoque innovador en soluciones. Para fortalecer tu perfil, te recomendaría mejorar en la gestión de equipos y coordinación de proyectos.", 5 },
                    { 6, 6, new DateTimeOffset(new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Tus conocimientos en sostenibilidad son valiosos. Para futuros procesos, trabaja en la articulación clara de tus logros y experiencias.", 6 },
                    { 7, 7, new DateTimeOffset(new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Tienes una sólida base en DevOps. Para mejorar, considera enfocarte más en la documentación técnica y en la comunicación de tu trabajo.", 7 },
                    { 8, 8, new DateTimeOffset(new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Tu experiencia en investigación biomédica es destacable. Te sugiero trabajar en cómo presentar tus hallazgos de manera más efectiva en futuras entrevistas.", 8 },
                    { 9, 9, new DateTimeOffset(new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Mostraste habilidades fuertes en análisis de datos. Te recomendaría enfocarte en la presentación visual de tus resultados y en cómo comunicar tus conclusiones.", 9 },
                    { 10, 10, new DateTimeOffset(new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Tienes una visión estratégica impresionante. Para mejorar tu perfil, trabaja en el desarrollo de habilidades de liderazgo y gestión de equipos.", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_UserId",
                table: "Answer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobOfferId",
                table: "Application",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_UserId",
                table: "Application",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTag_TagId",
                table: "CompanyTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_CompensationBenefit_CompanyId",
                table: "CompensationBenefit",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_UserId",
                table: "Education",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ApplicationId",
                table: "Feedback",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_RecruiterId",
                table: "Feedback",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Interest_UserId",
                table: "Interest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CompanyId",
                table: "JobOffer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_JobOfferId",
                table: "Match",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_UserId",
                table: "Match",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionPatent_Permission",
                table: "RolePermissionPatent",
                column: "Permission");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionPatent_ResourceId",
                table: "RolePermissionPatent",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_UserId",
                table: "SocialMedia",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreference_UserId",
                table: "UserPreference",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserId",
                table: "UserSkill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_UserId",
                table: "WorkExperience",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "CompanyTag");

            migrationBuilder.DropTable(
                name: "CompensationBenefit");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "RolePermissionPatent");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "UserPreference");

            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "WorkExperience");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "JobOffer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
