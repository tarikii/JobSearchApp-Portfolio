using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;
namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<MatchDTO>> GetAllMatchesAsync()
        {
            var matches = await _matchRepository.GetAllMatchesAsync();
            return _mapper.Map<IEnumerable<MatchDTO>>(matches);
        }

        public async Task<MatchDTO> GetMatchByIdAsync(int matchId)
        {
            var match = await _matchRepository.GetMatchByIdAsync(matchId);
            return match == null ? null : _mapper.Map<MatchDTO>(match);
        }

        public async Task<MatchDTO> CreateMatchAsync(CreateMatchDTO createMatchDTO)
        {
            var match = _mapper.Map<Match>(createMatchDTO);
            var createdMatch = await _matchRepository.CreateMatchAsync(match);
            return _mapper.Map<MatchDTO>(createdMatch);
        }

        public async Task<MatchDTO> UpdateMatchAsync(int matchId, UpdateMatchDTO updateMatchDTO)
        {
            if (matchId != updateMatchDTO.MatchId)
            {
                return null;
            }

            var match = _mapper.Map<Match>(updateMatchDTO);
            var updatedMatch = await _matchRepository.UpdateMatchAsync(match);
            return _mapper.Map<MatchDTO>(updatedMatch);
        }

        public async Task<bool> DeleteMatchAsync(int matchId)
        {
            return await _matchRepository.DeleteMatchAsync(matchId);
        }
    }
}