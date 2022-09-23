using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class RepositorioDLNA
    {
        public int ID_REPOSITORIO { get; set; }
        public string NOMBRE { get; set; }
        public string RUTA_ALOJAMIENTO { get; set; }
        public string FEC_ALTA { get; set; }
        public string USUARIO { get; set; }
    }
}
