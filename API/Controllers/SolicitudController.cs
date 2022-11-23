using API.Domain.Entity;
using API.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly ISolicitudRepository db;

        public SolicitudController(ISolicitudRepository db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return await db.GetAll();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(Solicitud solicitud)
        {
            return await db.Post(solicitud);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Put(Solicitud solicitud)
        {
            return await db.Update(solicitud);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            return await db.Delete(id);
        }

    }
}
