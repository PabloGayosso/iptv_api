using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class TemplateCanal
    {
        public int ID_CANAL_TEMPLATE { get; set; }
        public int ID_TEMPLATE { get; set; }
        public int ID_CANAL { get; set; }
        public int ID_ESTATUS { get; set; }
        public int ALTO { get; set; }
        public int ANCHO { get; set; }
        public int POSICION_X { get; set; }
        public int POSICION_Y { get; set; }
        public int ORDEN { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
        public List<Canal> canales { get; set; }
    }
}
