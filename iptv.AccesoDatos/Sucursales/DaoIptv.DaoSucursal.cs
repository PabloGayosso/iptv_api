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
    public partial class DaoIptv
    {
        public async Task<Sucursal> ObtnerSucursalIdAsync(int ID_SUCURSAL)
        {
            try
            {
                var resultado = await conexion.QueryAsync<Sucursal>(TextoSql.Sucursal.CONSULTASUCURSAL, param: new { ID_SUCURSAL }, commandType: CommandType.StoredProcedure);
                Sucursal sucursal = new Sucursal();
                if (resultado.ToList().Count > 0)
                    sucursal = resultado.AsList()[0];
                return sucursal;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
