using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class GrupoDto
    {
        public int ID_GRUPO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public int CANTIDAD_REPRODUCTORES { get; set; }
        public string FECHA_ALTA { get; set; }
        public string FECHA_MOD { get; set; }
        public string USUARIO { get; set; }
        public int ID_ESTATUS { get; set; }
        public int ID_TEMPLATE { get; set; }
        public string TEMPLATE_NOMBRE { get; set; }
        public List<ReproductorDto> reproductores { get; set; }

    }
}
