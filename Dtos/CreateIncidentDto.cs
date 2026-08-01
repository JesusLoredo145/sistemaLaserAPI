using System.ComponentModel.DataAnnotations;
namespace sistemaLaserAPI.Dtos
{
    public class CreateIncidentDto
    {
        [Required]
        [MaxLength(50)]
        public string deviceId { get; set; } = string.Empty;
        [Required]
        public int counter { get; set; }
        [Required]
        public int signalValue { get; set; }
        [Required]
        public DateTime detectionDate { get; set; }
    }
}
