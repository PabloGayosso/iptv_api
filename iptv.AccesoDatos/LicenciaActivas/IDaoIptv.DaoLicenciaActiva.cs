using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.LicenciaActivas
{
  public partial interface IDaoIptv
  {
    Task<List<LicenciaActiva>> ObtenerLicenciaActivaAsync(int ID_ESTATUS);
    Task<List<LicenciaActiva>> ObtnerLicenciaActivaLicenciaAsync(string LICENCIA);
    Task<int> AltaLicenciaActivaAsync(LicenciaActiva licencia);
    Task<int> EliminarLicenciaActivaAsync();
    Task<int> CambiarEstatusLicenciaAsync(int ID_LICENCIA, int ID_ESTATUS);
  }
}
