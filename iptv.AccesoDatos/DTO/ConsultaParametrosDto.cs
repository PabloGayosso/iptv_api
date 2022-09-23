using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaParametrosDto
    {
        public List<ParametroDto> parametro { get; set; }
        public int Total { get; set; }
    }
}
