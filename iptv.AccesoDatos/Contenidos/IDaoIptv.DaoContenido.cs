using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Contenidos
{
    public partial interface IDaoIptv
    {
        Task<List<Contenido>> ObtenerContenidosAsync(string Busqueda, int Filtro, int Pagina, int RegistrosPagina);
        Task<Contenido> ObtenerContenidoAsync(int ID_CONTENIDO);
        Task<int> ObtenerTotalContenidosAsync();
        Task<int> AltaContenidoTvDirectoAsync(Contenido contenido);
        Task<int> AltaContenidoMultimediaAsync(Contenido contenido);
        Task<int> AltaContenidoTextoAsync(Contenido contenido);
        Task<int> AltaContenidoTablaoAsync(Contenido contenido);
        Task<int> ActulizaContenidoTvDirectoAsync(int ID_CONTENIDO, Contenido contenido);
        Task<int> ActulizaContenidoMultimediaAsync(int ID_CONTENIDO, Contenido contenido);
        Task<int> ActulizaContenidoTextoAsync(int ID_CONTENIDO, Contenido contenido);
        Task<int> ActulizaContenidoTablaAsync(int ID_CONTENIDO, Contenido contenido);
        Task<List<Contenido>> ConsultaContenidoActivos(int ID_ESTATUS, int ID_TIPO_CANAL);
        Task<List<Contenido>> ConsultaContenidoTextActivos(int ID_ESTATUS, int ID_TIPO_CANAL);
        Task<List<Contenido>> ConsultaContenidoMediaActivos(int ID_ESTATUS, int ID_TIPO_CANAL);
        Task<List<Contenido>> ConsultaContenidoTablaAtivos(int ID_ESTATUS, int ID_TIPO_CANAL);
        Task<List<Contenido>> ConsultaContenidoTablaAtivosNoAsignado(int ID_CANAL, int ID_ESTATUS, int ID_TIPO_CANAL);
        Task<List<Contenido>> ObtenerContenidosPorIdCanalAsync(int ID_CANAL);
    }
}
