using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoColonia
    {
        Task<List<ColoniaDto>> ObtenerColniaIdDelegacionMunicipio(int ID_ESTADO, int ID_DELEG_MUNICIPIO);
    }
}
