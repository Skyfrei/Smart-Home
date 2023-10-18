using HomeLayoutService.Models;

namespace HomeLayoutService.Data
{
    public interface IHomeLayoutRepo
    {
        bool SaveChanges();

        List<Room> GetRooms();
        IEnumerable<Device> GetAllDevices();
        void CreateRoom(Room room);
        void CreateNewDevcie(Device device);
        Room GetRoomById(int id);
        void ChangeRoomSmartDevice(int roomId, int deviceId);
        void GetDevice(int id);
    }
}