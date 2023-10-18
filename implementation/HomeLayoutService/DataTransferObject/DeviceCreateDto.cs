using System.ComponentModel.DataAnnotations;

namespace HomeLayoutService.Dto
{
    public class DeviceCreateDto
    {
        [Required]
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int Type { get; set; }

        [Required]
        public int RoomId { get; set; }
    }
}