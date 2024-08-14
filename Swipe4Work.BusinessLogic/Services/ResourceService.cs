using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<ResourceDTO>> GetAllResourcesAsync()
        {
            var resources = await _resourceRepository.GetAllResourcesAsync();
            return _mapper.Map<IEnumerable<ResourceDTO>>(resources);
        }

        public async Task<ResourceDTO> GetResourceByIdAsync(int resourceId)
        {
            var resource = await _resourceRepository.GetResourceByIdAsync(resourceId);
            return resource == null ? null : _mapper.Map<ResourceDTO>(resource);
        }

        public async Task<ResourceDTO> CreateResourceAsync(CreateResourceDTO createResourceDTO)
        {
            var resource = _mapper.Map<Resource>(createResourceDTO);
            var createdResource = await _resourceRepository.CreateResourceAsync(resource);
            return _mapper.Map<ResourceDTO>(createdResource);
        }

        public async Task<ResourceDTO> UpdateResourceAsync(int resourceId, UpdateResourceDTO updateResourceDTO)
        {
            if (resourceId != updateResourceDTO.ResourceId)
            {
                return null;
            }

            var resource = _mapper.Map<Resource>(updateResourceDTO);
            var updatedResource = await _resourceRepository.UpdateResourceAsync(resource);
            return _mapper.Map<ResourceDTO>(updatedResource);
        }

        public async Task<bool> DeleteResourceAsync(int resourceId)
        {
            return await _resourceRepository.DeleteResourceAsync(resourceId);
        }
    }
}
