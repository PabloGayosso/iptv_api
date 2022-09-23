using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaCanalDto
    {
        public List<CanalDto> canal { get; set; }
        public int Total { get; set; }
    }
}
