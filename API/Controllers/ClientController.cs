using API.Domain.Entity;
using API.Infrastructure.Repository;
using API.Utils;
using API.Utils.Converter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository db;

        public ClientController(IClientRepository db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            //return await db.TableResult("SP_Client_All");
            return await db.GetAll();

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(Client client)
        {
            //var Params = new Collection<SqlParameter>();
            //Params.Add(new SqlParameter("@name", client.name));
            //return await db.PostResult("SP_Client_Insert", Params);
            return await db.Post(client);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(Client client)
        {
            //var Params = new Collection<SqlParameter>();
            //Params.Add(new SqlParameter("@id", client.id));
            //Params.Add(new SqlParameter("@name", client.name));
            //return await db.PostResult("SP_Client_Update", Params);
            return await db.Update(client);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            //var Params = new Collection<SqlParameter>();
            //Params.Add(new SqlParameter("@id", id));
            //return await db.PostResult("SP_Client_Delete", Params);
            return await db.Delete(id);
        }
        

    }


    
}
