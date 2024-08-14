using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;

namespace Swipe4Work.DataAccessLayer
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public AnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersAsync()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task<Answer> GetAnswerByIdAsync(int answerId)
        {
            return await _context.Answers.FindAsync(answerId);
        }

        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<Answer> UpdateAnswerAsync(Answer answer)
        {
            _context.Answers.Update(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<bool> DeleteAnswerAsync(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);
            if (answer == null)
            {
                return false;
            }

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}