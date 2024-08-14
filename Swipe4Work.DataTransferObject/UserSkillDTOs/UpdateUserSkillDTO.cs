namespace Swipe4Work.DataTransferObject
{
    public class UpdateUserSkillDTO
    {
        public int UserSkillId { get; set; }

        public string? ProficiencyLevel { get; set; }
        public string? RelatedTo { get; set; }
        public int RelatedId { get; set; }
    }
}
