using API.Domain.Entity;
using API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace API.Infrastructure.Repository
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly ISqlDataAccess db;

        public AlumnoRepository(ISqlDataAccess db)
        {
            this.db = db;   
        }

        public async Task<IActionResult> GetAll()
        {
            return await db.TableResult("SP_Alumno_All");
        }

        public async Task<IActionResult> Post(Alumno entity)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@Nombres", entity.Nombres));
            Params.Add(new SqlParameter("@Apellidos", entity.Apellidos));

            return await db.SaveResult("SP_Alumno_Insert", Params);
        }

        public async Task<IActionResult> Update(Alumno entity)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@id", entity.IdAlumno));
            Params.Add(new SqlParameter("@Nombres", entity.Nombres));
            Params.Add(new SqlParameter("@Apellidos", entity.Apellidos));

            return await db.PostResult("SP_Alumno_Update", Params);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@id", id));

            return await db.PostResult("SP_Alumno_Delete", Params);
        }

        public async Task<IActionResult> GetAlumno_Solicitudes(int id)
        {
            var Params = new Collection<SqlParameter>();
            Params.Add(new SqlParameter("@id", id));

            return await db.TableResult("SP_Alumno_Solicitudes", Params);
        }
    }
}
