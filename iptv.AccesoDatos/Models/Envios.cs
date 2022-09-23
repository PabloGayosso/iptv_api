using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Envios
    {
        public int id_Envio { get; set; }
        public string nombre_Contenido { get; set; }
        public string reproductor { get; set; }
        public string usuario { get; set; }
        public string fec_Envio { get; set; }
        public string velocidad { get; set; }
        public string tam_Total { get; set; }
        public string tam_Descargado { get; set; }
        public int porcentaje { get; set; }
        public string fec_Alta { get; set; }

    }
}
