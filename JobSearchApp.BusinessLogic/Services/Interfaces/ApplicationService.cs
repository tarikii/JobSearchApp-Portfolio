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
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ApplicationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationDto>> GetAllApplicationsAsync()
        {
            var applications = await _context.Applications.ToListAsync();
            return _mapper.Map<IEnumerable<ApplicationDto>>(applications);
        }

        public async Task<ApplicationDto> GetApplicationByIdAsync(int applicationId)
        {
            var application = await _context.Applications.FindAsync(applicationId);
            return application == null ? null : _mapper.Map<ApplicationDto>(application);
        }

        public async Task<ApplicationDto> CreateApplicationAsync(CreateApplicationDto createApplicationDto)
        {
            var application = _mapper.Map<Application>(createApplicationDto);
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return _mapper.Map<ApplicationDto>(application);
        }

        public async Task<ApplicationDto> UpdateApplicationAsync(int applicationId, UpdateApplicationDto updateApplicationDto)
        {
            if (applicationId != updateApplicationDto.ApplicationId)
            {
                return null;
            }

            var application = _mapper.Map<Application>(updateApplicationDto);
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
            return _mapper.Map<ApplicationDto>(application);
        }

        public async Task<bool> DeleteApplicationAsync(int applicationId)
        {
            var application = await _context.Applications.FindAsync(applicationId);
            if (application == null)
            {
                return false;
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
