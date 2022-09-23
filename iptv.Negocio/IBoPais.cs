using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoPais
    {
        Task<List<PaisDto>> ConsultaPaises();
        Task<PaisDto> ConsultaPais(int ID_PAIS);
    }
}
