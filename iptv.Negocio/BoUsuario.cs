using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using iptv.Negocio.Utilidades;

namespace iptv.Negocio
{
    public class BoUsuario : IBoUsuario
    {
        IConfiguration configuration;
        IMapper _mapper;
        CifradoDatos cifrado;
        public BoUsuario(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
            cifrado = new CifradoDatos(configuration);
        }
        public async Task<ConsultaUsuariosDto> ObtenerUsuarios(int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Usuario> usuarios = await daoIptv.ObtenerUsariosAsync(Pagina, RegistrosPagina);
                    List<UsuarioDto> usariosDto = _mapper.Map<List<UsuarioDto>>(usuarios);
                    int total = await daoIptv.ObtenerTotalUsuariosAsync();
                    ConsultaUsuariosDto consulta = new ConsultaUsuariosDto()
                    {
                        usuario = usariosDto,
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
        public async Task<UsuarioDto> ObtenerUsuario(int ID_USUARIO)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Usuario usuario = await daoIptv.ObtenerUsuarioAsync(ID_USUARIO);
                    UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(usuario);
                    usuarioDto.CONTRASENA = cifrado.Desencriptar(usuarioDto.CONTRASENA);
                    return usuarioDto;
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
        public async Task<int> AltaUsuraio(AltaUsuarioDto usuarioDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
                    usuario.CONTRASENA = cifrado.Encriptar(usuario.CONTRASENA);
                    int resultado = await daoIptv.AltaUsuarioAsync(usuario);
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
        public async Task<int> ActulizaUsuraio(int ID_USUARIO, AltaUsuarioDto usuarioDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
                    usuario.CONTRASENA = cifrado.Encriptar(usuario.CONTRASENA);
                    int respuesta = await daoIptv.ActulizaUsuarioAsync(ID_USUARIO, usuario);
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

        public async Task<List<UsuarioDto>> ObtenerUsuarios()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Usuario> usuarios = await daoIptv.ObtenerUsariosAsync();
                    List<UsuarioDto> usariosDto = _mapper.Map<List<UsuarioDto>>(usuarios);
                    return usariosDto;
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
    }
}
