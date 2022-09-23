using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos;
using iptv.Negocio.Utilidades;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using iptv.AccesoDatos.Enum;

namespace iptv.Negocio
{
    public class BoPersona : IBoPersona
    {
        IConfiguration configuration;
        IMapper _mapper;
        CifradoDatos cifrado;

        public BoPersona(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
            cifrado = new CifradoDatos(configuration);
        }
        public async Task<List<PersonaDto>> ObtenerPersonasActivas()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Persona> personas = await daoIptv.ObtenerPersonasActivas((int)CatEstatus.ACTIVO);
                    List<PersonaDto> personaDto = _mapper.Map<List<PersonaDto>>(personas);
                    return personaDto;
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
        public async Task<PersonaDto> ObtenerPersona(int ID_PERSONA)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Persona persona = await daoIptv.ObtenerPersonaIdAsync(ID_PERSONA);
                    PersonaDto personaDto = _mapper.Map<PersonaDto>(persona);
                    return personaDto;
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

        public async Task<ConsultaPersonaUsuarioDto> ObtenerPersonaUsuario(int ID_PERSONA)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Persona persona = await daoIptv.ObtenerPersonaIdAsync(ID_PERSONA);
                    Usuario usuario = await daoIptv.ObtenerUsuarioIdPersonaAsync(ID_PERSONA);

                    PersonaDto personaDto = _mapper.Map<PersonaDto>(persona);
                    UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(usuario);

                    ConsultaPersonaUsuarioDto consultaPersonaUsuarioDto = new ConsultaPersonaUsuarioDto();
                    consultaPersonaUsuarioDto.CLAVE = personaDto.CLAVE;
                    consultaPersonaUsuarioDto.NOMBRE = personaDto.NOMBRE;
                    consultaPersonaUsuarioDto.APELLIDO_MATERNO = personaDto.APELLIDO_MATERNO;
                    consultaPersonaUsuarioDto.APELLIDO_PATERNO = personaDto.APELLIDO_PATERNO;
                    consultaPersonaUsuarioDto.ID_ESTATUS = personaDto.ID_ESTATUS;
                    consultaPersonaUsuarioDto.ID_PERFIL = usuarioDto.ID_PERFIL;
                    consultaPersonaUsuarioDto.CLAVE_USUARIO = usuarioDto.CLAVE_USUARIO;
                    if(usuarioDto.CONTRASENA!=null && usuarioDto.CONTRASENA.Length>0)
                        consultaPersonaUsuarioDto.CONTRASENA = cifrado.Desencriptar(usuarioDto.CONTRASENA);

                    return consultaPersonaUsuarioDto;
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
        public async Task<ConsultaPersonaDto> ObtenerPersonas(int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Persona> personas = await daoIptv.ObtenerPersonasAsync(Pagina, RegistrosPagina);
                    List<PersonaDto> personaDto = _mapper.Map<List<PersonaDto>>(personas);
                    int total = await daoIptv.ObtenerTotalPersonasAsync();
                    ConsultaPersonaDto consulta = new ConsultaPersonaDto()
                    {
                        persona = personaDto,
                        Total = total
                    };
                    return consulta;
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
        public async Task<ConsultaPersonasUsuariosDto> ObtenerPersonasUsuarios(string Busqueda, int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<PersonasUsuarios> personasUsuarios = await daoIptv.ObtenerPersonasUsuariosAsync(Busqueda, Pagina, RegistrosPagina);
                    List<PersonaUsuarioDto> personasUsuariosDto = _mapper.Map<List<PersonaUsuarioDto>>(personasUsuarios);
                    if(personasUsuariosDto!= null && personasUsuariosDto.Count>0)
                    {
                        for(int x =0; x<personasUsuariosDto.Count; x++)
                        {
                            string contrasena = personasUsuariosDto[x].CONTRASENA;
                            if (contrasena != null && contrasena.Length>0)
                                personasUsuariosDto[x].CONTRASENA = cifrado.Desencriptar(contrasena);
                        }
                    }
                    int total = await daoIptv.ObtenerTotalPersonasAsync();
                    ConsultaPersonasUsuariosDto consulta = new ConsultaPersonasUsuariosDto()
                    {
                        personaUsuario = personasUsuariosDto,
                        Total = total
                    };
                    return consulta;
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
        public async Task<int> AltaPersona(AltaPersonaDto personaDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Persona persona = _mapper.Map<Persona>(personaDto);
                    int respuesta = await daoIptv.AltaPersonaAsync(persona);
                    unitOfWork.Commit();
                    return respuesta;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
        public async Task<int> AltaPersonaUsuario(AltaPersonaUsuarioDto personaUsuarioDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    PersonaDto personaDto = new PersonaDto();
                    personaDto.CLAVE = personaUsuarioDto.CLAVE;
                    personaDto.NOMBRE = personaUsuarioDto.NOMBRE;
                    personaDto.APELLIDO_PATERNO = personaUsuarioDto.APELLIDO_PATERNO;
                    personaDto.APELLIDO_MATERNO = personaUsuarioDto.APELLIDO_MATERNO;
                    personaDto.ID_ESTATUS = personaUsuarioDto.ID_ESTATUS;
                    personaDto.USUARIO = personaUsuarioDto.USUARIO;

                    UsuarioDto usuarioDto = new UsuarioDto();
                    usuarioDto.CLAVE_USUARIO = personaUsuarioDto.CLAVE_USUARIO;
                    usuarioDto.CONTRASENA = cifrado.Encriptar(personaUsuarioDto.CONTRASENA);
                    usuarioDto.USUARIO = personaUsuarioDto.USUARIO;
                    usuarioDto.ID_PERFIL = personaUsuarioDto.ID_PERFIL;
                    usuarioDto.ID_ESTATUS = personaUsuarioDto.ID_ESTATUS;

                    Persona persona = _mapper.Map<Persona>(personaDto);
                    Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

                    int respuesta = await daoIptv.AltaPersonaAsync(persona);
                    usuario.ID_PERSONA = respuesta;

                    int respuesta2 = await daoIptv.AltaUsuarioAsync(usuario);

                    unitOfWork.Commit();
                    return respuesta;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
        public async Task<int> ActulizaPersona(int ID_PERSONA, AltaPersonaDto personaDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();

                    Persona persona = _mapper.Map<Persona>(personaDto);
                    int resultado = await daoIptv.ActulizaPersonaAsync(ID_PERSONA, persona);

                    unitOfWork.Commit();
                    return resultado;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }

            }
        }

        public async Task<int> ActulizaPersonaUsuario(int ID_PERSONA, AltaPersonaUsuarioDto personaUsuarioDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();

                    PersonaDto personaDto = new PersonaDto();
                    personaDto.CLAVE = personaUsuarioDto.CLAVE;
                    personaDto.NOMBRE = personaUsuarioDto.NOMBRE;
                    personaDto.APELLIDO_PATERNO = personaUsuarioDto.APELLIDO_PATERNO;
                    personaDto.APELLIDO_MATERNO = personaUsuarioDto.APELLIDO_MATERNO;
                    personaDto.ID_ESTATUS = personaUsuarioDto.ID_ESTATUS;
                    personaDto.USUARIO = personaUsuarioDto.USUARIO;

                    UsuarioDto usuarioDto = new UsuarioDto();
                    usuarioDto.CLAVE_USUARIO = personaUsuarioDto.CLAVE_USUARIO;
                    usuarioDto.CONTRASENA = cifrado.Encriptar(personaUsuarioDto.CONTRASENA);
                    usuarioDto.USUARIO = personaUsuarioDto.USUARIO;
                    usuarioDto.ID_PERFIL = personaUsuarioDto.ID_PERFIL;
                    usuarioDto.ID_ESTATUS = personaUsuarioDto.ID_ESTATUS;


                    Persona persona = _mapper.Map<Persona>(personaDto);
                    Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

                    int resultado = await daoIptv.ActulizaPersonaAsync(ID_PERSONA, persona);
                    int resultado2 = await daoIptv.ActulizaUsuarioIdPersonaAsync(ID_PERSONA, usuario);

                    unitOfWork.Commit();
                    return resultado;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }

            }
        }
    }
}
