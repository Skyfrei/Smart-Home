using PrivilegeService.Models;
using Microsoft.EntityFrameworkCore;

namespace PrivilegeService.Data
{
    public class PrivilegeDataContext : DbContext
    {
        public PrivilegeDataContext(DbContextOptions<PrivilegeDataContext> opt) : base(opt)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Privilege>()
                .HasIndex(e => e.Email)
                .IsUnique(true);
            modelBuilder.Entity<Privilege>()
                .HasIndex(u => u.Username)
                .IsUnique(true);
        }

        public DbSet<Privilege> Users { get; set; }
    }

}