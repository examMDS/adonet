using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entity
{
    public class Alumno
    {
        [Key]
        public int IdAlumno { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public ICollection<Solicitud>? Solicitudes { get; set; }
    }
}
