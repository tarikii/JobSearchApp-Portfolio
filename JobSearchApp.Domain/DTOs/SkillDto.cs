using JobSearchApp.Domain.Models;

namespace JobSearchApp.Domain.DTOs
{
    public class SkillDto
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillType { get; set; }

        public SkillDto(Skill skill)
        {
            SkillId = skill.SkillId;
            SkillName = skill.SkillName;
            SkillType = skill.SkillType;
        }
    }
}