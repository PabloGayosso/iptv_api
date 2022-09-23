using System;
using System.Collections.Generic;
using System.Text;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace iptv.Negocio
{
    public interface IBoAutenticacion
    {
        Task<AutenticarTokenDto> Autenticar(AutenticacionDto autenticacionDto);
        Task<string> GenerarToken(Persona persona, Usuario usuario, Sucursal sucursal, IConfiguration configuration);
    Task<SerialDTO> GetSerial();  
    }
}
