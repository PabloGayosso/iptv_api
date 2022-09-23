using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Reproductores
{
    public partial interface IDaoIptv
    {
        Task<List<Reproductor>> ObtenerReproductoresAsync(int Pagina, int RegistrosPagina);
        Task<List<Reproductor>> ObtenerReproductoresCatalogoAsync();
        Task<List<Reproductor>> ObtenerReproductoresEstatusAsync(int Pagina, int RegistrosPagina, int ID_ESTATUS);
        Task<Reproductor> ObtenerReproductorAsync(int ID_REPRODUCTOR);
        Task<Reproductor> ObtenerReproductorTemplateAsync(int ID_REPRODUCTOR);
        Task<int> ObtenerTotalReproductoresAsync();
        Task<int> AltaReproductorAsync(Reproductor reproductor);
        Task<int> AltaReproductorTemplateAsync(int ID_REPRODUCTOR, int ID_TEMPLATE, int ID_ESTATUS, string USUARIOS);
        Task<int> ActulizaReproductorAsync(int ID_REPRODUCTOR, Reproductor reproductor);
        Task<int> ActulizaReproductorTemplateAsync(int ID_REPRODUCTOR, int ID_TEMPLATE, int ID_ESTATUS, string USUARIO);
        Task<int> EliminarReproductorAsync(int ID_REPRODUCTOR, Reproductor reproductor);
        Task<int> ActulizaReljAsync(int ID_REPRODUCTOR, Reproductor reproductor);
  }
}
