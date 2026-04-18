using CommandService.Data;
using CommandService.Models;

namespace CommandService.Repository.Impl
{
    public class CommandRepository : ICommandRepository
    {
        public readonly CommandDBContext _context;
        public CommandRepository(CommandDBContext _context)
        { 
            this._context = _context;
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            try
            {
                return _context.Platforms.ToList();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {nameof(GetAllPlatforms)}: {ex.Message}");
                return Enumerable.Empty<Platform>();
            }
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _context.Platforms.Add(platform);
            _context.SaveChanges();
        }

        public bool PlatformExist(int platformId)
        {
            return _context.Platforms.Any(p => p.ID == platformId);
        }

        public void CreateCommand(int platformId,Command command)
        {
            try
            {
                if(command == null)
                {
                    throw new ArgumentNullException(nameof(command));
                }
                command.PlatformId = platformId;
                _context.Commands.Add(command);
            }
            catch (Exception ex)
            {
               throw new Exception($"Error in CreateCommand : {ex.Message}");
            }
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            try
            {
                return _context.Commands.Where(c => c.PlatformId == platformId).ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Command>();
            }
        }

        public Command GetCommand(int platformId, int commandId)
        {
            try
            {
                return _context.Commands.FirstOrDefault(c => c.PlatformId == platformId && c.Id == commandId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
