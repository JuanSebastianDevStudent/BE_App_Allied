using Microsoft.EntityFrameworkCore;
using Npgsql;

//Crea y mapea la base de datos

namespace BE_CRUD_App_Allied.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { 

        }
        //Se debe hacer un DbSet por cada tabla de nuestro proyecto.
        public DbSet<Usuario_Allied> Usuarios { get; set; }
    }
}
