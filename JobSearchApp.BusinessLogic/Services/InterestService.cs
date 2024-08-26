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
            var existingInterest = await _interestRepository.GetInterestByIdAsync(interestId);
            if (existingInterest == null)
            {
                // Handle the case where the interest does not exist
                throw new Exception($"Interest with ID {interestId} not found.");
            }

            // Update properties on the existing interest
            _mapper.Map(updateInterestDto, existingInterest);

            // Save the updated interest entity
            var updatedInterest = await _interestRepository.UpdateInterestAsync(existingInterest);

            // Map the updated entity back to a DTO
            return _mapper.Map<InterestDto>(updatedInterest);
        }

        public async Task<bool> DeleteInterestAsync(int interestId)
        {
            return await _interestRepository.DeleteInterestAsync(interestId);
        }
    }
}
