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
        public async Task<List<Contenido>> ObtenerContenidosPorIdCanalAsync(int ID_CANAL)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOSPORIDCANAL, param: new { ID_CANAL }, transaction: unitOfWork.Transaccion);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Contenido>> ConsultaContenidoTextActivos(int ID_ESTATUS, int ID_TIPO_CANAL)
        {
            try
            {
                Dictionary<int, Contenido> diccionarioContenido = new Dictionary<int, Contenido>();
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOMENSAJEACTIVO,
                new[]{
                   typeof(Contenido),
                   typeof(Mensaje)
                },
                respuesta =>
                {
                    Contenido contenido;
                    Mensaje mensaje;
                    if (!diccionarioContenido.TryGetValue(((Contenido)respuesta[0]).ID_CONTENIDO, out contenido))
                    {
                        contenido = respuesta[0] as Contenido;
                        contenido.mensaje = new Mensaje();
                        diccionarioContenido.Add(contenido.ID_CONTENIDO, contenido);
                    }
                    mensaje = respuesta[1] as Mensaje;
                    contenido.mensaje = mensaje;
                    return contenido;
                },
                splitOn: "ID_MENSAJE"
                , param: new
                {
                    ID_ESTATUS,
                    ID_TIPO_CANAL
                }
                );
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Contenido>> ConsultaContenidoTextActivosNoAsignado(int ID_CANAL, int ID_ESTATUS, int ID_TIPO_CANAL)
        {
            try
            {
                Dictionary<int, Contenido> diccionarioContenido = new Dictionary<int, Contenido>();
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOMENSAJEACTIVONOASIGNADO,
                new[]{
                   typeof(Contenido),
                   typeof(Mensaje)
                },
                respuesta =>
                {
                    Contenido contenido;
                    Mensaje mensaje;
                    if (!diccionarioContenido.TryGetValue(((Contenido)respuesta[0]).ID_CONTENIDO, out contenido))
                    {
                        contenido = respuesta[0] as Contenido;
                        contenido.mensaje = new Mensaje();
                        diccionarioContenido.Add(contenido.ID_CONTENIDO, contenido);
                    }
                    mensaje = respuesta[1] as Mensaje;
                    contenido.mensaje = mensaje;
                    return contenido;
                },
                splitOn: "ID_MENSAJE"
                , param: new
                {
                    ID_CANAL,
                    ID_ESTATUS,
                    ID_TIPO_CANAL
                }
                );
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Contenido>> ConsultaContenidoTablaAtivos(int ID_ESTATUS, int ID_TIPO_CANAL)
        {
            try
            {
                Dictionary<int, Contenido> diccionarioContenido = new Dictionary<int, Contenido>();
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOTABLAASIGNADO,
                new[]{
                   typeof(Contenido),
                   typeof(Tabla)
                },
                respuesta =>
                {
                    Contenido contenido;
                    Tabla tabla;
                    if (!diccionarioContenido.TryGetValue(((Contenido)respuesta[0]).ID_CONTENIDO, out contenido))
                    {
                        contenido = respuesta[0] as Contenido;
                        contenido.tabla = new Tabla();
                        diccionarioContenido.Add(contenido.ID_CONTENIDO, contenido);
                    }
                    tabla = respuesta[1] as Tabla;
                    contenido.tabla = tabla;
                    return contenido;
                },
                splitOn: "ID_TABLA"
                , param: new
                {
                    ID_ESTATUS,
                    ID_TIPO_CANAL
                }
                );
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Contenido>> ConsultaContenidoTablaAtivosNoAsignado(int ID_CANAL, int ID_ESTATUS, int ID_TIPO_CANAL)
        {
            try
            {
                Dictionary<int, Contenido> diccionarioContenido = new Dictionary<int, Contenido>();
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOTABLANOASIGNADO,
                new[]{
                   typeof(Contenido),
                   typeof(Tabla)
                },
                respuesta =>
                {
                    Contenido contenido;
                    Tabla tabla;
                    if (!diccionarioContenido.TryGetValue(((Contenido)respuesta[0]).ID_CONTENIDO, out contenido))
                    {
                        contenido = respuesta[0] as Contenido;
                        contenido.tabla = new Tabla();
                        diccionarioContenido.Add(contenido.ID_CONTENIDO, contenido);
                    }
                    tabla = respuesta[1] as Tabla;
                    contenido.tabla = tabla;
                    return contenido;
                },
                splitOn: "ID_TABLA"
                , param: new
                {
                    ID_CANAL,
                    ID_ESTATUS,
                    ID_TIPO_CANAL
                }
                );
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Contenido>> ConsultaContenidoMediaActivos(int ID_ESTATUS, int ID_TIPO_CANAL)
        {
            try
            {
                Dictionary<int, Contenido> diccionarioContenido = new Dictionary<int, Contenido>();
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOREPOSITORIOACTIVO,
                new[]{
                   typeof(Contenido),
                   typeof(Repositorio)
                },
                respuesta =>
                {
                    Contenido contenido;
                    Repositorio repositorio;
                    if (!diccionarioContenido.TryGetValue(((Contenido)respuesta[0]).ID_CONTENIDO, out contenido))
                    {
                        contenido = respuesta[0] as Contenido;
                        contenido.repositorio = new Repositorio();
                        diccionarioContenido.Add(contenido.ID_CONTENIDO, contenido);
                    }
                    repositorio = respuesta[1] as Repositorio;
                    contenido.repositorio = repositorio;
                    return contenido;
                },
                splitOn: "ID_REPOSITORIO"
                , param: new
                {
                    ID_ESTATUS,
                    ID_TIPO_CANAL
                }
                );
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Contenido>> ConsultaContenidoMediaActivosNoAsignado(int ID_CANAL, int ID_ESTATUS, int ID_TIPO_CANAL)
        {
            try
            {
                Dictionary<int, Contenido> diccionarioContenido = new Dictionary<int, Contenido>();
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOREPOSITORIOACTIVONOASIGNADO,
                new[]{
                   typeof(Contenido),
                   typeof(Repositorio)
                },
                respuesta =>
                {
                    Contenido contenido;
                    Repositorio repositorio;
                    if (!diccionarioContenido.TryGetValue(((Contenido)respuesta[0]).ID_CONTENIDO, out contenido))
                    {
                        contenido = respuesta[0] as Contenido;
                        contenido.repositorio = new Repositorio();
                        diccionarioContenido.Add(contenido.ID_CONTENIDO, contenido);
                    }
                    repositorio = respuesta[1] as Repositorio;
                    contenido.repositorio = repositorio;
                    return contenido;
                },
                splitOn: "ID_REPOSITORIO"
                , param: new
                {
                    ID_CANAL,
                    ID_ESTATUS,
                    ID_TIPO_CANAL
                }
                );
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Contenido>> ConsultaContenidoActivos(int ID_ESTATUS, int ID_TIPO_CANAL)
        {
            try
            {
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOACTIVO, param: new { ID_ESTATUS, ID_TIPO_CANAL });
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Contenido>> ConsultaContenidoActivosNoAsignados(int ID_CANAL, int ID_ESTATUS, int ID_TIPO_CANAL)
        {
            try
            {
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOACTIVONOASIGNADO, param: new { ID_CANAL,ID_ESTATUS, ID_TIPO_CANAL });
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Contenido>> ObtenerContenidosAsync(string Busqueda, int Filtro, int Pagina, int RegistrosPagina)
        {
            try
            {
                Dictionary<int, Contenido> diccionarioContenido = new Dictionary<int, Contenido>();
                Dictionary<int, Repositorio> diccionarioRepositorio = new Dictionary<int, Repositorio>();
                Dictionary<int, Mensaje> diccionarioMensajes = new Dictionary<int, Mensaje>();
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOS,
                  new[]{
                   typeof(Contenido),
                   typeof(Repositorio),
                   typeof(Mensaje)
                },
                respuesta =>
                {
                    Contenido contenido;
                    Repositorio repositorio;
                    Mensaje mensaje;
                    if (!diccionarioContenido.TryGetValue(((Contenido)respuesta[0]).ID_CONTENIDO, out contenido))
                    {
                        contenido = respuesta[0] as Contenido;
                        contenido.repositorio = new Repositorio();
                        contenido.mensaje = new Mensaje();
                        diccionarioContenido.Add(contenido.ID_CONTENIDO, contenido);
                    }
                    if (respuesta[1] != null)
                    {
                        if (!diccionarioRepositorio.TryGetValue(((Repositorio)respuesta[1]).ID_REPOSITORIO, out repositorio))
                        {
                            repositorio = respuesta[1] as Repositorio;
                            diccionarioRepositorio.Add(repositorio.ID_REPOSITORIO, repositorio);
                        }
                    }
                    else
                    {
                        repositorio = new Repositorio();
                    }
                    if (respuesta[2] != null)
                    {
                        if (!diccionarioMensajes.TryGetValue(((Mensaje)respuesta[2]).ID_MENSAJE, out mensaje))
                        {
                            mensaje = respuesta[2] as Mensaje;
                            diccionarioMensajes.Add(mensaje.ID_MENSAJE, mensaje);
                        }
                    }
                    else
                    {
                        mensaje = new Mensaje();
                    }
                    contenido.repositorio = repositorio;
                    contenido.mensaje = mensaje;
                    return contenido;
                },
                splitOn: "ID_REPOSITORIO,ID_MENSAJE"
                , param: new
                {
                    Busqueda,
                    Filtro,
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina
                }, commandType: CommandType.StoredProcedure
                );
                List<Contenido> listaContenidos = new List<Contenido>();
                if (resultado.ToList().Count > 0)
                    listaContenidos = resultado.Distinct().ToList();

                return listaContenidos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Contenido> ObtenerContenidoAsync(int ID_CONTENIDO)
        {
            try
            {
                Dictionary<int, Contenido> diccionarioContenido = new Dictionary<int, Contenido>();
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDO,
                  new[]{
                   typeof(Contenido),
                   typeof(Repositorio),
                   typeof(Mensaje)
                },
                respuesta =>
                {
                    Contenido contenido;
                    Repositorio repositorio;
                    Mensaje mensaje;
                    if (!diccionarioContenido.TryGetValue(((Contenido)respuesta[0]).ID_CONTENIDO, out contenido))
                    {
                        contenido = respuesta[0] as Contenido;
                        contenido.repositorio = new Repositorio();
                        contenido.mensaje = new Mensaje();
                        diccionarioContenido.Add(contenido.ID_CONTENIDO, contenido);
                    }
                    repositorio = respuesta[1] as Repositorio;
                    mensaje = respuesta[2] as Mensaje;
                    contenido.repositorio = repositorio;
                    contenido.mensaje = mensaje;
                    return contenido;
                },
                splitOn: "ID_REPOSITORIO,ID_MENSAJE"
                , param: new
                {
                    ID_CONTENIDO = ID_CONTENIDO,
                }, commandType: CommandType.StoredProcedure
                , transaction: unitOfWork.Transaccion
                );
                Contenido contenidores = new Contenido();
                if (resultado.ToList().Count > 0)
                    contenidores = resultado.AsList()[0];
                return contenidores;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Contenido>> ObtenerContenidoCanalAsync(int ID_CANAL, int ID_ESTATUS)
        {
            try
            {
                var p = new
                {
                    ID_CANAL = ID_CANAL,
                    ID_ESTATUS = ID_ESTATUS
                };
                var resultado = await conexion.QueryAsync<Contenido>(TextoSql.Contenido.CONSULTACONTENIDOCANAL, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ObtenerTotalContenidosAsync()
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Contenido.CONSULTATOTALCONTENIDOS);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaContenidoTvDirectoAsync(Contenido contenido)
        {
            try
            {
                var p = new
                {
                    ID_TIPO_CANAL = contenido.ID_TIPO_CANAL,
                    RUTA = contenido.RUTA,
                    NOMBRE = contenido.NOMBRE,
                    DURACION_SEG = contenido.DURACION_SEG,
                    DURACION_MIN = contenido.DURACION_MIN,
                    DURACION_HRS = contenido.DURACION_HRS,
                    ORDEN = contenido.ORDEN,
                    //POSICION_X = contenido.POSICION_X,
                    //POSICION_Y = contenido.POSICION_Y,
                    //ANCHO = contenido.ANCHO,
                    //ALTO = contenido.ALTO,
                    OPACIDAD = contenido.OPACIDAD,
                    ID_ESTATUS = contenido.ID_ESTATUS,
                    USUARIO = contenido.USUARIO,
                    contenido.ES_INTERMITENCIA,
                    contenido.VOLUMEN,
                    contenido.INTERMITENCIA_SEG,
                    contenido.INTERMITENCIA_MIN,
                    contenido.INTERMITENCIA_HRS
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Contenido.ALTACONTENIDOSTREAM, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaContenidoMultimediaAsync(Contenido contenido)
        {
            try
            {
                var p = new
                {
                    ID_REPOSITORIO = contenido.ID_REPOSITORIO,
                    ID_TIPO_CANAL = contenido.ID_TIPO_CANAL,
                    RUTA = contenido.RUTA,
                    NOMBRE = contenido.NOMBRE,
                    DURACION_SEG = contenido.DURACION_SEG,
                    DURACION_MIN = contenido.DURACION_MIN,
                    DURACION_HRS = contenido.DURACION_HRS,
                    ORDEN = contenido.ORDEN,
                    //POSICION_X = contenido.POSICION_X,
                    //POSICION_Y = contenido.POSICION_Y,
                    //ANCHO = contenido.ANCHO,
                    //ALTO = contenido.ALTO,
                    OPACIDAD = contenido.OPACIDAD,
                    TEXTO = contenido.TEXTO,
                    ID_ESTATUS = contenido.ID_ESTATUS,
                    USUARIO = contenido.USUARIO,
                    contenido.ES_REPETITIVO,
                    contenido.ES_INTERMITENCIA,
                    contenido.INTERMITENCIA_SEG,
                    contenido.INTERMITENCIA_MIN,
                    contenido.INTERMITENCIA_HRS,
                    contenido.VOLUMEN
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Contenido.ALTACONTENIDOMULTIMEDIA, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaContenidoTextoAsync(Contenido contenido)
        {
            try
            {
                var p = new
                {
                    ID_MENSAJE = contenido.ID_MENSAJE,
                    ID_TIPO_CANAL = contenido.ID_TIPO_CANAL,
                    NOMBRE = contenido.NOMBRE,
                    DURACION_SEG = contenido.DURACION_SEG,
                    DURACION_MIN = contenido.DURACION_MIN,
                    DURACION_HRS = contenido.DURACION_HRS,
                    ORDEN = contenido.ORDEN,
                    //POSICION_X = contenido.POSICION_X,
                    //POSICION_Y = contenido.POSICION_Y,
                    RUTA = contenido.RUTA,
                    //ANCHO = contenido.ANCHO,
                    //ALTO = contenido.ALTO,
                    OPACIDAD = contenido.OPACIDAD_BARRA_TEXTO,
                    TEXTO = contenido.TEXTO,
                    ID_ESTATUS = contenido.ID_ESTATUS,
                    USUARIO = contenido.USUARIO,
                    contenido.ES_REPETITIVO,
                    contenido.ID_TIPO_PRESENTACION,
                    contenido.ID_FORMA_DESPLIEGUE,
                    contenido.OPACIDAD_TEXTO,
                    contenido.VELOCIDAD_TEXTO,
                    contenido.TAMANIO_LETRA_TEXTO,
                    contenido.TIPO_LETRA_TEXTO,
                    contenido.COLOR_FONDO_BARRA_TEXTO,
                    contenido.COLOR_TEXTO,
                    contenido.ES_INTERMITENCIA,
                    contenido.INTERMITENCIA_SEG,
                    contenido.INTERMITENCIA_MIN,
                    contenido.INTERMITENCIA_HRS,
                    contenido.ES_COLOR_FONDO_TEXTO,
                    contenido.RUTA_IMG_FONDO_BARRA_TEXTO,
                    contenido.ORIENTACION_TEXTO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Contenido.ALTACONTENIDOTEXTO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaContenidoTablaoAsync(Contenido contenido)
        {
            try
            {
                var p = new
                {
                    ID_TABLA = contenido.ID_TABLA,
                    ID_TIPO_CANAL = contenido.ID_TIPO_CANAL,
                    NOMBRE = contenido.NOMBRE,
                    DURACION_SEG = contenido.DURACION_SEG,
                    DURACION_MIN = contenido.DURACION_MIN,
                    DURACION_HRS = contenido.DURACION_HRS,
                    ORDEN = contenido.ORDEN,
                    //POSICION_X = contenido.POSICION_X,
                    //POSICION_Y = contenido.POSICION_Y,
                    RUTA = contenido.RUTA,
                    //ANCHO = contenido.ANCHO,
                    //ALTO = contenido.ALTO,
                    OPACIDAD = contenido.OPACIDAD,
                    TEXTO = contenido.TEXTO,
                    ID_ESTATUS = contenido.ID_ESTATUS,
                    USUARIO = contenido.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Contenido.ALTACONTENIDOTABLA, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaContenidoTvDirectoAsync(int ID_CONTENIDO, Contenido contenido)
        {
            try
            {
                var p = new
                {
                    ID_CONTENIDO = ID_CONTENIDO,
                    ID_TIPO_CANAL = contenido.ID_TIPO_CANAL,
                    RUTA = contenido.RUTA,
                    NOMBRE = contenido.NOMBRE,
                    DURACION_SEG = contenido.DURACION_SEG,
                    DURACION_MIN = contenido.DURACION_MIN,
                    DURACION_HRS = contenido.DURACION_HRS,
                    ORDEN = contenido.ORDEN,
                    //POSICION_X = contenido.POSICION_X,
                    //POSICION_Y = contenido.POSICION_Y,
                    //ANCHO = contenido.ANCHO,
                    //ALTO = contenido.ALTO,
                    OPACIDAD = contenido.OPACIDAD,
                    ID_ESTATUS = contenido.ID_ESTATUS,
                    USUARIO = contenido.USUARIO,
                    contenido.ES_INTERMITENCIA,
                    contenido.INTERMITENCIA_SEG,
                    contenido.INTERMITENCIA_MIN,
                    contenido.INTERMITENCIA_HRS,
                    contenido.VOLUMEN
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Contenido.ACTULIZACONTENIDOSTREAM, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaContenidoMultimediaAsync(int ID_CONTENIDO, Contenido contenido)
        {
            try
            {
                var p = new
                {
                    ID_CONTENIDO = ID_CONTENIDO,
                    ID_REPOSITORIO = contenido.ID_REPOSITORIO,
                    ID_TIPO_CANAL = contenido.ID_TIPO_CANAL,
                    RUTA = contenido.RUTA,
                    NOMBRE = contenido.NOMBRE,
                    DURACION_SEG = contenido.DURACION_SEG,
                    DURACION_MIN = contenido.DURACION_MIN,
                    DURACION_HRS = contenido.DURACION_HRS,
                    ORDEN = contenido.ORDEN,
                    //POSICION_X = contenido.POSICION_X,
                    //POSICION_Y = contenido.POSICION_Y,
                    //ANCHO = contenido.ANCHO,
                    //ALTO = contenido.ALTO,
                    OPACIDAD = contenido.OPACIDAD,
                    TEXTO = contenido.TEXTO,
                    ID_ESTATUS = contenido.ID_ESTATUS,
                    USUARIO = contenido.USUARIO,
                    contenido.ES_REPETITIVO,
                    contenido.ES_INTERMITENCIA,
                    contenido.INTERMITENCIA_SEG,
                    contenido.INTERMITENCIA_MIN,
                    contenido.INTERMITENCIA_HRS,
                    contenido.VOLUMEN
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Contenido.ACTULIZACONTENIDOMULTIMEDIA, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaContenidoTextoAsync(int ID_CONTENIDO, Contenido contenido)
        {
            try
            {
                var p = new
                {
                    ID_CONTENIDO = ID_CONTENIDO,
                    ID_MENSAJE = contenido.ID_MENSAJE,
                    ID_TIPO_CANAL = contenido.ID_TIPO_CANAL,
                    RUTA = contenido.RUTA,
                    NOMBRE = contenido.NOMBRE,
                    DURACION_SEG = contenido.DURACION_SEG,
                    DURACION_MIN = contenido.DURACION_MIN,
                    DURACION_HRS = contenido.DURACION_HRS,
                    ORDEN = contenido.ORDEN,
                    //POSICION_X = contenido.POSICION_X,
                    //POSICION_Y = contenido.POSICION_Y,
                    //ANCHO = contenido.ANCHO,
                    //ALTO = contenido.ALTO,
                    OPACIDAD = contenido.OPACIDAD,
                    TEXTO = contenido.TEXTO,
                    ID_ESTATUS = contenido.ID_ESTATUS,
                    USUARIO = contenido.USUARIO,
                    contenido.ES_REPETITIVO,
                    contenido.ID_TIPO_PRESENTACION,
                    contenido.ID_FORMA_DESPLIEGUE,
                    contenido.OPACIDAD_TEXTO,
                    contenido.VELOCIDAD_TEXTO,
                    contenido.TAMANIO_LETRA_TEXTO,
                    contenido.TIPO_LETRA_TEXTO,
                    contenido.COLOR_FONDO_BARRA_TEXTO,
                    contenido.COLOR_TEXTO,
                    contenido.ES_INTERMITENCIA,
                    contenido.INTERMITENCIA_SEG,
                    contenido.INTERMITENCIA_MIN,
                    contenido.INTERMITENCIA_HRS,
                    contenido.ES_COLOR_FONDO_TEXTO,
                    contenido.RUTA_IMG_FONDO_BARRA_TEXTO,
                    contenido.ORIENTACION_TEXTO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Contenido.ACTULIZACONTENIDOTEXTO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaContenidoTablaAsync(int ID_CONTENIDO, Contenido contenido)
        {
            try
            {
                var p = new
                {
                    ID_CONTENIDO = ID_CONTENIDO,
                    ID_TABLA = contenido.ID_TABLA,
                    ID_TIPO_CANAL = contenido.ID_TIPO_CANAL,
                    RUTA = contenido.RUTA,
                    NOMBRE = contenido.NOMBRE,
                    DURACION_SEG = contenido.DURACION_SEG,
                    DURACION_MIN = contenido.DURACION_MIN,
                    DURACION_HRS = contenido.DURACION_HRS,
                    ORDEN = contenido.ORDEN,
                    //POSICION_X = contenido.POSICION_X,
                    //POSICION_Y = contenido.POSICION_Y,
                    //ANCHO = contenido.ANCHO,
                    //ALTO = contenido.ALTO,
                    OPACIDAD = contenido.OPACIDAD,
                    TEXTO = contenido.TEXTO,
                    ID_ESTATUS = contenido.ID_ESTATUS,
                    USUARIO = contenido.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Contenido.ACTULIZACONTENIDOTABLA, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> EliminarContenidoAsync(int ID_CONTENIDO)
        {
            try
            {
                var resultado = await conexion.ExecuteAsync(TextoSql.Contenido.ELIMINARCONTENIDO, param: new { ID_CONTENIDO }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    public async Task<int> LimpiarRepositorioDLNAAsync()
    {
      try
      {
        var resultado = await conexion.ExecuteAsync(TextoSql.Contenido.LIMPIARREPOSITORIODLNA, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
