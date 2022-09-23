using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iptv.Negocio
{
    public interface IBoEnvios
    {
        Task<Consulta_EnviosDto> Consulta_Envios_Async();
        Task<EnviosDto> Consulta_Envio_Estatus_Async(int id_Envio);
        Task<Consulta_EnviosDto> Consulta_Envios_Post_Async(int idEnvio, string fec_Busqueda);
        Task<Consulta_EnviosHDto> Consulta_Envios_H_Async(int Pagina, int RegistrosPagina, string fec_Ini, string fec_Fin);
    }
}
