using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using Dapper;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        public async Task<List<Opcion>> ObtenerAsignado(int ID_PERFIL)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Opcion>(TextoSql.Opcion.OPCIONASIGNADO, param: new { ID_PERFIL }, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Opcion>> ObtnerNoAsignado(int ID_PERFIL)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Opcion>(TextoSql.Opcion.OPCIONDESASIGNADO, param: new { ID_PERFIL }, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AsignarOpcionesAsync(int ID_PERFIL, int ID_OPCION, string USUARIO)
        {
            try
            {
                var p = new
                {
                    ID_OPCION = ID_OPCION,
                    ID_PERFIL = ID_PERFIL,
                    USUARIO = USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Opcion.ALTAPERFILOPCION, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> EliminarAsignacionOpcionAsync(int ID_PERFIL)
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Opcion.BORRARPERFILOPCION, param: new { ID_PERFIL }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
