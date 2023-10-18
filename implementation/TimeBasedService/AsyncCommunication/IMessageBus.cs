using TimeBasedService.DataTransferObject;

namespace TimeBasedService.AsyncCommunication
{
    public interface IMessageBus
    {
        public void PublishUSer(TimeBasedServicePublish servicePublish);
    }
}