using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using iptv.AccesoDatos.Models;


namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        public async Task<int> AltaAuditoriaAsync(Auditoria auditoria)
        {
            try
            {
                var p = new
                {
                    DSC_AUDITORIA = auditoria.DSC_AUDITORIA,
                    ID_USUARIO = auditoria.ID_USUARIO,
                    FCH_ACCION = auditoria.FCH_ACCION,
                    DSC_ACCION = auditoria.DSC_ACCION,
                    USUARIO = auditoria.USUARIO,
                    ID_APLICACION = auditoria.ID_APLICACION,
                    ID_SUCURSAL = auditoria.ID_SUCURSAL
                };
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Audittoria.ALTAAUDITORIA, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Auditoria>> ConsultaAuditoriaFechasAsync(string FECHA_INIO, string FECHA_FINAL, int Pagina, int RegistrosPorPagina)
        {
            try
            {
                FECHA_FINAL += " 23:59:59.999";
                var p = new
                {
                    FECHA_INIO,
                    FECHA_FINAL,
                    Pagina,
                    RegistrosPorPagina
                };
                var respuesta = await conexion.QueryAsync<Auditoria>(TextoSql.Audittoria.CONSULTAAUDITORIAFECHAS, p, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Auditoria>> ConsultaAuditoriaFechasAsync(string FECHA_INIO, string FECHA_FINAL)
        {
            try
            {
                FECHA_FINAL += " 23:59:59.999";
                var p = new
                {
                    FECHA_INIO,
                    FECHA_FINAL
                };
                var respuesta = await conexion.QueryAsync<Auditoria>(TextoSql.Audittoria.CONSULTAAUDITORIAFECHASFILE, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> ObtenerTotalAuditoriasFechaAsync(string FCH_INI, string FCH_FIN)
        {
            try
            {
                FCH_FIN += " 23:59:59.999";
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Audittoria.CONSULTAAUDITORIAFECHASTOTAL, param: new { FCH_INI, FCH_FIN });
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
