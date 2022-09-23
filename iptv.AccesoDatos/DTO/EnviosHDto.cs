using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class EnviosHDto
    {
        public int id_Envio { get; set; }
        public string nombre_Contenido { get; set; }
        public string reproductor { get; set; }
        public string usuario { get; set; }
        public string fec_Envio { get; set; }
        public string fec_Alta { get; set; }
        public string estatus { get; set; }

    }
}
