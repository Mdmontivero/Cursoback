using Microsoft.EntityFrameworkCore;

namespace Cursoback.Model
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        { }

        
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
