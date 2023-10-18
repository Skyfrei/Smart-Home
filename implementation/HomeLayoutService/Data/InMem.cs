using HomeLayoutService.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeLayoutService.Data
{
    public static class InMem 
    {
        public static void PrepDb(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<HomeLayoutDbContext>());
            }
        }

        public static void SeedData(HomeLayoutDbContext context)
        {
            Console.WriteLine("--> Attempting to apply migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not run migrations: {ex.Message}");
            }
        }
    }
}