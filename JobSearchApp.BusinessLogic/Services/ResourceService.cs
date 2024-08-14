using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;

        public ResourceService(IResourceRepository resourceRepository, IMapper mapper)
        {
            _resourceRepository = resourceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResourceDto>> GetAllResourcesAsync()
        {
            var resources = await _resourceRepository.GetAllResourcesAsync();
            return _mapper.Map<IEnumerable<ResourceDto>>(resources);
        }

        public async Task<ResourceDto> GetResourceByIdAsync(int resourceId)
        {
            var resource = await _resourceRepository.GetResourceByIdAsync(resourceId);
            return resource == null ? null : _mapper.Map<ResourceDto>(resource);
        }

        public async Task<ResourceDto> CreateResourceAsync(CreateResourceDto createResourceDto)
        {
            var resource = _mapper.Map<Resource>(createResourceDto);
            var createdResource = await _resourceRepository.CreateResourceAsync(resource);
            return _mapper.Map<ResourceDto>(createdResource);
        }

        public async Task<ResourceDto> UpdateResourceAsync(int resourceId, UpdateResourceDto updateResourceDto)
        {
            if (resourceId != updateResourceDto.ResourceId)
            {
                return null;
            }

            var resource = _mapper.Map<Resource>(updateResourceDto);
            var updatedResource = await _resourceRepository.UpdateResourceAsync(resource);
            return _mapper.Map<ResourceDto>(updatedResource);
        }

        public async Task<bool> DeleteResourceAsync(int resourceId)
        {
            return await _resourceRepository.DeleteResourceAsync(resourceId);
        }
    }
}
