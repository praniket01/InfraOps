using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Dto;
using PlatformService.Entity;

namespace PlatformService.Repository.Impl
{
    public class PlatformRepo : IPlatform
    {
        private readonly PlatformDbContext _context;
        public PlatformRepo(PlatformDbContext _context)
        {
            this._context = _context;
        }
        public async Task<IActionResult> AddPlatForm(Platform platform)
        {
            try
            {
               var ifExists = _context.Platform.Where(p => p.Name == platform.Name).FirstOrDefault();
                if (ifExists != null)
                {
                    return new BadRequestObjectResult("Platform already exists");
                }
                var AddedPlatform = await _context.Platform.AddAsync(platform);
                await _context.SaveChangesAsync();
                return new OkObjectResult("Platform Added Successfully");
            }
            catch
            {
                return new BadRequestObjectResult("Error while adding platform");
            }
        }

        public async Task<IEnumerable<PlatformDto>> GetAllPlatforms()
        {
            try
            {
                var platforms = await _context.Platform.ToListAsync();
                var platFormsDto = platforms.Select(p => Conversion.Conversion.ToDto(p)).ToList();
                return platFormsDto;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IActionResult> GetPlatformById(int id)
        {
            try
            {
                var PlatfromExist = await _context.Platform.Where(p => p.Id == id).FirstOrDefaultAsync();
                if(PlatfromExist == null)
                {
                    return new NotFoundObjectResult("Platform not found");
                }
                PlatformDto platformDto = Conversion.Conversion.ToDto(PlatfromExist);
                return new OkObjectResult(platformDto);

            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

       
    }
}
