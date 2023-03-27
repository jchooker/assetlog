using AssetLogWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetLogWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Asset> Assets { get; set; }
    }
}
