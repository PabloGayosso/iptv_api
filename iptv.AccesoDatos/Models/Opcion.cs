using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Opcion
    {
        public int ID_OPCION { get; set; }
        public int ID_SUCURSAL { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string URL_ICON { get; set; }
        public string URL { get; set; }
        public int ID_ESTATUS { get; set; }
        public int OPCION_PADRE { get; set; }
        public int NIVEL { get; set; }
        public int ORDEN { get; set; }
        public string FEC_MOD { get; set; }
        public string FEC_ALTA { get; set; }
        public string USUARIO { get; set; }
    }
}
