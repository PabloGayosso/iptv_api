using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Usuarios
{
    public partial interface IDaoIptv
    {
        Task<List<Usuario>> ObtenerUsariosAsync(int Pagina, int RegistrosPagina);
        Task<List<Usuario>> ObtenerUsariosAsync();
        Task<Usuario> ObtenerUsuarioAsync(int ID_USUARIO);
        Task<int> AltaUsuarioAsync(Usuario usuario);
        Task<int> ActulizaUsuarioAsync(int ID_USUARIO, Usuario usuario);
        Task<int> ObtenerTotalUsuariosAsync();
    }
}
