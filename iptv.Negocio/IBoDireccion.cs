using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;

namespace iptv.Negocio
{
    public interface IBoDireccion
    {
        Task<ConsultaDireccionDto> ConsultaDirecciones(int Pagina, int RegistrosPagina);
        Task<DireccionDto> ConsultaDireccion(int ID_DIRECCION);
        Task<int> AltaDireccion(AltaDireccionDto direccionDto);
        Task<int> ActulizaDireccion(int ID_DIRECCION, AltaDireccionDto altaDireccionDto);
    }
}
