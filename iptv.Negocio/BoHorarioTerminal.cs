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
    public class BoHorarioTerminal : IBoHorarioTerminal
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoHorarioTerminal(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<int> AltaHorarioTerminal(AltaHorarioTerminalDto horarioTerminalDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWorck = nSession.UnitOfWork;
                try
                {
                    unitOfWorck.Begin();
                    DaoIptv daoiptv = new DaoIptv(unitOfWorck);
                    HorarioTerminal horarioTerminal = _mapper.Map<HorarioTerminal>(horarioTerminalDto);
                    int respuesta = await daoiptv.AltaHorarioTerminal(horarioTerminal);
                    unitOfWorck.Commit();
                    return respuesta;
                }
                catch (ExcepcionIptv ex)
                {
                    unitOfWorck.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    unitOfWorck.Rollback();
                    throw;
                }
            }
        }
        public async Task<int> ActulizaHorarioTerminal(int IdTvHorarioTerminal, AltaHorarioTerminalDto horarioTerminalDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWorck = nSession.UnitOfWork;
                try
                {
                    unitOfWorck.Begin();
                    DaoIptv daoiptv = new DaoIptv(unitOfWorck);
                    HorarioTerminal horarioTerminal = _mapper.Map<HorarioTerminal>(horarioTerminalDto);
                    horarioTerminal.IdTvHorarioTerminal = IdTvHorarioTerminal;
                    int respuesta = await daoiptv.ActulizaHorarioTerminal(horarioTerminal);
                    unitOfWorck.Commit();
                    return respuesta;
                }
                catch (ExcepcionIptv ex)
                {
                    unitOfWorck.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    unitOfWorck.Rollback();
                    throw;
                }
            }
        }
        public async Task<int> AltaHorarioGrupo(AltaHorarioTerminalDto horarioTerminalDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWorck = nSession.UnitOfWork;
                try
                {
                    unitOfWorck.Begin();
                    DaoIptv daoiptv = new DaoIptv(unitOfWorck);
                    HorarioTerminal horarioTerminal = _mapper.Map<HorarioTerminal>(horarioTerminalDto);
                    int respuesta = await daoiptv.AltaHorarioTerminal(horarioTerminal);
                    switch (respuesta > 0)
                    {
                        case true:
                            await daoiptv.EliminarHorarioGrupo(horarioTerminal.grupo.ID_GRUPO);
                            await daoiptv.AltaGrupoHorario(respuesta, horarioTerminal.grupo.ID_GRUPO, horarioTerminal.usuario);
                            break;
                        case false:
                            throw new ExcepcionIptv("¡No fue posible guardar el horario!");
                     }
                    unitOfWorck.Commit();
                    return respuesta;
                }
                catch (ExcepcionIptv ex)
                {
                    unitOfWorck.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    unitOfWorck.Rollback();
                    throw;
                }
            }
        }
        public async Task<HorarioTerminalDto> ObtenerHorarioGrupo(int ID_GRUPO)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWorck = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoiptv = new DaoIptv(unitOfWorck);
                    HorarioTerminal horarioTerminal = await daoiptv.ConsultaHorariosGrupos(ID_GRUPO);
                    HorarioTerminalDto horarioTerminalDto = _mapper.Map<HorarioTerminalDto>(horarioTerminal);
                    return horarioTerminalDto;
                }
                catch (ExcepcionIptv ex)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public async Task<List<HorarioTerminalDto>> ObtenerHorarioTerminal()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWorck = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoiptv = new DaoIptv(unitOfWorck);
                    List<HorarioTerminal> horarioTerminal = await daoiptv.ConsultaHorariosTerminal();
                    List<HorarioTerminalDto> horarioTerminalDto = _mapper.Map<List<HorarioTerminalDto>>(horarioTerminal);
                    return horarioTerminalDto;
                }
                catch (ExcepcionIptv ex)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
