using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entity
{
    public class Docente
    {
        [Key]
        public int IdDocente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public ICollection<DetalleSolicitud> DetalleSolicitudes { get; set; }
    }
}
