using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Grupos
{
    public partial interface IDaoIptv
    {
        Task<List<Grupo>> ObtenerGruposAsync(int Pagina, int RegistrosPagina);
        Task<List<Grupo>> ObtenerGrupoCatalogoAsync();
        Task<int> ObtenerTotalGruposAsync();
        Task<Grupo> ObtenerGrupoAsync(int ID_GRUPO);
        Task<int> AltaGrupoAsync(Grupo grupo);
        Task<int> ActulizaGrupoAsync(int ID_GRUPO, Grupo grupo);

    }
}
