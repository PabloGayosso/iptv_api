using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Linq;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos
{
  public partial class DaoIptv : IDaoIptv
  {
    public async Task<int> CambiarEstatusLicenciaAsync(int ID_LICENCIA_ACTIVA, int ID_ESTATUS)
    {
      try
      {
        var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.LicenciaActiva.CABIODEESTATUSLICENCIA, param: new { ID_LICENCIA_ACTIVA, ID_ESTATUS }, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {

        throw;
      }
    }
    public async Task<int> EliminarLicenciaActivaAsync()
    {
      try
      {
        var resultado = await conexion.ExecuteAsync(TextoSql.LicenciaActiva.ELIMINARLICENCIAACTIVA, transaction: unitOfWork.Transaccion);
        return resultado;
      }
      catch (Exception ex)
      {

        throw;
      }
    }
    public async Task<List<LicenciaActiva>> ObtenerLicenciaActivaAsync(int ID_ESTATUS)
    {
      try
      {
        var resultado = await conexion.QueryAsync<LicenciaActiva>(TextoSql.LicenciaActiva.CONSULTALICENCIASUCURSAL, param: new { ID_ESTATUS }, commandType: CommandType.StoredProcedure);
        return resultado.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<List<LicenciaActiva>> ObtnerLicenciaActivaLicenciaAsync(string LICENCIA)
    {
      try
      {
        var resultado = await conexion.QueryAsync<LicenciaActiva>(TextoSql.LicenciaActiva.CONSULTALICENCIASTRING, param: new { LICENCIA }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
        return resultado.AsList();
      }
      catch (Exception ex)
      {
        throw;
      }
    }
    public async Task<int> AltaLicenciaActivaAsync(LicenciaActiva licencia)
    {
      try
      {
        var p = new
        {
          ID_ENTIDAD = licencia.ID_ENTIDAD,
          ID_SUCURSAL = licencia.ID_SUCURSAL,
          ID_APLICACION_IST = licencia.ID_APLICACION_IST,
          ID_ESTATUS = licencia.ID_ESTATUS,
          LICENCIA = licencia.LICENCIA,
          LICENCIA_ACTIVA = licencia.LICENCIA_ACTIVA,
          USUARIO = licencia.USUARIO,
          licencia.SERIAL_NUMBER_BASE,
          licencia.SERIAL_NUMBER_BIOS,
          licencia.MAC_ADDRESS
        };
        var response = await conexion.ExecuteScalarAsync<int>(TextoSql.LicenciaActiva.ALTALICENCIAACTIVA, p, transaction: unitOfWork.Transaccion, commandType: CommandType.StoredProcedure);
        return response;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

  }
}
