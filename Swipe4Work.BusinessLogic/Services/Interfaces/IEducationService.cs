using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IEducationService
{
    Task<IEnumerable<EducationDTO>> GetAllEducationsAsync();
    Task<EducationDTO> GetEducationByIdAsync(int educationId);
    Task<EducationDTO> CreateEducationAsync(CreateEducationDTO createEducationDTO);
    Task<EducationDTO> UpdateEducationAsync(int educationId, UpdateEducationDTO updateEducationDTO);
    Task<bool> DeleteEducationAsync(int educationId);
}