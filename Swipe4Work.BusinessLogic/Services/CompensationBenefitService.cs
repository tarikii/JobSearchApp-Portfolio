using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<CompensationBenefitDTO>> GetAllCompensationBenefitsAsync()
        {
            var benefits = await _compensationBenefitRepository.GetAllCompensationBenefitsAsync();
            return _mapper.Map<IEnumerable<CompensationBenefitDTO>>(benefits);
        }

        public async Task<CompensationBenefitDTO> GetCompensationBenefitByIdAsync(int benefitId)
        {
            var benefit = await _compensationBenefitRepository.GetCompensationBenefitByIdAsync(benefitId);
            return benefit == null ? null : _mapper.Map<CompensationBenefitDTO>(benefit);
        }

        public async Task<CompensationBenefitDTO> CreateCompensationBenefitAsync(CreateCompensationBenefitDTO createBenefitDTO)
        {
            var benefit = _mapper.Map<CompensationBenefit>(createBenefitDTO);
            var createdBenefit = await _compensationBenefitRepository.CreateCompensationBenefitAsync(benefit);
            return _mapper.Map<CompensationBenefitDTO>(createdBenefit);
        }

        public async Task<CompensationBenefitDTO> UpdateCompensationBenefitAsync(int benefitId, UpdateCompensationBenefitDTO updateBenefitDTO)
        {
            if (benefitId != updateBenefitDTO.BenefitId)
            {
                return null;
            }

            var benefit = _mapper.Map<CompensationBenefit>(updateBenefitDTO);
            var updatedBenefit = await _compensationBenefitRepository.UpdateCompensationBenefitAsync(benefit);
            return _mapper.Map<CompensationBenefitDTO>(updatedBenefit);
        }

        public async Task<bool> DeleteCompensationBenefitAsync(int benefitId)
        {
            return await _compensationBenefitRepository.DeleteCompensationBenefitAsync(benefitId);
        }
    }
}
