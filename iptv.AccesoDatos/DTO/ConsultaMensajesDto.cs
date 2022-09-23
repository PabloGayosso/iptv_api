using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaMensajesDto
    {
        public List<MensajeDto> mensaje { get; set; }
        public int Total { get; set; }
    }
}
