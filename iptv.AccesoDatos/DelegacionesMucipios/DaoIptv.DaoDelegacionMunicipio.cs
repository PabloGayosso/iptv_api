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
        public async Task<List<DelegacionMunicipio>> ObtenerDelagacionMunicipioAsync(int ID_ESTADO)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<DelegacionMunicipio>(TextoSql.DelegacionMunicipio.CONSULTADELEGAIONMUNICIPIOIDESTADO, param: new { ID_ESTADO });
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
