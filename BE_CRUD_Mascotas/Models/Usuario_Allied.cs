using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace BE_CRUD_App_Allied.Models
{
    public class Usuario_Allied
    {
        [Key]
        public Int64 Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
      //  public DateTime Fecha_Ingreso { get; set; }
        public string Genero { get; set; }
        public string Eps { get; set; }
        public string Arl { get; set; }
        public Int64 Celular { get; set; }
       // public DateTime Fecha_Nacimiento { get; set; }
        
        // public DateTime FechaCreacion { get; set; }

    }
}
