﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class ConsultaContenidoDto
    {
        public List<ContenidoDto> contenido { get; set; }
        public int Total { get; set; }
    }
}
