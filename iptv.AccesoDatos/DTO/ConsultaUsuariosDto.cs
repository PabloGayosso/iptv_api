using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaUsuariosDto
    {
        public List<UsuarioDto> usuario { get; set; }
        public int Total { get; set; }
    }
}
