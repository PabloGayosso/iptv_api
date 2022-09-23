using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Auditoria
    {
        public int ID_AUDITORIA { get; set; }
        public string DSC_AUDITORIA { get; set; }
        public int ID_USUARIO { get; set; }
        public string FCH_ACCION { get; set; }
        public string DSC_ACCION { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
        public int ID_APLICACION { get; set; }
        public int ID_SUCURSAL { get; set; }
        public string FCH_INICIO { get; set; }
        public string FCH_FIN { get; set; }
        public string CLAVE_USUARIO { get; set; }
        public string CLAVE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
    }
}
