using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;


namespace iptv.Negocio
{
    public interface IBoReproductor 
    {
        Task<ConsultaReproductoresDto> CosultaReproductores(string Busqueda, int Pagina, int RegistrosPagina);
        Task<List<ReproductorDto>> CosultaReproductoresCatalogo(int Opcion);
        Task<ReproductorDto> ConsultaReproductor(int ID_REPRODUCTOR);
        Task<int> AltaReproductor(AltaReproductorDto reproductorDto);
        Task<int> ActulizaReproductor(int ID_REPRODUCTOR, AltaReproductorDto reproductorDto);
        Task<int> EliminaReproductor(int ID_REPRODUCTOR);
        Task<int> ActulizaReloj(int ID_REPRODUCTOR, AltaReproductorDto reproductorDto);
  }
}
