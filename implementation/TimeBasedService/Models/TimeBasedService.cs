using System.ComponentModel.DataAnnotations;
namespace TimeBasedService.Models
{
    public class BaseService
    {
        
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }
    }
}