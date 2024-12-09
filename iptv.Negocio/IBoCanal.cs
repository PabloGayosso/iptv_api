using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoCanal
    {
        Task<ConsultaCanalDto> CosultaCanales(int Pagina, int RegistrosPagina, string Busqueda);
        Task<CanalDto> ConsultaCanal(int ID_CANAL);
        Task<int> AltaCanal(AltaCanalDto canalDto);
        Task<int> ActulizaCanal(int ID_CANAL, AltaCanalDto canalDto);
        Task<List<CanalDto>> CanalesActivos();
        Task<int> CambioContenidoCanal(AltaCanalDto canalDto);
        Task EliminarCanalAsync(int canalId);

    }
}
