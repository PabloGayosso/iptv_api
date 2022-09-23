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
    public async Task<List<Reproductor>> ObtenerReproductoresAsync(int Pagina, int RegistrosPagina)
    {
      try
      {
        var p = new
        {
          Pagina = Pagina,
          RegistrosPorPagina = RegistrosPagina
        };
        var respuesta = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.CONSULTAREPRODUCTORES, p, commandType: CommandType.StoredProcedure);
        return respuesta.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<List<Reproductor>> ObtenerReproductoresCatalogoAsync()
    {
      try
      {
        var respuesta = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.CONSULTATOTALREPRODUCTORESCATALOGO, commandType: CommandType.StoredProcedure);
        return respuesta.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<List<Reproductor>> ObtenerReproductoresCatalogoAsignadoAsync()
    {
      try
      {
        var respuesta = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.CONSULTATOTALREPRODUCTORESCATALOGOASIGNADO, commandType: CommandType.StoredProcedure);
        return respuesta.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<List<Reproductor>> ObtenerReproductoresTemplatesAsync(string Busqueda, int Pagina, int RegistrosPagina)
    {
      try
      {
        Dictionary<int, Reproductor> diccionarioReproductor = new Dictionary<int, Reproductor>();
        var resultado = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.CONSULTAREPRODUCTORTEMPLATEALL,
        new[]{
                   typeof(Reproductor),
                   typeof(Template)
        },
        respuesta =>
        {
          Reproductor reproductor;
          Template template;
          if (!diccionarioReproductor.TryGetValue(((Reproductor)respuesta[0]).ID_REPRODUCTOR, out reproductor))
          {
            reproductor = respuesta[0] as Reproductor;
            reproductor.template = new Template();
            diccionarioReproductor.Add(reproductor.ID_REPRODUCTOR, reproductor);
          }
          template = respuesta[1] as Template;
          reproductor.template = template;
          return reproductor;
        },
        splitOn: "ID_TEMPLATE"
        , param: new
        {
          Busqueda,
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

    public async Task<List<Reproductor>> ObtenerReproductoresEstatusAsync(int Pagina, int RegistrosPagina, int ID_ESTATUS)
    {
      try
      {
        var p = new
        {
          Pagina = Pagina,
          RegistrosPorPagina = RegistrosPagina,
          ID_ESTATUS = ID_ESTATUS
        };
        var respuesta = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.CONSULTAREPRODUCTORESESTATUS, p, commandType: CommandType.StoredProcedure);
        return respuesta.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<List<Reproductor>> ObtenerReproductoresGrupoAsync(int ID_GRUPO)
    {
      try
      {
        var p = new
        {
          ID_GRUPO = ID_GRUPO
        };
        var respuesta = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.CONSULTAREPRODUCTORESGRUPO, p, commandType: CommandType.StoredProcedure);
        return respuesta.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<Reproductor> ObtenerReproductorAsync(int ID_REPRODUCTOR)
    {
      try
      {
        var resultado = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.OBTENERREPRODUCTOR, param: new { ID_REPRODUCTOR }, commandType: CommandType.StoredProcedure);
        Reproductor reproductor = new Reproductor();
        if (resultado.ToList().Count > 0)
          reproductor = resultado.AsList()[0];
        return reproductor;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<Reproductor> ObtenerGrupoReproductorAsync(int ID_GRUPO)
    {
      try
      {
        var respuesta = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.OBTENERREPRODUCTORGRUPO, new { ID_GRUPO }, commandType: CommandType.StoredProcedure);
        Reproductor grupo = new Reproductor();
        if (respuesta.ToList().Count > 0)
          grupo = respuesta.AsList()[0];
        return grupo;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<Reproductor> ObtenerReproductorGrupoAsync(int ID_REPRODUCTOR)
    {
      try
      {
        var respuesta = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.OBTENERREPRODUCTORGRUPOID, new { ID_REPRODUCTOR }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        Reproductor reproductor = new Reproductor();
        if (respuesta.ToList().Count > 0)
          reproductor = respuesta.AsList()[0];
        return reproductor;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<Reproductor> ObtenerReproductorTemplateAsync(int ID_REPRODUCTOR)
    {
      try
      {
        Dictionary<int, Reproductor> diccionarioReproductor = new Dictionary<int, Reproductor>();
        var resultado = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.CONSULTAREPRODUCTORTEMPLATE,
        new[]{
            typeof(Reproductor),
            typeof(Template)
        },
        respuesta =>
        {
          Reproductor reproductor;
          Template template;
          if (!diccionarioReproductor.TryGetValue(((Reproductor)respuesta[0]).ID_REPRODUCTOR, out reproductor))
          {
            reproductor = respuesta[0] as Reproductor;
            reproductor.template = new Template();
            diccionarioReproductor.Add(reproductor.ID_REPRODUCTOR, reproductor);
          }
          template = respuesta[1] as Template;
          reproductor.template = template;
          return reproductor;
        },
        splitOn: "ID_TEMPLATE"
        , param: new
        {
          ID_REPRODUCTOR
        }
        , transaction: unitOfWork.Transaccion
        );
        Reproductor reproductorTemplate = new Reproductor();
        if (resultado.ToList().Count > 0)
          reproductorTemplate = resultado.AsList()[0];
        return reproductorTemplate;
      }
      catch (Exception ex)
      {
        throw;
      }
    }


    public async Task<int> ObtenerTotalReproductoresAsync()
    {
      try
      {
        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.CONSULTATOTALREPRODUCTORES);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }



    public async Task<int> AltaReproductorAsync(Reproductor reproductor)
    {
      try
      {
        var p = new
        {
          CANTIDAD_VIDEOS = reproductor.CANTIDAD_VIDEOS,
          DESCRIPCION = reproductor.DESCRIPCION,
          ID_TIPO_DISPOSITIVO = reproductor.ID_TIPO_DISPOSITIVO,
          IP_CLIENTE = reproductor.IP_CLIENTE,
          PUERTO_CLIENTE = reproductor.PUERTO_CLIENTE,
          RUTA_REPOSITORIO = reproductor.RUTA_REPOSITORIO,
          USUARIO = reproductor.USUARIO,
          ID_ESTATUS = reproductor.ID_ESTATUS,
          DIRECCION_MAC = reproductor.DIRECCION_MAC
        };
        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ALTAREPRODUCTOR, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<int> AltaReproductorTemplateAsync(int ID_REPRODUCTOR, int ID_TEMPLATE, int ID_ESTATUS, string USUARIOS)
    {
      try
      {
        var p = new
        {
          ID_REPRODUCTOR = ID_REPRODUCTOR,
          ID_TEMPLATE = ID_TEMPLATE,
          ID_ESTATUS = ID_ESTATUS,
          USUARIO = USUARIOS
        };

        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ALTAREPRODUCTORTEMPLATE, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<int> AltaReproductorGrupoAsync(int ID_GRUPO, int ID_REPRODUCTOR, int ID_TEMPLATE, string USUARIO)
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

        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ALTAREPRODUCTORGRUPO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<int> ActulizaReproductorAsync(int ID_REPRODUCTOR, Reproductor reproductor)
    {
      try
      {
        var p = new
        {
          ID_REPRODUCTOR = ID_REPRODUCTOR,
          CANTIDAD_VIDEOS = reproductor.CANTIDAD_VIDEOS,
          DESCRIPCION = reproductor.DESCRIPCION,
          ID_TIPO_DISPOSITIVO = reproductor.ID_TIPO_DISPOSITIVO,
          IP_CLIENTE = reproductor.IP_CLIENTE,
          PUERTO_CLIENTE = reproductor.PUERTO_CLIENTE,
          RUTA_REPOSITORIO = reproductor.RUTA_REPOSITORIO,
          USUARIO = reproductor.USUARIO,
          ID_ESTATUS = reproductor.ID_ESTATUS,
          DIRECCION_MAC = reproductor.DIRECCION_MAC
        };

        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ACTUALIZAREPRODUCTOR, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<int> ActulizaReproductorTemplateAsync(int ID_REPRODUCTOR, int ID_TEMPLATE, int ID_ESTATUS, string USUARIO)
    {
      try
      {
        var p = new
        {
          ID_REPRODUCTOR = ID_REPRODUCTOR,
          ID_TEMPLATE = ID_TEMPLATE,
          ID_ESTATUS = ID_ESTATUS,
          USUARIO = USUARIO
        };

        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ACTUALIZAREPRODUCTORTEMPLATE, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<int> ActulizaReproductorGrupoAsync(int ID_REPRODUCTOR, int ID_TEMPLATE, int ID_ESTATUS, string USUARIO)
    {
      try
      {
        var p = new
        {
          ID_REPRODUCTOR = ID_REPRODUCTOR,
          ID_TEMPLATE = ID_TEMPLATE,
          ID_ESTATUS = ID_ESTATUS,
          USUARIO = USUARIO
        };

        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ACTUALIZAREPRODUCTORTEMPLATE, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<int> EliminarReproductorAsync(int ID_REPRODUCTOR)
    {
      try
      {
        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ELIMINAREPRODUCTOR, param: new { ID_REPRODUCTOR }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<int> EliminarReproductorGrupoAsync(int ID_REPRODUCTOR, int ID_GRUPO)
    {
      try
      {
        var p = new
        {
          ID_REPRODUCTOR = ID_REPRODUCTOR,
          ID_GRUPO = ID_GRUPO
        };

        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ELIMINAREPRODUCTORGRUPO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<int> EliminarReproductorTemplateAsync(int ID_REPRODUCTOR)
    {
      try
      {
        var p = new
        {
          ID_REPRODUCTOR = ID_REPRODUCTOR,
        };

        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ELIMINAREPRODUCTORTEMPLATE, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<int> EliminarReproductorGrupoIdReproAsync(int ID_REPRODUCTOR)
    {
      try
      {
        var p = new
        {
          ID_REPRODUCTOR = ID_REPRODUCTOR
        };

        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ELIMINAREPRODUCTORGRUPOID, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<int> ActulizaReljAsync(int ID_REPRODUCTOR, Reproductor reproductor)
    {
      try
      {
        var p = new
        {
          ID_REPRODUCTOR = ID_REPRODUCTOR,
          reproductor.RELOJ,
          reproductor.USUARIO
        };

        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Reproductor.ACTULIZARELOJ, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<Reproductor> ObtenerReproductorIPAsync(Reproductor reproductor)
    {
      try
      {

        var resultado = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.CONSULTAREPRODUCTORIP, param: new { reproductor.IP_CLIENTE }, transaction: unitOfWork.Transaccion);
        Reproductor repro = new Reproductor();
        if (resultado.ToList().Count > 0)
          repro = resultado.AsList()[0];
        return repro;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<Reproductor> ObtenerReproductorMACAsync(Reproductor reproductor)
    {
      try
      {

        var resultado = await conexion.QueryAsync<Reproductor>(TextoSql.Reproductor.CONSULTAREPRODUCTORMAC, param: new { reproductor.DIRECCION_MAC }, transaction: unitOfWork.Transaccion);
        Reproductor repro = new Reproductor();
        if (resultado.ToList().Count > 0)
          repro = resultado.AsList()[0];
        return repro;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
