using NotificationService.Models;

namespace NotificationService.Dtos
{
    public class NotificationPublish
    {
        public DateTime ProcTime { get; set; }

        public DeviceType Type { get; set; }
        
        public string NotificationDetails { get; set; }

        public bool Triggered { get; set; }
    }
}