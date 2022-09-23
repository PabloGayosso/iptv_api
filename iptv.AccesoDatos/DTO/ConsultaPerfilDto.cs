using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaPerfilDto
    {
        public List<PerfilDto> perfil { get; set; }
        public int Total { get; set; }
    }
}
