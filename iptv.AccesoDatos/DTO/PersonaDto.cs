using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class PersonaDto
    {
        public int ID_PERSONA { get; set; }
        public string CLAVE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string NOMBRE { get; set; }
        public int ID_TIPO_PERSONA { get; set; }
        public int ID_PERFIL { get; set; }
        public int ID_GENERO { get; set; }
        public int ID_ESTATUS { get; set; }
        public int ID_PAIS { get; set; }
        public string NACIONALIDAD { get; set; }
        public string FECHA_NACIMIENTO { get; set; }
        public string FECHA_ALTA { get; set; }
        public string FECHA_MOD { get; set; }
        public string USUARIO { get; set; }
    }
}
