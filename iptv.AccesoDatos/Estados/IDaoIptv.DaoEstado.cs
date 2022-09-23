using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Estados
{
    public partial interface IDaoIptv
    {
        Task<List<Estado>> ObtenerEstadosAsync();
    }
}
