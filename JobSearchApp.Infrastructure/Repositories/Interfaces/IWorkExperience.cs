using JobSearchApp.Domain.Models;

namespace JobSearchApp.Infrastructure.Interfaces
{
    public interface IWorkExperienceRepository
    {
        Task<IEnumerable<WorkExperience>> GetAllWorkExperiencesAsync();
        Task<WorkExperience> GetWorkExperienceByIdAsync(int workExperienceId);
        Task<WorkExperience> CreateWorkExperienceAsync(WorkExperience workExperience);
        Task<WorkExperience> UpdateWorkExperienceAsync(WorkExperience workExperience);
        Task<bool> DeleteWorkExperienceAsync(int workExperienceId);
    }
}