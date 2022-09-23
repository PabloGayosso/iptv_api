using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos;
using iptv.Negocio.Utilidades;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using System.Runtime.ExceptionServices;

namespace iptv.Negocio
{
    public class BoMensaje : IBoMensaje
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoMensaje(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<List<MensajeDto>> ConsultaCatMensajes()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Mensaje> mensajes = await daoIptv.ObtenerCatMensajesAsync();
                    List<MensajeDto> mensajeDto = _mapper.Map<List<MensajeDto>>(mensajes);
                    return mensajeDto;
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
        public async  Task<ConsultaMensajesDto> ConsultarMensajes(string Busqueda, int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Mensaje> mensajes = await daoIptv.ObtenerMensajesAsync(Busqueda, Pagina, RegistrosPagina);
                    List<MensajeDto> mensajeDto = _mapper.Map<List<MensajeDto>>(mensajes);
                    int total = await daoIptv.TotalMensajesAsync();
                    ConsultaMensajesDto consulta = new ConsultaMensajesDto()
                    {
                        mensaje = mensajeDto,
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
        public async Task<MensajeDto> ConsultaMensaje(int ID_MENSAJE)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Mensaje mensaje = await daoIptv.ObtenerMensajeAsync(ID_MENSAJE);
                    MensajeDto mensajeDto = _mapper.Map<MensajeDto>(mensaje);
                    return mensajeDto;
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
        public async Task<int> AltaMensaje(AltaMensajeDto mensajeDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Mensaje mensaje = _mapper.Map<Mensaje>(mensajeDto);
                    int resultado = await daoIptv.AltaMensajeAsync(mensaje);
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
        public async Task<int> ActulizaMensaje(int ID_MENSAJE, AltaMensajeDto mensajeDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Mensaje mensaje = _mapper.Map<Mensaje>(mensajeDto);
                    int resultado = await daoIptv.ActulizaMensajeAsync(ID_MENSAJE, mensaje);
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
