namespace sistemaLaserAPI.Models
{
    public class Incident
    {
        public int id { get; set; }
        public string? deviceId { get; set; } = string.Empty;
        public int? counter { get; set; }
        public int? signalValue { get; set; }
        public DateTime? detectionDate { get; set; }
        public DateTime? created { get; set; } = DateTime.UtcNow;
    }
}
