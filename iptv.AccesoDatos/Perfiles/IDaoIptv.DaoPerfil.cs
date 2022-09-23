using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Perfiles
{
    public partial interface IDaoIptv
    {
        Task<List<Perfil>> ObtenerPerfilesAsync(string Busqueda, int Pagina, int RegistrosPagina);
        Task<Perfil> ObtnerPerfilAsync(int ID_PERFIL);
        Task<int> AltaPerfilAsync(Perfil perfil);
        Task<int> ActulizaPerfilAsync(Perfil perfil);
        Task<Perfil> ObtenerPerfilOpcionAsync(int ID_PERFIL);
        Task<int> ObtenerTotalPerfilesAsync();
        Task<List<Perfil>> ObtenerPerfilesActivosAsync(int ID_ESTATUS); 
    }
}
