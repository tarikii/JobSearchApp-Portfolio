using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using JobSearchApp.BusinessLogic.Services.Interfaces;
using JobSearchApp.Infrastructure.Interfaces;
using JobSearchApp.Infrastructure.Repositories;

namespace JobSearchApp.Views.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            //services.AddAutoMapper(typeof(Program));
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompensationBenefitRepository, CompensationBenefitRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IInterestRepository, InterestRepository>();
            services.AddScoped<IJobOfferRepository, JobOfferRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IRolePermissionPatentRepository, RolePermissionPatentRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserPreferenceRepository, UserPreferenceRepository>();
            services.AddScoped<IUserSkillRepository, UserSkillRepository>();
            services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompensationBenefitService, CompensationBenefitService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IInterestService, InterestService>();
            services.AddScoped<IJobOfferService, JobOfferService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IRolePermissionPatentService, RolePermissionPatentService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IUserPreferenceService, UserPreferenceService>();
            services.AddScoped<IUserSkillService, UserSkillService>();
            services.AddScoped<IWorkExperienceService, WorkExperienceService>();
        }
    }
}