using iptv.AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoTablaDinamica
    {
        Task<int> AltaTablaDinamica(string TablaDinamicaDto);
        Task<List<TablaDTO>> CatalogoTablas();
        Task<ConsultaTablaDinamicaDTO> ObtnerTablas(int Pagina, int RegistroPorPagina);
        Task<List<dynamic>> ObtenerTablaDinamicaIDTabla(int ID_TABLA);
    }
}
