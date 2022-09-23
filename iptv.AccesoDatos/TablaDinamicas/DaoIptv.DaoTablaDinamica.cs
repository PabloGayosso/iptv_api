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
        public async Task<List<dynamic>> ConsultaTablaDinamicaAsync(int ID_TABLA)
        {
            try
            {
                var respuesta = await conexion.QueryAsync(TextoSql.TablaDinamica.CONSULTATABLADINAMICA, param: new { ID_TABLA }, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<Tabla> ConsultaTablaAsync(int ID_TABLA)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Tabla>(TextoSql.TablaDinamica.OBTENERTABLAIDTABLA, param: new { ID_TABLA }, transaction: unitOfWork.Transaccion);
                Tabla tabla = new Tabla();
                if (respuesta.ToList().Count > 0)
                    tabla = respuesta.AsList()[0];
                return tabla;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> ConsultaTablaNombreAsync(string NOMBRE)
        {
            try
            {
                bool res = false;
                var respuesta = await conexion.QueryAsync<Tabla>(TextoSql.TablaDinamica.CONSULTATBLANOMBRE, param: new { NOMBRE }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                if (respuesta.ToList().Count > 0)
                    res = true;
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaDatosTablaAsync(int ID_TABLA, string REGISTRO)
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.TablaDinamica.CONTENIDOTABLADINAMICA, param: new { ID_TABLA, REGISTRO }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> CrearTablaASync(string NOMBRE_TABLA, string NOM_COLUMNAS, string USUARIO)
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.TablaDinamica.CREARTABLA, param: new { NOMBRE_TABLA, NOM_COLUMNAS, USUARIO }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Tabla>> ConsultaCatTabla()
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Tabla>(TextoSql.TablaDinamica.OBTENERTABLASCAT);
                return respuesta.AsList();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Tabla>> ConsultaTablasAsync(int Pagina, int RegistroPorPagina)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Tabla>(TextoSql.TablaDinamica.OBTENERTABLAS, param: new { Pagina, RegistroPorPagina });
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ConsultaTablasTotalAsync()
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.TablaDinamica.TOTALTABLAS);
                return respuesta;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
