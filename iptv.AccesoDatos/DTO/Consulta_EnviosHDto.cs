using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class Consulta_EnviosHDto
    {
        public List<EnviosHDto> envios { get; set; }
        public int total { get; set; }
    }
}
