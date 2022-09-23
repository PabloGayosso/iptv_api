using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoUsuario
    {
        Task<ConsultaUsuariosDto> ObtenerUsuarios(int Pagina, int RegistrosPagina);
        Task<UsuarioDto> ObtenerUsuario(int ID_USUARIO);
        Task<int> AltaUsuraio(AltaUsuarioDto usuarioDto);
        Task<int> ActulizaUsuraio(int ID_USUARIO, AltaUsuarioDto usuarioDto);
        Task<List<UsuarioDto>> ObtenerUsuarios();
    }
}
