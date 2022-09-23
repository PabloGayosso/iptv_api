using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Recolectores
{
    public partial interface IDaoIptv
    {
        Task<List<Recolector>> ConsultaRecolectoresAsync();
        Task<Recolector> ConsultaRecolectorAsync(int ID_RECOLECTOR);
        Task<int> AltaRecolectorAsync(Recolector recolector);
        Task<int> ConsultaRecolectorAsync(int ID_RECOLECTOR, Recolector recolector);
        Task<Recolector> CosultaRecolectorTemplate(int ID_TEMPLATE);
    }
}
