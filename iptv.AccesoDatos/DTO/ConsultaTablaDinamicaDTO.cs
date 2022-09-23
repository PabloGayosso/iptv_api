using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaTablaDinamicaDTO
    {
        public List<TablaDTO> ConsultaTabla { get; set; }
        public int Total { get; set; }
    }
}
