using HomeLayoutService.Models;

namespace HomeLayoutService.Data
{
    public class HomeLayoutRepo : IHomeLayoutRepo
    {
        private readonly HomeLayoutDbContext _context;

        public HomeLayoutRepo(HomeLayoutDbContext context)
        {
            _context = context;
        }

        public void GetDevice(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _context.Devices.ToList();
        }

        public void CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
        }

        public List<Room> GetRooms()
        {
            // return _context.Rooms.ToArray();
            return _context.Rooms.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Room GetRoomById(int id)
        {
            return _context.Rooms.FirstOrDefault(r => r.Id == id);
        }

        public void ChangeRoomSmartDevice(int roomId, int deviceId)
        {
            var room = GetRoomById(roomId);
            room.SmartDeviceId = deviceId;
            SaveChanges();
        }

        public void CreateNewDevcie(Device device)
        {
            _context.Devices.Add(device);
        }
    }
}