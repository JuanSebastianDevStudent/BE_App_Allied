using System.ComponentModel.DataAnnotations;

namespace BE_CRUD_Mascotas.Models.DTO
{
    public class MascotaDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public int Peso { get; set; }

       // public DateTime FechaCreacion { get; set; }
    }
}
