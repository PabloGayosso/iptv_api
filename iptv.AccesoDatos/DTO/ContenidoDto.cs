using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ContenidoDto
    {
        public int ID_CONTENIDO { get; set; }
        public int ID_REPOSITORIO { get; set; }
        public int ID_MENSAJE { get; set; }
        public int ID_TABLA { get; set; }
        public int ID_TIPO_CANAL { get; set; }
        public string RUTA { get; set; }
        public string NOMBRE { get; set; }
        public int DURACION_SEG { get; set; }
        public int DURACION_MIN { get; set; }
        public int DURACION_HRS { get; set; }
        public int ORDEN { get; set; }
        public int POSICION_X { get; set; }
        public int POSICION_Y { get; set; }
        public int ANCHO { get; set; }
        public int ALTO { get; set; }
        public decimal OPACIDAD { get; set; }
        public string TEXTO { get; set; }
        public int ID_ESTATUS { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
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
        public bool enUso { get; set; }
        public int ID_CANAL_CONTENIDO { get; set; }
        public string FEC_FIN { get; set; }
        public string FEC_INICIO { get; set; }
        public int INICIO_SEG { get; set; }
        public int INICIO_MIN { get; set; }
        public int INICIO_HRS { get; set; }
        public int FIN_SEG { get; set; }
        public int FIN_MIN { get; set; }
        public int FIN_HRS { get; set; }
        public MensajeDto mensaje { get; set; }
        public TablaDTO tabla { get; set; }
        public RepositorioDto repositorio { get; set; }
    }
}
