using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;


namespace iptv.Negocio
{
    public interface IBoGrupo
    {
        Task<ConsultaGruposDto> CosultaGrupos(string Busqueda, int Pagina, int RegistrosPagina);
        Task<List<GrupoDto>> CosultaGruposCatalogo(int Opcion);
        Task<GrupoDto> ConsultaGrupo(int ID_GRUPO);
        Task<int> AltaGrupo(AltaGrupoDto altaGrupoDto);
        Task<int> ActulizaGrupo(int ID_GRUPO, AltaGrupoDto altaGrupoDto);

    }
}
