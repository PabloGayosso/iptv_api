using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;

namespace iptv.Negocio
{
    public interface IBoOpcion
    {
        Task<List<OpcionDto>> ObtnerAsignado(int ID_PERFIL);
        Task<List<OpcionDto>> ObtnerNoAsignado(int ID_PERFIL);
        Task<int> AsginarOpcion(AsignaPerfilOpcionDto perfilDto);
    }
}
