using System;
using System.Collections.Generic;
using System.Text;
using iptv.AccesoDatos.Models;
using System.Threading.Tasks;

namespace iptv.AccesoDatos.Repositorios
{
    public partial interface IDaoIptv
    {
        Task<int> EliminarRepositorioAsync(int ID_REPOSITORIO);
        Task<int> AltaRepositorioAsync(Repositorio repositorio);
        Task<List<Repositorio>> ConsultaRepositoriosAsync(string Busqueda, int ID_TIPO_CONTENIDO, int Pagina, int RegistrosPagina);
        Task<Repositorio> ConsultaRepositorioId(int ID_REPOSITORIO);
        Task<int> ObtenerTotalRepositoriosAsync();
        Task<List<Repositorio>> ConsultaRepositorioContenidoAsync(int ID_TIPO_CONTENIDO);
        Task<RepositorioDLNA> ContultarCatalogoRepositorioNombreAsync(string NOMBRE);
        Task<int> EliminarCatalogoRepositorioAsync(int ID_REPOSITORIO, string NOMBRE);
        Task<RepositorioDLNA> ConsultaCatalogoRepositorioAsync(int ID_REPOSITORIO); 
    }
}
