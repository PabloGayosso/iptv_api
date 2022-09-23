using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Reproductor
    {
        public int ID_REPRODUCTOR { get; set; }
        public int CANTIDAD_VIDEOS { get; set; }
        public string DESCRIPCION { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public int ID_TIPO_DISPOSITIVO { get; set; }
        public string IP_CLIENTE { get; set; }
        public string PUERTO_CLIENTE { get; set; }
        public bool ACTUALIZACION { get; set; }
        public bool RELOJ { get; set; }
        public string RUTA_REPOSITORIO { get; set; }
        public string USUARIO { get; set; }
        public int ID_ESTATUS { get; set; }
        public string DIRECCION_MAC { get; set; }
        public int ID_GRUPO { get; set; }
        public Template template {get;set;}

    }
}
