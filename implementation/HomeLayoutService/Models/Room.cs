using System.ComponentModel.DataAnnotations;

namespace HomeLayoutService.Models
{
    public class Room
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SmartDeviceId { get; set; }
    }
}