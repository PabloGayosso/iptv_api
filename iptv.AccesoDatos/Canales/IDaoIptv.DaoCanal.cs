using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Canales
{
    public partial interface IDaoIptv
    {
        Task<List<Canal>> ConsultaCanalesAsync(int Pagina, int RegistrosPagina);
        Task<Canal> ConsultaCanalAsync(int ID_CANAL);
        Task<int> ConsultaTotalCanales();
        Task<int> AltaCanalAsync(Canal canal);
        Task<int> ActulizaCanalAsync(int ID_CANAL, Canal canal);
        Task<List<Canal>> ConsultaCanalesActivosAsync(int iD_ESTATUS);
        Task<int> CambioDeContenido(int ID_CANAL, int ID_CONTENIDO_NUEVO, int ID_CONTENIDO_ANT, string USUARIO);
    }
}
