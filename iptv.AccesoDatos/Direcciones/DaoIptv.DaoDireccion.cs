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
        public async Task<List<Direccion>> ObtenerDireccionesAsync(int Pagina, int RegistrosPagina)
        {
            try
            {
                Dictionary<int, Direccion> diccionarioDireccion = new Dictionary<int, Direccion>();
                var resultado = await conexion.QueryAsync<Direccion>(TextoSql.Direccion.OBTENERDIRECCIONESPERSNA,
                new[]{
                   typeof(Direccion),
                   typeof(Persona),
                   typeof(Pais),
                   typeof(Estado),
                   typeof(DelegacionMunicipio),
                   typeof(Colonia)
                },
                respuesta =>
                {
                    Direccion direccion;
                    Persona persona;
                    Pais pais;
                    Estado estado;
                    DelegacionMunicipio delegacionMunicipio;
                    Colonia colonia;
                    if (!diccionarioDireccion.TryGetValue(((Direccion)respuesta[0]).ID_DIRECCION, out direccion))
                    {
                        direccion = respuesta[0] as Direccion;
                        direccion.Persona = new Persona();
                        direccion.Pais = new Pais();
                        direccion.Estado = new Estado();
                        direccion.DelegacionMunicipio = new DelegacionMunicipio();
                        direccion.Colonia = new Colonia();
                        diccionarioDireccion.Add(direccion.ID_DIRECCION, direccion);
                    }
                    persona = respuesta[1] as Persona;
                    pais = respuesta[2] as Pais;
                    estado = respuesta[3] as Estado;
                    delegacionMunicipio = respuesta[4] as DelegacionMunicipio;
                    colonia = respuesta[5] as Colonia;
                    direccion.Persona = persona;
                    direccion.Pais = pais;
                    direccion.Estado = estado;
                    direccion.DelegacionMunicipio = delegacionMunicipio;
                    direccion.Colonia = colonia;
                    return direccion;
                },
                splitOn: "ID_PERSONA,ID_PAIS,ID_ESTADO,ID_DELEG_MUNICIPIO,ID_COLONIA"
                , param: new
                {
                    Pagina,
                    RegistrosPorPagina = RegistrosPagina
                }
                );
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ObtenerTotalDireccionesAsync()
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Direccion.OBTENERTOTALDIRECCIONES);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Direccion> ObtenerDireccionAsync(int ID_DIRECCION)
        {
            try
            {
                Dictionary<int, Direccion> diccionarioDireccion = new Dictionary<int, Direccion>();
                var resultado = await conexion.QueryAsync<Direccion>(TextoSql.Direccion.CONSULTADIRECCIONPERSONAIDDIRECCION,
                new[]{
                   typeof(Direccion),
                   typeof(Persona),
                   typeof(Pais),
                   typeof(Estado),
                   typeof(DelegacionMunicipio),
                   typeof(Colonia)
                },
                respuesta =>
                {
                    Direccion direccion;
                    Persona persona;
                    Pais pais;
                    Estado estado;
                    DelegacionMunicipio delegacionMunicipio;
                    Colonia colonia;
                    if (!diccionarioDireccion.TryGetValue(((Direccion)respuesta[0]).ID_DIRECCION, out direccion))
                    {
                        direccion = respuesta[0] as Direccion;
                        direccion.Persona = new Persona();
                        direccion.Pais = new Pais();
                        direccion.Estado = new Estado();
                        direccion.DelegacionMunicipio = new DelegacionMunicipio();
                        direccion.Colonia = new Colonia();
                        diccionarioDireccion.Add(direccion.ID_DIRECCION, direccion);
                    }
                    persona = respuesta[1] as Persona;
                    pais = respuesta[2] as Pais;
                    estado = respuesta[3] as Estado;
                    delegacionMunicipio = respuesta[4] as DelegacionMunicipio;
                    colonia = respuesta[5] as Colonia;
                    direccion.Persona = persona;
                    direccion.Pais = pais;
                    direccion.Estado = estado;
                    direccion.DelegacionMunicipio = delegacionMunicipio;
                    direccion.Colonia = colonia;
                    return direccion;
                },
                splitOn: "ID_PERSONA,ID_PAIS,ID_ESTADO,ID_DELEG_MUNICIPIO,ID_COLONIA"
                , param: new
                {
                    ID_DIRECCION
                }
                );
                Direccion direccionMod = new Direccion();
                if (resultado.ToList().Count > 0)
                    direccionMod = resultado.AsList()[0];
                return direccionMod;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaDireccionAsync(Direccion direccion)
        {
            try
            {
                var p = new
                {
                    ID_TIPO_DIRECCION = direccion.ID_TIPO_DIRECCION,
                    ID_PAIS = direccion.Pais.ID_PAIS,
                    ID_ESTADO = direccion.Estado.ID_ESTADO,
                    ID_DELEG_MUNICIPIO = direccion.DelegacionMunicipio.ID_DELEG_MUNICIPIO,
                    ID_COLONIA = direccion.Colonia.ID_COLONIA,
                    CODIGO_POSTAL = direccion.CODIGO_POSTAL,
                    CALLE = direccion.CALLE,
                    NUMERO_EXTERIOR = direccion.NUMERO_EXTERIOR,
                    NUMERO_INTERIOR = direccion.NUMERO_INTERIOR,
                    ID_ESTATUS = direccion.ID_ESTATUS,
                    USUARIO = direccion.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Direccion.ALTADIRECCION, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaDireccionAsync(int ID_DIRECCION, Direccion direccion)
        {
            try
            {
                var p = new
                {
                    ID_DIRECCION = ID_DIRECCION,
                    ID_TIPO_DIRECCION = direccion.ID_TIPO_DIRECCION,
                    ID_PAIS = direccion.Pais.ID_PAIS,
                    ID_ESTADO = direccion.Estado.ID_ESTADO,
                    ID_DELEG_MUNICIPIO = direccion.DelegacionMunicipio.ID_DELEG_MUNICIPIO,
                    ID_COLONIA = direccion.Colonia.ID_COLONIA,
                    CODIGO_POSTAL = direccion.CODIGO_POSTAL,
                    CALLE = direccion.CALLE,
                    NUMERO_EXTERIOR = direccion.NUMERO_EXTERIOR,
                    NUMERO_INTERIOR = direccion.NUMERO_INTERIOR,
                    ID_ESTATUS = direccion.ID_ESTATUS,
                    USUARIO = direccion.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Direccion.ACTULIZADIRECCION, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaDireccionPersonaAsync(int ID_DIRECCION, int ID_PERSONA, string USUARIO)
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Direccion.ALTAPERSONADIRECCION, param: new { ID_DIRECCION, ID_PERSONA, USUARIO }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> EliminarDireccionesPersonasAsync(int ID_DIRECCION)
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Direccion.BORRARDIRECCIONESPERSNA, param: new { ID_DIRECCION }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
