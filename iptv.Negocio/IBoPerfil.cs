using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoPerfil
    {
        Task<ConsultaPerfilDto> ObtnerPerfiles(string Busqueda, int Pagina, int RegistrosPagina);
        Task<PerfilDto> ObtnerPerfil(int ID_PERFIL);
        Task<PerfilDto> ObtenerPerfilOpcion(int ID_PERFIL);
        Task<int> AltaPerfil(AltaPerfilDto perfilDto);
        Task<int> ActulizaPerfil(int ID_PERFIL, AltaPerfilDto perfilDto);
        Task<List<PerfilDto>> ObtenerPerfilesActivos();
    }
}
