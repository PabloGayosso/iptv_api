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
        public async Task<int> CambioDeContenido(int ID_CANAL_CONTENIDO, int ID_CONTENIDO, string USUARIO)
        {
            try
            {
                var p = new
                {
                    ID_CANAL_CONTENIDO,
                    ID_CONTENIDO,
                    USUARIO
                };
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Canal.CAMBIODECONTENIDO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Canal>> ConsultaCanalesActivosAsync(int ID_ESTATUS)
        {
            try
            {
                Dictionary<int, Canal> diccionarioCanal = new Dictionary<int, Canal>(); 
                Dictionary<int, Contenido> diccionarioContenido = new Dictionary<int, Contenido>();
                var resultado = await conexion.QueryAsync<Canal>(TextoSql.Canal.CONSULTACANALESACTIVOS,
                    new[]
                    {
                        typeof (Canal),
                        typeof (Contenido),
                        typeof (Repositorio),
                        typeof (Mensaje),
                        typeof (Tabla)
                    },
                    respuesta =>
                    {
                        Canal canal;
                        Contenido contenido;
    
                        if (!diccionarioCanal.TryGetValue(((Canal)respuesta[0]).ID_CANAL, out canal))
                        {
                            canal = respuesta[0] as Canal;
                            canal.contenidos = new List<Contenido>();
                            diccionarioContenido = new Dictionary<int, Contenido>();
                            diccionarioCanal.Add(canal.ID_CANAL, canal);
                        }

                        if (respuesta[1] != null && !diccionarioContenido.TryGetValue(((Contenido)respuesta[1]).ID_CONTENIDO, out contenido))
                        {
                            contenido = respuesta[1] as Contenido;
                            contenido.repositorio = new Repositorio();
                            contenido.mensaje = new Mensaje();
                            contenido.tabla = new Tabla();

                            if (respuesta[2] != null)
                                contenido.repositorio = respuesta[2] as Repositorio;
                            if (respuesta[3] != null)
                                contenido.mensaje = respuesta[3] as Mensaje;
                            if (respuesta[4] != null)
                                contenido.tabla = respuesta[4] as Tabla;

                            canal.contenidos.Add(contenido);
                            diccionarioContenido.Add(contenido.ID_CONTENIDO, contenido);
                        }

                        return canal;
                    },
                    splitOn: "ID_CONTENIDO,ID_REPOSITORIO,ID_MENSAJE,ID_TABLA",
                    param: new { ID_ESTATUS });

                List<Canal> listaCanal = new List<Canal>();

                if (resultado.AsList().Count > 0)
                    listaCanal = resultado.Distinct().ToList();

                return listaCanal;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Canal>> ConsultaCanalesAsync(int Pagina, int RegistrosPagina, string Busqueda)
        {
            try
            {
                var resultado = await conexion.QueryAsync<Canal>(TextoSql.Canal.CONSULTACANELS, param: new { Busqueda }, commandType: CommandType.StoredProcedure);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Canal> ConsultaCanalAsync(int ID_CANAL)
        {
            try
            {
                Dictionary<int, Canal> diccionarioCanal = new Dictionary<int, Canal>();
                var resultado = await conexion.QueryAsync<Canal>(TextoSql.Canal.CONSULTACANAL,
                    new[]
                    {
                        typeof (Canal),
                        typeof (Contenido),
                    },
                    respuesta =>
                    {
                        Canal canal;
                        Contenido contenido;
                        if (!diccionarioCanal.TryGetValue(((Canal)respuesta[0]).ID_CANAL, out canal))
                        {
                            canal = respuesta[0] as Canal;
                            canal.contenidos = new List<Contenido>();
                            diccionarioCanal.Add(canal.ID_CANAL, canal);
                        }
                        contenido = respuesta[1] as Contenido;
                        canal.contenidos.Add(contenido);
                        return canal;
                    }
                    ,splitOn: "ID_CONTENIDO"
                    ,param: new { ID_CANAL }
                    ,commandType: CommandType.StoredProcedure);
                Canal canalRes = new Canal();
                if (resultado.ToList().Count > 0)
                    canalRes = resultado.AsList()[0];
                return canalRes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ConsultaTotalCanales()
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Canal.TOTALCANALES);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaCanalAsync(Canal canal)
        {
            try
            {
                var p = new
                {
                    ID_TIPO_CANAL = canal.ID_TIPO_CANAL,
                    //DURACION_SEG = canal.DURACION_SEG,
                    //DURACION_MIN = canal.DURACION_MIN,
                    //DURACION_HRS = canal.DURACION_HRS,
                    //INICIO_SEG = canal.INICIO_SEG,
                    //INICIO_MIN = canal.INICIO_MIN,
                    //INICIO_HRS = canal.INICIO_HRS,
                    //POSICION_X = canal.POSICION_X,
                    //POSICION_Y = canal.POSICION_Y,
                    //FEC_REPRODUCCION = canal.FEC_REPRODUCCION,
                    ID_ESTATUS = canal.ID_ESTATUS,
                    //ALTO = canal.ALTO,
                    //ANCHO = canal.ANCHO,
                    CANTIDAD_CONTENIDO = canal.CANTIDAD_CONTENIDO,
                    CLAVE = canal.CLAVE,
                    //FEC_FIN = canal.FEC_FIN,
                    //FEC_INICIO = canal.FEC_INICIO,
                    //FIN_HRS = canal.FIN_HRS,
                    //FIN_MIN = canal.FIN_MIN,
                    //FIN_SEG = canal.FIN_SEG,
                    USUARIO = canal.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Canal.ALTACANAL_, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AltaCanalContenidoAsync(int ID_CANAL, Contenido contenido)
        {
            try
            {
                var p = new
                {
                    ID_CANAL = ID_CANAL
                    ,ID_CONTENIDO = contenido.ID_CONTENIDO
                    ,ORDEN = contenido.ORDEN
                    ,ID_ESTATUS = contenido.ID_ESTATUS
                    ,USUARIO = contenido.USUARIO
                    ,contenido.FEC_INICIO
                    ,contenido.FEC_FIN
                    ,contenido.INICIO_HRS
                    ,contenido.INICIO_MIN
                    ,contenido.INICIO_SEG
                    ,contenido.FIN_HRS
                    ,contenido.FIN_MIN
                    ,contenido.FIN_SEG
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Canal.ALTACANALCONTENIDO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaCanalAsync(int ID_CANAL, Canal canal)
        {
            try
            {
                var p = new
                {
                    ID_CANAL = ID_CANAL,
                    ID_TIPO_CANAL = canal.ID_TIPO_CANAL,
                    //DURACION_SEG = canal.DURACION_SEG,
                    //DURACION_MIN = canal.DURACION_MIN,
                    //DURACION_HRS = canal.DURACION_HRS,
                    //INICIO_SEG = canal.INICIO_SEG,
                    //INICIO_MIN = canal.INICIO_MIN,
                    //INICIO_HRS = canal.INICIO_HRS,
                    //POSICION_X = canal.POSICION_X,
                    //POSICION_Y = canal.POSICION_Y,
                    //FEC_REPRODUCCION = canal.FEC_REPRODUCCION,
                    ID_ESTATUS = canal.ID_ESTATUS,
                    //ALTO = canal.ALTO,
                    //ANCHO = canal.ANCHO,
                    CANTIDAD_CONTENIDO = canal.CANTIDAD_CONTENIDO,
                    CLAVE = canal.CLAVE,
                    //FEC_FIN = canal.FEC_FIN,
                    //FEC_INICIO = canal.FEC_INICIO,
                    //FIN_HRS = canal.FIN_HRS,
                    //FIN_MIN = canal.FIN_MIN,
                    //FIN_SEG = canal.FIN_SEG,
                    USUARIO = canal.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Canal.ACTULIZACANAL_, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> EliminaCanalContenidoAsync(int ID_CANAL)
        {
            try
            {
                var p = new
                {
                    ID_CANAL = ID_CANAL
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Canal.ELIMINACANALCONTENIDO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
