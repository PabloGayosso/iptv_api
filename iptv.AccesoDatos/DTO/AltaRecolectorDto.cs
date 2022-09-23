using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaRecolectorDto
    {
        public int ID_TEMPLATE { get; set; }
        public string ARCHIVO_XML { get; set; }
        public bool ACTULIZACION { get; set; }
        public int ID_ESTATUS { get; set; }
        public string USUARIO { get; set; }
    }
}
