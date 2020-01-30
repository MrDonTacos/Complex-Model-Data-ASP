using Microsoft.EntityFrameworkCore;
using Tienda_Musica.Models;

namespace Tienda_Musica.Data
{
    public class TiendaMusicaContext : DbContext
    {
        public TiendaMusicaContext (DbContextOptions<TiendaMusicaContext> options)
            : base(options)
        {
        }

        public DbSet<Musician> Musician { get; set; }
        public DbSet<Album> Album {get; set;}
    }
}