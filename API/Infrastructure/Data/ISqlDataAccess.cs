using API.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Infrastructure.Data
{
    public interface ISqlDataAccess
    {
        Task<DataTable> Table(string SP, IEnumerable<SqlParameter>? Params = null);

        Task<Response> Save(string SP, IEnumerable<SqlParameter>? Params = null);

        Task<Response> Post(string SP, IEnumerable<SqlParameter>? Params = null);

        Task<ContentResult> TableResult(string SP, IEnumerable<SqlParameter>? Params = null);
  
        Task<ContentResult> SaveResult(string SP, IEnumerable<SqlParameter>? Params = null);

        Task<ContentResult> PostResult(string SP, IEnumerable<SqlParameter>? Params = null);
    }
}
