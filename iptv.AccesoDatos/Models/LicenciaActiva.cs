using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
  public class LicenciaActiva
  {
    public int ID_LICENCIA_ACTIVA { get; set; }
    public int ID_ENTIDAD { get; set; }
    public int ID_SUCURSAL { get; set; }
    public int ID_APLICACION_IST { get; set; }
    public int ID_ESTATUS { get; set; }
    public string LICENCIA { get; set; }
    public string LICENCIA_ACTIVA { get; set; }
    public string MAC_ADDRESS { get; set; }
    public string SERIAL_NUMBER_BASE { get; set; }
    public string SERIAL_NUMBER_BIOS { get; set; }
    public string FECHA_ALTA { get; set; }
    public string FECHA_MOD { get; set; }
    public string USUARIO { get; set; }
  }
}
