using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos;
using iptv.Negocio.Utilidades;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using iptv.AccesoDatos.Enum;

namespace iptv.Negocio
{
    public class BoPerfil : IBoPerfil
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoPerfil(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<List<PerfilDto>> ObtenerPerfilesActivos()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Perfil> perfils = await daoIptv.ObtenerPerfilesActivosAsync((int)CatEstatus.ACTIVO);
                    List<PerfilDto> perfilDto = _mapper.Map<List<PerfilDto>>(perfils);
                    return perfilDto;
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
        public async Task<ConsultaPerfilDto> ObtnerPerfiles(string Busqueda, int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Perfil> perfiles = await daoIptv.ObtenerPerfilesAsync(Busqueda, Pagina, RegistrosPagina);
                    List<PerfilDto> perfilDto = _mapper.Map<List<PerfilDto>>(perfiles);
                    int total = await daoIptv.ObtenerTotalPerfilesAsync();
                    ConsultaPerfilDto consultaPerfilDto = new ConsultaPerfilDto()
                    {
                        perfil = perfilDto,
                        Total = total
                    };
                    return consultaPerfilDto;
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
        public async Task<PerfilDto> ObtnerPerfil(int ID_PERFIL)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Perfil perfil = await daoIptv.ObtnerPerfilAsync(ID_PERFIL);
                    PerfilDto perfilDto = _mapper.Map<PerfilDto>(perfil);
                    return perfilDto;
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
        public async Task<PerfilDto> ObtenerPerfilOpcion(int ID_PERFIL)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Perfil perfil = await daoIptv.ObtenerPerfilOpcionAsync(ID_PERFIL);
                    PerfilDto perfilDto = _mapper.Map<PerfilDto>(perfil);
                    return perfilDto;
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
        public async Task<int> AltaPerfil(AltaPerfilDto perfilDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Perfil perfil = _mapper.Map<Perfil>(perfilDto);
                    var resultado = await daoIptv.AltaPerfilAsync(perfil);
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
        public async Task<int> ActulizaPerfil(int ID_PERFIL, AltaPerfilDto perfilDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Perfil perfil = _mapper.Map<Perfil>(perfilDto);
                    perfil.ID_PERFIL = ID_PERFIL;
                    int resutlado = await daoIptv.ActulizaPerfilAsync(perfil);
                    unitOfWork.Commit();
                    return resutlado;
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
