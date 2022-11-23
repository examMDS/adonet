using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entity
{
    public class Solicitud
    {
        [Key]
        public int IdSolicitud { get; set; }   
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;
        public string CodRegistrante { get; set; } = String.Empty; 
        public string Carrera { get; set; } = String.Empty;
        public string Periodo { get; set; } = String.Empty;
        public int IdAlumno { get; set; }

        [ForeignKey("IdAlumno")]
        public virtual Alumno? Alumno { get; set; }

        public ICollection<DetalleSolicitud>? DetalleSolicitudes { get; set; }
    }
}
