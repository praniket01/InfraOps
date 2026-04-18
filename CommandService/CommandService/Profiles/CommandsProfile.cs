
using AutoMapper;
using CommandService.DTO;
using CommandService.Models;

namespace CommandService.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command,CommandReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
            CreateMap<Platform, PlatformReadDTO>();
        }
    }
}
