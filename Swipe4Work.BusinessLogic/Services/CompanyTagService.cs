using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<CompanyTagDTO>> GetAllCompanyTagsAsync()
        {
            var companies = await _companyTagRepository.GetAllCompanyTagsAsync();
            return _mapper.Map<IEnumerable<CompanyTagDTO>>(companies);
        }

        public async Task<CompanyTagDTO> GetCompanyTagByIdAsync(int companyId)
        {
            var company = await _companyTagRepository.GetCompanyTagByIdAsync(companyId);
            return company == null ? null : _mapper.Map<CompanyTagDTO>(company);
        }

        public async Task<CompanyTagDTO> CreateCompanyTagAsync(CreateCompanyTagDTO createCompanyDTO)
        {
            var companyTag = _mapper.Map<CompanyTag>(createCompanyDTO);
            var createdCompany = await _companyTagRepository.CreateCompanyTagAsync(companyTag);
            return _mapper.Map<CompanyTagDTO>(createdCompany);
        }

        public async Task<CompanyTagDTO> UpdateCompanyTagAsync(int companyId, UpdateCompanyTagDTO updateCompanyDTO)
        {
            if (companyId != updateCompanyDTO.CompanyTagId)
            {
                return null;
            }

            var companyTag = _mapper.Map<CompanyTag>(updateCompanyDTO);
            var updatedCompany = await _companyTagRepository.UpdateCompanyTagAsync(companyTag);
            return _mapper.Map<CompanyTagDTO>(updatedCompany);
        }

        public async Task<bool> DeleteCompanyTagAsync(int companyId)
        {
            return await _companyTagRepository.DeleteCompanyTagAsync(companyId);
        }
    }
}
