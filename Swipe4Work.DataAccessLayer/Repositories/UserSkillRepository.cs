using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;

namespace Swipe4Work.DataAccessLayer
{
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly ApplicationDbContext _context;

        public UserSkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserSkill>> GetAllUserSkillsAsync()
        {
            return await _context.UserSkills.ToListAsync();
        }

        public async Task<UserSkill> GetUserSkillByIdAsync(int userSkillId)
        {
            return await _context.UserSkills.FindAsync(userSkillId);
        }

        public async Task<UserSkill> CreateUserSkillAsync(UserSkill userSkill)
        {
            _context.UserSkills.Add(userSkill);
            await _context.SaveChangesAsync();
            return userSkill;
        }

        public async Task<UserSkill> UpdateUserSkillAsync(UserSkill userSkill)
        {
            _context.UserSkills.Update(userSkill);
            await _context.SaveChangesAsync();
            return userSkill;
        }

        public async Task<bool> DeleteUserSkillAsync(int userSkillId)
        {
            var userSkill = await _context.UserSkills.FindAsync(userSkillId);
            if (userSkill == null)
            {
                return false;
            }

            _context.UserSkills.Remove(userSkill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}