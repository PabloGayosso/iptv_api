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
  public class BoMensajeVivo : IBoMensajeVivo
  {
    IConfiguration configuration;
    IMapper _mapper;
    public BoMensajeVivo(IConfiguration configuration, IMapper _mapper)
    {
      this.configuration = configuration;
      this._mapper = _mapper;
    }

    public async Task<ConsultaMensajeVivoDto> ConsultaMensajesVivo(string Busqueda, int Pagina, int RegistrosPagina)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          List<MensajeVivo> mensajes = await daoIptv.ObtenerMensajesVivoAsync(Busqueda, Pagina, RegistrosPagina);
          List<MensajeVivoDto> mensajeDto = _mapper.Map<List<MensajeVivoDto>>(mensajes);
          int total = await daoIptv.ObtenerTotalMensajesVivoAsync();
          ConsultaMensajeVivoDto consulta = new ConsultaMensajeVivoDto()
          {
            mensajeVivoDto = mensajeDto,
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

    public async Task<MensajeVivoDto> ConsultaMensajeVivo(int ID_MENSAJE)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          MensajeVivo mensajeVivo = await daoIptv.ObtenerMensajeVivoAsync(ID_MENSAJE);
          MensajeVivoDto mensajeVivoDto = _mapper.Map<MensajeVivoDto>(mensajeVivo);
          return mensajeVivoDto;
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



    public async Task<ConsultaMensajeVivoDto> ConsultaMensajesVivoGrupRep(int Pagina, int RegistrosPagina)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          List<MensajeVivo> mensajes = await daoIptv.ObtenerMensajesVivoGrupoReporductorAsync(Pagina, RegistrosPagina);
          List<MensajeVivoDto> mensajeDto = _mapper.Map<List<MensajeVivoDto>>(mensajes);
          int total = await daoIptv.ObtenerTotalMensajesVivoGruRepAsync();
          ConsultaMensajeVivoDto consulta = new ConsultaMensajeVivoDto()
          {
            mensajeVivoDto = mensajeDto,
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

    public async Task<MensajeVivoDto> ConsultaMensajeVivoGrupRep(int ID_GRUPO_REPRODUCTOR_MENSAJE)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          MensajeVivo mensajeVivo = await daoIptv.ObtenerMensajeVivoGruReproAsync(ID_GRUPO_REPRODUCTOR_MENSAJE);
          MensajeVivoDto mensajeVivoDto = _mapper.Map<MensajeVivoDto>(mensajeVivo);
          return mensajeVivoDto;
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

    public async Task<int> AltaMensajeVivo(AltaMensajeVivoDto altaMensajeVivoDto)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          unitOfWork.Begin();
          MensajeVivo mensajeVivo = _mapper.Map<MensajeVivo>(altaMensajeVivoDto);
          int respuesta = await daoIptv.AltaMensajeVivoAsync(mensajeVivo);
          switch (respuesta > 0)
          {
            case true:
              await daoIptv.AltaMensajeVivoReproductorAsync(mensajeVivo.ID_GRUPO, mensajeVivo.ID_REPRODUCTOR, respuesta, mensajeVivo.ID_ESTATUS, mensajeVivo.USUARIO);
              break;
            case false:
              throw new ExcepcionIptv("Fallo alta Reproductor :3");
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

    public async Task<int> ActulizaMensajeVivo(int ID_MENSAJE, AltaMensajeVivoDto altaMensajeVivoDto)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          unitOfWork.Begin();
          MensajeVivo mensajeVivo = _mapper.Map<MensajeVivo>(altaMensajeVivoDto);
          int respuesta = await daoIptv.ActulizaMensajeVivoAsync(ID_MENSAJE, mensajeVivo);
          switch (respuesta > 0)
          {
            case true:
              await daoIptv.EliminarMensajeVivoAsync(ID_MENSAJE);
              await daoIptv.AltaMensajeVivoReproductorAsync(mensajeVivo.ID_GRUPO, mensajeVivo.ID_REPRODUCTOR, ID_MENSAJE, mensajeVivo.ID_ESTATUS, mensajeVivo.USUARIO);
              break;
            case false:
              throw new ExcepcionIptv("Fallo alta Reproductor :3");
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
