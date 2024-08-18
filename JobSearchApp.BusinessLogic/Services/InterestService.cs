using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;
using JobSearchApp.Infrastructure.Repositories;

namespace JobSearchApp.BusinessLogic.Services
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

        public async Task<IEnumerable<InterestDto>> GetAllInterestsAsync()
        {
            var interests = await _interestRepository.GetAllInterestsAsync();
            return _mapper.Map<IEnumerable<InterestDto>>(interests);
        }

        public async Task<InterestDto> GetInterestByIdAsync(int interestId)
        {
            var interest = await _interestRepository.GetInterestByIdAsync(interestId);
            return interest == null ? null : _mapper.Map<InterestDto>(interest);
        }

        public async Task<InterestDto> CreateInterestAsync(CreateInterestDto createInterestDto, int userId)
        {
            CreateInterestDto newInterest = createInterestDto;
            newInterest.UserId = userId;

            var interest = _mapper.Map<Interest>(newInterest);
            var createdInterest = await _interestRepository.CreateInterestAsync(interest);
            return _mapper.Map<InterestDto>(createdInterest);
        }

        public async Task<InterestDto> UpdateInterestAsync(int interestId, UpdateInterestDto updateInterestDto)
        {
            if (interestId != updateInterestDto.InterestId)
            {
                return null;
            }

            var interest = _mapper.Map<Interest>(updateInterestDto);
            var updatedInterest = await _interestRepository.UpdateInterestAsync(interest);
            return _mapper.Map<InterestDto>(updatedInterest);
        }

        public async Task<bool> DeleteInterestAsync(int interestId)
        {
            return await _interestRepository.DeleteInterestAsync(interestId);
        }
    }
}
