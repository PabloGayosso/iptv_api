using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using System.Data;
using System.Linq;
using Dapper;

namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        public async Task<List<MensajeVivo>> ObtenerMensajesVivoAsync(string Busqueda, int Pagina, int RegistrosPagina)
        {
            try
            {
                var p = new
                {
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina,
                    Busqueda = Busqueda
                };
                var respuesta = await conexion.QueryAsync<MensajeVivo>(TextoSql.MensajesVivo.CONSULTAMENSAJESVIVO, p, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MensajeVivo> ObtenerMensajeVivoAsync(int ID_MENSAJE)
        {
            try
            {
                var resultado = await conexion.QueryAsync<MensajeVivo>(TextoSql.MensajesVivo.CONSULTAMENSAJEVIVO, param: new { ID_MENSAJE }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                MensajeVivo mensajeVivo = new MensajeVivo();
                if (resultado.ToList().Count > 0)
                    mensajeVivo = resultado.AsList()[0];
                return mensajeVivo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> ObtenerTotalMensajesVivoAsync()
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.MensajesVivo.CONSULTATOTALMENSAJESVIVO);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<MensajeVivo>> ObtenerMensajesVivoGrupoReporductorAsync(int Pagina, int RegistrosPagina)
        {
            try
            {
                var p = new
                {
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina
                };
                var respuesta = await conexion.QueryAsync<MensajeVivo>(TextoSql.MensajesVivo.CONSULTAMENSAJESVIVOGRUPOREPRO, p, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MensajeVivo> ObtenerMensajeVivoGruReproAsync(int ID_GRUPO_REPRODUCTOR_MENSAJE)
        {
            try
            {
                var resultado = await conexion.QueryAsync<MensajeVivo>(TextoSql.MensajesVivo.CONSULTAMENSAJEVIVOGRUPOREPRO, param: new { ID_GRUPO_REPRODUCTOR_MENSAJE }, commandType: CommandType.StoredProcedure);
                MensajeVivo mensajeVivo = new MensajeVivo();
                if (resultado.ToList().Count > 0)
                    mensajeVivo = resultado.AsList()[0];
                return mensajeVivo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> ObtenerTotalMensajesVivoGruRepAsync()
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.MensajesVivo.CONSULTATOTALMENSAJESVIVOGRUREP);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AltaMensajeVivoAsync(MensajeVivo mensajeVivo)
        {
            try
            {
                var p = new
                {
                    ID_ESTATUS = mensajeVivo.ID_ESTATUS,
                    DSC_MENSAJE = mensajeVivo.DSC_MENSAJE,
                    ES_REPETITIVO = mensajeVivo.ES_REPETITIVO,
                    TIEMPO_REPETICION = mensajeVivo.TIEMPO_REPETICION,
                    USUARIO = mensajeVivo.USUARIO,
                    COLOR_FONDO_BARRA_TEXTO = mensajeVivo.COLOR_FONDO_BARRA_TEXTO,
                    OPACIDAD_TEXTO = mensajeVivo.OPACIDAD_TEXTO,
                    OPACIDAD_BARRA_TEXTO = mensajeVivo.OPACIDAD_BARRA_TEXTO,
                    TIPO_LETRA_TEXTO = mensajeVivo.TIPO_LETRA_TEXTO,
                    TAMANIO_LETRA_TEXTO = mensajeVivo.TAMANIO_LETRA_TEXTO,
                    COLOR_TEXTO = mensajeVivo.COLOR_TEXTO,
                    VELOCIDAD_TEXTO = mensajeVivo.VELOCIDAD_TEXTO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.MensajesVivo.ALTAMENSAJEVIVO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AltaMensajeVivoReproductorAsync(int ID_GRUPO, int ID_REPRODUCTOR, int ID_MENSAJE, int ID_ESTATUS, string USUARIO)
        {
            try
            {
                var p = new
                {
                    ID_GRUPO = ID_GRUPO,
                    ID_REPRODUCTOR = ID_REPRODUCTOR,
                    ID_MENSAJE = ID_MENSAJE,
                    ID_ESTATUS = ID_ESTATUS,
                    USUARIO = USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.MensajesVivo.ALTAMENSAJEVIVOREPRODUCTOR, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> ActulizaMensajeVivoAsync(int ID_MENSAJE, MensajeVivo mensajeVivo)
        {
            try
            {
                var p = new
                {
                    ID_MENSAJE = ID_MENSAJE,
                    ID_ESTATUS = mensajeVivo.ID_ESTATUS,
                    DSC_MENSAJE = mensajeVivo.DSC_MENSAJE,
                    ES_REPETITIVO = mensajeVivo.ES_REPETITIVO,
                    TIEMPO_REPETICION = mensajeVivo.TIEMPO_REPETICION,
                    USUARIO = mensajeVivo.USUARIO,
                    COLOR_FONDO_BARRA_TEXTO = mensajeVivo.COLOR_FONDO_BARRA_TEXTO,
                    OPACIDAD_TEXTO = mensajeVivo.OPACIDAD_TEXTO,
                    OPACIDAD_BARRA_TEXTO = mensajeVivo.OPACIDAD_BARRA_TEXTO,
                    TIPO_LETRA_TEXTO = mensajeVivo.TIPO_LETRA_TEXTO,
                    TAMANIO_LETRA_TEXTO = mensajeVivo.TAMANIO_LETRA_TEXTO,
                    COLOR_TEXTO = mensajeVivo.COLOR_TEXTO,
                    VELOCIDAD_TEXTO = mensajeVivo.VELOCIDAD_TEXTO
                };

                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.MensajesVivo.ACTUALIZAMENSAJEVIVO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> ActulizaMensajeVivoReproductorAsync(int ID_GRUPO_REPRODUCTOR_MENSAJE,
            int ID_GRUPO, int ID_REPRODUCTOR, int ID_MENSAJE, int ID_ESTATUS, string USUARIO)
        {
            try
            {
                var p = new
                {
                    ID_GRUPO_REPRODUCTOR_MENSAJE = ID_GRUPO_REPRODUCTOR_MENSAJE,
                    ID_GRUPO = ID_GRUPO,
                    ID_REPRODUCTOR = ID_REPRODUCTOR,
                    ID_MENSAJE = ID_MENSAJE,
                    ID_ESTATUS = ID_ESTATUS,
                    USUARIO = USUARIO
                };

                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.MensajesVivo.ACTUALIZAMENSAJEVIVOREPRODUCTOR, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> EliminarMensajeVivoReproductorAsync(int ID_MENSAJE, int ID_REPRODUCTOR)
        {
            try
            {
                var p = new
                {
                    ID_MENSAJE = ID_MENSAJE,
                    ID_REPRODUCTOR = ID_REPRODUCTOR                  
                };

                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.MensajesVivo.ELIMINAMENSAJEVIVOREPRODUCTOR, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> EliminarMensajeVivoGrupoAsync(int ID_MENSAJE, int ID_GRUPO)
        {
            try
            {
                var p = new
                {
                    ID_MENSAJE = ID_MENSAJE,
                    ID_GRUPO = ID_GRUPO
                };

                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.MensajesVivo.ELIMINAMENSAJEVIVOGRUPO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> EliminarMensajeVivoAsync(int ID_MENSAJE)
        {
            try
            {
                var p = new
                {
                    ID_MENSAJE = ID_MENSAJE
                };

                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.MensajesVivo.ELIMINAMENSAJEVIVO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
