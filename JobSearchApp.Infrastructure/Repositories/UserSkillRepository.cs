using System.Collections.Generic;
using System.Threading.Tasks;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Data;
using JobSearchApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.Infrastructure.Repositories
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
            return await _context.UserSkills
                .Include(us => us.Skill)
                .ToListAsync();
        }

        public async Task<UserSkill> GetUserSkillByIdAsync(int userSkillId)
        {
            return await _context.UserSkills
                .Include(us => us.Skill)
                .FirstOrDefaultAsync(us => us.UserSkillId == userSkillId);
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