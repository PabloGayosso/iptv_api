using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaRepositorioDto
    {
        public string DESCRIPCION { get; set; }
        public string RUTA_ALOJAMIENTO { get; set; }
        public string EXTENCION { get; set; }
        public int ID_ESTATUS { get; set; }
        public string USUARIO { get; set; }
        public int ID_TIPO_CONTENIDO { get; set; }
    }
}
