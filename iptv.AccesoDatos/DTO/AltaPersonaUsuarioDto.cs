using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaPersonaUsuarioDto
    {
        public string CLAVE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public int ID_ESTATUS { get; set; }
        public string CLAVE_USUARIO { get; set; }
        public string CONTRASENA { get; set; }
        public int ID_PERFIL { get; set; }
        public string USUARIO { get; set; }

    }
}
