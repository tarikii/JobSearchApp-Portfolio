using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IMapper _mapper;

        public JobOfferService(IJobOfferRepository jobOfferRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobOfferDto>> GetAllJobOffersAsync()
        {
            var jobOffers = await _jobOfferRepository.GetAllJobOffersAsync();

            return _mapper.Map<IEnumerable<JobOfferDto>>(jobOffers);
        }

        public async Task<JobOfferDto> GetJobOfferByIdAsync(int jobOfferId)
        {
            var jobOffer = await _jobOfferRepository.GetJobOfferByIdAsync(jobOfferId);
            return jobOffer == null ? null : _mapper.Map<JobOfferDto>(jobOffer);
        }

        public async Task<JobOfferDto> GetJobOfferByCompanyIdAsync(int companyId)
        {
            var jobOffers= await _jobOfferRepository.GetAllJobOffersAsync();

            return jobOffers == null ? null : _mapper.Map<JobOfferDto>(jobOffers.Where(c => c.CompanyId == companyId));
        }

        public async Task<JobOfferDto> CreateJobOfferAsync(CreateJobOfferDto createJobOfferDto)
        {
            var jobOffer = _mapper.Map<JobOffer>(createJobOfferDto);
            var createdJobOffer = await _jobOfferRepository.CreateJobOfferAsync(jobOffer);
            return _mapper.Map<JobOfferDto>(createdJobOffer);
        }

        public async Task<JobOfferDto> UpdateJobOfferAsync(int jobOfferId, UpdateJobOfferDto updateJobOfferDto)
        {
            if (jobOfferId != updateJobOfferDto.JobOfferId)
            {
                return null;
            }

            var jobOffer = _mapper.Map<JobOffer>(updateJobOfferDto);
            var updatedJobOffer = await _jobOfferRepository.UpdateJobOfferAsync(jobOffer);
            return _mapper.Map<JobOfferDto>(updatedJobOffer);
        }

        public async Task<bool> DeleteJobOfferAsync(int jobOfferId)
        {
            return await _jobOfferRepository.DeleteJobOfferAsync(jobOfferId);
        }
    }
}
