using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Paises
{
    public partial interface IDaoIptv
    {
        Task<List<Pais>> ConsultaPaisesAsync();
        Task<Pais> ConsultaPaisAsync(int ID_PAIS);
    }
}
