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

namespace iptv.Negocio
{
    public class BoParametro : IBoParametro
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoParametro(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<ConsultaParametrosDto> ObtenerParametros(int Pagina, int RegistrosPagina, int Parametro)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Parametro> parametros = await daoIptv.ObtenerParametroIdPadreAsync(Pagina, RegistrosPagina, Parametro);
                    List<ParametroDto> parametroDto = _mapper.Map<List<ParametroDto>>(parametros);
                    int total = await daoIptv.ObtenerTotalParametrosAsync(Parametro);
                    ConsultaParametrosDto consulta = new ConsultaParametrosDto()
                    {
                        parametro = parametroDto,
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

        public async Task<List<ParametroDto>> ObtenerParametrosFont()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Parametro> parametros = await daoIptv.ObtenerParametroFontsAsync();
                    List<ParametroDto> parametroDto = _mapper.Map<List<ParametroDto>>(parametros);
                    
                    return parametroDto;
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

        public async Task<ConsultaParametrosDto> ObtenerCatalogo(int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Parametro> parametros = await daoIptv.ObtnerCatalogoAsync(Pagina, RegistrosPagina);
                    List<ParametroDto> parametroDto = _mapper.Map<List<ParametroDto>>(parametros);
                    int total = await daoIptv.ObtenerTotalCatalogoAsync();
                    ConsultaParametrosDto consulta = new ConsultaParametrosDto()
                    {
                        parametro = parametroDto,
                        Total = total
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
        public async Task<List<ParametroDto>> ObtenerCombo(int ID_PADRE)
        {
            using(NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Parametro> parametros = await daoIptv.ObtenerComboAsync(ID_PADRE);
                    List<ParametroDto> parametroDto = _mapper.Map<List<ParametroDto>>(parametros);
                    for(int x = 0; x < parametroDto.Count; x++)
                    {
                        if(parametroDto[x].ID_PARAMETRO == 1)
                        {
                            parametroDto.Remove(parametroDto[x]);
                            return parametroDto;
                        }
                    }
                    return parametroDto;
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
        public async Task<ParametroDto> ObtenerParametro(int ID_PARAMETRO)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Parametro parametro = await daoIptv.ObtenerParametroIdAsync(ID_PARAMETRO);
                    ParametroDto parametroDto = _mapper.Map<ParametroDto>(parametro);
                    return parametroDto;
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
        public async Task<int> AltaParametro(AltaParametroDto parametroDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Parametro parametro = _mapper.Map<Parametro>(parametroDto);
                    var resultado = await daoIptv.AltaParametroAsync(parametro);
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
        public async Task<int> ActulizaParametro(int ID_PARAMETRO, AltaParametroDto parametroDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Parametro parametro = _mapper.Map<Parametro>(parametroDto);
                    parametro.ID_PARAMETRO = ID_PARAMETRO;
                    var resultado = await daoIptv.ActulizaParametroAsync(parametro);
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
        public async Task<int> AltaParametroCatalogo(AltaParametroDto parametroDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Parametro parametro = _mapper.Map<Parametro>(parametroDto);
                    var resultado = await daoIptv.AltaParametroCatalogoAsync(parametro);
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
        public async Task<int> ActulizaParametroCatalogo(int ID_PARAMETRO, AltaParametroDto parametroDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Parametro parametro = _mapper.Map<Parametro>(parametroDto);
                    parametro.ID_PARAMETRO = ID_PARAMETRO;
                    var resultado = await daoIptv.ActulizaParametroCatalogoAsync(parametro);
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
