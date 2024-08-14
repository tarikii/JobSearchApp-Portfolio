using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public EducationService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EducationDTO>> GetAllEducationsAsync()
        {
            var educations = await _educationRepository.GetAllEducationsAsync();
            return _mapper.Map<IEnumerable<EducationDTO>>(educations);
        }

        public async Task<EducationDTO> GetEducationByIdAsync(int educationId)
        {
            var education = await _educationRepository.GetEducationByIdAsync(educationId);
            return education == null ? null : _mapper.Map<EducationDTO>(education);
        }

        public async Task<EducationDTO> CreateEducationAsync(CreateEducationDTO createEducationDTO)
        {
            var education = _mapper.Map<Education>(createEducationDTO);
            var createdEducation = await _educationRepository.CreateEducationAsync(education);
            return _mapper.Map<EducationDTO>(createdEducation);
        }

        public async Task<EducationDTO> UpdateEducationAsync(int educationId, UpdateEducationDTO updateEducationDTO)
        {
            if (educationId != updateEducationDTO.EducationId)
            {
                return null;
            }

            var education = _mapper.Map<Education>(updateEducationDTO);
            var updatedEducation = await _educationRepository.UpdateEducationAsync(education);
            return _mapper.Map<EducationDTO>(updatedEducation);
        }

        public async Task<bool> DeleteEducationAsync(int educationId)
        {
            return await _educationRepository.DeleteEducationAsync(educationId);
        }
    }
}
