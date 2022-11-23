using API.Domain.Entity;
using API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace API.Infrastructure.Repository
{
    public class SolicitudRepository : ISolicitudRepository
    {

        private readonly ISqlDataAccess db;

        public SolicitudRepository(ISqlDataAccess db)
        {
            this.db = db;   
        }

        public async Task<IActionResult> GetAll()
        {
            return await db.TableResult("SP_Solicitud_All");
        }

        public async Task<IActionResult> Post(Solicitud entity)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@IdAlumno", entity.IdAlumno));
            Params.Add(new SqlParameter("@FechaSolicitud", entity.FechaSolicitud));
            Params.Add(new SqlParameter("@CodRegistrante", entity.CodRegistrante));
            Params.Add(new SqlParameter("@Carrera", entity.Carrera));
            Params.Add(new SqlParameter("@Periodo", entity.Periodo));

            return await db.SaveResult("SP_Solicitud_Insert", Params);
        }

        public async Task<IActionResult> Update(Solicitud entity)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@id", entity.IdSolicitud));
            Params.Add(new SqlParameter("@IdAlumno", entity.IdAlumno));
            Params.Add(new SqlParameter("@FechaSolicitud", entity.FechaSolicitud));
            Params.Add(new SqlParameter("@CodRegistrante", entity.CodRegistrante));
            Params.Add(new SqlParameter("@Carrera", entity.Carrera));
            Params.Add(new SqlParameter("@Periodo", entity.Periodo));

            return await db.PostResult("SP_Solicitud_Update", Params);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@id", id));

            return await db.PostResult("SP_Solicitud_Delete", Params);
        }

    }
}
