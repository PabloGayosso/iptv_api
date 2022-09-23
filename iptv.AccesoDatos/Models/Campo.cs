using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Campo
    {
        public int ID_CAMPO { get; set; }
        public string NOMBRE_CAMPO { get; set; }
        public string ETIQUETA { get; set; }
        public int ID_TIPO_DATO { get; set; }
        public int TAMAÑO { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
    }
}
