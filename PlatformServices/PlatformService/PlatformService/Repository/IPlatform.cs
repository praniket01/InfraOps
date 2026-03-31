using Microsoft.AspNetCore.Mvc;
using PlatformService.Dto;
using PlatformService.Entity;

namespace PlatformService.Repository
{
    public interface IPlatform
    {
        Task<IEnumerable<PlatformDto>> GetAllPlatforms();
        Task<IActionResult> AddPlatForm(Platform platform);
        Task<IActionResult> GetPlatformById(int id);

    }
}
