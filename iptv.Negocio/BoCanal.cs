using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.Negocio.Utilidades;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using iptv.AccesoDatos.Enum;
using iptv.Negocio.Log;
using System.Globalization;

namespace iptv.Negocio
{
    public class BoCanal : IBoCanal
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoCanal(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<int> CambioContenidoCanal(AltaCanalDto canalDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Canal canal = _mapper.Map<Canal>(canalDto);
                    int respuesta = 0;
                    foreach (Contenido contenido in canal.contenidos)
                    {
                        respuesta = await daoIptv.CambioDeContenido(contenido.ID_CANAL_CONTENIDO, contenido.ID_CONTENIDO, canal.USUARIO);
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
        public async Task<ConsultaCanalDto> CosultaCanales(int Pagina, int RegistrosPagina, string Busqueda)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {

                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Canal> canales = await daoIptv.ConsultaCanalesAsync(Pagina, RegistrosPagina, Busqueda);
                    List<CanalDto> canalDtos = _mapper.Map<List<CanalDto>>(canales);
                    int total = await daoIptv.ConsultaTotalCanales();
                    ConsultaCanalDto consulta = new ConsultaCanalDto()
                    {
                        canal = canalDtos,
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
        public async Task<CanalDto> ConsultaCanal(int ID_CANAL)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Canal canal = await daoIptv.ConsultaCanalAsync(ID_CANAL);
                    List<Contenido> contenidos = await daoIptv.ObtenerContenidoCanalAsync(ID_CANAL, (int)Constantes.ACTIVO);
                    if (contenidos != null && contenidos.Count > 0)
                        canal.contenidos = contenidos;
                    CanalDto canalDto = _mapper.Map<CanalDto>(canal);
                    return canalDto;
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
        public async Task<int> AltaCanal(AltaCanalDto canalDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Canal canal = _mapper.Map<Canal>(canalDto);
                    int respuesta = await daoIptv.AltaCanalAsync(canal);
                    int orden = 1;
                    switch (respuesta > 0)
                    {
                        case true:
                            if (canal.contenidos != null && canal.contenidos.Count > 0)
                            {
                                foreach (Contenido contenido in canal.contenidos)
                                {
                                    contenido.ID_ESTATUS = canal.ID_ESTATUS;
                                    contenido.USUARIO = canal.USUARIO;
                                    contenido.ORDEN = orden;

                                    contenido.FEC_INICIO = contenido.FEC_INICIO.Replace(",","");
                                    contenido.FEC_FIN = contenido.FEC_FIN.Replace(",", "");

                                    string conten = @"AltaCanalContenidoAsync
                                           ID_CANAL = " + respuesta +
                                           "ID_CONTENIDO = " + contenido.ID_CONTENIDO +
                                           "ID_ESTATUS = " + contenido.ID_ESTATUS +
                                           "ORDEN = " + contenido.ORDEN +
                                           "FEC_INICIO = " + contenido.FEC_INICIO +
                                           "FEC_FIN = " + contenido.FEC_FIN +
                                           "INICIO_HRS = " + contenido.INICIO_HRS +
                                           "INICIO_MIN = " + contenido.INICIO_MIN +
                                           "INICIO_SEG = " + contenido.INICIO_SEG +
                                           "FIN_HRS = " + contenido.FIN_HRS +
                                           "FIN_MIN = " + contenido.FIN_MIN +
                                           "FIN_SEG = " + contenido.FIN_SEG +
                                           "USUARIO = " + contenido.USUARIO;

                                    Logger.LogInfo(conten);
                                    await daoIptv.AltaCanalContenidoAsync(respuesta, contenido);
                                    orden++;
                                }
                            }
                            else
                                throw new ExcepcionIptv("¡No es posible crear canal sin contenidos!");
                            break;
                        case false:
                            throw new ExcepcionIptv("¡No fue posible guardar el canal!");
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
        public async Task<int> ActulizaCanal(int ID_CANAL, AltaCanalDto canalDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Canal canal = _mapper.Map<Canal>(canalDto);
                    int orden = 1;
                    int respuesta = await daoIptv.ActulizaCanalAsync(ID_CANAL, canal);
                    switch (respuesta == 0)
                    {
                        case true:
                            await daoIptv.EliminaCanalContenidoAsync(ID_CANAL);
                            if (canal.contenidos != null && canal.contenidos.Count > 0)
                            {
                                foreach (Contenido contenido in canal.contenidos)
                                {
                                    contenido.ID_ESTATUS = canal.ID_ESTATUS;
                                    contenido.USUARIO = canal.USUARIO;
                                    contenido.ORDEN = orden;

                                    contenido.FEC_INICIO = contenido.FEC_INICIO.Replace(",", "");
                                    contenido.FEC_FIN = contenido.FEC_FIN.Replace(",", "");

                                    await daoIptv.AltaCanalContenidoAsync(ID_CANAL, contenido);
                                    orden++;
                                }
                            }
                            else
                                throw new ExcepcionIptv("¡No es posible crear un canal sin contenidos!");
                            break;
                        case false:
                            throw new ExcepcionIptv("¡No fue posible guardar el canal!");
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
        public async Task<List<CanalDto>> CanalesActivos()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Canal> canales = await daoIptv.ConsultaCanalesActivosAsync((int)CatEstatus.ACTIVO);
                    List<CanalDto> canalesDto = _mapper.Map<List<CanalDto>>(canales);
                    return canalesDto;
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
