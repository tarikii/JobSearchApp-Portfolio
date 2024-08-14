using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;


namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<CompanyDTO>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllCompaniesAsync();
            return _mapper.Map<IEnumerable<CompanyDTO>>(companies);
        }

        public async Task<CompanyDTO> GetCompanyByIdAsync(int companyId)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(companyId);
            return company == null ? null : _mapper.Map<CompanyDTO>(company);
        }

        public async Task<CompanyDTO> CreateCompanyAsync(CreateCompanyDTO createCompanyDTO)
        {
            var company = _mapper.Map<Company>(createCompanyDTO);
            var createdCompany = await _companyRepository.CreateCompanyAsync(company);
            return _mapper.Map<CompanyDTO>(createdCompany);
        }

        public async Task<CompanyDTO> UpdateCompanyAsync(int companyId, UpdateCompanyDTO updateCompanyDTO)
        {
            if (companyId != updateCompanyDTO.CompanyId)
            {
                return null;
            }

            var company = _mapper.Map<Company>(updateCompanyDTO);
            var updatedCompany = await _companyRepository.UpdateCompanyAsync(company);
            return _mapper.Map<CompanyDTO>(updatedCompany);
        }

        public async Task<bool> DeleteCompanyAsync(int companyId)
        {
            return await _companyRepository.DeleteCompanyAsync(companyId);
        }
    }
}
