using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;


namespace iptv.Negocio
{
    public interface IBoMensajeVivo
    {
        Task<ConsultaMensajeVivoDto> ConsultaMensajesVivo(string Busqueda, int Pagina, int RegistrosPagina);
        Task<MensajeVivoDto> ConsultaMensajeVivo(int ID_MENSAJE);
        Task<ConsultaMensajeVivoDto> ConsultaMensajesVivoGrupRep(int Pagina, int RegistrosPagina);
        Task<MensajeVivoDto> ConsultaMensajeVivoGrupRep(int ID_GRUPO_REPRODUCTOR_MENSAJE);
        Task<int> AltaMensajeVivo(AltaMensajeVivoDto altaMensajeVivoDto);
        Task<int> ActulizaMensajeVivo(int ID_MENSAJE, AltaMensajeVivoDto altaMensajeVivoDto);


    }
}
