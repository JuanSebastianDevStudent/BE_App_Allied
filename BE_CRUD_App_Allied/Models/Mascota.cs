using System.ComponentModel.DataAnnotations;

namespace BE_CRUD_Mascotas.Models
{
    public class Mascota
    {
        [Key]
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public int Apellido { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public string Genero { get; set; }
        public string Eps { get; set; }
        public string Arl { get; set; }
        public int Celular { get; set; }
        public DateTime FechaCreacion { get; set; }
        
        // public DateTime FechaCreacion { get; set; }

    }
}
