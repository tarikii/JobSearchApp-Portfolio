using Microsoft.Extensions.DependencyInjection;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.BusinessLogic.Profiles;
using Swipe4Work.BusinessLogic.Services;

namespace Swipe4Work.BusinessLogic
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
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
            services.AddAutoMapper(typeof(Swipe4WorkProfile));
        }
    }
}
