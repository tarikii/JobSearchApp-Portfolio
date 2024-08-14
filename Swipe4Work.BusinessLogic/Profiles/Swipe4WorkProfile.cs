using AutoMapper;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Profiles
{
    public class Swipe4WorkProfile : Profile
    {
        public Swipe4WorkProfile() 
        {
            // User Mapping
            CreateMap<User, UserDTO>()
                .ForMember(dto => dto.RoleName, opt => opt.MapFrom(r => r.Role.Name))
                .ReverseMap();

            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<UpdateUserDTO, User>().ReverseMap();

            // Company Mapping
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<CreateCompanyDTO, Company>().ReverseMap();
            CreateMap<UpdateCompanyDTO, Company>().ReverseMap();

            // JobOffer Mapping
            CreateMap<JobOffer, JobOfferDTO>().ReverseMap();
            CreateMap<CreateJobOfferDTO, JobOffer>().ReverseMap();
            CreateMap<UpdateJobOfferDTO, JobOffer>().ReverseMap();

            // CompensationBenefit Mapping
            CreateMap<CompensationBenefit, CompensationBenefitDTO>().ReverseMap();
            CreateMap<CreateCompensationBenefitDTO, CompensationBenefit>().ReverseMap();
            CreateMap<UpdateCompensationBenefitDTO, CompensationBenefit>().ReverseMap();

            // Role Mapping
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<CreateRoleDTO, Role>().ReverseMap();
            CreateMap<UpdateRoleDTO, Role>().ReverseMap();

            // Permission Mapping
            CreateMap<Permission, PermissionDTO>().ReverseMap();
            CreateMap<CreatePermissionDTO, Permission>().ReverseMap();
            CreateMap<UpdatePermissionDTO, Permission>().ReverseMap();

            // Resource Mapping
            CreateMap<Resource, ResourceDTO>().ReverseMap();
            CreateMap<CreateResourceDTO, Resource>().ReverseMap();
            CreateMap<UpdateResourceDTO, Resource>().ReverseMap();

            // RolePermissionPatent Mapping
            CreateMap<RolePermissionPatent, RolePermissionPatentDTO>().ReverseMap();
            CreateMap<CreateRolePermissionPatentDTO, RolePermissionPatent>().ReverseMap();
            CreateMap<UpdateRolePermissionPatentDTO, RolePermissionPatent>().ReverseMap();

            // Skill Mapping
            CreateMap<Skill, SkillDTO>().ReverseMap();
            CreateMap<CreateSkillDTO, Skill>().ReverseMap();
            CreateMap<UpdateSkillDTO, Skill>().ReverseMap();

            // Tag Mapping
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<CreateTagDTO, Tag>().ReverseMap();
            CreateMap<UpdateTagDTO, Tag>().ReverseMap();

            // CompanyTag Mapping
            CreateMap<CompanyTag, CompanyTagDTO>().ReverseMap();
            CreateMap<CreateCompanyTagDTO, CompanyTag>().ReverseMap();
            CreateMap<UpdateCompanyTagDTO, CompanyTag>().ReverseMap();

            // Answer Mapping
            CreateMap<Answer, AnswerDTO>().ReverseMap();
            CreateMap<CreateAnswerDTO, Answer>().ReverseMap();
            CreateMap<UpdateAnswerDTO, Answer>().ReverseMap();

            // Application Mapping
            CreateMap<Application, ApplicationDTO>().ReverseMap();
            CreateMap<CreateApplicationDTO, Application>().ReverseMap();
            CreateMap<UpdateApplicationDTO, Application>().ReverseMap();

            // Education Mapping
            CreateMap<Education, EducationDTO>().ReverseMap();
            CreateMap<CreateEducationDTO, Education>().ReverseMap();
            CreateMap<UpdateEducationDTO, Education>().ReverseMap();

            // Feedback Mapping
            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            CreateMap<CreateFeedbackDTO, Feedback>().ReverseMap();
            CreateMap<UpdateFeedbackDTO, Feedback>().ReverseMap();

            // Interest Mapping
            CreateMap<Interest, InterestDTO>().ReverseMap();
            CreateMap<CreateInterestDTO, Interest>().ReverseMap();
            CreateMap<UpdateInterestDTO, Interest>().ReverseMap();

            // Match Mapping
            CreateMap<Match, MatchDTO>().ReverseMap();
            CreateMap<CreateMatchDTO, Match>().ReverseMap();
            CreateMap<UpdateMatchDTO, Match>().ReverseMap();

            // SocialMedia Mapping
            CreateMap<SocialMedia, SocialMediaDTO>().ReverseMap();
            CreateMap<CreateSocialMediaDTO, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDTO, SocialMedia>().ReverseMap();

            // UserPreference Mapping
            CreateMap<UserPreference, UserPreferenceDTO>().ReverseMap();
            CreateMap<CreateUserPreferenceDTO, UserPreference>().ReverseMap();
            CreateMap<UpdateUserPreferenceDTO, UserPreference>().ReverseMap();

            // UserSkill Mapping
            CreateMap<UserSkill, UserSkillDTO>().ReverseMap();
            CreateMap<CreateUserSkillDTO, UserSkill>().ReverseMap();
            CreateMap<UpdateUserSkillDTO, UserSkill>().ReverseMap();

            // WorkExperience Mapping
            CreateMap<WorkExperience, WorkExperienceDTO>().ReverseMap();
            CreateMap<CreateWorkExperienceDTO, WorkExperience>().ReverseMap();
            CreateMap<UpdateWorkExperienceDTO, WorkExperience>().ReverseMap();

            // Question Mapping
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<CreateQuestionDTO, Question>().ReverseMap();
            CreateMap<UpdateQuestionDTO, Question>().ReverseMap();
        }
    }
}
