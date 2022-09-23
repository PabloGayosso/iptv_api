using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.DelegacionesMucipios
{
    public partial interface IDaoIptv
    {
        Task<List<DelegacionMunicipio>> ObtenerDelagacionMunicipioAsync(int ID_ESTADO);
    }
}
