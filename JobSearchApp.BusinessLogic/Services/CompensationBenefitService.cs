using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
{
    public class CompensationBenefitService : ICompensationBenefitService
    {
        private readonly ICompensationBenefitRepository _compensationBenefitRepository;
        private readonly IMapper _mapper;

        public CompensationBenefitService(ICompensationBenefitRepository compensationBenefitRepository, IMapper mapper)
        {
            _compensationBenefitRepository = compensationBenefitRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompensationBenefitDto>> GetAllCompensationBenefitsAsync()
        {
            var benefits = await _compensationBenefitRepository.GetAllCompensationBenefitsAsync();
            return _mapper.Map<IEnumerable<CompensationBenefitDto>>(benefits);
        }

        public async Task<CompensationBenefitDto> GetCompensationBenefitByIdAsync(int benefitId)
        {
            var benefit = await _compensationBenefitRepository.GetCompensationBenefitByIdAsync(benefitId);
            return benefit == null ? null : _mapper.Map<CompensationBenefitDto>(benefit);
        }

        public async Task<CompensationBenefitDto> CreateCompensationBenefitAsync(CreateCompensationBenefitDto createBenefitDto)
        {
            var benefit = _mapper.Map<CompensationBenefit>(createBenefitDto);
            var createdBenefit = await _compensationBenefitRepository.CreateCompensationBenefitAsync(benefit);
            return _mapper.Map<CompensationBenefitDto>(createdBenefit);
        }

        public async Task<CompensationBenefitDto> UpdateCompensationBenefitAsync(int benefitId, UpdateCompensationBenefitDto updateBenefitDto)
        {
            if (benefitId != updateBenefitDto.BenefitId)
            {
                return null;
            }

            var benefit = _mapper.Map<CompensationBenefit>(updateBenefitDto);
            var updatedBenefit = await _compensationBenefitRepository.UpdateCompensationBenefitAsync(benefit);
            return _mapper.Map<CompensationBenefitDto>(updatedBenefit);
        }

        public async Task<bool> DeleteCompensationBenefitAsync(int benefitId)
        {
            return await _compensationBenefitRepository.DeleteCompensationBenefitAsync(benefitId);
        }
    }
}
