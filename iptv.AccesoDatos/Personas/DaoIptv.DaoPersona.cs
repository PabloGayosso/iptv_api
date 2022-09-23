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
        public async Task<Persona> ObtenerPersonaIdAsync(int ID_PERSONA)
        {
            try
            {
                var resultado = await conexion.QueryAsync<Persona>(TextoSql.Persona.CONSULTAPERSONA, param: new { ID_PERSONA }, commandType: CommandType.StoredProcedure);
                Persona persona = new Persona();
                if (resultado.ToList().Count > 0)
                    persona = resultado.AsList()[0];
                return persona;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Persona>> ObtenerPersonasAsync(int Pagina, int RegistrosPagina)
        {
            try
            {
                var p = new
                {
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina
                };
                var resultado = await conexion.QueryAsync<Persona>(TextoSql.Persona.CONSULTAPERSONAS, p,commandType: CommandType.StoredProcedure);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<PersonasUsuarios>> ObtenerPersonasUsuariosAsync(string Busqueda, int Pagina, int RegistrosPagina)
        {
            try
            {
                var p = new
                {
                    Busqueda = Busqueda,
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina
                };
                var resultado = await conexion.QueryAsync<PersonasUsuarios>(TextoSql.Persona.CONSULTAPERSONASUSUARIOS, p, commandType: CommandType.StoredProcedure);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ObtenerTotalPersonasAsync()
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Persona.CONSULTATOTALPERSONA);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaPersonaAsync(Persona persona)
        {
            try
            {
                var p = new
                {
                    CLAVE = persona.CLAVE,
                    NOMBRE = persona.NOMBRE,
                    APELLIDO_PATERNO = persona.APELLIDO_PATERNO,
                    APELLIDO_MATERNO = persona.APELLIDO_MATERNO,
                    ID_ESTATUS = persona.ID_ESTATUS,
                    //ID_PAIS = persona.ID_PAIS,
                    //FECHA_NACIMIENTO = persona.FECHA_NACIMIENTO,
                    //ID_GENERO = persona.ID_GENERO,
                    USUARIO = persona.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Persona.ALTAPERSONA, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaPersonaAsync(int ID_PERSONA, Persona persona)
        {
            try
            {
                var p = new
                {
                    ID_PERSONA = ID_PERSONA,
                    CLAVE = persona.CLAVE,
                    NOMBRE = persona.NOMBRE,
                    APELLIDO_PATERNO = persona.APELLIDO_PATERNO,
                    APELLIDO_MATERNO = persona.APELLIDO_MATERNO,
                    ID_ESTATUS = persona.ID_ESTATUS,
                    //ID_PAIS = persona.ID_PAIS,
                    //FECHA_NACIMIENTO = persona.FECHA_NACIMIENTO,
                    //ID_GENERO = persona.ID_GENERO,
                    //ID_ESTADO_CIVIL = persona.ID_ESTADO_CIVIL,
                    //ID_ESCOLARIDAD = persona.ID_ESCOLARIDAD,
                    //OCUPACION = persona.OCUPACION,
                    //RELIGION = persona.RELIGION,
                    USUARIO = persona.USUARIO   
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Persona.ACTULIZAPERSONA, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Persona>> ObtenerPersonasActivas(int ID_ESTATUS)
        {
            try
            {
                var resultado = await conexion.QueryAsync<Persona>(TextoSql.Persona.CONSULTAPERSONASACTIVAS, param: new { ID_ESTATUS });
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
