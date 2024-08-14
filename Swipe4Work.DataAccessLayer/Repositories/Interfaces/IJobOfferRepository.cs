using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataAccessLayer.Interfaces
{
    public interface IJobOfferRepository
    {
        Task<IEnumerable<JobOffer>> GetAllJobOffersAsync();
        Task<JobOffer> GetJobOfferByIdAsync(int jobOfferId);
        Task<JobOffer> CreateJobOfferAsync(JobOffer jobOffer);
        Task<JobOffer> UpdateJobOfferAsync(JobOffer jobOffer);
        Task<bool> DeleteJobOfferAsync(int jobOfferId);
    }
}