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
        public async Task<List<Perfil>> ObtenerPerfilesActivosAsync(int ID_ESTATUS)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Perfil>(TextoSql.Perfil.CONSULTACATPERFIILES, param: new { ID_ESTATUS });
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Perfil>> ObtenerPerfilesAsync(string Busqueda, int Pagina, int RegistrosPagina)
        {
            try
            {
                var p = new
                {
                    Busqueda = Busqueda,
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina
                };
                var respuesta = await conexion.QueryAsync<Perfil>(TextoSql.Perfil.CONSULTAPERFILES, p ,commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ObtenerTotalPerfilesAsync()
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Perfil.CONSULTATOTALPERFILES);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Perfil> ObtnerPerfilAsync(int ID_PERFIL)
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Perfil>(TextoSql.Perfil.CONSULTAPERFIL, param: new { ID_PERFIL } ,commandType: CommandType.StoredProcedure);
                Perfil perfil = new Perfil();
                if (respuesta.ToList().Count > 0)
                    perfil = respuesta.AsList()[0];
                return perfil;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaPerfilAsync(Perfil perfil)
        {
            try
            {
                var p = new
                {
                    NOMBRE = perfil.NOMBRE,
                    DESCRIPCION = perfil.DESCRIPCION,
                    ID_ESTATUS = perfil.ID_ESTATUS,
                    USUARIO = perfil.USUARIO
                };
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Perfil.ALTAPERFIL, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaPerfilAsync(Perfil perfil)
        {
            var p = new
            {
                ID_PERFIL = perfil.ID_PERFIL,
                NOMBRE = perfil.NOMBRE,
                DESCRIPCION = perfil.DESCRIPCION,
                ID_ESTATUS = perfil.ID_ESTATUS,
                USUARIO = perfil.USUARIO
            };
            var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Perfil.ACTULIZAPERFIL, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
            return respuesta;
        }
        public async Task<Perfil> ObtenerPerfilOpcionAsync(int ID_PERFIL)
        {
            try
            {
                Dictionary<int, Perfil> diccionarioPerfil = new Dictionary<int, Perfil>();
                var resultado = await conexion.QueryAsync<Perfil>(TextoSql.Opcion.CONSSULTAOPCIONPERFIL,
                new[]{
                   typeof(Perfil),
                   typeof(Opcion)
                },
                respuesta =>
                {
                    Perfil perfil;
                    Opcion opcion;
                    if (!diccionarioPerfil.TryGetValue(((Perfil)respuesta[0]).ID_PERFIL, out perfil))
                    {
                        perfil = respuesta[0] as Perfil;
                        perfil.Opcion = new List<Opcion>();
                        diccionarioPerfil.Add(perfil.ID_PERFIL, perfil);
                    }
                    opcion = respuesta[1] as Opcion;
                    perfil.Opcion.Add(opcion);
                    return perfil;
                },
                splitOn: "ID_OPCION"
                , param: new
                {
                    ID_PERFIL
                }
                );
                Perfil perfilOpcion = new Perfil();
                if (resultado.AsList().Count > 0)
                    perfilOpcion = resultado.AsList()[0];
                return perfilOpcion;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
