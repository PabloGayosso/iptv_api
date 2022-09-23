using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        public async Task<List<Envios>> Consulta_Envios_Async()
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Envios>(TextoSql.Envios.CONSULTA_ENVIOS, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Envios>> Consulta_Envio_Estatus_Async(int id_Envio)
        {
            try
            {
                var variables = new
                {
                    ID_ENVIO = id_Envio,
                };
                var respuesta = await conexion.QueryAsync<Envios>(TextoSql.Envios.CONSULTA_ENVIO_ESTATUS, variables, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Envios>> Consulta_Envios_Post_Async(int idEnvio, string fec_Busqueda)
        {
            try
            {
                var variables = new
                {
                    ID_BUSQUEDA = idEnvio,
                    FEC_BUSQUEDA = fec_Busqueda
                };
                var respuesta = await conexion.QueryAsync<Envios>(TextoSql.Envios.CONSULTA_ENVIOS_POST, variables, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Consulta_Envios_Total()
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Envios.TOTAL_ENVIOS);
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Consulta_Envios_H_Total()
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Envios.TOTAL_ENVIOS_H);
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EnvioH>> Consulta_Envios_H_Async(int Pagina, int RegistrosPagina, string fec_Ini, string fec_Fin)
        {
            try
            {
                var p = new
                {
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina,
                    Fec_Ini = fec_Ini,
                    Fec_Fin = fec_Fin
                };
                var respuesta = await conexion.QueryAsync<EnvioH>(TextoSql.Envios.CONSULTA_ENVIOS_H, p, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AltaEnvioHistoricoAsync(EnvioH envios, int idEliminar)
        {
            try
            {
                var p = new
                {
                    ID_ENVIO = idEliminar,
                    NOMBRE_CONTENIDO = envios.nombre_Contenido,
                    REPRODUCTOR = envios.reproductor,
                    USUARIO = envios.usuario,
                    FEC_ENVIO = envios.fec_Envio,
                    FEC_ALTA = envios.fec_Alta,
                    ESTATUS = envios.estatus
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Envios.ALTA_ENVIOS_H, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
