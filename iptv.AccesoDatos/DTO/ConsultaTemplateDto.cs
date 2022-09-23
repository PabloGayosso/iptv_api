using iptv.AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaTemplateDto
    {
        public List<TemplateDto> template { get; set; }
        public int Total { get; set; }
    }
}
