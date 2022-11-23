using API.Domain.Entity;
using API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace API.Infrastructure.Repository
{
    public class DetalleRepository : IDetalleRepository
    {

        private readonly ISqlDataAccess db;

        public DetalleRepository(ISqlDataAccess _db )
        {
            this.db = _db;
        }

        public async Task<IActionResult> GetAll()
        {
            return await db.TableResult("SP_DetalleSolicitud_All");
        }

        public async Task<IActionResult> Post(DetalleSolicitud entity)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@IdSolicitud", entity.IdSolicitud));
            Params.Add(new SqlParameter("@IdCurso", entity.IdCurso));
            Params.Add(new SqlParameter("@IdDocente", entity.IdDocente));
            Params.Add(new SqlParameter("@Aula", entity.Aula));
            Params.Add(new SqlParameter("@Sede", entity.Sede));
            Params.Add(new SqlParameter("@Observacion", entity.Observacion));

            return await db.SaveResult("SP_DetalleSolicitud_Insert", Params);
        }

        public async Task<IActionResult> Update(DetalleSolicitud entity)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@IdDetalleSol", entity.IdDetalleSol));
            Params.Add(new SqlParameter("@IdSolicitud", entity.IdSolicitud));
            Params.Add(new SqlParameter("@IdCurso", entity.IdCurso));
            Params.Add(new SqlParameter("@IdDocente", entity.IdDocente));
            Params.Add(new SqlParameter("@Aula", entity.Aula));
            Params.Add(new SqlParameter("@Sede", entity.Sede));
            Params.Add(new SqlParameter("@Observacion", entity.Observacion));

            return await db.PostResult("SP_DetalleSolicitud_Update", Params);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@IdDetalleSol", id));

            return await db.PostResult("SP_DetalleSolicitud_Delete");
        }
    }
}
