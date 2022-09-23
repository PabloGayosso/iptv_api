using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Personas
{
    public partial interface IDaoIptv
    {
        Task<Persona> ObtenerPersonaIdAsync(int ID_PERSONA);
        Task<List<Persona>> ObtenerPersonasAsync(int Pagina, int RegistrosPagina);
        Task<int> ObtenerTotalPersonasAsync();
        Task<int> AltaPersonaAsync(Persona persona);
        Task<int> ActulizaPersonaAsync(int ID_PERSONA, Persona persona);
        Task<List<Persona>> ObtenerPersonasActivas(int ID_ESTATUS);


    }
}
