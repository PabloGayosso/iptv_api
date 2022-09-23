using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iptv.AccesoDatos;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.Enum;
using iptv.Negocio.Utilidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace iptv.Negocio
{
    public class BoAutenticacion : IBoAutenticacion
    {
        IConfiguration configuration;
        IMapper _mapper;
        CifradoDatos cifrado;
        ValidarLicencia validarLicencia;
        public BoAutenticacion(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
            cifrado = new CifradoDatos(configuration);
            validarLicencia = new ValidarLicencia(configuration);
        }
        public async Task<AutenticarTokenDto> Autenticar(AutenticacionDto autenticacionDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Usuario usuario = await daoIptv.ValirdarUsuarioAsync(autenticacionDto.USERNAME);
                    if (usuario.ID_USUARIO > 0)
                    {
                        if (usuario.ID_ESTATUS != Convert.ToInt32(CatEstatus.INACTIVO))
                        {
                            Perfil perfil = await daoIptv.ObtnerPerfilAsync(usuario.ID_PERFIL);
                            if (perfil.ID_ESTATUS == (int)CatEstatus.ACTIVO)
                            {
                                var pass = cifrado.Desencriptar(usuario.CONTRASENA);
                                if (cifrado.Desencriptar(usuario.CONTRASENA) == autenticacionDto.PASSWORD)
                                {
                                    Persona persona = await daoIptv.ObtenerPersonaIdAsync(usuario.ID_PERSONA);
                                    Sucursal sucursal = await daoIptv.ObtnerSucursalIdAsync(usuario.ID_SUCURSAL);
                                    List<LicenciaActiva> licenciaActivas = await daoIptv.ObtenerLicenciaActivaAsync(Convert.ToInt32(CatEstatus.ACTIVO));
                                    //bool valido = await ValidarLIcencias(licenciaActivas, daoIptv);
                                    bool valido = true;
                                    if (valido)
                                    {
                                        string token = await GenerarToken(persona, usuario, sucursal, configuration);
                                        var autToken = new AutenticarTokenDto
                                        {
                                            Token = token
                                        };
                                        return autToken;
                                    }
                                    else
                                        throw new ExcepcionIptv("Producto con licencia caduca");
                                }
                                else
                                    throw new ExcepcionIptv("Contraseña incorrecta");
                            }
                            else
                                throw new ExcepcionIptv($"El usuario {autenticacionDto.USERNAME} tiene el perfil {perfil.NOMBRE} inactivo asignado");
                        }
                        else
                            throw new ExcepcionIptv($"Usuario {autenticacionDto.USERNAME} no activo");
                    }
                    else
                        throw new ExcepcionIptv($"Usuario {autenticacionDto.USERNAME} no registrado en el sistema");
                }
                catch (ExcepcionIptv)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public async Task<string> GenerarToken(Persona persona, Usuario Usuario, Sucursal sucursal, IConfiguration configuracion)
        {
            // Tu código para validar que el usuario ingresado es válido

            // Leemos el secret_key desde nuestro appseting
            var secretKey = configuracion.GetSection("SecretToken").Value;
            var key = Encoding.ASCII.GetBytes(secretKey);

            // Creamos los claims (pertenencias, características) del usuario
            var claims = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Email, $"{Usuario.CLAVE_USUARIO}"),
            new Claim("ID_APLICACION", $"{1}"),
            new Claim("ID_USUARIO", $"{Usuario.ID_USUARIO}"),
            new Claim("ID_PERFIL", $"{Usuario.ID_PERFIL}"),
            new Claim("ID_SUCURSAL", $"{sucursal.ID_SUCURSAL}"),
            new Claim("ID_PERSONA", $"{Usuario.ID_PERSONA}")
            });

            int Dias = Convert.ToInt32(configuracion.GetSection("DiasToken").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(Dias),
                Audience = "IPTV",
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }


        public async Task<string> GenerarToken(IConfiguration configuracion)
        {
            // Tu código para validar que el usuario ingresado es válido
            // Asumamos que tenemos un usuario válido
            var user = new UsuarioDto
            {
                CLAVE_USUARIO = "Eduardo",
                USUARIO = "admin@kodoti.com",
                ID_USUARIO = 95
            };

            // Leemos el secret_key desde nuestro appseting
            var secretKey = configuracion.GetSection("SecretKey").Value;
            var key = Encoding.ASCII.GetBytes(secretKey);

            // Creamos los claims (pertenencias, características) del usuario
            var claims = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, user.CLAVE_USUARIO),
            new Claim(ClaimTypes.Email, user.USUARIO),
            new Claim("ID_USUARIO", $"{ user.ID_USUARIO }")
        });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                Audience = "Licenciamiento",
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
        public async Task<SerialDTO> GetSerial()
        {
            try
            {
                SerialDTO serialdto = new SerialDTO()
                {
                    serialBios = cifrado.SerialNumberBios(),
                    serialBase = cifrado.SeralNumberBase()

                };
                return serialdto;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> ValidarLIcencias(List<LicenciaActiva> licenciaActivas, DaoIptv daoIptv)
        {
            try
            {
                if (licenciaActivas.Count > 0)
                {
                    bool valido = false;
                    foreach (LicenciaActiva licencia in licenciaActivas)
                    {
                        if (licencia.ID_ESTATUS != (int)CatEstatus.ACTIVO) continue;
                        var Lic = cifrado.DesencriptarLicencia(licencia.LICENCIA_ACTIVA);
                        var licc = Lic.Split("||");
                        var fecha = licc[licc.Length - 2];
                        DateTime fechaF = Convert.ToDateTime(fecha).Date;
                        DateTime FechAc = DateTime.Now.Date;

                        if (licencia.SERIAL_NUMBER_BIOS == cifrado.SerialNumberBios())
                        {
                            if (cifrado.Desencriptar(licencia.MAC_ADDRESS) == cifrado.ObtenerDireccionMAC())
                            {
                                if (fechaF <= FechAc) continue;
                                valido = true;
                                break;
                            }
                            else
                            {
                                await daoIptv.CambiarEstatusLicenciaAsync(licencia.ID_LICENCIA_ACTIVA, (int)CatEstatus.INACTIVO);
                                throw new ExcepcionIptv("Este producto tiene una direccion MAC distinta");
                            }
                        }
                        else
                        {
                            await daoIptv.CambiarEstatusLicenciaAsync(licencia.ID_LICENCIA_ACTIVA, (int)CatEstatus.INACTIVO);
                            throw new ExcepcionIptv("Este producto esta licenciado para otro disposiivo");
                        }
                    }
                    return valido;
                }
                else throw new ExcepcionIptv("¡Producto sin licencia!");
            }
            catch (ExcepcionIptv)
            {
                throw;
            }
        }
    }
}
