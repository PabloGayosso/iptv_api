using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaRepositorioDto
    {
        public List<RepositorioDto> repositorio { get; set; }
        public int Total { get; set; }
    }
}
