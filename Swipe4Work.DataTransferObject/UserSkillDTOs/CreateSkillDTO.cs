
namespace Swipe4Work.DataTransferObject
{
    public class CreateUserSkillDTO
    {
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public string? ProficiencyLevel { get; set; }
        public string? RelatedTo { get; set; }
        public int RelatedId { get; set; }
    }
}
