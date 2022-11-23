using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entity
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int NroCreditos { get; set; }
        public int Activo { get; set; }

        public ICollection<DetalleSolicitud> DetalleSolicitudes { get; set; }
    }
}
