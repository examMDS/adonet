using API.Domain.Entity;
using API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace API.Infrastructure.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ISqlDataAccess db;

        public CursoRepository(ISqlDataAccess db)
        {
            this.db = db;
        }
    
        public async Task<IActionResult> GetAll()
        {
            return await db.TableResult("SP_Curso_All");
        }

        public async Task<IActionResult> Post(Curso entity)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@Nombre", entity.Nombre));
            Params.Add(new SqlParameter("@Descripcion", entity.Descripcion));
            Params.Add(new SqlParameter("@NroCreditos", entity.NroCreditos));
            Params.Add(new SqlParameter("@Activo", entity.Activo));

            return await db.SaveResult("SP_Curso_Insert", Params);

        }

        public async Task<IActionResult> Update(Curso entity)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@IdCurso", entity.IdCurso));
            Params.Add(new SqlParameter("@Nombre", entity.Nombre));
            Params.Add(new SqlParameter("@Descripcion", entity.Descripcion));
            Params.Add(new SqlParameter("@NroCreditos", entity.NroCreditos));
            Params.Add(new SqlParameter("@Activo", entity.Activo));

            return await db.PostResult("SP_Curso_Update", Params);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@IdCurso", id));

            return await db.PostResult("SP_Curso_Delete", Params);
        }
    }
}
