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
    public class BoColonia : IBoColonia
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoColonia(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<List<ColoniaDto>> ObtenerColniaIdDelegacionMunicipio(int ID_ESTADO, int ID_DELEG_MUNICIPIO)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Colonia> colonias = await daoIptv.ObtenerColoniasIdDelegacionEstadoAsync(ID_ESTADO, ID_DELEG_MUNICIPIO);
                    List<ColoniaDto> coloniaDto = _mapper.Map<List<ColoniaDto>>(colonias);
                    return coloniaDto;
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
