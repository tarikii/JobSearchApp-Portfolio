using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<JobOfferDTO>> GetAllJobOffersAsync()
        {
            var jobOffers = await _jobOfferRepository.GetAllJobOffersAsync();
            return _mapper.Map<IEnumerable<JobOfferDTO>>(jobOffers);
        }

        public async Task<JobOfferDTO> GetJobOfferByIdAsync(int jobOfferId)
        {
            var jobOffer = await _jobOfferRepository.GetJobOfferByIdAsync(jobOfferId);
            return jobOffer == null ? null : _mapper.Map<JobOfferDTO>(jobOffer);
        }

        public async Task<JobOfferDTO> CreateJobOfferAsync(CreateJobOfferDTO createJobOfferDTO)
        {
            var jobOffer = _mapper.Map<JobOffer>(createJobOfferDTO);
            var createdJobOffer = await _jobOfferRepository.CreateJobOfferAsync(jobOffer);
            return _mapper.Map<JobOfferDTO>(createdJobOffer);
        }

        public async Task<JobOfferDTO> UpdateJobOfferAsync(int jobOfferId, UpdateJobOfferDTO updateJobOfferDTO)
        {
            if (jobOfferId != updateJobOfferDTO.JobOfferId)
            {
                return null;
            }

            var jobOffer = _mapper.Map<JobOffer>(updateJobOfferDTO);
            var updatedJobOffer = await _jobOfferRepository.UpdateJobOfferAsync(jobOffer);
            return _mapper.Map<JobOfferDTO>(updatedJobOffer);
        }

        public async Task<bool> DeleteJobOfferAsync(int jobOfferId)
        {
            return await _jobOfferRepository.DeleteJobOfferAsync(jobOfferId);
        }
    }
}
