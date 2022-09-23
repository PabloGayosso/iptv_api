using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoParametro
    {
        Task<ConsultaParametrosDto> ObtenerParametros(int Pagina, int RegistrosPagina, int Parametro);
        Task<List<ParametroDto>> ObtenerParametrosFont();
        Task<ConsultaParametrosDto> ObtenerCatalogo(int Pagina, int RegistrosPagina);
        Task<List<ParametroDto>> ObtenerCombo(int ID_PADRE);
        Task<ParametroDto> ObtenerParametro(int ID_PARAMETRO);
        Task<int> AltaParametro(AltaParametroDto parametroDto);
        Task<int> ActulizaParametro(int ID_PARAMETRO, AltaParametroDto parametroDto);
        Task<int> AltaParametroCatalogo(AltaParametroDto parametroDto);
        Task<int> ActulizaParametroCatalogo(int ID_PARAMETRO, AltaParametroDto parametroDto);
    }
}
