using API.Domain.Entity;
using API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace API.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ISqlDataAccess db;

        public ClientRepository(ISqlDataAccess db)
        {
            this.db = db;
        }
        public async Task<IActionResult> GetAll()
        {
            return await db.TableResult("SP_Client_All");
        }

        public async Task<IActionResult> Post(Client client)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@name", client.name));
            return await db.SaveResult("SP_Client_Insert", Params);
        }

        public async Task<IActionResult> Update(Client client)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@id", client.id));
            Params.Add(new SqlParameter("@name", client.name));
            return await db.PostResult("SP_Client_Update", Params);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@id", id));
            return await db.PostResult("SP_Client_Delete", Params);
        }
    }
}
