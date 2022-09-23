using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Linq;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos;
namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        public async Task<Usuario> ValirdarUsuarioAsync(string USERNAME)
        {
            try
            {   
                var p = new
                {
                    CLAVE_USUARIO = USERNAME
                };
                var resultado = await conexion.QueryAsync<Usuario>(TextoSql.Autenticacion.AUTENTICA, param: p, commandType: CommandType.StoredProcedure);
                Usuario usuario = new Usuario();

                if (resultado.ToList().Count > 0)
                    usuario = resultado.AsList()[0];

                return usuario;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
