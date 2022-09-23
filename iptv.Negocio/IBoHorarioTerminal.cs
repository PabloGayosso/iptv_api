using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoHorarioTerminal
    {
        Task<int> AltaHorarioTerminal(AltaHorarioTerminalDto horarioTerminalDto);
        Task<int> ActulizaHorarioTerminal(int IdTvHorarioTerminal, AltaHorarioTerminalDto horarioTerminalDto);
        Task<int> AltaHorarioGrupo(AltaHorarioTerminalDto horarioTerminalDto);
        Task<HorarioTerminalDto> ObtenerHorarioGrupo(int ID_GRUPO);
        Task<List<HorarioTerminalDto>> ObtenerHorarioTerminal();
    }
}
