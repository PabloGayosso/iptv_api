using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaPersonasUsuariosDto
    {
        public List<PersonaUsuarioDto> personaUsuario { get; set; }
        public int Total { get; set; }
    }
}
