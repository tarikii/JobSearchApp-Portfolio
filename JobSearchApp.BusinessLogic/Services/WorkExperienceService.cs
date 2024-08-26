using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IWorkExperienceRepository _workExperienceRepository;
        private readonly IMapper _mapper;

        public WorkExperienceService(IWorkExperienceRepository workExperienceRepository, IMapper mapper)
        {
            _workExperienceRepository = workExperienceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkExperienceDto>> GetAllWorkExperiencesAsync()
        {
            var workExperiences = await _workExperienceRepository.GetAllWorkExperiencesAsync();
            return _mapper.Map<IEnumerable<WorkExperienceDto>>(workExperiences);
        }

        public async Task<WorkExperienceDto> GetWorkExperienceByIdAsync(int workExperienceId)
        {
            var workExperience = await _workExperienceRepository.GetWorkExperienceByIdAsync(workExperienceId);
            return workExperience == null ? null : _mapper.Map<WorkExperienceDto>(workExperience);
        }

        public async Task<WorkExperienceDto> CreateWorkExperienceAsync(CreateWorkExperienceDto createWorkExperienceDto, int userId)
        {
            CreateWorkExperienceDto newWorkExperience = createWorkExperienceDto;
            newWorkExperience.UserId = userId;

            var workExperience = _mapper.Map<WorkExperience>(createWorkExperienceDto);
            var createdWorkExperience = await _workExperienceRepository.CreateWorkExperienceAsync(workExperience);
            return _mapper.Map<WorkExperienceDto>(createdWorkExperience);
        }

        public async Task<WorkExperienceDto> UpdateWorkExperienceAsync(int workExperienceId, UpdateWorkExperienceDto updateWorkExperienceDto)
        {
            if (workExperienceId != updateWorkExperienceDto.WorkExperienceId)
            {
                return null;
            }

            var workExperience = _mapper.Map<WorkExperience>(updateWorkExperienceDto);
            var updatedWorkExperience = await _workExperienceRepository.UpdateWorkExperienceAsync(workExperience);
            return _mapper.Map<WorkExperienceDto>(updatedWorkExperience);
        }

        public async Task<bool> DeleteWorkExperienceAsync(int workExperienceId)
        {
            return await _workExperienceRepository.DeleteWorkExperienceAsync(workExperienceId);
        }
    }
}
