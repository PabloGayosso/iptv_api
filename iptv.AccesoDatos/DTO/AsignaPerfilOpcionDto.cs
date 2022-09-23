using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AsignaPerfilOpcionDto
    {
        public int ID_PERFIL { get; set; }
        public List<OpcionDto> opcion { get; set; }
        public string USUARIO { get; set; }
    }
}
