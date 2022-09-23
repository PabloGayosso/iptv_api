using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoPersona
    {
        Task<PersonaDto> ObtenerPersona(int ID_PERSONA);
        Task<ConsultaPersonaUsuarioDto> ObtenerPersonaUsuario(int ID_PERSONA);
        Task<ConsultaPersonaDto> ObtenerPersonas(int Pagina, int RegistrosPagina);
        Task<ConsultaPersonasUsuariosDto> ObtenerPersonasUsuarios(string Busqueda, int Pagina, int RegistrosPagina);

        Task<int> AltaPersona(AltaPersonaDto personaDto);
        Task<int> AltaPersonaUsuario(AltaPersonaUsuarioDto personaUsuarioDto);
        Task<int> ActulizaPersona(int ID_PERSONA, AltaPersonaDto personaDto);
        Task<int> ActulizaPersonaUsuario(int ID_PERSONA, AltaPersonaUsuarioDto personaDto);

        Task<List<PersonaDto>> ObtenerPersonasActivas();
    }
}
