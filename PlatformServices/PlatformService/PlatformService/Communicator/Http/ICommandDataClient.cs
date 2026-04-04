using PlatformService.Dto;

namespace PlatformService.Communicator.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformDto plat);
    }
}
