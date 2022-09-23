using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaTemplateDto
    {
        public int ALTO { get; set; }
        public int ANCHO { get; set; }
        public int CANTIDAD_REGIONES { get; set; }
        public string NOMBRE { get; set; }
        public string USUARIO { get; set; }
        public int ID_ESTATUS { get; set; }
        public List<CanalDto> canales { get; set; } 
    }
}
