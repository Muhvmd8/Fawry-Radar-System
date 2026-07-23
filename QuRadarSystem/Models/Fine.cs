namespace QuRadarSystem.Models
{
    public class Fine
    {
        public string PlateNumber { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public List<Violation> Violations { get; set; } = [];
    }
}
