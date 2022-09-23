using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
  public static class LicenciaActiva
  {
    public const string CONSULTALICENCIASUCURSAL = @"[SPS_GL_D_LICENCIA_ACTIVA_ESTATUS]";
    public const string CONSULTALICENCIASTRING = @"[SPS_GL_D_LICENCIA_ACTIVA_LICENCIA]";
    public const string ALTALICENCIAACTIVA = @"[SPI_GL_D_LICENCIA_ACTIVA]";
    public const string CABIODEESTATUSLICENCIA = @" UPDATE GL_D_LICENCIA_ACTIVA SET ID_ESTATUS = @ID_ESTATUS WHERE ID_LICENCIA_ACTIVA = @ID_LICENCIA_ACTIVA";
    public const string ELIMINARLICENCIAACTIVA = @"TRUNCATE TABLE GL_D_LICENCIA_ACTIVA";
  }
}
