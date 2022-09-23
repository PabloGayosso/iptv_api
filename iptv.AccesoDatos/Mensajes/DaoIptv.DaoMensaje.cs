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
        public async Task<List<Mensaje>> ObtenerCatMensajesAsync()
        {
            try
            {
                var resultado = await conexion.QueryAsync<Mensaje>(TextoSql.Mensaje.CATMENSAJE);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Mensaje>> ObtenerMensajesAsync(string Busqueda, int Pagina, int RegistrosPagina)
        {
            try
            {
                var p = new
                {
                    Busqueda = Busqueda,
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina
                };
                var resultado = await conexion.QueryAsync<Mensaje>(TextoSql.Mensaje.OBTENERMENSAJES, p, commandType: CommandType.StoredProcedure);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Mensaje> ObtenerMensajeAsync(int ID_MENSAJE)
        {
            try
            {
                var resultado = await conexion.QueryAsync<Mensaje>(TextoSql.Mensaje.OBTENERMENSAJE, param: new { ID_MENSAJE }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                Mensaje mensaje = new Mensaje();
                if (resultado.ToList().Count > 0)
                    mensaje = resultado.AsList()[0];
                return mensaje;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaMensajeAsync(Mensaje mensaje)
        {
            try
            {
                var p = new
                {
                    NOMBRE = mensaje.NOMBRE,
                    DESCRIPCION = mensaje.DESCRIPCION,
                    ID_ESTATUS = mensaje.ID_ESTATUS,
                    USUARIO = mensaje.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Mensaje.ALTAMENSAJE, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaMensajeAsync(int ID_MENSAJE, Mensaje mensaje)
        {
            try
            {
                var p = new
                {
                    ID_MENSAJE = ID_MENSAJE,
                    NOMBRE = mensaje.NOMBRE,
                    DESCRIPCION = mensaje.DESCRIPCION,
                    ID_ESTATUS = mensaje.ID_ESTATUS,
                    USUARIO = mensaje.USUARIO
                    
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Mensaje.ACTULIZAMENSAJE, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> TotalMensajesAsync()
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Mensaje.TOTALMENSAJE);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> EliminarMensajeAsync(int ID_MENSAJE)
        {
            try
            {
                var resultado = await conexion.ExecuteAsync(TextoSql.Mensaje.ELIMINARMENSAJE, param: new { ID_MENSAJE }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
