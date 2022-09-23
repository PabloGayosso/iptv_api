using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaAuditoria
    {
        public List<AuditoriaDto> auditoria { get; set; }
        public int total { get; set; }

    }
}
