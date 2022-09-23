using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Parametros
{
    public partial interface IDaoIptv
    {
        Task<List<Parametro>> ObtenerParametroAsync();
        Task<Parametro> ObtenerParametroIdAsync(int ID_PARAMETRO);
        Task<List<Parametro>> ObtenerParametroFontsAsync();
        Task<List<Parametro>> ObtnerCatalogoAsync(int Pagina, int RegistrosPagina);
        Task<List<Parametro>> ObtenerParametroIdPadreAsync(int Pagina, int RegistrosPagina, int Parametro);
        Task<List<Parametro>> ObtenerComboAsync(int ID_PADRE);
        Task<int> AltaParametroAsync(Parametro parametro);
        Task<int> ActulizaParametroAsync(Parametro parametro);
        Task<int> AltaParametroCatalogoAsync(Parametro parametro);
        Task<int> ActulizaParametroCatalogoAsync(Parametro parametro);
        Task<int> ObtenerTotalParametrosAsync(int Parametro);
        Task<int> ObtenerTotalCatalogoAsync();
    }
}
