using AutoMapper;
using iptv.AccesoDatos;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;
using iptv.Negocio.Utilidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iptv.Negocio
{
    public class BoEnvios : IBoEnvios
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoEnvios(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }

        public async Task<Consulta_EnviosDto> Consulta_Envios_Async()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Envios> envios = await daoIptv.Consulta_Envios_Async();
                    List<EnviosDto> enviosDto = _mapper.Map<List<EnviosDto>>(envios);
                    Consulta_EnviosDto consulta = new Consulta_EnviosDto()
                    {
                        envios = enviosDto
                    };

                    if (enviosDto != null && enviosDto.Count > 0)
                    {
                        consulta.total = enviosDto.Count;
                        consulta.id_Busqueda = enviosDto[0].id_Envio;
                        consulta.fec_Busqueda = enviosDto[0].fec_Alta;
                    }
                    else
                    {
                        consulta.total = 0;
                    }

                    return consulta;
                }
                catch (ExcepcionIptv)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<Consulta_EnviosHDto> Consulta_Envios_H_Async(int Pagina, int RegistrosPagina, string fec_Ini, string fec_Fin)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<EnvioH> envios = await daoIptv.Consulta_Envios_H_Async(Pagina, RegistrosPagina, fec_Ini, fec_Fin);
                    List<EnviosHDto> enviosDto = _mapper.Map<List<EnviosHDto>>(envios);
                    int total = await daoIptv.Consulta_Envios_H_Total();
                    Consulta_EnviosHDto consulta = new Consulta_EnviosHDto()
                    {
                        envios = enviosDto,
                        total = total
                    };
                    return consulta;
                }
                catch (ExcepcionIptv)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<Consulta_EnviosDto> Consulta_Envios_Post_Async(int idEnvio, string fec_Busqueda)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Envios> envios = await daoIptv.Consulta_Envios_Post_Async(idEnvio, fec_Busqueda);
                    List<EnviosDto> enviosDto = _mapper.Map<List<EnviosDto>>(envios);
                    Consulta_EnviosDto consulta = new Consulta_EnviosDto()
                    {
                        envios = enviosDto
                    };

                    if (enviosDto != null && enviosDto.Count > 0)
                    {
                        consulta.total = enviosDto.Count;
                        consulta.id_Busqueda = enviosDto[0].id_Envio;
                        consulta.fec_Busqueda = enviosDto[0].fec_Alta;
                    }
                    else
                    {
                        consulta.total = 0;
                    }

                    return consulta;
                }
                catch (ExcepcionIptv)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<EnviosDto> Consulta_Envio_Estatus_Async(int id_Envio)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                bool esRollback = false;
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Envios> envios = await daoIptv.Consulta_Envio_Estatus_Async(id_Envio);

                    
                    EnviosDto envioDto = null;
                    if (envios != null && envios.Count > 0)
                    {
                        Envios envio = envios[0];
                        envioDto = _mapper.Map<EnviosDto>(envio);
                        if (envioDto.porcentaje == 100)
                        {
                            EnvioH envioH = new EnvioH();
                            envioH.nombre_Contenido = envioDto.nombre_Contenido;
                            envioH.reproductor = envioDto.reproductor;
                            envioH.usuario = envioDto.usuario;
                            envioH.fec_Envio = envioDto.fec_Envio;
                            envioH.fec_Alta = envioDto.fec_Envio;
                            envioH.estatus = "ENVIO COMPLETO";
                            unitOfWork.Begin();
                            esRollback = true;
                            int respuesta = await daoIptv.AltaEnvioHistoricoAsync(envioH, id_Envio);
                            unitOfWork.Commit();
                        }
                        
                        else
                        {
                           
                            //Obtener la fecha de fec_actualizar
                            DateTime t_Actualizacion = DateTime.Parse(envio.fec_Actualizacion);
                            
                            //obten fec act de la maquina
                            DateTime fActual = DateTime.Now;
                            //comparar con la fec actualizacion convertida a datetime
                            //int t_Result = DateTime.Compare(t_Sys, t_Actualizacion);
                            TimeSpan tsDiferencia = fActual - t_Actualizacion;

                            if (tsDiferencia.TotalSeconds > 90)
                            {
                                EnvioH envioH = new EnvioH();
                                envioH.nombre_Contenido = envioDto.nombre_Contenido;
                                envioH.reproductor = envioDto.reproductor;
                                envioH.usuario = envioDto.usuario;
                                envioH.fec_Envio = envioDto.fec_Envio;
                                envioH.fec_Alta = envioDto.fec_Envio;
                                envioH.estatus = "ENVIO INCOMPLETO";
                                unitOfWork.Begin();
                                esRollback = true;
                                int respuesta = await daoIptv.AltaEnvioHistoricoAsync(envioH, id_Envio);
                                unitOfWork.Commit();
                            }


                        }
                    }
                    else
                        envioDto = new EnviosDto();
                    return envioDto;
                }
                catch (ExcepcionIptv)
                {
                    if (esRollback)
                        unitOfWork.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    if (esRollback)
                        unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
