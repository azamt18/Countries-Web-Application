using Microsoft.EntityFrameworkCore;
using Catalog.Infrastructure.Entities;

namespace Catalog.Infrastructure.DbContexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
