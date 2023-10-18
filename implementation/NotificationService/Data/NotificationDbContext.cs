using NotificationService.Models;
using Microsoft.EntityFrameworkCore;

namespace NotificationService.Data
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Notification> Notifications { get; set; }
    }
}