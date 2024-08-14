using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IEducationService
{
    Task<IEnumerable<EducationDto>> GetAllEducationsAsync();
    Task<EducationDto> GetEducationByIdAsync(int educationId);
    Task<EducationDto> CreateEducationAsync(CreateEducationDto createEducationDto);
    Task<EducationDto> UpdateEducationAsync(int educationId, UpdateEducationDto updateEducationDto);
    Task<bool> DeleteEducationAsync(int educationId);
}