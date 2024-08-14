using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IJobOfferService
{
    Task<IEnumerable<JobOfferDTO>> GetAllJobOffersAsync();
    Task<JobOfferDTO> GetJobOfferByIdAsync(int jobOfferId);
    Task<JobOfferDTO> CreateJobOfferAsync(CreateJobOfferDTO createJobOfferDTO);
    Task<JobOfferDTO> UpdateJobOfferAsync(int jobOfferId, UpdateJobOfferDTO updateJobOfferDTO);
    Task<bool> DeleteJobOfferAsync(int jobOfferId);
}