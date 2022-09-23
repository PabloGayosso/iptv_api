using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Tabla
    {
        public int ID_TABLA { get; set; }
        public string NOMBRE_BD { get; set; }
        public string NOMBRE { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
    }
}
