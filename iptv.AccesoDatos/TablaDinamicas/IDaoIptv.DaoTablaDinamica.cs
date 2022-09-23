using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.TablaDinamicas
{
    public partial interface IDaoIptv
    {
        Task<int> CrearTablaASync(string NOMBRE_TABLA, string NOM_COLUMNAS, string USUARIO);
        Task<int> AltaDatosTablaAsync(int ID_TABLA, string REGISTRO);
        Task<bool> ConsultaTablaNombreAsync(string NOMBRE);
        Task<List<Tabla>> ConsultaTablasAsync(int Pagina, int RegistrosPorPagina);
        Task<List<Tabla>> ConsultaCatTabla();
        Task<int> ConsultaTablasTotalAsync();
        Task<Tabla> ConsultaTablaAsync(int ID_TABLA);
        Task<List<dynamic>> ConsultaTablaDinamicaAsync(int ID_TABLA);
    }
}
