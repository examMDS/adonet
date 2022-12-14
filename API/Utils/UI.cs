using API.Domain.Entity;
using API.Utils.Converter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace API.Utils
{
    public class UI
    {

        public string CadenaSQL { get; set; } = string.Empty;

        public UI(string cadenaSQL)
        {
            CadenaSQL = cadenaSQL;

        }

        public async Task<DataTable> Table(string SP, IEnumerable<SqlParameter>? Params = null)
        {
            var dt = new DataTable();
            try
            {
                using var cnn = new SqlConnection(CadenaSQL);
                using var adaptador = new SqlDataAdapter(SP, cnn);
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (Params != null)
                {
                    foreach (var item in Params)
                    {
                        adaptador.SelectCommand.Parameters.AddWithValue(item.ParameterName, item.Value);
                    }
                }
                await cnn.OpenAsync();
                adaptador.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }



            return dt;
        }

        public async Task<Response> Post(string SP, IEnumerable<SqlParameter>? Params = null)
        {
            var result = new Response();

            try
            {
                using var cnn = new SqlConnection(CadenaSQL);
                var comando = new SqlCommand(SP, cnn);
                comando.CommandType = CommandType.StoredProcedure;
                if (Params != null)
                {
                    foreach (var item in Params)
                    {
                        comando.Parameters.AddWithValue(item.ParameterName, item.Value);
                    }
                }

                await cnn.OpenAsync();
                await comando.ExecuteNonQueryAsync();

                result.success = 1;
                result.message = "OK";
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }

            return result;

        }

        public async Task<ContentResult> TableResult(string SP)
        {
            var dt = await Table(SP);

            var options = new JsonSerializerOptions()
            {
                Converters = { new DataTableConverter() }
            };

            string jsonDataTable = JsonSerializer.Serialize(dt, options);

            var content = new ContentResult();
            content.Content = jsonDataTable;
            content.ContentType = "application/json";

            return content;
        }

        public async Task<ContentResult> PostResult(string SP, IEnumerable<SqlParameter>? Params = null)
        {
            var dt = await Post(SP, Params);
            string jsonDataTable = JsonSerializer.Serialize(dt);
            var content = new ContentResult();
            content.Content = jsonDataTable;
            content.ContentType = "application/json";
            return content;
        }
    }
}
