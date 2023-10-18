using System.ComponentModel.DataAnnotations;
using HomeLayoutService.Models;

namespace HomeLayoutService.Dto
{
    public class RoomCreateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int SmartDeviceId { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}