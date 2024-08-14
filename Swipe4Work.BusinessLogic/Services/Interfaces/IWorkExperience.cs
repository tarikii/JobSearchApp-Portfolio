using Swipe4Work.DataTransferObject;
namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IWorkExperienceService
{
    Task<IEnumerable<WorkExperienceDTO>> GetAllWorkExperiencesAsync();
    Task<WorkExperienceDTO> GetWorkExperienceByIdAsync(int workExperienceId);
    Task<WorkExperienceDTO> CreateWorkExperienceAsync(CreateWorkExperienceDTO createWorkExperienceDTO);

    Task<WorkExperienceDTO> UpdateWorkExperienceAsync(int workExperienceId,
        UpdateWorkExperienceDTO updateWorkExperienceDTO);

    Task<bool> DeleteWorkExperienceAsync(int workExperienceId);
}