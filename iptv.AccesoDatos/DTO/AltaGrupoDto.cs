using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaGrupoDto
    {
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public int CANTIDAD_REPRODUCTORES { get; set; }
        public string FECHA_ALTA { get; set; }
        public string FECHA_MOD { get; set; }
        public string USUARIO { get; set; }
        public int ID_ESTATUS { get; set; }
        public int ID_TEMPLATE { get; set; }
        public List<ReproductorDto> reproductores { get; set; }

    }
}
