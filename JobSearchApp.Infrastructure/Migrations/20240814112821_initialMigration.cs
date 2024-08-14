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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundedYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillType = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    BenefitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoined = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LinkedInUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderIdentity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pronoun = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ethnicity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequireVisa = table.Column<bool>(type: "bit", nullable: false),
                    SearchStage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortfolioUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
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
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivitiesAndSocieties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    InterestText = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    ProficiencyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelatedTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    FeedbackText = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 1, "Una empresa dedicada a ofrecer soluciones tecnológicas avanzadas.", 2012, "Ciudad de México, México", "Tecnología", "Ciudad de México, México", "Innovación Tecnológica S.A.", "Mediana", "https://www.innovaciontecnologica.com" },
                    { 2, "Expertos en diseño gráfico y desarrollo de estrategias creativas.", 2008, "Buenos Aires, Argentina", "Creatividad", "Buenos Aires, Argentina", "Servicios Creativos Ltda.", "Grande", "https://www.servicioscreativos.com" },
                    { 3, "Proporciona servicios de consultoría en diversas áreas empresariales.", 2000, "Madrid, España", "Consultoría", "Madrid, España", "Consultoría Global", "Grande", "https://www.consultoriaglobal.com" }
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
                    { 1, "¿Por qué quieres trabajar con nosotros?" },
                    { 2, "Describe un desafío que enfrentaste en tu trabajo anterior." }
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
                    { 1, "C#", "Tech" },
                    { 2, "C#", "Tech" },
                    { 3, "C#", "Tech" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagId", "ImageUrl", "TagName" },
                values: new object[,]
                {
                    { 1, "URL", "Remoto" },
                    { 2, "URL", "Tiempo completo" }
                });

            migrationBuilder.InsertData(
                table: "CompanyTag",
                columns: new[] { "CompanyId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "CompensationBenefit",
                columns: new[] { "BenefitId", "BenefitType", "CompanyId", "Description" },
                values: new object[,]
                {
                    { 1, "Seguro de Salud", 1, "Cobertura completa de seguro médico para empleados y sus familias." },
                    { 2, "Bonificación Anual", 1, "Bonificación basada en el rendimiento anual del empleado." },
                    { 3, "Estudio y Capacitación", 2, "Reembolsos para cursos de desarrollo profesional y capacitación continua." },
                    { 4, "Tiempo de Vacaciones", 2, "Tiempo adicional de vacaciones por antigüedad y desempeño." }
                });

            migrationBuilder.InsertData(
                table: "JobOffer",
                columns: new[] { "JobOfferId", "CompanyId", "Description", "EstimatedDurationDays", "ExperienceLevel", "ExpiredDate", "IsActive", "JobType", "Location", "MaxSalary", "MinSalary", "PostedDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Buscamos un desarrollador de software senior para trabajar en proyectos innovadores en el área de tecnología.", 30, "Senior", new DateTimeOffset(new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Tiempo completo", "Ciudad de México, México", 80000m, 60000m, new DateTimeOffset(new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Desarrollador de Software Senior" },
                    { 2, 2, "Se busca diseñador gráfico con experiencia para crear material visual atractivo para nuestros clientes.", 45, "Junior", new DateTimeOffset(new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Medio tiempo", "Buenos Aires, Argentina", 40000m, 30000m, new DateTimeOffset(new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Diseñador Gráfico" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionPatent",
                columns: new[] { "Permission", "ResourceId", "RoleId" },
                values: new object[,]
                {
                    { "Eliminar", 1, 1 },
                    { "Escribir", 1, 1 },
                    { "Leer", 1, 1 },
                    { "Leer", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CompanyId", "DateJoined", "Email", "Ethnicity", "FirstName", "GenderIdentity", "Headline", "IsWorking", "LastName", "LinkedInUrl", "Location", "MobileNumber", "PasswordHash", "PortfolioUrl", "ProfilePicture", "ProfileUrl", "Pronoun", "RequireVisa", "RoleId", "SearchStage", "Summary", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2019, 8, 14, 13, 28, 21, 292, DateTimeKind.Unspecified).AddTicks(5017), new TimeSpan(0, 2, 0, 0, 0)), "admin@techcorp.com", "Latino", "Carlos", "Masculino", "Gerente de TI", true, "Martínez", "https://www.linkedin.com/in/carlosmartinez", "San Francisco, CA", "555-1234", "AQAAAAEAACcQAAAAEDu6ak/YXB+W7W0zY6jEjG5L8/lRxV9NkH5j2Jsfg==", "https://portfolio.com/carlosmartinez", "https://example.com/perfil1.jpg", "https://example.com/carlosmartinez", "Él", false, 1, "Activo", "Profesional con más de 10 años de experiencia en la gestión de proyectos tecnológicos.", "admin", "Administrador" },
                    { 2, 2, new DateTimeOffset(new DateTime(2021, 8, 14, 13, 28, 21, 292, DateTimeKind.Unspecified).AddTicks(5042), new TimeSpan(0, 2, 0, 0, 0)), "jane.doe@saludplus.com", "Caucásica", "Jane", "Femenino", "Científica de Datos", false, "Doe", "https://www.linkedin.com/in/janedoe", "Nueva York, NY", "555-5678", "AQAAAAEAACcQAAAAEBvD5Bb5FVJL/OoYNm4OE4bD81kFfgp1zB/gE4bZg==", "https://portfolio.com/janedoe", "https://example.com/perfil2.jpg", "https://example.com/janedoe", "Ella", false, 2, "En búsqueda", "Especialista en análisis de datos con un enfoque en el sector salud.", "janedoe", "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "AnswerId", "AnswerText", "IsFeatured", "QuestionId", "UserId" },
                values: new object[,]
                {
                    { 1, "Creo que la tecnología blockchain transformará muchas industrias, especialmente las finanzas.", true, 1, 1 },
                    { 2, "El aprendizaje automático ya está revolucionando el análisis de datos en el sector salud.", false, 2, 2 },
                    { 3, "En mi opinión, la realidad aumentada cambiará la manera en que interactuamos con el mundo digital.", false, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Application",
                columns: new[] { "ApplicationId", "ApplicationDate", "JobOfferId", "SalaryExpected", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 1, 60000m, "Pendiente", 1 },
                    { 2, new DateTimeOffset(new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 2, 50000m, "Aceptado", 2 }
                });

            migrationBuilder.InsertData(
                table: "Education",
                columns: new[] { "EducationId", "ActivitiesAndSocieties", "Degree", "Description", "EndDate", "FieldOfStudy", "Grade", "SchoolName", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Club de Programación", "Licenciatura", "Estudios de ingeniería de software con enfoque en desarrollo web y móvil.", new DateTimeOffset(new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Ingeniería de Software", "Excelente", "Universidad de Ejemplo", new DateTimeOffset(new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 },
                    { 2, "Data Science Club", "Máster", "Máster en ciencia de datos con especialización en análisis predictivo y aprendizaje automático.", new DateTimeOffset(new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Ciencias de Datos", "A", "Instituto de Ejemplo", new DateTimeOffset(new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 2 }
                });

            migrationBuilder.InsertData(
                table: "Interest",
                columns: new[] { "InterestId", "InterestText", "UserId" },
                values: new object[,]
                {
                    { 1, "Desarrollo de software y tecnologías emergentes", 1 },
                    { 2, "Diseño de interfaces de usuario y experiencia de usuario (UI/UX)", 2 },
                    { 3, "Gestión de proyectos y metodologías ágiles", 2 },
                    { 4, "Inteligencia artificial y aprendizaje automático", 1 },
                    { 5, "Ciberseguridad y protección de datos", 2 }
                });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "MatchId", "IsAccepted", "JobOfferId", "MatchDate", "UserId" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTimeOffset(new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 2, false, 2, new DateTimeOffset(new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2 }
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
                    { 1, "Tipo de Trabajo", 1, "Trabajo Remoto" },
                    { 2, "Tipo de Trabajo", 2, "Posición de tiempo completo" },
                    { 3, "Salario", 2, "Salario Alto" },
                    { 4, "Horario", 1, "Horario Flexible" },
                    { 5, "Oportunidades", 2, "Oportunidades de Crecimiento" }
                });

            migrationBuilder.InsertData(
                table: "UserSkill",
                columns: new[] { "UserSkillId", "ProficiencyLevel", "RelatedId", "RelatedTo", "SkillId", "UserId" },
                values: new object[,]
                {
                    { 1, "Experto", 101, "Certificación", 1, 1 },
                    { 2, "Intermedio", 202, "Curso", 2, 2 },
                    { 3, "Básico", 303, "Proyecto", 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "WorkExperience",
                columns: new[] { "WorkExperienceId", "CompanyName", "Description", "EndDate", "JobTitle", "Location", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Tech Solutions", "Desarrollo de aplicaciones web utilizando .NET y JavaScript.", new DateTimeOffset(new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Desarrollador de Software", "Ciudad de México", new DateTimeOffset(new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 },
                    { 2, "Innovate Inc.", "Gestión y análisis de grandes volúmenes de datos con Python y SQL.", new DateTimeOffset(new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Ingeniero de Datos", "Guadalajara", new DateTimeOffset(new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 2 },
                    { 3, "Creative Labs", "Diseño de interfaces de usuario y experiencias de usuario para aplicaciones móviles.", new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Diseñador UX/UI", "Monterrey", new DateTimeOffset(new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "ApplicationId", "FeedbackDate", "FeedbackText", "RecruiterId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "El candidato mostró un gran conocimiento en las tecnologías requeridas y una actitud muy positiva durante la entrevista. Sin embargo, sería beneficioso para él mejorar sus habilidades de comunicación.", 1 },
                    { 2, 2, new DateTimeOffset(new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "El candidato tiene una experiencia impresionante en gestión de proyectos y ha demostrado habilidades excepcionales en la resolución de problemas. Recomiendo proceder con una segunda ronda de entrevistas.", 2 }
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
