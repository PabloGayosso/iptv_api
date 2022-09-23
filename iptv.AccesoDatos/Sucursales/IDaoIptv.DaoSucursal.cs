using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Sucursales
{
    public partial interface IDaoIptv
    {
        Task<Sucursal> ObtnerSucursalIdAsync(int ID_SUCURSAL);
    }
}
