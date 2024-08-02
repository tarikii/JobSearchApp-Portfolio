using System.Collections.Generic;
using System.Threading.Tasks;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Data;
using JobSearchApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.Infrastructure.Repositories
{
    public class InterestRepository : IInterestRepository
    {
        private readonly ApplicationDbContext _context;

        public InterestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interest>> GetAllInterestsAsync()
        {
            return await _context.Interests.ToListAsync();
        }

        public async Task<Interest> GetInterestByIdAsync(int interestId)
        {
            return await _context.Interests.FindAsync(interestId);
        }

        public async Task<Interest> CreateInterestAsync(Interest interest)
        {
            _context.Interests.Add(interest);
            await _context.SaveChangesAsync();
            return interest;
        }

        public async Task<Interest> UpdateInterestAsync(Interest interest)
        {
            _context.Interests.Update(interest);
            await _context.SaveChangesAsync();
            return interest;
        }

        public async Task<bool> DeleteInterestAsync(int interestId)
        {
            var interest = await _context.Interests.FindAsync(interestId);
            if (interest == null)
            {
                return false;
            }

            _context.Interests.Remove(interest);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}