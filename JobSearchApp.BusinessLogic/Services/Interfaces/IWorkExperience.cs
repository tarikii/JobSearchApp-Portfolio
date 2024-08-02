using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IWorkExperienceService
{
    Task<IEnumerable<WorkExperienceDto>> GetAllWorkExperiencesAsync();
    Task<WorkExperienceDto> GetWorkExperienceByIdAsync(int workExperienceId);
    Task<WorkExperienceDto> CreateWorkExperienceAsync(CreateWorkExperienceDto createWorkExperienceDto);

    Task<WorkExperienceDto> UpdateWorkExperienceAsync(int workExperienceId,
        UpdateWorkExperienceDto updateWorkExperienceDto);

    Task<bool> DeleteWorkExperienceAsync(int workExperienceId);
}