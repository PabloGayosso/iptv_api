using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using iptv.AccesoDatos.Models;

namespace iptv.Negocio.Utilidades
{
  public class ValidarLicencia
  {
    IConfiguration configuration;
    CifradoDatos cifradoDatos;
    public ValidarLicencia(IConfiguration configuration)
    {
      this.configuration = configuration;
      cifradoDatos = new CifradoDatos(configuration);
    }
  
    public bool getLicencia(List<LicenciaActiva> licenciaActivas)
    {
      bool blnResult = false;
      string[] stringSeparators = null;
      string cadLicencia = null;
      try
      {
        stringSeparators = new string[] { "||" };
        for (int a = 0; a < licenciaActivas.Count; a++)
        {
          cadLicencia = cifradoDatos.Desencriptar(licenciaActivas[a].LICENCIA_ACTIVA);
          string[] cont = cadLicencia.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
          DateTime fecVencimiento = new DateTime(
              Convert.ToInt32(cont[13].Substring(6, 4))
              , Convert.ToInt32(cont[13].Substring(3, 2))
              , Convert.ToInt32(cont[13].Substring(0, 2))
              , Convert.ToInt32(cont[13].Substring(11, 2))
              , Convert.ToInt32(cont[13].Substring(14, 2))
              , Convert.ToInt32(cont[13].Substring(17, 2))
              );
          if (DateTime.Now <= fecVencimiento)
          {
            blnResult = true;
            //sbreak;
          }
        }
      }
      catch (Exception Error)
      {
        throw;
      }
      return blnResult;
    }
  }
}
