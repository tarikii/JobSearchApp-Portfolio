using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IJobOfferService
{
    Task<IEnumerable<JobOfferDto>> GetAllJobOffersAsync();
    Task<JobOfferDto> GetJobOfferByIdAsync(int jobOfferId);
    Task<JobOfferDto> CreateJobOfferAsync(CreateJobOfferDto createJobOfferDto);
    Task<JobOfferDto> UpdateJobOfferAsync(int jobOfferId, UpdateJobOfferDto updateJobOfferDto);
    Task<bool> DeleteJobOfferAsync(int jobOfferId);
}