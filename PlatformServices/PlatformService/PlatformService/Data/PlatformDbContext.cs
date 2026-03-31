

using Microsoft.EntityFrameworkCore;
using PlatformService.Entity;

namespace PlatformService.Data

{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options)   
        {
            
        }

        public DbSet<Platform> Platform { get; set; }
    }
}
