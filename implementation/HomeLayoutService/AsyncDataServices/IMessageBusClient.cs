using HomeLayoutService.Dto;

namespace HomeLayoutService.AsyncDataService
{
    public interface IMessageBusClient
    {
        void PublishNewRoom(RoomPublishedDto roomDto);
        
    }
}