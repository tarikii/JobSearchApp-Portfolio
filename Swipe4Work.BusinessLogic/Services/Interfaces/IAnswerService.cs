using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IAnswerService
{
    Task<IEnumerable<AnswerDTO>> GetAllAnswersAsync();
    Task<AnswerDTO> GetAnswerByIdAsync(int answerId);
    Task<AnswerDTO> CreateAnswerAsync(CreateAnswerDTO createAnswerDTO);
    Task<AnswerDTO> UpdateAnswerAsync(int answerId, UpdateAnswerDTO updateAnswerDTO);
    Task<bool> DeleteAnswerAsync(int answerId);
}