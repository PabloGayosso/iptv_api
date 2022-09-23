using iptv.AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class TemplateDto
    {
        public int ID_TEMPLATE { get; set; }
        public int ALTO { get; set; }
        public int ANCHO { get; set; }
        public int CANTIDAD_REGIONES { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string NOMBRE { get; set; }
        public string USUARIO { get; set; }
        public int ID_ESTATUS { get; set; }
        public List<TemplateCanal> templateCanal { get; set; }
        public List<CanalDto> canal { get; set; }
    }
}
