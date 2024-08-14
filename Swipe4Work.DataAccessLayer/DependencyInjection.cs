using Microsoft.Extensions.DependencyInjection;
using Swipe4Work.DataAccessLayer.Interfaces;
using System.ComponentModel.Design;

namespace Swipe4Work.DataAccessLayer
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
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
        }
    }
}
