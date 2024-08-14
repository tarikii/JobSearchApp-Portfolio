namespace Swipe4Work.Domain.Models
{
    public class UserSkill
    {
        public int UserSkillId { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public string? ProficiencyLevel { get; set; }
        public string? RelatedTo { get; set; }
        public int RelatedId { get; set; }

        public User? User { get; set; }
        public Skill? Skill { get; set; }
    }
}
