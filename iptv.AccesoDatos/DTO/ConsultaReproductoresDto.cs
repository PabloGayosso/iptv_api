using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaReproductoresDto
    {
        public List<ReproductorDto> reproductor { get; set; }
        public int Total { get; set; }
    }
}
