﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaPersonaDto
    {
        public string CLAVE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public int ID_ESTATUS { get; set; }
        public int ID_PAIS { get; set; }
        public string FECHA_NACIMIENTO { get; set; }
        public int ID_GENERO { get; set; }
        public int ID_ESTADO_CIVIL { get; set; }
        public int ID_ESCOLARIDAD { get; set; }
        public string OCUPACION { get; set; }
        public string RELIGIONb { get; set; }
        public string USUARIO { get; set; }
    }
}
