using AutoMapper;
using JobSearchApp.Domain.DTOs;
using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User Mapping
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();

            // Company Mapping
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CompanyCreateDto>().ReverseMap();
            CreateMap<Company, CompanyUpdateDto>().ReverseMap();

            // JobOffer Mapping
            CreateMap<JobOffer, JobOfferDto>().ReverseMap();
            CreateMap<JobOffer, JobOfferCreateDto>().ReverseMap();
            CreateMap<JobOffer, JobOfferUpdateDto>().ReverseMap();

            // CompensationBenefit Mapping
            CreateMap<CompensationBenefit, CompensationBenefitDto>().ReverseMap();
            CreateMap<CompensationBenefit, CompensationBenefitCreateDto>().ReverseMap();
            CreateMap<CompensationBenefit, CompensationBenefitUpdateDto>().ReverseMap();

            // Role Mapping
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, RoleCreateDto>().ReverseMap();
            CreateMap<Role, RoleUpdateDto>().ReverseMap();

            // Permission Mapping
            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<Permission, PermissionCreateDto>().ReverseMap();
            CreateMap<Permission, PermissionUpdateDto>().ReverseMap();

            // Resource Mapping
            CreateMap<Resource, ResourceDto>().ReverseMap();
            CreateMap<Resource, ResourceCreateDto>().ReverseMap();
            CreateMap<Resource, ResourceUpdateDto>().ReverseMap();

            // RolePermissionPatent Mapping
            CreateMap<RolePermissionPatent, RolePermissionPatentDto>().ReverseMap();
            CreateMap<RolePermissionPatent, RolePermissionPatentCreateDto>().ReverseMap();
            CreateMap<RolePermissionPatent, RolePermissionPatentUpdateDto>().ReverseMap();

            // Skill Mapping
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<Skill, SkillCreateDto>().ReverseMap();
            CreateMap<Skill, SkillUpdateDto>().ReverseMap();

            // Tag Mapping
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, TagCreateDto>().ReverseMap();
            CreateMap<Tag, TagUpdateDto>().ReverseMap();

            // CompanyTag Mapping
            CreateMap<CompanyTag, CompanyTagDto>().ReverseMap();
            CreateMap<CompanyTag, CompanyTagCreateDto>().ReverseMap();
            CreateMap<CompanyTag, CompanyTagUpdateDto>().ReverseMap();

            // Answer Mapping
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Answer, AnswerCreateDto>().ReverseMap();
            CreateMap<Answer, AnswerUpdateDto>().ReverseMap();

            // Application Mapping
            CreateMap<Application, ApplicationDto>().ReverseMap();
            CreateMap<Application, ApplicationCreateDto>().ReverseMap();
            CreateMap<Application, ApplicationUpdateDto>().ReverseMap();

            // Education Mapping
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Education, EducationCreateDto>().ReverseMap();
            CreateMap<Education, EducationUpdateDto>().ReverseMap();

            // Feedback Mapping
            CreateMap<Feedback, FeedbackDto>().ReverseMap();
            CreateMap<Feedback, FeedbackCreateDto>().ReverseMap();
            CreateMap<Feedback, FeedbackUpdateDto>().ReverseMap();

            // Interest Mapping
            CreateMap<Interest, InterestDto>().ReverseMap();
            CreateMap<Interest, InterestCreateDto>().ReverseMap();
            CreateMap<Interest, InterestUpdateDto>().ReverseMap();

            // Match Mapping
            CreateMap<Match, MatchDto>().ReverseMap();
            CreateMap<Match, MatchCreateDto>().ReverseMap();
            CreateMap<Match, MatchUpdateDto>().ReverseMap();

            // SocialMedia Mapping
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaCreateDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateDto>().ReverseMap();

            // UserPreference Mapping
            CreateMap<UserPreference, UserPreferenceDto>().ReverseMap();
            CreateMap<UserPreference, UserPreferenceCreateDto>().ReverseMap();
            CreateMap<UserPreference, UserPreferenceUpdateDto>().ReverseMap();

            // UserSkill Mapping
            CreateMap<UserSkill, UserSkillDto>().ReverseMap();
            CreateMap<UserSkill, UserSkillCreateDto>().ReverseMap();
            CreateMap<UserSkill, UserSkillUpdateDto>().ReverseMap();

            // WorkExperience Mapping
            CreateMap<WorkExperience, WorkExperienceDto>().ReverseMap();
            CreateMap<WorkExperience, WorkExperienceCreateDto>().ReverseMap();
            CreateMap<WorkExperience, WorkExperienceUpdateDto>().ReverseMap();
        }
    }
}
