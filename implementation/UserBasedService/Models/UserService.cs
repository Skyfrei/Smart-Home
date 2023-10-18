using System.ComponentModel.DataAnnotations;
namespace UserBased.Models
{
    public class UserService
    {
        
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public DateTime ProcTime { get; set; }

        [Required]
        public string NotificationDetails { get; set; }

        [Required]
        public string Type { get; set; }
    }
}