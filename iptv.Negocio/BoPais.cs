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
    public class BoPais : IBoPais
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoPais(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<List<PaisDto>> ConsultaPaises()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Pais> pais = await daoIptv.ConsultaPaisesAsync();
                    List<PaisDto> paisDto = _mapper.Map<List<PaisDto>>(pais);
                    return paisDto;
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
        public async Task<PaisDto> ConsultaPais(int ID_PAIS)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Pais pais = await daoIptv.ConsultaPaisAsync(ID_PAIS);
                    PaisDto paisDto = _mapper.Map<PaisDto>(pais);
                    return paisDto;
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
