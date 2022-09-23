using iptv.AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoDelegacionMunicipio
    {
        Task<List<DelegacionMunicipioDto>> ObtenerDelegacionMunicipioEstado(int ID_ESTADO);
    }
}
