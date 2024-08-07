using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.Controllers;
using Microsoft.Extensions.DependencyInjection;
using JobSearchApp.Web.Controllers;

namespace JobSearchApp.Infrastructure.Data
{
    public class DataSeeder
    {
        private readonly IServiceProvider _serviceProvider;

        public DataSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SeedDataAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Seed Roles
                var roleController = scope.ServiceProvider.GetRequiredService<RoleController>();
                await roleController.CreateRole(new CreateRoleDto { Name = "Admin", Description = "Administrator" });
                await roleController.CreateRole(new CreateRoleDto { Name = "Recruiter", Description = "Recruiter" });
                await roleController.CreateRole(new CreateRoleDto { Name = "Candidate", Description = "Candidate" });

                // Seed Permissions
                var permissionController = scope.ServiceProvider.GetRequiredService<PermissionController>();
                await permissionController.CreatePermission(new CreatePermissionDto { Name = "View" });
                await permissionController.CreatePermission(new CreatePermissionDto { Name = "Edit" });

                // Seed Resources
                var resourceController = scope.ServiceProvider.GetRequiredService<ResourceController>();
                await resourceController.CreateResource(new CreateResourceDto { Name = "JobOffer", Description = "Job Offer Resource" });
                await resourceController.CreateResource(new CreateResourceDto { Name = "Application", Description = "Application Resource" });

                // Seed Companies
                var companyController = scope.ServiceProvider.GetRequiredService<CompanyController>();
                var createdCompany1 = (await companyController.CreateCompany(new CreateCompanyDto { Name = "Company A", WebsiteUrl = "https://companya.com", Industry = "Tech", Size = "100-500", Headquarters = "New York", FoundedYear = 2000, Description = "A tech company", Location = "New York" })).Value;
                var createdCompany2 = (await companyController.CreateCompany(new CreateCompanyDto { Name = "Company B", WebsiteUrl = "https://companyb.com", Industry = "Finance", Size = "50-200", Headquarters = "San Francisco", FoundedYear = 2010, Description = "A finance company", Location = "San Francisco" })).Value;

                // Seed CompensationBenefits
                var compensationBenefitController = scope.ServiceProvider.GetRequiredService<CompensationBenefitController>();
                await compensationBenefitController.CreateCompensationBenefit(new CreateCompensationBenefitDto { CompanyId = createdCompany1.CompanyId, BenefitType = "Health Insurance", Description = "Comprehensive health insurance" });
                await compensationBenefitController.CreateCompensationBenefit(new CreateCompensationBenefitDto { CompanyId = createdCompany2.CompanyId, BenefitType = "Retirement Plan", Description = "401(k) retirement plan" });

                // Seed Users
                var userController = scope.ServiceProvider.GetRequiredService<UserController>();
                var createdUser1 = (await userController.CreateUser(new CreateUserDto { Email = "admin@example.com", UserName = "admin", PasswordHash = "password", UserType = "Admin", FirstName = "Admin", LastName = "User", RoleId = 1, CompanyId = createdCompany1.CompanyId })).Value;
                var createdUser2 = (await userController.CreateUser(new CreateUserDto { Email = "recruiter@example.com", UserName = "recruiter", PasswordHash = "password", UserType = "Recruiter", FirstName = "Recruiter", LastName = "User", RoleId = 2, CompanyId = createdCompany2.CompanyId })).Value;
                var createdUser3 = (await userController.CreateUser(new CreateUserDto { Email = "candidate@example.com", UserName = "candidate", PasswordHash = "password", UserType = "Candidate", FirstName = "Candidate", LastName = "User", RoleId = 3, CompanyId = createdCompany1.CompanyId })).Value;

                // Seed JobOffers
                var jobOfferController = scope.ServiceProvider.GetRequiredService<JobOfferController>();
                var createdJobOffer1 = (await jobOfferController.CreateJobOffer(new CreateJobOfferDto { CompanyId = createdCompany1.CompanyId, Title = "Software Engineer", Description = "Develop software applications", Location = "New York", JobType = "Full-time", ExperienceLevel = "Mid", MinSalary = 60000, MaxSalary = 120000 })).Value;
                var createdJobOffer2 = (await jobOfferController.CreateJobOffer(new CreateJobOfferDto { CompanyId = createdCompany2.CompanyId, Title = "Financial Analyst", Description = "Analyze financial data", Location = "San Francisco", JobType = "Full-time", ExperienceLevel = "Junior", MinSalary = 50000, MaxSalary = 100000 })).Value;

                // Seed Applications
                var applicationController = scope.ServiceProvider.GetRequiredService<ApplicationController>();
                await applicationController.CreateApplication(new CreateApplicationDto { UserId = createdUser3.UserId, JobOfferId = createdJobOffer1.JobOfferId, SalaryExpected = 80000 });

                // Seed Feedbacks
                var feedbackController = scope.ServiceProvider.GetRequiredService<FeedbackController>();
                await feedbackController.CreateFeedback(new CreateFeedbackDto { ApplicationId = 1, RecruiterId = createdUser2.UserId, FeedbackText = "Good candidate, proceed to next round." });

                // Seed SocialMedia
                var socialMediaController = scope.ServiceProvider.GetRequiredService<SocialMediaController>();
                await socialMediaController.CreateSocialMedia(new CreateSocialMediaDto { UserId = createdUser3.UserId, Platform = "LinkedIn", Url = "https://linkedin.com/in/candidate" });

                // Seed Questions
                var questionController = scope.ServiceProvider.GetRequiredService<QuestionController>();
                var createdQuestion = (await questionController.CreateQuestion(new CreateQuestionDto { QuestionText = "Why do you want this job?" })).Value;

                // Seed Answers
                var answerController = scope.ServiceProvider.GetRequiredService<AnswerController>();
                await answerController.CreateAnswer(new CreateAnswerDto { UserId = createdUser3.UserId, QuestionId = createdQuestion.QuestionId, AnswerText = "Because it aligns with my career goals." });

                // Seed Interests
                var interestController = scope.ServiceProvider.GetRequiredService<InterestController>();
                await interestController.CreateInterest(new CreateInterestDto { UserId = createdUser3.UserId, InterestText = "Machine Learning" });

                // Seed Educations
                var educationController = scope.ServiceProvider.GetRequiredService<EducationController>();
                await educationController.CreateEducation(new CreateEducationDto { UserId = createdUser3.UserId, SchoolName = "MIT", Degree = "BSc", FieldOfStudy = "Computer Science", StartDate = DateTimeOffset.Parse("2015-09-01"), EndDate = DateTimeOffset.Parse("2019-06-01") });

                // Seed WorkExperiences
                var workExperienceController = scope.ServiceProvider.GetRequiredService<WorkExperienceController>();
                await workExperienceController.CreateWorkExperience(new CreateWorkExperienceDto { UserId = createdUser3.UserId, CompanyName = "Tech Corp", JobTitle = "Intern", StartDate = DateTimeOffset.Parse("2018-06-01"), EndDate = DateTimeOffset.Parse("2018-08-31"), Description = "Worked on software development projects." });

                // Seed Skills
                var skillController = scope.ServiceProvider.GetRequiredService<SkillController>();
                var createdSkill = (await skillController.CreateSkill(new CreateSkillDto { SkillName = "C#", SkillType = "Technical" })).Value;

                // Seed UserSkills
                var userSkillController = scope.ServiceProvider.GetRequiredService<UserSkillController>();
                await userSkillController.CreateUserSkill(new CreateUserSkillDto { UserId = createdUser3.UserId, SkillId = createdSkill.SkillId, ProficiencyLevel = "Intermediate" });

                // Seed Tags
                var tagController = scope.ServiceProvider.GetRequiredService<TagController>();
                var createdTag = (await tagController.CreateTag(new CreateTagDto { TagName = "Innovative" })).Value;

                // Seed CompanyTags
                var companyTagController = scope.ServiceProvider.GetRequiredService<CompanyTagController>();
                await companyTagController.CreateCompanyTag(new CreateCompanyTagDto { CompayName = createdCompany1.Name, TagId = createdTag.TagId, TagName = createdTag.TagName });

                // Seed Matches
                var matchController = scope.ServiceProvider.GetRequiredService<MatchController>();
                await matchController.CreateMatch(new CreateMatchDto { JobOfferId = createdJobOffer1.JobOfferId, UserId = createdUser3.UserId, IsAccepted = true });

                // Seed RolePermissionPatents
                var rolePermissionPatentController = scope.ServiceProvider.GetRequiredService<RolePermissionPatentController>();
                await rolePermissionPatentController.CreateRolePermissionPatent(new CreateRolePermissionPatentDto { RoleId = 1, ResourceId = 1, Permission = "View" });
            }
        }
    }
}
