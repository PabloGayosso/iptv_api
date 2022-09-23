using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.MensajesVivo
{
    public partial interface IDaoIptv
    {
        Task<List<MensajeVivo>> ObtenerMensajesVivoAsync(int Pagina, int RegistrosPagina);
        Task<MensajeVivo> ObtenerMensajeVivoAsync(int ID_MENSAJE);
        Task<int> AltaMensajeVivoAsync(MensajeVivo mensajeVivo);
        Task<int> AltaMensajeVivoReproductorAsync(int ID_GRUPO, int ID_REPRODUCTOR, int ID_MENSAJE, int ID_ESTATUS, string USUARIO);
        Task<int> ActulizaMensajeVivoAsync(int ID_MENSAJE, MensajeVivo mensajeVivo);
        Task<int> ActulizaMensajeVivoReproductorAsync(int ID_GRUPO_REPRODUCTOR_MENSAJE);
        Task<int> EliminarMensajeVivoReproductorAsync(int ID_MENSAJE, int ID_REPRODUCTOR);
        Task<int> EliminarMensajeVivoGrupoAsync(int ID_MENSAJE, int ID_GRUPO);
        Task<int> EliminarMensajeVivoAsync(int ID_MENSAJE);
    }
}
