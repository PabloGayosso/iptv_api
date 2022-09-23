using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaReproductorDto
    {
        public int CANTIDAD_VIDEOS { get; set; }
        public string DESCRIPCION { get; set; }
        public int ID_TIPO_DISPOSITIVO { get; set; }
        public string IP_CLIENTE { get; set; }
        public string PUERTO_CLIENTE { get; set; }
        public bool ACTUALIZACION { get; set; }
        public string RUTA_REPOSITORIO { get; set; }
        public string USUARIO { get; set; }
        public int ID_ESTATUS { get; set; }
        public int ID_TEMPLATE { get; set; }
        public int ID_GRUPO { get; set; }
        public string DIRECCION_MAC { get; set; }

    }
}
