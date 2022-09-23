using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Entidad
    {
        public int ID_ENTIDAD { get; set; }
        public string CLAVE_IS { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string RFC { get; set; }
        public bool ES_GRUPO { get; set; }
        public int ID_ESTATUS { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set;  }
    }
}
