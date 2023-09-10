using Microsoft.EntityFrameworkCore;

namespace BackEndInz.Helpers
{
    public class BackEndInzDbContext : DbContext
    {
        public BackEndInzDbContext(DbContextOptions<BackEndInzDbContext> options) : base(options)
        {

        }

        // public DbSet<Nazwa Encji> Nazwa Właściwości { get; set; }

    }
}
