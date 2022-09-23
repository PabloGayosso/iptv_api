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
        public async Task<List<Colonia>> ObtenerColoniasIdDelegacionEstadoAsync(int ID_ESTADO, int ID_DELEG_MUNICIPIO)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Colonia>(TextoSql.Colonia.CONSULTACOLONIADELEGACIONMUNICIPIO, param: new { ID_ESTADO, ID_DELEG_MUNICIPIO });
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
