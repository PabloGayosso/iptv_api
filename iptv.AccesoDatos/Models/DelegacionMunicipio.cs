using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class DelegacionMunicipio
    {
        public int ID_DELEG_MUNICIPIO { get; set; }
        public int ID_ESTADO { get; set; }
        public string DSC_DELEG_MUNICIPIO { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
    }
}
