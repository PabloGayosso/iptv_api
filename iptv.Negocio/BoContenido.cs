using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Enum;
using iptv.Negocio.Utilidades;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace iptv.Negocio
{
  public class BoContenido : IBoContenido
  {
    IConfiguration configuration;
    IMapper _mapper;
    public BoContenido(IConfiguration configuration, IMapper _mapper)
    {
      this.configuration = configuration;
      this._mapper = _mapper;
    }
    public async Task<List<ContenidoDto>> ConsultaContenidosActivos(int ID_CANAL, int ID_TIPO_CANAL)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          List<Contenido> contenidos;
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          switch (ID_TIPO_CANAL)
          {
            case (int)CatTipoCanal.IMAGEN:
            case (int)CatTipoCanal.MUSICA:
            case (int)CatTipoCanal.VIDEOIMAGEN:
              contenidos = await daoIptv.ConsultaContenidoMediaActivos((int)CatEstatus.ACTIVO, ID_TIPO_CANAL);
              break;
            case (int)CatTipoCanal.TEXTO:
              contenidos = await daoIptv.ConsultaContenidoTextActivos((int)CatEstatus.ACTIVO, ID_TIPO_CANAL);
              break;
            case (int)CatTipoCanal.TVDIRECTO:
              contenidos = await daoIptv.ConsultaContenidoActivos((int)CatEstatus.ACTIVO, ID_TIPO_CANAL);
              break;
            case (int)CatTipoCanal.TABLA:
              contenidos = await daoIptv.ConsultaContenidoTablaAtivos((int)CatEstatus.ACTIVO, ID_TIPO_CANAL);
              break;
            default:
              throw new ExcepcionIptv("¡Tipo canal no encontrado!");
          }
          List<ContenidoDto> contenidoDto = _mapper.Map<List<ContenidoDto>>(contenidos);
          return contenidoDto;
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
    public async Task<ConsultaContenidoDto> ConsultaContenidos(string Busqueda, int Filtro, int Pagina, int RegistrosPagina)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          List<Contenido> contenidos = await daoIptv.ObtenerContenidosAsync(Busqueda, Filtro, Pagina, RegistrosPagina);
          List<ContenidoDto> contenidoDto = _mapper.Map<List<ContenidoDto>>(contenidos);
          int total = await daoIptv.ObtenerTotalContenidosAsync();
          ConsultaContenidoDto consulta = new ConsultaContenidoDto()
          {
            contenido = contenidoDto,
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
    public async Task<ContenidoDto> ConsultaContenido(int ID_CONTENIDO)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          Contenido contenido = await daoIptv.ObtenerContenidoAsync(ID_CONTENIDO);
          ContenidoDto contenidoDto = _mapper.Map<ContenidoDto>(contenido);
          return contenidoDto;
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
    public async Task<int> AltaContenido(AltaContenidoDto Contenido, string NombreCompleto, string NombreActual, string Nombre, string Extension, int tipoContenido)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          var respuesta = 0;
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          unitOfWork.Begin();
          Contenido contenido = _mapper.Map<Contenido>(Contenido);
          switch (contenido.ID_TIPO_CANAL)
          {
            case (int)CatTipoCanal.IMAGEN:
            case (int)CatTipoCanal.MUSICA:
            case (int)CatTipoCanal.VIDEOIMAGEN:
              Repositorio repositorio = new Repositorio()
              {
                RUTA_ALOJAMIENTO = NombreActual,
                DESCRIPCION = Nombre,
                USUARIO = Contenido.USUARIO,
                ID_TIPO_CONTENIDO = tipoContenido,
                EXTENSION = Extension,
                ID_ESTATUS = Convert.ToInt32(CatEstatus.ACTIVO)
              };
              respuesta = await daoIptv.AltaRepositorioAsync(repositorio);
              if (respuesta > 0)
              {
                contenido.ID_REPOSITORIO = respuesta;
                contenido.RUTA = NombreCompleto;
                contenido.NOMBRE = NombreActual;
                respuesta = await daoIptv.AltaContenidoMultimediaAsync(contenido);

              }
              else throw new ExcepcionIptv("¡Contenido no valido!");
              break;
            case (int)CatTipoCanal.TEXTO:
              respuesta = await daoIptv.AltaMensajeAsync(contenido.mensaje);
              if (respuesta > 0)
              {
                contenido.ID_MENSAJE = respuesta;
                contenido.NOMBRE = contenido.mensaje.NOMBRE;
                contenido.RUTA = contenido.RUTA;
                respuesta = await daoIptv.AltaContenidoTextoAsync(contenido);
              }
              else throw new ExcepcionIptv("¡Mensaje no valido!");
              break;
            case (int)CatTipoCanal.TVDIRECTO:
              respuesta = await daoIptv.AltaContenidoTvDirectoAsync(contenido);
              break;
            default:
              throw new ExcepcionIptv("¡Tipo contenido no valido!");
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
    public async Task<int> NuevoContenido(AltaContenidoDto contenidoDto)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          var respuesta = 0;
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          unitOfWork.Begin();
          Contenido contenido = _mapper.Map<Contenido>(contenidoDto);
          switch (contenido.ID_TIPO_CANAL)
          {
            case (int)CatTipoCanal.IMAGEN:
            case (int)CatTipoCanal.MUSICA:
            case (int)CatTipoCanal.VIDEOIMAGEN:
              if (contenido.repositorio.ID_REPOSITORIO > 0)
              {
                contenido.ID_REPOSITORIO = contenido.repositorio.ID_REPOSITORIO;
                contenido.RUTA = contenido.repositorio.RUTA_ALOJAMIENTO;
                contenido.NOMBRE = contenido.repositorio.DESCRIPCION;
                respuesta = await daoIptv.AltaContenidoMultimediaAsync(contenido);
              }
              else throw new ExcepcionIptv("¡Contenido no valido!");
              break;
            case (int)CatTipoCanal.TEXTO:
              respuesta = await daoIptv.AltaMensajeAsync(contenido.mensaje);
              if (respuesta > 0)
              {
                contenido.ID_MENSAJE = respuesta;
                contenido.NOMBRE = contenido.mensaje.NOMBRE;
                contenido.RUTA = contenido.RUTA;
                respuesta = await daoIptv.AltaContenidoTextoAsync(contenido);
              }
              else throw new ExcepcionIptv("¡Mensaje no valido!");
              break;
            case (int)CatTipoCanal.TVDIRECTO:
              respuesta = await daoIptv.AltaContenidoTvDirectoAsync(contenido);
              break;
            default:
              throw new ExcepcionIptv("¡Tipo contenido no valido!");
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
    public async Task<int> ActulizaContenido(int ID_CONTENIDO, AltaContenidoDto contenidoDto)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          var respuesta = 0;
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          unitOfWork.Begin();
          Contenido contenido = _mapper.Map<Contenido>(contenidoDto);
          switch (contenido.ID_TIPO_CANAL)
          {
            case (int)CatTipoCanal.IMAGEN:
            case (int)CatTipoCanal.MUSICA:
            case (int)CatTipoCanal.VIDEOIMAGEN:
              respuesta = await daoIptv.ActulizaContenidoMultimediaAsync(ID_CONTENIDO, contenido);
              break;
            case (int)CatTipoCanal.TEXTO:
              Mensaje mensaje = await daoIptv.ObtenerMensajeAsync(contenido.ID_MENSAJE);
              if (mensaje.ID_MENSAJE > 0)
              {
                respuesta = await daoIptv.ActulizaMensajeAsync(mensaje.ID_MENSAJE, contenido.mensaje);
                contenido.RUTA = "TEXTO";
                respuesta = await daoIptv.ActulizaContenidoTextoAsync(ID_CONTENIDO, contenido);
              }
              else throw new ExcepcionIptv("¡Mensaje no valido!");
              break;
            case (int)CatTipoCanal.TVDIRECTO:
              respuesta = await daoIptv.ActulizaContenidoTvDirectoAsync(ID_CONTENIDO, contenido);
              break;
            default:
              throw new ExcepcionIptv("¡Tipo canal no encontrado!");
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
    public async Task<int> EliminarContenido(int ID_CONTENIDO)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          var respuesta = 0;
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          unitOfWork.Begin();
          Contenido contenido = await daoIptv.ObtenerContenidoAsync(ID_CONTENIDO);
          switch (contenido.ID_TIPO_CANAL)
          {
            case (int)CatTipoCanal.IMAGEN:
            case (int)CatTipoCanal.MUSICA:
            case (int)CatTipoCanal.VIDEOIMAGEN:
              if (contenido.repositorio.ID_REPOSITORIO > 0)
              {
                RepositorioDLNA repo = await daoIptv.ContultarCatalogoRepositorioNombreAsync(contenido.repositorio.RUTA_ALOJAMIENTO);
                respuesta = await daoIptv.EliminarContenidoAsync(ID_CONTENIDO);
                respuesta = await daoIptv.EliminarRepositorioAsync(contenido.repositorio.ID_REPOSITORIO);
                if (repo.ID_REPOSITORIO > 0)
                  await daoIptv.EliminarCatalogoRepositorioAsync(repo.ID_REPOSITORIO, repo.NOMBRE);
              }
              break;
            case (int)CatTipoCanal.TEXTO:
              if (contenido.mensaje.ID_MENSAJE > 0)
              {
                respuesta = await daoIptv.EliminarContenidoAsync(ID_CONTENIDO);
                respuesta = await daoIptv.EliminarMensajeAsync(contenido.mensaje.ID_MENSAJE);
              }
              else throw new ExcepcionIptv("¡Mensaje no valido!");
              break;
            case (int)CatTipoCanal.TVDIRECTO:
              respuesta = await daoIptv.EliminarContenidoAsync(ID_CONTENIDO);
              break;
            default:
              throw new ExcepcionIptv("¡Tipo canal no encontrado!");
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
    public async Task<int> LimpiarRepositorioDLNA()
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          unitOfWork.Begin();
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          int respuesta = await daoIptv.LimpiarRepositorioDLNAAsync();
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

    public async Task<ContenidoDto> AltaRepositorio(string NombreActual, string Nombre, string Extension, TimeSpan duration, int tipoContenido, string UsuarioRegistro)
    {
      using (NegocioSesion nSession = new NegocioSesion(configuration))
      {
        UnitOfWork unitOfWork = nSession.UnitOfWork;
        try
        {
          unitOfWork.Begin();
          DaoIptv daoIptv = new DaoIptv(unitOfWork);
          Contenido contenido = new Contenido();
          Repositorio repositorio = new Repositorio()
          {
            RUTA_ALOJAMIENTO = Nombre,
            DESCRIPCION = Nombre,
            USUARIO = UsuarioRegistro,
            ID_TIPO_CONTENIDO = tipoContenido,
            EXTENSION = Extension,
            DURACION = duration,
            ID_ESTATUS = Convert.ToInt32(CatEstatus.ACTIVO)
          };
          var respuesta = await daoIptv.AltaRepositorioAsync(repositorio);
          if (respuesta > 0)
          {
            RepositorioDLNA repo = await daoIptv.ContultarCatalogoRepositorioNombreAsync(repositorio.RUTA_ALOJAMIENTO);
            repositorio.rutaCatalogo = repo.RUTA_ALOJAMIENTO;
            repositorio.ID_REPOSITORIO = respuesta;
            contenido.USUARIO = UsuarioRegistro;
            contenido.ID_REPOSITORIO = respuesta;
            contenido.RUTA = NombreActual;
            contenido.NOMBRE = Nombre;
            contenido.ID_TIPO_CANAL = TipoContenido.getTipoCanal(Extension);
            contenido.ID_ESTATUS = Convert.ToInt32(CatEstatus.INACTIVO);
            respuesta = await daoIptv.AltaContenidoMultimediaAsync(contenido);
          }
          contenido.ID_CONTENIDO = respuesta;
          contenido.repositorio = repositorio;
          ContenidoDto contenidoDto = _mapper.Map<ContenidoDto>(contenido);
          unitOfWork.Commit();
          return contenidoDto;
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
