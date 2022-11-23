using API.Domain.Entity;
using API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace API.Infrastructure.Repository
{
    public class DocenteRepository : IDocenteRepository
    {
        private readonly ISqlDataAccess db;

        public DocenteRepository(ISqlDataAccess db)
        {
            this.db = db;
        }

        public async Task<IActionResult> GetAll()
        {
            return await db.TableResult("SP_Docente_All");
        }

        public async Task<IActionResult> Post(Docente entity)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@Nombres", entity.Nombres));
            Params.Add(new SqlParameter("@Apellidos", entity.Apellidos));

            return await db.SaveResult("SP_Docente_Insert", Params);
        }

        public async Task<IActionResult> Update(Docente entity)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@Nombres", entity.Nombres));
            Params.Add(new SqlParameter("@Apellidos", entity.Apellidos));

            return await db.PostResult("SP_Docente_Update", Params);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@IdDocente", id));

            return await db.PostResult("SP_Docente_Delete", Params);
        }
    }
}
