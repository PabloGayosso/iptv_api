using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class UsuarioDto
    {
        public int ID_USUARIO { get; set; }
        public string CLAVE_USUARIO { get; set; }
        public string CONTRASENA { get; set; }
        public int ID_PERSONA { get; set; }
        public int ID_PERFIL { get; set; }
        public int ID_EMPRESA { get; set; }
        public int ID_SUCURSAL { get; set; }
        public int ID_ESTATUS { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string Estatus { get; set; }
        public string Perfil { get; set; }
    }
}
