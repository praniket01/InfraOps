using Microsoft.AspNetCore.Mvc;
using PlatformService.Dto;
using PlatformService.Entity;
using PlatformService.Repository;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatform _platform;
        public PlatformController(IPlatform _platform)
        {
            this._platform = _platform;
        }

        [HttpGet]
        public async Task<IEnumerable<PlatformDto>> AllPlatform()
        {
            return await _platform.GetAllPlatforms();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await _platform.GetPlatformById(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEntry([FromBody] Platform platform)
        {
            return await _platform.AddPlatForm(platform);
        }

    }
}
