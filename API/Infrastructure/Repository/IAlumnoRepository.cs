using API.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Infrastructure.Repository
{
    public interface IAlumnoRepository : IRepository<Alumno>
    {

        Task<IActionResult> GetAlumno_Solicitudes(int id);
    }
}
