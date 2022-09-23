using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaPersonaDto
    {
        public List<PersonaDto> persona { get; set; }
        public int Total { get; set; }
    }
}
