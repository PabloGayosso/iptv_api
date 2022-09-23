using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Colonias
{
    public interface IDaoIptv
    {
        Task<List<Colonia>> ObtenerColoniasIdDelegacionEstadoAsync(int ID_ESTADO, int ID_DELEG_MUNICIPIO);
    }
}
