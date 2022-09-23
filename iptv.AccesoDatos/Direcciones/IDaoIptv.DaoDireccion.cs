using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Direcciones
{
    public partial interface IDaoIptv
    {
        Task<List<Direccion>> ObtenerDireccionesAsync(int Pagina, int RegistrosPagina);
        Task<Direccion> ObtenerDireccionAsync(int ID_DIRECCION);
        Task<int> AltaDireccionAsync(Direccion direccion);
        Task<int> ActulizaDireccionAsync(int ID_DIRECCION, Direccion direccion);
        Task<int> ObtenerTotalDireccionesAsync();
        Task<int> AltaDireccionPersonaAsync(int ID_DIRECCION, int ID_PERSONA, string USUARIO);
        Task<int> EliminarDireccionesPersonasAsync(int ID_DIRECCION);
    }
}
