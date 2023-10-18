using NotificationService.Dtos;

namespace NotificationService.AsyncCommunication
{
    public interface IMessageBus
    {
        public void PublishNotification(NotificationPublish publishNotification);
    }
}