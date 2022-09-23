using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class RepositorioDto
    {
        public int ID_REPOSITORIO { get; set; }
        public int ID_TIPO_CONTENIDO { get; set; }
        public string DESCRIPCION { get; set; }
        public string RUTA_ALOJAMIENTO { get; set; }
        public string EXTENSION { get; set; }
        public int ID_ESTATUS { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
        public bool enUso { get; set; }
        public string rutaCatalogo { get; set; }
    }
}
