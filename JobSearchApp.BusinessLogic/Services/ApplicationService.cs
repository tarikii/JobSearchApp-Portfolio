using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
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

        public async Task<IEnumerable<ApplicationDto>> GetAllApplicationsAsync()
        {
            var applications = await _applicationRepository.GetAllApplicationsAsync();
            return _mapper.Map<IEnumerable<ApplicationDto>>(applications);
        }

        public async Task<ApplicationDto> GetApplicationByIdAsync(int applicationId)
        {
            var application = await _applicationRepository.GetApplicationByIdAsync(applicationId);
            return application == null ? null : _mapper.Map<ApplicationDto>(application);
        }

        public async Task<ApplicationDto> CreateApplicationAsync(CreateApplicationDto createApplicationDto)
        {
            var application = _mapper.Map<Application>(createApplicationDto);
            var createdApplication = await _applicationRepository.CreateApplicationAsync(application);
            return _mapper.Map<ApplicationDto>(createdApplication);
        }

        public async Task<ApplicationDto> UpdateApplicationAsync(int applicationId, UpdateApplicationDto updateApplicationDto)
        {
            if (applicationId != updateApplicationDto.ApplicationId)
            {
                return null;
            }

            var application = _mapper.Map<Application>(updateApplicationDto);
            var updatedApplication = await _applicationRepository.UpdateApplicationAsync(application);
            return _mapper.Map<ApplicationDto>(updatedApplication);
        }

        public async Task<bool> DeleteApplicationAsync(int applicationId)
        {
            return await _applicationRepository.DeleteApplicationAsync(applicationId);
        }
    }
}
