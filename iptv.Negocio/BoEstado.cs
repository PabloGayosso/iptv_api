using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iptv.AccesoDatos;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.Enum;
using iptv.Negocio.Utilidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace iptv.Negocio
{
    public class BoEstado : IBoEstado
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoEstado(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<List<EstadoDto>> ObtenerEstados()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Estado> estados = await daoIptv.ObtenerEstadosAsync();
                    List<EstadoDto> estadoDto = _mapper.Map<List<EstadoDto>>(estados);
                    return estadoDto;
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
