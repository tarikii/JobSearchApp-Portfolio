using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IEducationService
{
    Task<IEnumerable<EducationDto>> GetAllEducationsAsync();
    Task<EducationDto> GetEducationByIdAsync(int id);
    Task<EducationDto> CreateEducationAsync(EducationDto educationDto);
    Task<bool> UpdateEducationAsync(EducationDto educationDto);
    Task<bool> DeleteEducationAsync(int id);
}