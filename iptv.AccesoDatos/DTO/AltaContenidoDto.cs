using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaContenidoDto
    {
        public int ID_TIPO_CANAL { get; set; }
        public int ID_REPOSITORIO { get; set; }
        public int ID_MENSAJE { get; set; }
        public int ID_TABLA { get; set; }
        public string RUTA { get; set; }
        public string NOMBRE { get; set; }
        public int DURACION_SEG { get; set; }
        public int DURACION_MIN { get; set; }
        public int DURACION_HRS { get; set; }
        public int ORDEN { get; set; }
        public decimal OPACIDAD { get; set; }
        public string TEXTO { get; set; }
        public int ID_ESTATUS { get; set; }
        public string USUARIO { get; set; }
        public int TAMANIO_LETRA_TEXTO { get; set; }
        public string COLOR_FONDO_BARRA_TEXTO { get; set; }
        public decimal OPACIDAD_TEXTO { get; set; }
        public decimal OPACIDAD_BARRA_TEXTO { get; set; }
        public bool ES_REPETITIVO { get; set; }
        public string TIPO_LETRA_TEXTO { get; set; }
        public string COLOR_TEXTO { get; set; }
        public decimal VELOCIDAD_TEXTO { get; set; }
        public int ID_TIPO_PRESENTACION { get; set; }
        public int ID_FORMA_DESPLIEGUE { get; set; }
        public bool ES_COLOR_FONDO_TEXTO { get; set; }
        public string RUTA_IMG_FONDO_BARRA_TEXTO { get; set; }
        public int ORIENTACION_TEXTO { get; set; }
        public bool ES_INTERMITENCIA { get; set; }
        public int INTERMITENCIA_SEG { get; set; }
        public int INTERMITENCIA_MIN { get; set; }
        public int INTERMITENCIA_HRS { get; set; }
        public int VOLUMEN { get; set; }
        public MensajeDto Mensaje { get; set; }
        public RepositorioDto Repositorio { get; set; }
    }
}
