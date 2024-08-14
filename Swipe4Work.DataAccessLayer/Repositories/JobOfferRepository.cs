using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;

namespace Swipe4Work.DataAccessLayer
{
    public class JobOfferRepository : IJobOfferRepository
    {
        private readonly ApplicationDbContext _context;

        public JobOfferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobOffer>> GetAllJobOffersAsync()
        {
            return await _context.JobOffers.ToListAsync();
        }

        public async Task<JobOffer> GetJobOfferByIdAsync(int jobOfferId)
        {
            return await _context.JobOffers.FindAsync(jobOfferId);
        }

        public async Task<JobOffer> CreateJobOfferAsync(JobOffer jobOffer)
        {
            _context.JobOffers.Add(jobOffer);
            await _context.SaveChangesAsync();
            return jobOffer;
        }

        public async Task<JobOffer> UpdateJobOfferAsync(JobOffer jobOffer)
        {
            _context.JobOffers.Update(jobOffer);
            await _context.SaveChangesAsync();
            return jobOffer;
        }

        public async Task<bool> DeleteJobOfferAsync(int jobOfferId)
        {
            var jobOffer = await _context.JobOffers.FindAsync(jobOfferId);
            if (jobOffer == null)
            {
                return false;
            }

            _context.JobOffers.Remove(jobOffer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}