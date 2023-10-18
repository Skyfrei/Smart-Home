using HomeLayoutService.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeLayoutService.Data
{
    public class HomeLayoutDbContext : DbContext
    {
        public HomeLayoutDbContext(DbContextOptions<HomeLayoutDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
