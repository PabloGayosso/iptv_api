using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaUsuarioDto
    {
        public string CLAVE_USUARIO { get; set; }
        public string CONTRASENA { get; set; }
        public int ID_PERSONA { get; set; }
        public int ID_PERFIL { get; set; }
        public int ID_SUCURSAL { get; set; }
        public int ID_ESTATUS { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
