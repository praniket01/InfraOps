using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PlatformService.Dto;
using PlatformService.Entity;

namespace PlatformService.Conversion
{
    public static class Conversion
    {
        public static PlatformDto ToDto(Platform platform)
        {
            return new PlatformDto
            {
                Id = platform.Id,
                Name = platform.Name,
                Publisher = platform.Publisher,
                Cost = platform.Cost
            };
        }

        public static Platform ToEntity(PlatformDto platformDto)
        {
            return new Platform
            {
                Id = platformDto.Id,
                Name = platformDto.Name,
                Publisher = platformDto.Publisher,
                Cost = platformDto.Cost
            };
        }
    }
}
