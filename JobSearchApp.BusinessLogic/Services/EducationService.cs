using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.BusinessLogic.Services
{
    public class EducationService : IEducationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EducationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EducationDto>> GetAllEducationsAsync()
        {
            var educations = await _context.Educations.ToListAsync();
            return _mapper.Map<IEnumerable<EducationDto>>(educations);
        }

        public async Task<EducationDto> GetEducationByIdAsync(int educationId)
        {
            var education = await _context.Educations.FindAsync(educationId);
            return education == null ? null : _mapper.Map<EducationDto>(education);
        }

        public async Task<EducationDto> CreateEducationAsync(CreateEducationDto createEducationDto)
        {
            var education = _mapper.Map<Education>(createEducationDto);
            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
            return _mapper.Map<EducationDto>(education);
        }

        public async Task<EducationDto> UpdateEducationAsync(int educationId, UpdateEducationDto updateEducationDto)
        {
            if (educationId != updateEducationDto.EducationId)
            {
                return null;
            }

            var education = _mapper.Map<Education>(updateEducationDto);
            _context.Educations.Update(education);
            await _context.SaveChangesAsync();
            return _mapper.Map<EducationDto>(education);
        }

        public async Task<bool> DeleteEducationAsync(int educationId)
        {
            var education = await _context.Educations.FindAsync(educationId);
            if (education == null)
            {
                return false;
            }

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
