using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;

namespace iptv.Negocio
{
    public interface IBoRepositorio
    {
        Task<int> AltaRepositorio(string NombreActual, string Nombre, string Extencion, int TipoContenido, string UsuarioRegistro);
        Task<ConsultaRepositorioDto> ObtnerRepositorios(string Busqueda, int ID_TIPO_CONTENIDO, int Pagina, int RegistrosPagina);
        Task<List<RepositorioDto>> ObtenerRepositorioTipoContenido(int ID_TIPO_CONTENIDO);
        Task<int> EliminarRepositorio(int ID_REPOSITORIO);
        Task<RepositorioDto> ObtenerRepositorio(int ID_REPOSITORIO);
        Task<RepositorioDLNADto> ObtenerCatalogoRepositorioNombre(string NOMBRE);
        Task<RepositorioDLNADto> ObtenerCatalogoRepositorio(int ID_REPOSITORIO);
        Task<int> EliminarCatalogoRepositorio(int ID_REPOSITORIO, string NOMBRE);
    }
}
