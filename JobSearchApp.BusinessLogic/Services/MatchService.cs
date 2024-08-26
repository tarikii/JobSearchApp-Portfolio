using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatchDto>> GetAllMatchesAsync()
        {
            var matches = await _matchRepository.GetAllMatchesAsync();
            return _mapper.Map<IEnumerable<MatchDto>>(matches);
        }

        public async Task<MatchDto> GetMatchByIdAsync(int matchId)
        {
            var match = await _matchRepository.GetMatchByIdAsync(matchId);
            return match == null ? null : _mapper.Map<MatchDto>(match);
        }

        public async Task<MatchDto> CreateMatchAsync(CreateMatchDto createMatchDto)
        {
            var match = _mapper.Map<Match>(createMatchDto);
            var createdMatch = await _matchRepository.CreateMatchAsync(match);
            return _mapper.Map<MatchDto>(createdMatch);
        }

        public async Task<MatchDto> UpdateMatchAsync(int matchId, MatchDto updateMatchDto)
        {
            var match = await _matchRepository.GetMatchByIdAsync(matchId);

            if (matchId != updateMatchDto.MatchId)
            {
                return null;
            }

            match.IsAccepted = updateMatchDto.IsAccepted;

            var updatedMatch = await _matchRepository.UpdateMatchAsync(match);
            return _mapper.Map<MatchDto>(updatedMatch);
        }

        public async Task<bool> DeleteMatchAsync(int matchId)
        {
            return await _matchRepository.DeleteMatchAsync(matchId);
        }
    }
}