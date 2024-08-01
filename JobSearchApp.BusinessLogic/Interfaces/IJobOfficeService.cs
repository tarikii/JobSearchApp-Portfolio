using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces; 

public interface IJobOfferService
{
    Task<IEnumerable<JobOfferDto>> GetAllJobOffersAsync();
    Task<JobOfferDto> GetJobOfferByIdAsync(int id);
    Task<JobOfferDto> CreateJobOfferAsync(JobOfferDto jobOfferDto);
    Task<bool> UpdateJobOfferAsync(JobOfferDto jobOfferDto);
    Task<bool> DeleteJobOfferAsync(int id);
}