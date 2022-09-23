using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoMensaje
    {
        Task<ConsultaMensajesDto> ConsultarMensajes(string Busqueda, int Pagina, int RegistrosPagina);
        Task<List<MensajeDto>> ConsultaCatMensajes();
        Task<MensajeDto> ConsultaMensaje(int ID_MENSAJE);
        Task<int> AltaMensaje(AltaMensajeDto mensajeDto);
        Task<int> ActulizaMensaje(int ID_MENSAJE, AltaMensajeDto mensajeDto);
    }
}
