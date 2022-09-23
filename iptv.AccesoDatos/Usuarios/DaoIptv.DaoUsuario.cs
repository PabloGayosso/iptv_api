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
        public async Task<List<Usuario>> ObtenerUsariosAsync(int Pagina, int RegistrosPagina)
        {
            try
            {
                var p = new
                {
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina
                };
                var resultado = await conexion.QueryAsync<Usuario>(TextoSql.Usuario.CONSULTAUSUARIOS, p, commandType: CommandType.StoredProcedure);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Usuario>> ObtenerUsariosAsync()
        {
            try
            {
                var resultado = await conexion.QueryAsync<Usuario>(TextoSql.Usuario.CONSULTAUSUARIOSREPORTE, commandType: CommandType.StoredProcedure);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ObtenerTotalUsuariosAsync()
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Usuario.CONSULTATOTALUSUARIOS);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Usuario> ObtenerUsuarioAsync(int ID_USUARIO)
        {
            try
            {
                var resultaddo = await conexion.QueryAsync<Usuario>(TextoSql.Usuario.CONSULTAUSUARIO, param: new { ID_USUARIO }, commandType: CommandType.StoredProcedure);
                Usuario usuario = new Usuario();
                if (resultaddo.ToList().Count > 0)
                   usuario = resultaddo.AsList()[0];
                return usuario;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Usuario> ObtenerUsuarioIdPersonaAsync(int ID_PERSONA)
        {
            try
            {
                var resultaddo = await conexion.QueryAsync<Usuario>(TextoSql.Usuario.CONSULTAUSUARIOIDPERSONA, param: new { ID_PERSONA }, commandType: CommandType.StoredProcedure);
                Usuario usuario = new Usuario();
                if (resultaddo.ToList().Count > 0)
                    usuario = resultaddo.AsList()[0];
                return usuario;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaUsuarioAsync(Usuario usuario)
        {
            try
            {
                var p = new
                {
                    ID_PERSONA = usuario.ID_PERSONA,
                    ID_SUCURSAL = 1,
                    CLAVE_USUARIO = usuario.CLAVE_USUARIO,
                    CONTRASENA = usuario.CONTRASENA,
                    ID_PERFIL = usuario.ID_PERFIL,
                    ID_ESTATUS = usuario.ID_ESTATUS,
                    USUARIO = usuario.USUARIO
                };
                var resultaddo = await conexion.ExecuteScalarAsync<int>(TextoSql.Usuario.ALTAUUAUDIO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultaddo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaUsuarioAsync(int ID_USUARIO, Usuario usuario)
        {
            try
            {
                var p = new
                {
                    ID_USUARIO = ID_USUARIO,
                    ID_PERSONA = usuario.ID_PERSONA,
                    ID_SUCURSAL = usuario.ID_SUCURSAL,
                    CLAVE_USUARIO = usuario.CLAVE_USUARIO,
                    CONTRASENA = usuario.CONTRASENA,
                    ID_PERFIL = usuario.ID_PERFIL,
                    ID_ESTATUS = usuario.ID_ESTATUS,
                    USUARIO = usuario.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Usuario.ACTULIZAUSUARIO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> ActulizaUsuarioIdPersonaAsync(int ID_PERSONA, Usuario usuario)
        {
            try
            {
                var p = new
                {
                    ID_PERSONA = ID_PERSONA,
                    ID_SUCURSAL = 1,
                    CLAVE_USUARIO = usuario.CLAVE_USUARIO,
                    CONTRASENA = usuario.CONTRASENA,
                    ID_PERFIL = usuario.ID_PERFIL,
                    ID_ESTATUS = usuario.ID_ESTATUS,
                    USUARIO = usuario.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Usuario.ACTULIZAUSUARIOIDPERSONA, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
