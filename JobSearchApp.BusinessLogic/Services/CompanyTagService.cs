using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
{
    public class CompanyTagService : ICompanyTagService
    {
        private readonly ICompanyTagRepository _companyTagRepository;
        private readonly IMapper _mapper;

        public CompanyTagService(ICompanyTagRepository companyRepository, IMapper mapper)
        {
            _companyTagRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyTagDto>> GetAllCompanyTagsAsync()
        {
            var companies = await _companyTagRepository.GetAllCompanyTagsAsync();
            return _mapper.Map<IEnumerable<CompanyTagDto>>(companies);
        }

        public async Task<CompanyTagDto> GetCompanyTagByIdAsync(int companyId)
        {
            var company = await _companyTagRepository.GetCompanyTagByIdAsync(companyId);
            return company == null ? null : _mapper.Map<CompanyTagDto>(company);
        }

        public async Task<CompanyTagDto> CreateCompanyTagAsync(CreateCompanyTagDto createCompanyDto)
        {
            var companyTag = _mapper.Map<CompanyTag>(createCompanyDto);
            var createdCompany = await _companyTagRepository.CreateCompanyTagAsync(companyTag);
            return _mapper.Map<CompanyTagDto>(createdCompany);
        }

        public async Task<CompanyTagDto> UpdateCompanyTagAsync(int companyId, UpdateCompanyTagDto updateCompanyDto)
        {
            if (companyId != updateCompanyDto.CompanyTagId)
            {
                return null;
            }

            var companyTag = _mapper.Map<CompanyTag>(updateCompanyDto);
            var updatedCompany = await _companyTagRepository.UpdateCompanyTagAsync(companyTag);
            return _mapper.Map<CompanyTagDto>(updatedCompany);
        }

        public async Task<bool> DeleteCompanyTagAsync(int companyId)
        {
            return await _companyTagRepository.DeleteCompanyTagAsync(companyId);
        }
    }
}
