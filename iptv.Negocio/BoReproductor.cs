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
  public class BoReproductor : IBoReproductor
  {
    IConfiguration configuration;
    IMapper _mapper;

    public BoReproductor(IConfiguration configuration, IMapper _mapper)
    {
      this.configuration = configuration;
      this._mapper = _mapper;
    }

    public async Task<ConsultaReproductoresDto> CosultaReproductores(string Busqueda, int Pagina, int RegistrosPagina)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          List<Reproductor> reproductores = await daoIptv.ObtenerReproductoresTemplatesAsync(Busqueda, Pagina, RegistrosPagina);
          List<ReproductorDto> reproductoresDto = _mapper.Map<List<ReproductorDto>>(reproductores);
          int total = await daoIptv.ObtenerTotalReproductoresAsync();
          ConsultaReproductoresDto consulta = new ConsultaReproductoresDto()
          {
            reproductor = reproductoresDto,
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

    public async Task<List<ReproductorDto>> CosultaReproductoresCatalogo(int Opcion)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          List<Reproductor> reproductores = null;
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          if (Opcion == Constantes.GET_ALL_REPRODUCTOR_ACTIVO)
            reproductores = await daoIptv.ObtenerReproductoresCatalogoAsync();
          else if (Opcion == Constantes.GET_REPRODUCTOR_NO_GRUPO_ACTIVO)
            reproductores = await daoIptv.ObtenerReproductoresCatalogoAsignadoAsync();

          List<ReproductorDto> reproductoresDto = _mapper.Map<List<ReproductorDto>>(reproductores);
          return reproductoresDto;
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

    public async Task<ReproductorDto> ConsultaReproductor(int ID_REPRODUCTOR)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          Reproductor reproductor = await daoIptv.ObtenerReproductorTemplateAsync(ID_REPRODUCTOR);
          ReproductorDto reproductorDto = _mapper.Map<ReproductorDto>(reproductor);
          return reproductorDto;
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

    public async Task<int> AltaReproductor(AltaReproductorDto reproductorDto)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          unitOfWork.Begin();
          int respuesta = 0;
          Reproductor reproductor = _mapper.Map<Reproductor>(reproductorDto);
          Reproductor repro = await daoIptv.ObtenerReproductorIPAsync(reproductor);
          if (repro.ID_REPRODUCTOR == 0)
          {
            repro = await daoIptv.ObtenerReproductorMACAsync(reproductor);
            if (repro.ID_REPRODUCTOR == 0)
            {
              respuesta = await daoIptv.AltaReproductorAsync(reproductor);
              switch (respuesta > 0)
              {
                case true:
                  if (reproductor.ID_GRUPO == 0)
                    if (reproductorDto.ID_TEMPLATE > 0)
                      await daoIptv.AltaReproductorTemplateAsync(respuesta, reproductorDto.ID_TEMPLATE, reproductor.ID_ESTATUS, reproductor.USUARIO);
                    else
                    {
                      Grupo grupo = await daoIptv.ObtenerGrupoAsync(reproductor.ID_GRUPO);
                      if (grupo.ID_GRUPO > 0)
                      {
                        await daoIptv.AltaReproductorTemplateAsync(respuesta, grupo.ID_TEMPLATE, reproductor.ID_ESTATUS, reproductor.USUARIO);
                        if (reproductorDto.ID_TEMPLATE > 0)
                          await daoIptv.AltaReproductorGrupoAsync(reproductor.ID_GRUPO, respuesta, grupo.ID_TEMPLATE, reproductor.USUARIO);
                      }
                    }
                  break;
                case false:
                  throw new ExcepcionIptv("Fallo alta Reproductor");
              }
            }
            else
              throw new ExcepcionIptv("Ya existe un reproductor con esta dirección MAC: " + repro.DIRECCION_MAC);
          }
          else
            throw new ExcepcionIptv("Ya existe un reproductor con esta dirección IP: " + repro.IP_CLIENTE);
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

    public async Task<int> ActulizaReproductor(int ID_REPRODUCTOR, AltaReproductorDto reproductorDto)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          unitOfWork.Begin();
          Reproductor reproductor = _mapper.Map<Reproductor>(reproductorDto);
          int respuesta = await daoIptv.ActulizaReproductorAsync(ID_REPRODUCTOR, reproductor);
          switch (respuesta == 0)
          {
            case true:
              if (reproductor.ID_GRUPO == 0)
              {
                Grupo grupo = await daoIptv.ObtenerGrupoReproAsync(ID_REPRODUCTOR);

                if (grupo != null && grupo.ID_GRUPO > 0)
                  await daoIptv.EliminarReproductorGrupoAsync(ID_REPRODUCTOR, grupo.ID_GRUPO);
                Reproductor repo = await daoIptv.ObtenerReproductorTemplateAsync(ID_REPRODUCTOR);
                if (reproductorDto.ID_TEMPLATE > 0)
                {
                  if (repo.template != null)
                    await daoIptv.ActulizaReproductorTemplateAsync(ID_REPRODUCTOR, reproductorDto.ID_TEMPLATE, reproductor.ID_ESTATUS, reproductor.USUARIO);
                  else
                    await daoIptv.AltaReproductorTemplateAsync(ID_REPRODUCTOR, reproductorDto.ID_TEMPLATE, reproductor.ID_ESTATUS, reproductor.USUARIO);
                }
                else
                  await daoIptv.EliminarReproductorTemplateAsync(ID_REPRODUCTOR);
              }
              else
              {
                Grupo grupo = await daoIptv.ObtenerGrupoAsync(reproductor.ID_GRUPO);
                await daoIptv.EliminarReproductorGrupoAsync(ID_REPRODUCTOR, reproductor.ID_GRUPO);
                if (reproductorDto.ID_TEMPLATE > 0)
                  await daoIptv.AltaReproductorGrupoAsync(reproductor.ID_GRUPO, ID_REPRODUCTOR, grupo.ID_TEMPLATE, reproductor.USUARIO);
                else
                  await daoIptv.EliminarReproductorTemplateAsync(ID_REPRODUCTOR);
              }
              break;
            case false:
              throw new ExcepcionIptv("Fallo alta Reproductor");
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

    public async Task<int> EliminaReproductor(int ID_REPRODUCTOR)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          unitOfWork.Begin();
          int respuesta = await daoIptv.EliminarReproductorAsync(ID_REPRODUCTOR);
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
    public async Task<int> ActulizaReloj(int ID_REPRODUCTOR, AltaReproductorDto reproductorDto)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          unitOfWork.Begin();
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          Reproductor reproductor = _mapper.Map<Reproductor>(reproductorDto);
          int respuesta = await daoIptv.ActulizaReljAsync(ID_REPRODUCTOR, reproductor);
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
