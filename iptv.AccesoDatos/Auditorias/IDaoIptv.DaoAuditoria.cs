using System;
using System.Collections.Generic;
using System.Text;
using iptv.AccesoDatos.Models;
using System.Threading.Tasks;

namespace iptv.AccesoDatos.Auditorias
{
    public partial interface IDaoIptv
    {
        Task<int> AltaAuditoriaAsync(Auditoria auditoria);
        Task<List<Auditoria>> ConsultaAuditoriaFechasAsync(string fchIni, string fchFin, int Pagina, int RegistrosPaginaS);
        Task<List<Auditoria>> ConsultaAuditoriaFechasAsync(string fchIni, string fchFin);


    }
}
