using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Colonia
    {
        public int ID_COLONIA { get; set; }
        public int ID_DELEG_MUNICIPIO { get; set; }
        public int ID_ESTADO { get; set; }
        public int ID_TIPO_ASENTAMIENTO { get; set; }
        public string CODIGO_POSTAL { get; set; }
        public string DESC_COLONIA { get; set; }
        public string DESC_CUIDAD { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
    }
}
