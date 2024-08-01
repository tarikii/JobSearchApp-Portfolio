using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IWorkExperienceService
{
    Task<IEnumerable<WorkExperienceDto>> GetAllWorkExperiencesAsync();
    Task<WorkExperienceDto> GetWorkExperienceByIdAsync(int id);
    Task<WorkExperienceDto> CreateWorkExperienceAsync(WorkExperienceDto workExperienceDto);
    Task<bool> UpdateWorkExperienceAsync(WorkExperienceDto workExperienceDto);
    Task<bool> DeleteWorkExperienceAsync(int id);
}