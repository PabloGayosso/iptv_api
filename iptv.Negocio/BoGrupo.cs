using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using iptv.AccesoDatos;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.Negocio.Utilidades;
using System.Threading.Tasks;

namespace iptv.Negocio
{
    public class BoGrupo : IBoGrupo
    {
        IConfiguration configuration;
        IMapper _mapper;

        public BoGrupo(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }

        public async Task<ConsultaGruposDto> CosultaGrupos(string Busqueda, int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Grupo> grupo = await daoIptv.ObtenerGruposAsync(Busqueda, Pagina, RegistrosPagina);
                    List<GrupoDto> grupoDto = _mapper.Map<List<GrupoDto>>(grupo);
                    int total = await daoIptv.ObtenerTotalGruposAsync();
                    ConsultaGruposDto consulta = new ConsultaGruposDto()
                    {
                        grupoDto = grupoDto,
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

        public async Task<List<GrupoDto>> CosultaGruposCatalogo(int Opcion)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    List<Grupo> grupo = null;
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    if(Opcion == Constantes.GET_ALL_GRUPO_ACTIVO)
                        grupo = await daoIptv.ObtenerGrupoCatalogoAllAsync();
                    else if (Opcion == Constantes.GET_GRUPO_ACTIVO)
                        grupo = await daoIptv.ObtenerGrupoCatalogoAsync();

                    List<GrupoDto> grupoDto = _mapper.Map<List<GrupoDto>>(grupo);           
                    return grupoDto;
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

        public async Task<GrupoDto> ConsultaGrupo(int ID_GRUPO)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Grupo grupo = await daoIptv.ObtenerGrupoAsync(ID_GRUPO);
                    List<Reproductor> reproductores = await daoIptv.ObtenerReproductoresGrupoAsync(ID_GRUPO);
                    if (reproductores != null && reproductores.Count > 0)
                        grupo.reproductores = reproductores;
                    GrupoDto grupoDto = _mapper.Map<GrupoDto>(grupo);
                    return grupoDto;
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

        public async Task<int> AltaGrupo(AltaGrupoDto altaGrupoDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Grupo grupo = _mapper.Map<Grupo>(altaGrupoDto);
                    int respuesta = await daoIptv.AltaGrupoAsync(grupo);
                    switch (respuesta > 0)
                    {
                        case true:
                            if (grupo.reproductores != null && grupo.reproductores.Count > 0)
                            {
                                foreach(Reproductor reproductor in grupo.reproductores)
                                {
                                    await daoIptv.AltaGrupoReproductorAsync(respuesta,
                                                 reproductor.ID_REPRODUCTOR,
                                                 grupo.ID_TEMPLATE, grupo.USUARIO);
                                }
                            }
                        break;
                        case false:
                            throw new ExcepcionIptv("Fallo alta Reproductor :3");
                    }
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

        public async Task<int> ActulizaGrupo(int ID_GRUPO, AltaGrupoDto altaGrupoDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Grupo grupo = _mapper.Map<Grupo>(altaGrupoDto);
                    int respuesta = await daoIptv.ActulizaGrupoAsync(ID_GRUPO, grupo);
                    switch (respuesta == 0)
                    {
                        case true:
                            await daoIptv.EliminarGrupoReproductor(ID_GRUPO);
                            if (grupo.reproductores != null && grupo.reproductores.Count > 0)
                            {
                                foreach(Reproductor reproductor in grupo.reproductores)
                                {
                                    await daoIptv.AltaGrupoReproductorAsync(ID_GRUPO,
                                     reproductor.ID_REPRODUCTOR,
                                      grupo.ID_TEMPLATE, grupo.USUARIO);
                                }
                            }
                            break;
                        case false:
                            throw new ExcepcionIptv("Fallo alta Reproductor :3");
                    }
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
    }
}
