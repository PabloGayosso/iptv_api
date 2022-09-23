using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos;
using iptv.Negocio.Utilidades;

namespace iptv.Negocio
{
    public class BoAuditoria : IBoAuditoria
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoAuditoria(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }

        
        public async Task<int> AltaAudiroria(AltaAuditoriaDto auditoriaDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Auditoria auditoria = _mapper.Map<Auditoria>(auditoriaDto);
                    int respuesta = await daoIptv.AltaAuditoriaAsync(auditoria);
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

        public async Task<ConsultaAuditoria> ConsultaAuditoriaFechas(string fchIni, string fchFin, int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Auditoria> auditorias = await daoIptv.ConsultaAuditoriaFechasAsync(fchIni, fchFin, Pagina, RegistrosPagina);
                    List<AuditoriaDto> auditoriasDto = _mapper.Map<List<AuditoriaDto>>(auditorias);
                    int total = await daoIptv.ObtenerTotalAuditoriasFechaAsync(fchIni, fchFin);
                    ConsultaAuditoria consulta = new ConsultaAuditoria()
                    {
                        auditoria = auditoriasDto,
                        total = total
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

        public async Task<List<AuditoriaDto>> ConsultaAuditoriaFechas(string fchIni, string fchFin)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Auditoria> auditorias = await daoIptv.ConsultaAuditoriaFechasAsync(fchIni, fchFin);
                    List<AuditoriaDto> auditoriasDto = _mapper.Map<List<AuditoriaDto>>(auditorias);
                    return auditoriasDto;
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
