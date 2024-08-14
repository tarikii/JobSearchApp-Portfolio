using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;


namespace Swipe4Work.BusinessLogic.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationDTO>> GetAllApplicationsAsync()
        {
            var applications = await _applicationRepository.GetAllApplicationsAsync();
            return _mapper.Map<IEnumerable<ApplicationDTO>>(applications);
        }

        public async Task<ApplicationDTO> GetApplicationByIdAsync(int applicationId)
        {
            var application = await _applicationRepository.GetApplicationByIdAsync(applicationId);
            return application == null ? null : _mapper.Map<ApplicationDTO>(application);
        }

        public async Task<ApplicationDTO> CreateApplicationAsync(CreateApplicationDTO createApplicationDTO)
        {
            var application = _mapper.Map<Application>(createApplicationDTO);
            var createdApplication = await _applicationRepository.CreateApplicationAsync(application);
            return _mapper.Map<ApplicationDTO>(createdApplication);
        }

        public async Task<ApplicationDTO> UpdateApplicationAsync(int applicationId, UpdateApplicationDTO updateApplicationDTO)
        {
            if (applicationId != updateApplicationDTO.ApplicationId)
            {
                return null;
            }

            var application = _mapper.Map<Application>(updateApplicationDTO);
            var updatedApplication = await _applicationRepository.UpdateApplicationAsync(application);
            return _mapper.Map<ApplicationDTO>(updatedApplication);
        }

        public async Task<bool> DeleteApplicationAsync(int applicationId)
        {
            return await _applicationRepository.DeleteApplicationAsync(applicationId);
        }
    }
}
