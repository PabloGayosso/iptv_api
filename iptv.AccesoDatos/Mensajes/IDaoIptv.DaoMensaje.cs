using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Mensajes
{
    public partial interface IDaoIptv
    {
        Task<List<Mensaje>> ObtenerMensajesAsync(string Busqueda, int Pagina, int RegistrosPagina);
        Task<List<Mensaje>> ObtenerCatMensajesAsync();
        Task<Mensaje> ObtenerMensajeAsync(int ID_MENSAJE);
        Task<int> AltaMensajeAsync(Mensaje mensaje);
        Task<int> ActulizaMensajeAsync(int ID_MENSAJE, Mensaje mensaje);
        Task<int> TotalMensajesAsync();
    }
}
