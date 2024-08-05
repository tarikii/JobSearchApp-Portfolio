using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllCompaniesAsync();
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public async Task<CompanyDto> GetCompanyByIdAsync(int companyId)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(companyId);
            return company == null ? null : _mapper.Map<CompanyDto>(company);
        }

        public async Task<CompanyDto> CreateCompanyAsync(CreateCompanyDto createCompanyDto)
        {
            var company = _mapper.Map<Company>(createCompanyDto);
            var createdCompany = await _companyRepository.CreateCompanyAsync(company);
            return _mapper.Map<CompanyDto>(createdCompany);
        }

        public async Task<CompanyDto> UpdateCompanyAsync(int companyId, UpdateCompanyDto updateCompanyDto)
        {
            if (companyId != updateCompanyDto.CompanyId)
            {
                return null;
            }

            var company = _mapper.Map<Company>(updateCompanyDto);
            var updatedCompany = await _companyRepository.UpdateCompanyAsync(company);
            return _mapper.Map<CompanyDto>(updatedCompany);
        }

        public async Task<bool> DeleteCompanyAsync(int companyId)
        {
            return await _companyRepository.DeleteCompanyAsync(companyId);
        }
    }
}
