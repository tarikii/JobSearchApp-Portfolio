using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;

namespace Swipe4Work.DataAccessLayer
{
    public class CompensationBenefitRepository : ICompensationBenefitRepository
    {
        private readonly ApplicationDbContext _context;

        public CompensationBenefitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompensationBenefit>> GetAllCompensationBenefitsAsync()
        {
            return await _context.CompensationBenefits.ToListAsync();
        }

        public async Task<CompensationBenefit> GetCompensationBenefitByIdAsync(int benefitId)
        {
            return await _context.CompensationBenefits.FindAsync(benefitId);
        }

        public async Task<CompensationBenefit> CreateCompensationBenefitAsync(CompensationBenefit compensationBenefit)
        {
            _context.CompensationBenefits.Add(compensationBenefit);
            await _context.SaveChangesAsync();
            return compensationBenefit;
        }

        public async Task<CompensationBenefit> UpdateCompensationBenefitAsync(CompensationBenefit compensationBenefit)
        {
            _context.CompensationBenefits.Update(compensationBenefit);
            await _context.SaveChangesAsync();
            return compensationBenefit;
        }

        public async Task<bool> DeleteCompensationBenefitAsync(int benefitId)
        {
            var compensationBenefit = await _context.CompensationBenefits.FindAsync(benefitId);
            if (compensationBenefit == null)
            {
                return false;
            }

            _context.CompensationBenefits.Remove(compensationBenefit);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}