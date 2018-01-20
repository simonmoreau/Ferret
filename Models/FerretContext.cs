using Microsoft.EntityFrameworkCore;

namespace Ferret.Models
{
    public class FerretContext : DbContext
    {
        public FerretContext(DbContextOptions<FerretContext> options)
            : base(options)
        {
        }

        public DbSet<HousingUnit> TodoItems { get; set; }

    }
}