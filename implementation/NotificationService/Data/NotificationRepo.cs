using NotificationService.Models;

namespace NotificationService.Data
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly NotificationDbContext _context;
        
        public NotificationRepo (NotificationDbContext context)
        {
            _context = context;
        }

        public void CreateNotification(Notification notif)
        {
            if (notif == null)
            {
                throw new ArgumentNullException(nameof(notif));
            }

            _context.Notifications.Add(notif);
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return _context.Notifications.ToList();
        }

        public Notification GetNotificationById(int id)
        {
            return _context.Notifications.FirstOrDefault(n => n.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}