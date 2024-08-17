using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
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

        public async Task<IEnumerable<EducationDto>> GetAllEducationsAsync()
        {
            var educations = await _educationRepository.GetAllEducationsAsync();
            return _mapper.Map<IEnumerable<EducationDto>>(educations);
        }

        public async Task<EducationDto> GetEducationByIdAsync(int educationId)
        {
            var education = await _educationRepository.GetEducationByIdAsync(educationId);
            return education == null ? null : _mapper.Map<EducationDto>(education);
        }

        public async Task<EducationDto> CreateEducationAsync(CreateEducationDto createEducationDto, int userId)
        {
            CreateEducationDto newEducation = createEducationDto;
            newEducation.UserId = userId;

            var education = _mapper.Map<Education>(newEducation);
            var createdEducation = await _educationRepository.CreateEducationAsync(education);
            return _mapper.Map<EducationDto>(createdEducation);
        }

        public async Task<EducationDto> UpdateEducationAsync(int educationId, UpdateEducationDto updateEducationDto)
        {
            if (educationId != updateEducationDto.EducationId)
            {
                return null;
            }

            var education = _mapper.Map<Education>(updateEducationDto);
            var updatedEducation = await _educationRepository.UpdateEducationAsync(education);
            return _mapper.Map<EducationDto>(updatedEducation);
        }

        public async Task<bool> DeleteEducationAsync(int educationId)
        {
            return await _educationRepository.DeleteEducationAsync(educationId);
        }
    }
}
