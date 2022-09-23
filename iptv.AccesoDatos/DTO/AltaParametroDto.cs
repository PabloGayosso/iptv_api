using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaParametroDto
    {
        public int PARAMETRO { get; set; }
        public int CONSECUTIVO { get; set; }
        public string CLAVE { get; set; }
        public string DESCRIPCION { get; set; }
        public bool PREDETERMINADO { get; set; }
        public decimal FACTOR { get; set; }
        public string USUARIO { get; set; }
    }
}
