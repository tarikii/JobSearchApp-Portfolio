using JobSearchApp.Domain.Models;

namespace JobSearchApp.Infrastructure.Interfaces;

public interface IEducationRepository
{
    Task<IEnumerable<Education>> GetAllEducationsAsync();
    Task<Education> GetEducationByIdAsync(int educationId);
    Task<Education> CreateEducationAsync(Education education);
    Task<Education> UpdateEducationAsync(Education education);
    Task<bool> DeleteEducationAsync(int educationId);
}