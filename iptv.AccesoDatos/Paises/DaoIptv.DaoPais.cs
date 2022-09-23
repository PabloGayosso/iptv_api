using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using iptv.AccesoDatos.Models;
using System.Linq;


namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        public async Task<List<Pais>> ConsultaPaisesAsync()
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Pais>(TextoSql.Pais.CONSULTAPAISES, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Pais> ConsultaPaisAsync(int ID_PAIS)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Pais>(TextoSql.Pais.CONSULTAPAIS, param: new { ID_PAIS }, commandType: CommandType.StoredProcedure);
                Pais pais = new Pais();
                if (respuesta.ToList().Count > 0)
                    pais = respuesta.AsList()[0];
                return pais;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
