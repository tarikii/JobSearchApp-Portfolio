
namespace Swipe4Work.DataTransferObject
{
    public class UpdateUserPreferenceDTO
    {
        public int PreferenceId { get; set; }

        public string? Category { get; set; }
        public string? Value { get; set; }
    }
}
