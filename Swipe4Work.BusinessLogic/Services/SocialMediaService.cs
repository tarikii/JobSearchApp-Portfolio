using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;

        public SocialMediaService(ISocialMediaRepository socialMediaRepository, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SocialMediaDTO>> GetAllSocialMediasAsync()
        {
            var socialMedias = await _socialMediaRepository.GetAllSocialMediasAsync();
            return _mapper.Map<IEnumerable<SocialMediaDTO>>(socialMedias);
        }

        public async Task<SocialMediaDTO> GetSocialMediaByIdAsync(int socialMediaId)
        {
            var socialMedia = await _socialMediaRepository.GetSocialMediaByIdAsync(socialMediaId);
            return socialMedia == null ? null : _mapper.Map<SocialMediaDTO>(socialMedia);
        }

        public async Task<SocialMediaDTO> CreateSocialMediaAsync(CreateSocialMediaDTO createSocialMediaDTO)
        {
            var socialMedia = _mapper.Map<SocialMedia>(createSocialMediaDTO);
            var createdSocialMedia = await _socialMediaRepository.CreateSocialMediaAsync(socialMedia);
            return _mapper.Map<SocialMediaDTO>(createdSocialMedia);
        }

        public async Task<SocialMediaDTO> UpdateSocialMediaAsync(int socialMediaId, UpdateSocialMediaDTO updateSocialMediaDTO)
        {
            if (socialMediaId != updateSocialMediaDTO.SocialMediaId)
            {
                return null;
            }

            var socialMedia = _mapper.Map<SocialMedia>(updateSocialMediaDTO);
            var updatedSocialMedia = await _socialMediaRepository.UpdateSocialMediaAsync(socialMedia);
            return _mapper.Map<SocialMediaDTO>(updatedSocialMedia);
        }

        public async Task<bool> DeleteSocialMediaAsync(int socialMediaId)
        {
            return await _socialMediaRepository.DeleteSocialMediaAsync(socialMediaId);
        }
    }
}
