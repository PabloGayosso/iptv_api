using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using Dapper;
using System.Data;
using System.Linq;

namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        public async Task<List<Estado>> ObtenerEstadosAsync()
        {
            try
            {
                var resultado = await conexion.QueryAsync<Estado>(TextoSql.Estado.OBTENERESTADOS, commandType: CommandType.StoredProcedure);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
