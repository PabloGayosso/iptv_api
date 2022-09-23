using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaMensajeVivoDto
    {
        public List<MensajeVivoDto> mensajeVivoDto { get; set; }
        public int Total { get; set; }
    }
}
