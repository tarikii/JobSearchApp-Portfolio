using Swipe4Work.Domain.Models;


namespace Swipe4Work.DataTransferObject
{
    public class UserSkillDTO
    {
        public int UserSkillId { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public string? ProficiencyLevel { get; set; }
        public string? RelatedTo { get; set; }
        public int RelatedId { get; set; }

        public string? UserName { get; set; }
        public string? SkillName { get; set; }

        public UserSkillDTO(UserSkill userSkill)
        {
            UserSkillId = userSkill.UserSkillId;
            UserId = userSkill.UserId;
            SkillId = userSkill.SkillId;
            ProficiencyLevel = userSkill.ProficiencyLevel;
            RelatedTo = userSkill.RelatedTo;
            RelatedId = userSkill.RelatedId;
            UserName = userSkill.User?.UserName;
            SkillName = userSkill.Skill?.SkillName;
        }
        public UserSkillDTO() { }

    }
}
