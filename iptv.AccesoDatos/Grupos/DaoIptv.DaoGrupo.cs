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
        public async Task<List<Grupo>> ObtenerGruposAsync(string Busqueda, int Pagina, int RegistrosPagina)
        {
            try
            {
                var p = new
                {
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina,
                    Busqueda = Busqueda
                };
                var respuesta = await conexion.QueryAsync<Grupo>(TextoSql.Grupo.OBTENERGRUPOS, p, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Grupo>> ObtenerGrupoCatalogoAsync()
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Grupo>(TextoSql.Grupo.OBTENERGRUPOSCATALOGO, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Grupo>> ObtenerGrupoCatalogoAllAsync()
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Grupo>(TextoSql.Grupo.OBTENERGRUPOSCATALOGOALL, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> ObtenerTotalGruposAsync()
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Grupo.TATOTALGRUPOS);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Grupo> ObtenerGrupoAsync(int ID_GRUPO)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Grupo>(TextoSql.Grupo.OBTENERGRUPO, new { ID_GRUPO }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                Grupo grupo = new Grupo();
                if (respuesta.ToList().Count > 0)
                    grupo = respuesta.AsList()[0];
                return grupo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Grupo> ObtenerGrupoReproAsync(int ID_REPRODUCTOR)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Grupo>(TextoSql.Grupo.OBTENERGRUPOREPRODUCTOR, new { ID_REPRODUCTOR }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                Grupo grupo = new Grupo();
                if (respuesta.ToList().Count > 0)
                    grupo = respuesta.AsList()[0];
                return grupo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AltaGrupoAsync(Grupo grupo)
        {
            try
            {
                var p = new
                {
                    NOMBRE = grupo.NOMBRE,
                    DESCRIPCION = grupo.DESCRIPCION,
                    CANTIDAD_REPRODUCTORES = grupo.CANTIDAD_REPRODUCTORES,
                    USUARIO = grupo.USUARIO,
                    ID_ESTATUS = grupo.ID_ESTATUS,
                    ID_TEMPLATE = grupo .ID_TEMPLATE
                };

                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Grupo.ALTAGRUPO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaGrupoReproductorAsync(int ID_GRUPO, int ID_REPRODUCTOR, int ID_TEMPLATE, string USUARIO)
        {
            try
            {
                var p = new
                {
                    ID_GRUPO = ID_GRUPO,
                    ID_REPRODUCTOR = ID_REPRODUCTOR,
                    ID_TEMPLATE = ID_TEMPLATE,
                    USUARIO = USUARIO
                };

                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Grupo.ALTAGRUPOREPRODUCTOR, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> ActulizaGrupoAsync(int ID_GRUPO, Grupo grupo)
        {
            try
            {
                var p = new
                {
                    ID_GRUPO = ID_GRUPO,
                    NOMBRE = grupo.NOMBRE,
                    DESCRIPCION = grupo.DESCRIPCION,
                    USUARIO = grupo.USUARIO,
                    ID_ESTATUS = grupo.ID_ESTATUS,
                    ID_TEMPLATE = grupo.ID_TEMPLATE
                };

                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Grupo.ACTUALIZAGRUPO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> EliminarGrupoReproductor(int ID_GRUPO)
        {
            try
            {
                var p = new
                {
                    ID_GRUPO = ID_GRUPO
                };

                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Grupo.ELIMINARGRUPO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
