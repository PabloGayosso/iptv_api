using iptv.AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iptv.AccesoDatos.Envio
{
    public partial interface IDaoIptv
    {
        Task<List<Envios>> Consulta_Envios_Async();
        Task<List<Envios>> Consulta_Envio_Estatus_Async(int id_Envio);
        Task<List<Envios>> Consulta_Envios_Post_Async(int idEnvio, string fec_Busqueda);
        Task<int> Consulta_Envios_H_Total();
        Task<List<Envios>> Consulta_Envios_H_Async(string Busqueda, int Pagina, int RegistrosPagina, string fec_Ini, string fec_Fin);
    }
}
