using NotificationService.Models;
using System.Collections.Generic;

namespace NotificationService.Data
{
    public interface INotificationRepo 
    {
        bool SaveChanges();

        IEnumerable<Notification> GetAllNotifications();
        Notification GetNotificationById(int id);
        void CreateNotification(Notification notif);
    }
}