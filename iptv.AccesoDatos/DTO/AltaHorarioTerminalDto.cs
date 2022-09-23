using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaHorarioTerminalDto
    {
		public TimeSpan horaEncendio { get; set; }
		public TimeSpan horaApagado { get; set; }
		public bool idEstatus { get; set; }
		public string usuario { get; set; }
		public GrupoDto grupo { get; set; }
	}
}
