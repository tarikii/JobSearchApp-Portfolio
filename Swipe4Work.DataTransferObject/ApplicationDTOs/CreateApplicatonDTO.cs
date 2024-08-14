namespace Swipe4Work.DataTransferObject
{
    public class CreateApplicationDTO
    {
        public int UserId { get; set; }
        public int JobOfferId { get; set; }
        public DateTimeOffset ApplicationDate { get; set; } = DateTimeOffset.Now;
        public string Status { get; set; } = "Pending";
        public decimal SalaryExpected { get; set; }
    }
}
