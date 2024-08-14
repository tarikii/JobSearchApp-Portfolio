using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<WorkExperienceDTO>> GetAllWorkExperiencesAsync()
        {
            var workExperiences = await _workExperienceRepository.GetAllWorkExperiencesAsync();
            return _mapper.Map<IEnumerable<WorkExperienceDTO>>(workExperiences);
        }

        public async Task<WorkExperienceDTO> GetWorkExperienceByIdAsync(int workExperienceId)
        {
            var workExperience = await _workExperienceRepository.GetWorkExperienceByIdAsync(workExperienceId);
            return workExperience == null ? null : _mapper.Map<WorkExperienceDTO>(workExperience);
        }

        public async Task<WorkExperienceDTO> CreateWorkExperienceAsync(CreateWorkExperienceDTO createWorkExperienceDTO)
        {
            var workExperience = _mapper.Map<WorkExperience>(createWorkExperienceDTO);
            var createdWorkExperience = await _workExperienceRepository.CreateWorkExperienceAsync(workExperience);
            return _mapper.Map<WorkExperienceDTO>(createdWorkExperience);
        }

        public async Task<WorkExperienceDTO> UpdateWorkExperienceAsync(int workExperienceId, UpdateWorkExperienceDTO updateWorkExperienceDTO)
        {
            if (workExperienceId != updateWorkExperienceDTO.WorkExperienceId)
            {
                return null;
            }

            var workExperience = _mapper.Map<WorkExperience>(updateWorkExperienceDTO);
            var updatedWorkExperience = await _workExperienceRepository.UpdateWorkExperienceAsync(workExperience);
            return _mapper.Map<WorkExperienceDTO>(updatedWorkExperience);
        }

        public async Task<bool> DeleteWorkExperienceAsync(int workExperienceId)
        {
            return await _workExperienceRepository.DeleteWorkExperienceAsync(workExperienceId);
        }
    }
}
