using NotificationService.Dtos;

namespace NotificationService.SynchDataService.Http
{
    public interface INotificationDataClient
    {
        Task SendNotificationToHomeLayout(NotificationReadDto notifReadDto);
    }
}