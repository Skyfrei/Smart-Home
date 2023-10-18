using Microsoft.EntityFrameworkCore;

namespace PrivilegeService.Data
{
    public static class PrepDatabase
    {

        public static void PrepPopulation(IApplicationBuilder app)
        {
           
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                PrivilegeDataContext context = serviceScope.ServiceProvider.GetService<PrivilegeDataContext>();
                SeedData(context);
            }
        }
            
        public static void SeedData(PrivilegeDataContext context)
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