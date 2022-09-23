using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class MensajeVivo
    {
        public int ID_MENSAJE { get; set; }
        public int ID_ESTATUS { get; set; }
        public string DSC_MENSAJE { get; set; }
        public bool ES_REPETITIVO { get; set; }
        public TimeSpan TIEMPO_REPETICION { get; set; }
        public string FECHA_ALTA { get; set; }
        public string FECHA_MOD { get; set; }
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
        public string NOMBRE_GRUPO { get; set; }
        public string NOMBRE_RERODUCTOR { get; set; }
        

    }
}
