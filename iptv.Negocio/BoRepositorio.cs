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
    public class BoRepositorio : IBoRepositorio
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoRepositorio(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<RepositorioDLNADto> ObtenerCatalogoRepositorioNombre(string NOMBRE)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    RepositorioDLNA repositorio = await daoIptv.ContultarCatalogoRepositorioNombreAsync(NOMBRE);
                    RepositorioDLNADto repositorioDto = _mapper.Map<RepositorioDLNADto>(repositorio);
                    return repositorioDto;
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
        public async Task<RepositorioDLNADto> ObtenerCatalogoRepositorio(int ID_REPOSITORIO)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    RepositorioDLNA repositorio = await daoIptv.ConsultaCatalogoRepositorioAsync(ID_REPOSITORIO);
                    RepositorioDLNADto repositorioDto = _mapper.Map<RepositorioDLNADto>(repositorio);
                    return repositorioDto;
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
        public async Task<int> EliminarCatalogoRepositorio(int ID_REPOSITORIO, string NOMBRE)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    int resultado = await daoIptv.EliminarCatalogoRepositorioAsync(ID_REPOSITORIO, NOMBRE);
                    unitOfWork.Commit();
                    return resultado;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
        public async Task<List<RepositorioDto>> ObtenerRepositorioTipoContenido(int ID_TIPO_CONTENIDO)
        {
            using (NegocioSesion nSesion = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSesion.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Repositorio> repositorios = await daoIptv.ConsultaRepositorioContenidoAsync(ID_TIPO_CONTENIDO);
                    List<RepositorioDto> repositoriosDto = _mapper.Map<List<RepositorioDto>>(repositorios);
                    return repositoriosDto;
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
        public async Task<ConsultaRepositorioDto> ObtnerRepositorios(string Busqueda, int ID_TIPO_CONTENIDO, int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Repositorio> repositorios = await daoIptv.ConsultaRepositoriosAsync(Busqueda, ID_TIPO_CONTENIDO, Pagina, RegistrosPagina);
                    List<RepositorioDto> repositorioDto = _mapper.Map<List<RepositorioDto>>(repositorios);
                    int total = await daoIptv.ObtenerTotalRepositoriosAsync();
                    ConsultaRepositorioDto consulta = new ConsultaRepositorioDto()
                    {
                        repositorio = repositorioDto,
                        Total = total,
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
        public async Task<int> AltaRepositorio(string NombreActual, string Nombre, string Extension, int TipoContenido, string UsuarioRegistro)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Repositorio repositorio = new Repositorio()
                    {
                        RUTA_ALOJAMIENTO = NombreActual,
                        DESCRIPCION = Nombre,
                        USUARIO = UsuarioRegistro,
                        ID_TIPO_CONTENIDO = TipoContenido,
                        EXTENSION = Extension,
                        ID_ESTATUS = Convert.ToInt32(CatEstatus.ACTIVO)
                    };
                    var respuesta = await daoIptv.AltaRepositorioAsync(repositorio);
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
        public async Task<int> EliminarRepositorio(int ID_REPOSITORIO)
        {
            using(NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    int resultado = await daoIptv.EliminarRepositorioAsync(ID_REPOSITORIO);
                    unitOfWork.Commit();
                    return resultado;
                }
                catch(ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
        public async Task<RepositorioDto> ObtenerRepositorio(int ID_REPOSITORIO)
        {
            using(NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Repositorio repositorio = await daoIptv.ConsultaRepositorioId(ID_REPOSITORIO);
                    RepositorioDto repositorioDto = _mapper.Map<RepositorioDto>(repositorio);
                    return repositorioDto;
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
