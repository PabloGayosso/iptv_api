using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Opciones
{
    public partial interface IDaoIptv
    {
        Task<List<Opcion>> ObtenerAsignado(int ID_PERFIL);
        Task<List<Opcion>> ObtnerNoAsignado(int ID_PERFIL);
        Task<int> AsignarOpcionesAsync(int ID_PERFIL, int ID_OPCION, string USUARIO);
        Task<int> EliminarAsignacionOpcionAsync(int ID_PERFIL);
    }
}
