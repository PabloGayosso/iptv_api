using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaAuditoriaDto
    {
        public string DSC_AUDITORIA { get; set; }
        public int ID_USUARIO { get; set; }
        public string FCH_ACCION { get; set; }
        public string DSC_ACCION { get; set; }
        public string USUARIO { get; set; }
        public int ID_APLICACION { get; set; }
        public int ID_SUCURSAL { get; set; }
    }
}
