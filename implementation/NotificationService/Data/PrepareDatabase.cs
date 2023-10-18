using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using NotificationService.Models;
using System.Timers;
using Microsoft.EntityFrameworkCore;

namespace NotificationService.Data
{
    public static class PrepareDatabase
    {
        private static System.Timers.Timer aTimer;

        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            aTimer = new System.Timers.Timer(1000);
           
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                NotificationDbContext context = serviceScope.ServiceProvider.GetService<NotificationDbContext>();
                SeedData(context, isProd);
                aTimer.Elapsed += (Object, ElapsedEventArgs) => OnTimedEvent(Object, ElapsedEventArgs, app);
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }
        }
            
            public static void SeedData(NotificationDbContext context, bool isProd)
            {

                if(isProd)
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


                if (!context.Notifications.Any())
                {
                    Console.WriteLine("Seeding data.");

                    context.Notifications.AddRange(
                        new Notification() { NotificationDetails = "Lights", ProcTime = DateTime.Now, Type = nameof(DeviceType.Light) },
                        new Notification() { NotificationDetails = "Boiler",  ProcTime = DateTime.Today, Type = nameof(DeviceType.Boiler) },
                        new Notification() { NotificationDetails = "Window",  ProcTime = DateTime.Now, Type = nameof(DeviceType.Window) }
                    );

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("We already have data.");
                }
            }

            private static void CheckForNotifications(NotificationDbContext context)
            {
                var notificationList = context.Notifications.ToList();

                for (int i = 0; i < notificationList.Count; i++)
                {
                    if (notificationList[i].ProcTime <= DateTime.Now && notificationList[i].Triggered == false)
                    {
                        notificationList[i].Triggered = true;
                        context.SaveChanges();
                    }
                }
            }

            private static void OnTimedEvent(Object source, ElapsedEventArgs e, IApplicationBuilder app)
            {
                var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<NotificationDbContext>();
                CheckForNotifications(context);
            }
    }
}