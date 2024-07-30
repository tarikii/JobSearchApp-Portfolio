using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User Mapping
            CreateMap<User, UserDto>().ReverseMap();

            // Company Mapping
            CreateMap<Company, CompanyDto>().ReverseMap();

            // JobOffer Mapping
            CreateMap<JobOffer, JobOfferDto>().ReverseMap();

            // CompensationBenefit Mapping
            CreateMap<CompensationBenefit, CompensationBenefitDto>().ReverseMap();

            // Role Mapping
            CreateMap<Role, RoleDto>().ReverseMap();

            // Permission Mapping
            CreateMap<Permission, PermissionDto>().ReverseMap();

            // Resource Mapping
            CreateMap<Resource, ResourceDto>().ReverseMap();

            // RolePermissionPatent Mapping
            CreateMap<RolePermissionPatent, RolePermissionPatentDto>().ReverseMap();

            // Skill Mapping
            CreateMap<Skill, SkillDto>().ReverseMap();

            // Tag Mapping
            CreateMap<Tag, TagDto>().ReverseMap();

            // CompanyTag Mapping
            CreateMap<CompanyTag, CompanyTagDto>().ReverseMap();

            // Answer Mapping
            CreateMap<Answer, AnswerDto>().ReverseMap();

            // Application Mapping
            CreateMap<Application, ApplicationDto>().ReverseMap();

            // Education Mapping
            CreateMap<Education, EducationDto>().ReverseMap();

            // Feedback Mapping
            CreateMap<Feedback, FeedbackDto>().ReverseMap();

            // Interest Mapping
            CreateMap<Interest, InterestDto>().ReverseMap();

            // Match Mapping
            CreateMap<Match, MatchDto>().ReverseMap();

            // SocialMedia Mapping
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();

            // UserPreference Mapping
            CreateMap<UserPreference, UserPreferenceDto>().ReverseMap();

            // UserSkill Mapping
            CreateMap<UserSkill, UserSkillDto>().ReverseMap();

            // WorkExperience Mapping
            CreateMap<WorkExperience, WorkExperienceDto>().ReverseMap();
        }
    }
}
