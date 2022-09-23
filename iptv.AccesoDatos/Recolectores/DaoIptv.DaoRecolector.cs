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
        public async Task<Recolector> CosultaRecolectorTemplate(int ID_TEMPLATE)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Recolector>(TextoSql.Recolector.CONSULTARECOLECTORTEMPLATE, param: new { ID_TEMPLATE }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                Recolector recolector = new Recolector();
                if (respuesta.ToList().Count > 0)
                    recolector = respuesta.AsList()[0];
                return recolector;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Recolector>> ConsultaRecolectoresAsync()
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Recolector>(TextoSql.Recolector.CONSULTARECOLECTORES, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Recolector> ConsultaRecolectorAsync(int ID_RECOLECTOR)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Recolector>(TextoSql.Recolector.CONSULTARECOLECTOR, param: new { ID_RECOLECTOR }, commandType: CommandType.StoredProcedure);
                Recolector recolector = new Recolector();
                if (respuesta.ToList().Count > 0)
                    recolector = respuesta.AsList()[0];
                return recolector;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AltaRecolectorReproAsync(int ID_REPRODUCTOR, Recolector recolector)
        {
            try
            {
                var p = new
                {
                    ID_REPRODUCTOR,
                    ID_TEMPLATE = recolector.ID_TEMPLATE,
                    ARCHIVO_XML = recolector.ARCHIVO_XML,
                    USUARIO = recolector.USUARIO,
                    ID_ESTATUS = recolector.ID_ESTATUS,
                    ACTUALIZACION = 1
                };
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Recolector.ALTARECOLECTORREPRO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaRecolectorAsync(Recolector recolector)
        {
            try
            {
                var p = new
                {
                    ID_TEMPLATE = recolector.ID_TEMPLATE,
                    ARCHIVO_XML = recolector.ARCHIVO_XML,
                    USUARIO = recolector.USUARIO,
                    ID_ESTATUS = recolector.ID_ESTATUS,
                    ACTUALIZACION = 1
                };
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Recolector.ALTARECOLECTOR, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaRecolectorRepro(int ID_REPRODUCTOR, int ID_RECOLECTOR, Recolector recolector)
        {
            try
            {
                var p = new
                {
                    ID_REPRODUCTOR,
                    ID_RECOLECTOR = ID_RECOLECTOR,
                    ID_TEMPLATE = recolector.ID_TEMPLATE,
                    ARCHIVO_XML = recolector.ARCHIVO_XML,
                    USUARIO = recolector.USUARIO,
                    ID_ESTATUS = recolector.ID_ESTATUS
                    ,
                    ACTUALIZACION = 1
                };
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Recolector.ACTULIZARECOLECTORREPRO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> ActulizaRecolector(int ID_RECOLECTOR, Recolector recolector)
        {
            try
            {
                var p = new
                {
                    ID_RECOLECTOR = ID_RECOLECTOR,
                    ID_TEMPLATE = recolector.ID_TEMPLATE,
                    ARCHIVO_XML = recolector.ARCHIVO_XML,
                    USUARIO = recolector.USUARIO,
                    ID_ESTATUS = recolector.ID_ESTATUS
                    ,ACTUALIZACION = 1
                };
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Recolector.ACTULIZARECOLECTOR, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
