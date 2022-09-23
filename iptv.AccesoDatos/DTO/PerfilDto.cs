﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class PerfilDto
    {
        public int ID_PERFIL { get; set; } 
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public int ID_ESTATUS { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
        public List<OpcionDto> Opcion { get; set; }
    }
}
