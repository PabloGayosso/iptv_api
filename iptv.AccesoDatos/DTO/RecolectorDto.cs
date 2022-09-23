using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class RecolectorDto
    {
        public int ID_RECOLECTOR { get; set; }
        public int ID_TEMPLATE { get; set; }
        public string ARCHIVO_XML { get; set; }
        public bool ACTULIZACION { get; set; }
        public int ID_ESTATUS { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
    }
}
