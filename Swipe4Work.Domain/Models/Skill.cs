namespace Swipe4Work.Domain.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillType { get; set; }

        public ICollection<UserSkill>? UserSkills { get; set; }
    }
}
