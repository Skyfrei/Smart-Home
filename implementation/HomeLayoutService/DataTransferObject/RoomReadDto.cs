using HomeLayoutService.Models;

namespace HomeLayoutService.Dto
{
    public class RoomReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SmartDeviceId { get; set; }
    }
}