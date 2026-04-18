using CommandService.Models;

namespace CommandService.Repository
{
    public interface ICommandRepository
    {
        //Get all platform , create platform, check if platform exist
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
        bool PlatformExist(int platformId);

        //Get all command for a platform, get command by id, create command
        void CreateCommand(int platformId,Command command);
        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int commandId);

    }
}
