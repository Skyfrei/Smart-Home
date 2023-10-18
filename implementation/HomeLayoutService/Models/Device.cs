using System.ComponentModel.DataAnnotations;

namespace HomeLayoutService.Models
{
    public class Device
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public DeviceType Type { get; set; }

        [Required]
        public int RoomId { get; set; }

        //Needs room id

        // public List<DeviceFunction> Functions { get; set; }  // For example a lamb can have 2 effects (actions, functions). We can shut it down completely, or reduce the dimness.
    }

    public enum DeviceType
    {
        Light,
        Shower,
        Boiler,
        Window,
        Door,
    }
}