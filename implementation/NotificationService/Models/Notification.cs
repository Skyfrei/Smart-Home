using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class Notification
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

        [Required]
        public bool Triggered { get; set; }
    }
}