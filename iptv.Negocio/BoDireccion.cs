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

namespace iptv.Negocio
{
    public class BoDireccion : IBoDireccion
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoDireccion(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<ConsultaDireccionDto> ConsultaDirecciones(int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Direccion> direccions = await daoIptv.ObtenerDireccionesAsync(Pagina, RegistrosPagina);
                    List<DireccionDto> direccionDto = _mapper.Map<List<DireccionDto>>(direccions);
                    int total = await daoIptv.ObtenerTotalDireccionesAsync();
                    ConsultaDireccionDto consulta = new ConsultaDireccionDto()
                    {
                        direccion = direccionDto,
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
        public async Task<DireccionDto> ConsultaDireccion(int ID_DIRECCION)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Direccion direccion = await daoIptv.ObtenerDireccionAsync(ID_DIRECCION);
                    DireccionDto direccionDto = _mapper.Map<DireccionDto>(direccion);
                    return direccionDto;
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
        public async Task<int> AltaDireccion(AltaDireccionDto direccionDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Direccion direccion = _mapper.Map<Direccion>(direccionDto);
                    int respuesta = await daoIptv.AltaDireccionAsync(direccion);
                    switch (respuesta > 0)
                    {
                        case true:
                            await daoIptv.AltaDireccionPersonaAsync(respuesta, direccion.Persona.ID_PERSONA, direccion.USUARIO);
                            break;
                        case false:
                            throw new ExcepcionIptv("¡Fallo al enrolar!");
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
        public async Task<int> ActulizaDireccion(int ID_DIRECCION, AltaDireccionDto altaDireccionDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Direccion direccion = _mapper.Map<Direccion>(altaDireccionDto);
                    int respuesta = await daoIptv.ActulizaDireccionAsync(ID_DIRECCION, direccion);
                    switch (respuesta >= 0)
                    {
                        case true:
                            await daoIptv.EliminarDireccionesPersonasAsync(ID_DIRECCION);
                            await daoIptv.AltaDireccionPersonaAsync(ID_DIRECCION, direccion.Persona.ID_PERSONA, direccion.USUARIO);
                            break;
                        case false:
                            throw new ExcepcionIptv("¡Fallo al actulizar!");
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
