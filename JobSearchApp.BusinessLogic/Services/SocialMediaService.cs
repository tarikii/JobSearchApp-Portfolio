using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
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

        public async Task<IEnumerable<SocialMediaDto>> GetAllSocialMediasAsync()
        {
            var socialMedias = await _socialMediaRepository.GetAllSocialMediasAsync();
            return _mapper.Map<IEnumerable<SocialMediaDto>>(socialMedias);
        }

        public async Task<SocialMediaDto> GetSocialMediaByIdAsync(int socialMediaId)
        {
            var socialMedia = await _socialMediaRepository.GetSocialMediaByIdAsync(socialMediaId);
            return socialMedia == null ? null : _mapper.Map<SocialMediaDto>(socialMedia);
        }

        public async Task<SocialMediaDto> CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto)
        {
            var socialMedia = _mapper.Map<SocialMedia>(createSocialMediaDto);
            var createdSocialMedia = await _socialMediaRepository.CreateSocialMediaAsync(socialMedia);
            return _mapper.Map<SocialMediaDto>(createdSocialMedia);
        }

        public async Task<SocialMediaDto> UpdateSocialMediaAsync(int socialMediaId, UpdateSocialMediaDto updateSocialMediaDto)
        {
            if (socialMediaId != updateSocialMediaDto.SocialMediaId)
            {
                return null;
            }

            var socialMedia = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            var updatedSocialMedia = await _socialMediaRepository.UpdateSocialMediaAsync(socialMedia);
            return _mapper.Map<SocialMediaDto>(updatedSocialMedia);
        }

        public async Task<bool> DeleteSocialMediaAsync(int socialMediaId)
        {
            return await _socialMediaRepository.DeleteSocialMediaAsync(socialMediaId);
        }
    }
}
