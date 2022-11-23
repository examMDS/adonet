using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entity
{
    public class DetalleSolicitud
    {
        [Key]
        public int IdDetalleSol { get; set; }


        public string Profesor { get; set; } = string.Empty;
        public string Aula { get; set; } = string.Empty;
        public string Sede { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;

        [NotMapped]
        public string error { get; set; } = string.Empty;
        public int IdSolicitud { get; set; }

        public int IdDocente { get; set; }

        [ForeignKey("IdDocente")]
        public Docente Docente { get; set; }

        [ForeignKey("IdSolicitud")]
        public Solicitud Solicitud { get; set; }


        public int IdCurso { get; set; }

        [ForeignKey("IdCurso")]
        public Curso Cursos { get; set; }
    }
}
