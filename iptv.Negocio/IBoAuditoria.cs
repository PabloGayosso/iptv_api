using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoAuditoria
    {
        Task<int> AltaAudiroria(AltaAuditoriaDto auditoriaDto);
        Task<ConsultaAuditoria> ConsultaAuditoriaFechas(string fchIni, string fchFin, int Pagina, int RegistrosPagina);
        Task<List<AuditoriaDto>> ConsultaAuditoriaFechas(string fchIni, string fchFin);

    }
}
