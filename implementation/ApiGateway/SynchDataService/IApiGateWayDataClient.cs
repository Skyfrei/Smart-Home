using ApiGateway.Dto;

namespace ApiGateway.SynchDataService
{
    public interface IApiGatewayDataClient
    {
        Task<string> GetHomeLayout();
        Task CreateNotification(NotificationReadDto readDto);
        Task CreateUser(UserReadDto userDto);
        Task CreateRoom(RoomReadDto roomDto);
        Task AddNewDevice(DeviceReadDto devicereaddto);
        Task ChangeSmartDeviceId(ChangeIds roomDto);
        Task<UserReadDto> Login(Login obj);
        Task<string> GetAllUsers();
        Task<string> GetAllDevices();
        Task<string> GetAllNotifications();
    }
}