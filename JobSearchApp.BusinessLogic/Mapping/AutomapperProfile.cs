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
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();

            // Company Mapping
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CreateCompanyDto, Company>().ReverseMap();
            CreateMap<UpdateCompanyDto, Company>().ReverseMap();

            // JobOffer Mapping
            CreateMap<JobOffer, JobOfferDto>().ReverseMap();
            CreateMap<CreateJobOfferDto, JobOffer>().ReverseMap();
            CreateMap<UpdateJobOfferDto, JobOffer>().ReverseMap();

            // CompensationBenefit Mapping
            CreateMap<CompensationBenefit, CompensationBenefitDto>().ReverseMap();
            CreateMap<CreateCompensationBenefitDto, CompensationBenefit>().ReverseMap();
            CreateMap<UpdateCompensationBenefitDto, CompensationBenefit>().ReverseMap();

            // Role Mapping
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<CreateRoleDto, Role>().ReverseMap();
            CreateMap<UpdateRoleDto, Role>().ReverseMap();

            // Permission Mapping
            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<CreatePermissionDto, Permission>().ReverseMap();
            CreateMap<UpdatePermissionDto, Permission>().ReverseMap();

            // Resource Mapping
            CreateMap<Resource, ResourceDto>().ReverseMap();
            CreateMap<CreateResourceDto, Resource>().ReverseMap();
            CreateMap<UpdateResourceDto, Resource>().ReverseMap();

            // RolePermissionPatent Mapping
            CreateMap<RolePermissionPatent, RolePermissionPatentDto>().ReverseMap();
            CreateMap<CreateRolePermissionPatentDto, RolePermissionPatent>().ReverseMap();
            CreateMap<UpdateRolePermissionPatentDto, RolePermissionPatent>().ReverseMap();

            // Skill Mapping
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<CreateSkillDto, Skill>().ReverseMap();
            CreateMap<UpdateSkillDto, Skill>().ReverseMap();

            // Tag Mapping
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<CreateTagDto, Tag>().ReverseMap();
            CreateMap<UpdateTagDto, Tag>().ReverseMap();

            // CompanyTag Mapping
            CreateMap<CompanyTag, CompanyTagDto>().ReverseMap();
            CreateMap<CreateCompanyTagDto, CompanyTag>().ReverseMap();
            CreateMap<UpdateCompanyTagDto, CompanyTag>().ReverseMap();

            // Answer Mapping
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<CreateAnswerDto, Answer>().ReverseMap();
            CreateMap<UpdateAnswerDto, Answer>().ReverseMap();

            // Application Mapping
            CreateMap<Application, ApplicationDto>().ReverseMap();
            CreateMap<CreateApplicationDto, Application>().ReverseMap();
            CreateMap<UpdateApplicationDto, Application>().ReverseMap();

            // Education Mapping
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<CreateEducationDto, Education>().ReverseMap();
            CreateMap<UpdateEducationDto, Education>().ReverseMap();

            // Feedback Mapping
            CreateMap<Feedback, FeedbackDto>().ReverseMap();
            CreateMap<CreateFeedbackDto, Feedback>().ReverseMap();
            CreateMap<UpdateFeedbackDto, Feedback>().ReverseMap();

            // Interest Mapping
            CreateMap<Interest, InterestDto>().ReverseMap();
            CreateMap<CreateInterestDto, Interest>().ReverseMap();
            CreateMap<UpdateInterestDto, Interest>().ReverseMap();

            // Match Mapping
            CreateMap<Match, MatchDto>().ReverseMap();
            CreateMap<CreateMatchDto, Match>().ReverseMap();
            CreateMap<UpdateMatchDto, Match>().ReverseMap();

            // SocialMedia Mapping
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<CreateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();

            // UserPreference Mapping
            CreateMap<UserPreference, UserPreferenceDto>().ReverseMap();
            CreateMap<CreateUserPreferenceDto, UserPreference>().ReverseMap();
            CreateMap<UpdateUserPreferenceDto, UserPreference>().ReverseMap();

            // UserSkill Mapping
            CreateMap<UserSkill, UserSkillDto>().ReverseMap();
            CreateMap<CreateUserSkillDto, UserSkill>().ReverseMap();
            CreateMap<UpdateUserSkillDto, UserSkill>().ReverseMap();

            // WorkExperience Mapping
            CreateMap<WorkExperience, WorkExperienceDto>().ReverseMap();
            CreateMap<CreateWorkExperienceDto, WorkExperience>().ReverseMap();
            CreateMap<UpdateWorkExperienceDto, WorkExperience>().ReverseMap();

            // Question Mapping
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<CreateQuestionDto, Question>().ReverseMap();
            CreateMap<UpdateQuestionDto, Question>().ReverseMap();
        }
    }
}
