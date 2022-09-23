using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using iptv.AccesoDatos.Models;
using System.Linq;
using System.Drawing;
using System.Drawing.Text;

namespace iptv.AccesoDatos
{
  public partial class DaoIptv : IDaoIptv
  {
    public async Task<List<Parametro>> ObtenerParametroIdPadreAsync(int Pagina, int RegistrosPagina, int Parametro)
    {
      try
      {
        var p = new
        {
          PARAMETRO = Parametro,
          Pagina = Pagina,
          RegistrosPorPagina = RegistrosPagina
        };
        var resultado = await conexion.QueryAsync<Parametro>(TextoSql.Parametro.OBTENERPARAMETROSIDPADRE, p, commandType: CommandType.StoredProcedure);
        return resultado.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<List<Parametro>> ObtenerParametroFontsAsync()
    {
      try
      {
        List<Parametro> fontfamilies = new List<Parametro>();
        FontFamily[] fontFamilies;
        InstalledFontCollection installedFontCollection = new InstalledFontCollection();
        // Get the array of FontFamily objects.
        fontFamilies = installedFontCollection.Families;
        foreach (FontFamily family in fontFamilies)
        {
          if (family.Name != null && family.Name != "")
          {
            Parametro font = new Parametro();
            font.DESCRIPCION = family.Name;
            fontfamilies.Add(font);
          }
        }
        return fontfamilies;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<List<Parametro>> ObtenerComboAsync(int ID_PADRE)
    {
      try
      {
        var p = new
        {
          PARAMETRO = ID_PADRE
        };
        var resultado = await conexion.QueryAsync<Parametro>(TextoSql.Parametro.OBTENERCOMBOCATALOGO, p, commandType: CommandType.StoredProcedure);
        return resultado.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<List<Parametro>> ObtenerParametroAsync()
    {
      try
      {
        var resultado = await conexion.QueryAsync<Parametro>(TextoSql.Parametro.OBTENERPARAMETROS, commandType: CommandType.StoredProcedure);

        return resultado.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<List<Parametro>> ObtnerCatalogoAsync(int Pagina, int RegistrosPagina)
    {
      try
      {
        var p = new
        {
          Pagina = Pagina,
          RegistrosPorPagina = RegistrosPagina
        };
        var resultado = await conexion.QueryAsync<Parametro>(TextoSql.Parametro.OBTENERCATALOGOS, p, commandType: CommandType.StoredProcedure);
        return resultado.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<int> ObtenerTotalCatalogoAsync()
    {
      try
      {
        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Parametro.TOTALCATALOGO);
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<int> ObtenerTotalParametrosAsync(int Parametro)
    {
      try
      {
        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Parametro.TOTALPAREMETROSID, param: new { Parametro });
        return resultado;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<Parametro> ObtenerParametroIdAsync(int ID_PARAMETRO)
    {
      try
      {
        var resultado = await conexion.QueryAsync<Parametro>(TextoSql.Parametro.OBTENERPARAMETRO, param: new { ID_PARAMETRO }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        Parametro parametro = new Parametro();
        if (resultado.ToList().Count > 0)
          parametro = resultado.AsList()[0];

        return parametro;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<int> AltaParametroAsync(Parametro parametro)
    {
      try
      {
        var p = new
        {
          PARAMETRO = parametro.PARAMETRO,
          CONSECUTIVO = parametro.CONSECUTIVO,
          CLAVE = parametro.CLAVE,
          DESCRIPCION = parametro.DESCRIPCION,
          PREDETERMINADO = parametro.PREDETERMINADO,
          FACTOR = parametro.FACTOR,
          USUARIO = parametro.USUARIO
        };
        var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Parametro.ALTAPARAMETRO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return respuesta;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<int> ActulizaParametroAsync(Parametro parametro)
    {
      try
      {
        var p = new
        {
          ID_PARAMETRO = parametro.ID_PARAMETRO,
          PARAMETRO = parametro.PARAMETRO,
          CONSECUTIVO = parametro.CONSECUTIVO,
          CLAVE = parametro.CLAVE,
          DESCRIPCION = parametro.DESCRIPCION,
          PREDETERMINADO = parametro.PREDETERMINADO,
          FACTOR = parametro.FACTOR,
          USUARIO = parametro.USUARIO
        };
        var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Parametro.ACTULIZAPARAMETRO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return respuesta;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<int> AltaParametroCatalogoAsync(Parametro parametro)
    {
      try
      {
        var p = new
        {
          PARAMETRO = parametro.PARAMETRO,
          CONSECUTIVO = parametro.CONSECUTIVO,
          CLAVE = parametro.CLAVE,
          DESCRIPCION = parametro.DESCRIPCION,
          PREDETERMINADO = parametro.PREDETERMINADO,
          FACTOR = parametro.FACTOR,
          USUARIO = parametro.USUARIO
        };
        var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Parametro.ALTACATALOGO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return respuesta;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<int> ActulizaParametroCatalogoAsync(Parametro parametro)
    {
      try
      {
        var p = new
        {
          ID_PARAMETRO = parametro.ID_PARAMETRO,
          PARAMETRO = parametro.PARAMETRO,
          CONSECUTIVO = parametro.CONSECUTIVO,
          CLAVE = parametro.CLAVE,
          DESCRIPCION = parametro.DESCRIPCION,
          PREDETERMINADO = parametro.PREDETERMINADO,
          FACTOR = parametro.FACTOR,
          USUARIO = parametro.USUARIO
        };
        var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Parametro.ACTULIZAPARAMETRO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return respuesta;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
