using System.ComponentModel.DataAnnotations;

namespace TimeBasedService.DataTransferObject
{
    public class TimeBasedServiceCreateDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }
    }
}