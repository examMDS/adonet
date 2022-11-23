using API.Domain.Entity;
using API.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoRepository db;

        public AlumnoController(IAlumnoRepository db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return await db.GetAll();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(Alumno alumno)
        {
            return await db.Post(alumno);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Put(Alumno alumno)
        {
            return await db.Update(alumno);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            return await db.Delete(id);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAlumno_Solicitudes(int id)
        {
            return await db.GetAlumno_Solicitudes(id);
        }
    }
}
