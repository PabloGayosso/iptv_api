using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Parametro
    {
        public int ID_PARAMETRO { get; set; }
        public int PARAMETRO { get; set; }
        public int CONSECUTIVO { get; set; }
        public string CLAVE { get; set; }
        public string DESCRIPCION { get; set; }
        public int PREDETERMINADO { get; set; }
        public int FACTOR { get; set; }
        public int ID_APLICACION_IST { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
    }
}
