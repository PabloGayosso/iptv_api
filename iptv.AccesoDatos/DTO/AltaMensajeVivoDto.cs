using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaMensajeVivoDto
    {
        public int ID_ESTATUS { get; set; }
        public string DSC_MENSAJE { get; set; }
        public bool ES_REPETITIVO { get; set; }
        public string TIEMPO_REPETICION { get; set; }
        public string USUARIO { get; set; }
        public string COLOR_FONDO_BARRA_TEXTO { get; set; }
        public decimal OPACIDAD_TEXTO { get; set; }
        public decimal OPACIDAD_BARRA_TEXTO { get; set; }
        public string TIPO_LETRA_TEXTO { get; set; }
        public int TAMANIO_LETRA_TEXTO { get; set; }
        public string COLOR_TEXTO { get; set; }
        public decimal VELOCIDAD_TEXTO { get; set; }
        public int ID_GRUPO { get; set; }
        public int ID_REPRODUCTOR { get; set; }
        public int ID_GRUPO_REPRODUCTOR_MENSAJE { get; set; }

    }
}
