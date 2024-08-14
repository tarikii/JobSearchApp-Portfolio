using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
{
    public class InterestService : IInterestService
    {
        private readonly IInterestRepository _interestRepository;
        private readonly IMapper _mapper;

        public InterestService(IInterestRepository interestRepository, IMapper mapper)
        {
            _interestRepository = interestRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InterestDTO>> GetAllInterestsAsync()
        {
            var interests = await _interestRepository.GetAllInterestsAsync();
            return _mapper.Map<IEnumerable<InterestDTO>>(interests);
        }

        public async Task<InterestDTO> GetInterestByIdAsync(int interestId)
        {
            var interest = await _interestRepository.GetInterestByIdAsync(interestId);
            return interest == null ? null : _mapper.Map<InterestDTO>(interest);
        }

        public async Task<InterestDTO> CreateInterestAsync(CreateInterestDTO createInterestDTO)
        {
            var interest = _mapper.Map<Interest>(createInterestDTO);
            var createdInterest = await _interestRepository.CreateInterestAsync(interest);
            return _mapper.Map<InterestDTO>(createdInterest);
        }

        public async Task<InterestDTO> UpdateInterestAsync(int interestId, UpdateInterestDTO updateInterestDTO)
        {
            if (interestId != updateInterestDTO.InterestId)
            {
                return null;
            }

            var interest = _mapper.Map<Interest>(updateInterestDTO);
            var updatedInterest = await _interestRepository.UpdateInterestAsync(interest);
            return _mapper.Map<InterestDTO>(updatedInterest);
        }

        public async Task<bool> DeleteInterestAsync(int interestId)
        {
            return await _interestRepository.DeleteInterestAsync(interestId);
        }
    }
}
