using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaGruposDto
    {
        public List<GrupoDto> grupoDto { get; set; }
        public int Total { get; set; }
    }
}
