using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class Consulta_EnviosDto
    {
        public List<EnviosDto> envios { get; set; }
        public int total { get; set; }
        public int id_Busqueda { get; set; }
        public string fec_Busqueda { get; set; }

    }
}
