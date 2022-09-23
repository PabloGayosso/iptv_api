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

namespace iptv.Negocio
{
    public class BoDelegacionMunicipio : IBoDelegacionMunicipio
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoDelegacionMunicipio(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<List<DelegacionMunicipioDto>> ObtenerDelegacionMunicipioEstado(int ID_ESTADO)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<DelegacionMunicipio> delegacionMunicipios = await daoIptv.ObtenerDelagacionMunicipioAsync(ID_ESTADO);
                    List<DelegacionMunicipioDto> delegacionMunicipioDto = _mapper.Map<List<DelegacionMunicipioDto>>(delegacionMunicipios);
                    return delegacionMunicipioDto;
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
