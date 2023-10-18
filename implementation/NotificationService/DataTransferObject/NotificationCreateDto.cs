using System.ComponentModel.DataAnnotations;
using NotificationService.Models;

namespace NotificationService.Dtos
{
    public class NotificationCreateDto
    {
        [Required]
        public DateTime ProcTime { get; set; }

        [Required]
        public string NotificationDetails { get; set; }

        [Required]
        public string Type { get; set; }
        
        public bool Triggered = false;
    }
}