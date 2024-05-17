using Microsoft.EntityFrameworkCore;
using Npgsql;

//Crea y mapea la base de datos

namespace BE_CRUD_Mascotas.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { 

        }
        public DbSet<Mascota> Mascotas { get; set; }
    }
}
