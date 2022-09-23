using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Dapper;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos;
using iptv.Negocio.Utilidades;

namespace iptv.Negocio
{
    public class BoOpcion : IBoOpcion
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoOpcion(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<int> AsginarOpcion(AsignaPerfilOpcionDto perfilDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Perfil perfil = _mapper.Map<Perfil>(perfilDto);
                    int resultado = await daoIptv.EliminarAsignacionOpcionAsync(perfil.ID_PERFIL);
                    switch (resultado >= 0)
                    {
                        case true:
                            for (int i = 0; i < perfil.Opcion.Count; i++)
                            {
                                await daoIptv.AsignarOpcionesAsync(perfil.ID_PERFIL, perfil.Opcion[i].ID_OPCION, perfil.USUARIO);
                            }
                            break;
                        case false:
                            throw new ExcepcionIptv("Error al asignar las opciones");
                    }
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
        public async Task<List<OpcionDto>> ObtnerAsignado(int ID_PERFIL)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Opcion> opcions = await daoIptv.ObtenerAsignado(ID_PERFIL);
                    List<OpcionDto> opcionDto = _mapper.Map<List<OpcionDto>>(opcions);
                    return opcionDto;
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
        public async Task<List<OpcionDto>> ObtnerNoAsignado(int ID_PERFIL)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Opcion> opcions = await daoIptv.ObtnerNoAsignado(ID_PERFIL);
                    List<OpcionDto> opcionDto = _mapper.Map<List<OpcionDto>>(opcions);
                    return opcionDto;
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
