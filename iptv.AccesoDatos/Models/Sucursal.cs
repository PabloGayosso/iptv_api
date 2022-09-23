using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Sucursal
    {
        public int ID_SUCURSAL { get; set; }
        public int ID_IDENTIDAD { get; set; }
        public string CLAVE { get; set; }
        public string NOMBRE { get; set; }
        public int ID_ESTATUS { get; set; }
        public string FECHA_ALTA { get; set; }
        public string FECHA_MOD { get; set; }
        public string USUARIO { get; set; }
    }
}
