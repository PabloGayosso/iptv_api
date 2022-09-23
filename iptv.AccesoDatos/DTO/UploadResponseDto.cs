using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class UploadResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public string nombreFile { get; set; }
        public int ID_CONTENIDO { get; set; }
        public ContenidoDto contenido { get; set; }
    }
}
