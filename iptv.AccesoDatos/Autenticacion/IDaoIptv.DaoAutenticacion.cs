using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Autenticacion
{
    public partial interface IDaoIptv
    {
        Task<Usuario> ValirdarUsuarioAsync(string USERNAME);
    }
}
