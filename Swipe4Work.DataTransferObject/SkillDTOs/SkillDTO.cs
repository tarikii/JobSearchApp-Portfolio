using Swipe4Work.Domain.Models;


namespace Swipe4Work.DataTransferObject
{
    public class SkillDTO
    {
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillType { get; set; }

        //public SkillDTO(Skill skill)
        //{
        //    SkillId = skill.SkillId;
        //    SkillName = skill.SkillName;
        //    SkillType = skill.SkillType;
        //}
        //public SkillDTO() { }

    }
}
