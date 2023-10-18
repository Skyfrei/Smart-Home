namespace NotificationService.Models
{
    public static class Preferences
    {
        private static List<DeviceType> deviceTypes = new List<DeviceType>();
    }
    
    public enum DeviceType
    {
        Light,
        Boiler,
        Door,
        Water,
        Microwave,
        Heater,
        UserActivity,
        Window,
    }
}