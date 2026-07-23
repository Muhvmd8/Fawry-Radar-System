namespace QuRadarSystem.Models
{
    public class Observation
    {
        public string PlateNumber { get; set; } = default!;
        public DateTime DateTime { get; set; }
        public CarType CarType { get; set; }
        public int Speed { get; set; }
        public bool IsSeatbeltFastned { get; set; }

        public override string ToString()
             => $"PlateNumber: {PlateNumber}, DateTime: {DateTime}, CarType: {CarType}, Speed: {Speed}, Seatbelt: {IsSeatbeltFastned}";
    }
}