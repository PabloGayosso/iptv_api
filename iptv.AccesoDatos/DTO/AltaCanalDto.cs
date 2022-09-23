using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaCanalDto
    {
        public int ID_TIPO_CANAL { get; set; }
        public string CLAVE { get; set; }
        public int CANTIDAD_CONTENIDO { get; set; }
        public int ID_ESTATUS { get; set; }
        public string USUARIO { get; set; }
        public int ALTO { get; set; }
        public int ANCHO { get; set; }
        public int POSICION_X { get; set; }
        public int POSICION_Y { get; set; }
        public int ORDEN { get; set; }
        public List<ContenidoDto> contenidos { get; set; }
    }
}
