using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoContenido
    {
        Task<ConsultaContenidoDto> ConsultaContenidos(string Busqueda, int Filtro, int Pagina, int RegistrosPagina);
        Task<ContenidoDto> ConsultaContenido(int ID_CONTENIDO);
        Task<int> AltaContenido(AltaContenidoDto Contenido, string NombreCompleto, string NombreActual, string Nombre, string Extension, int tipoContenido);
        Task<int> ActulizaContenido(int ID_CONTENIDO, AltaContenidoDto contenidoDto);
        Task<List<ContenidoDto>> ConsultaContenidosActivos(int ID_CANAL, int ID_TIPO_CANAL);
        Task<int> EliminarContenido(int ID_CONTENIDO);
    Task<int> LimpiarRepositorioDLNA();
        Task<int> NuevoContenido(AltaContenidoDto contenidoDto);
        Task<ContenidoDto> AltaRepositorio(string NombreActual, string Nombre, string Extension, TimeSpan duration, int TipoContenido, string UsuarioRegistro);
    
  }
}
