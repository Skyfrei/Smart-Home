using System.ComponentModel.DataAnnotations;

namespace HomeLayoutService.Models
{
    public class SmartDevice
    {
        [Key]
        [Required]
        public int Id { get; set; }

    }
}