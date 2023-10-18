using PrivilegeService.Dto;

namespace PrivilegeService.AsyncCommunication
{
    public interface IMessageBus
    {
        public void PublishUSer(PrivilegePublish privilegePublish);
    }
}