using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;


namespace iptv.AccesoDatos.HorariosTerminal
{
    public partial interface IDaoIptv
    {
        Task<int> AltaHorarioTerminal(HorarioTerminal horariosTerminal);
        Task<int> ActulizaHorarioTerminal(HorarioTerminal horariosTerminal);
        Task<int> AltaGrupoHorario(int ID_GRUPO, int ID_HORARIO, string USAURIO);
        Task<int> EliminarHorarioGrupo(int ID_GRUPO);
        Task<HorarioTerminal> ConsultaHorariosGrupos(int ID_GRUPO);
        Task<List<HorarioTerminal>> ConsultaHorariosTerminal();
    }
}
