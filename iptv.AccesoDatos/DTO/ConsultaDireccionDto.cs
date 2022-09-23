using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaDireccionDto
    {
        public List<DireccionDto> direccion { get; set; }
        public int Total { get; set; }
    }
}
