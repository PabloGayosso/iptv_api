using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class HorarioTerminalDto
    {
		public int IdTvHorarioTerminal { get; set; }
		public TimeSpan horaEncendio { get; set; }
		public TimeSpan horaApagado { get; set; }
		public bool idEstatus { get; set; }
		public string fechaAlta { get; set; }
		public string fechaModificacion { get; set; }
		public string usuario { get; set; }
		public GrupoDto grupo { get; set; }
	}
}
