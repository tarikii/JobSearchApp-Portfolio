using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.BusinessLogic.Services
{
    public class CompensationBenefitService : ICompensationBenefitService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CompensationBenefitService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompensationBenefitDto>> GetAllCompensationBenefitsAsync()
        {
            var benefits = await _context.CompensationBenefits.ToListAsync();
            return _mapper.Map<IEnumerable<CompensationBenefitDto>>(benefits);
        }

        public async Task<CompensationBenefitDto> GetCompensationBenefitByIdAsync(int benefitId)
        {
            var benefit = await _context.CompensationBenefits.FindAsync(benefitId);
            return benefit == null ? null : _mapper.Map<CompensationBenefitDto>(benefit);
        }

        public async Task<CompensationBenefitDto> CreateCompensationBenefitAsync(CreateCompensationBenefitDto createBenefitDto)
        {
            var benefit = _mapper.Map<CompensationBenefit>(createBenefitDto);
            _context.CompensationBenefits.Add(benefit);
            await _context.SaveChangesAsync();
            return _mapper.Map<CompensationBenefitDto>(benefit);
        }

        public async Task<CompensationBenefitDto> UpdateCompensationBenefitAsync(int benefitId, UpdateCompensationBenefitDto updateBenefitDto)
        {
            if (benefitId != updateBenefitDto.BenefitId)
            {
                return null;
            }

            var benefit = _mapper.Map<CompensationBenefit>(updateBenefitDto);
            _context.CompensationBenefits.Update(benefit);
            await _context.SaveChangesAsync();
            return _mapper.Map<CompensationBenefitDto>(benefit);
        }

        public async Task<bool> DeleteCompensationBenefitAsync(int benefitId)
        {
            var benefit = await _context.CompensationBenefits.FindAsync(benefitId);
            if (benefit == null)
            {
                return false;
            }

            _context.CompensationBenefits.Remove(benefit);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
