using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using iptv.AccesoDatos.DTO;
using iptv.Negocio;
using iptv.Negocio.Utilidades;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
namespace iptv.Servicios.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MensajeVivoController : ControllerBase
  {
    IBoMensajeVivo boMensajeVivo;
    IConfiguration configuration;
    ILogger<MensajeVivoController> _logger;
    public MensajeVivoController(IBoMensajeVivo boMensajeVivo, IConfiguration configuration, ILogger<MensajeVivoController> logger)
    {
      this.boMensajeVivo = boMensajeVivo;
      this.configuration = configuration;
      this._logger = logger;
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerMensajesVivo/{Busqueda}/{Pagina:int}/{RegistrosPagina:int}")]
    public async Task<ActionResult<ConsultaMensajeVivoDto>> ObtenerMensajesVivo(string Busqueda, int Pagina, int RegistrosPagina)
    {
      try
      {
        return Ok(await boMensajeVivo.ConsultaMensajesVivo(Busqueda, Pagina, RegistrosPagina));
      }
      catch (ExcepcionIptv ex)
      {
        _logger.LogWarning(ex.Message);
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        //Guid objGuid = Guid.NewGuid();
        string strMensajeError = "Error en: " + this.GetType().FullName + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : ";
        //log.Error(strMensajeError + e.Message, e);
        _logger.LogError(strMensajeError + ex.Message, ex);
        return NotFound(new Exception("Error al realizar la operación, contacte al administrador del sistema"));
        //return NotFound(ex.Message);
      }
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerMensajeVivo/{ID_MENSAJE:int}")]
    public async Task<ActionResult<MensajeVivoDto>> ObtenerMensajeVivo(int ID_MENSAJE)
    {
      try
      {
        return Ok(await boMensajeVivo.ConsultaMensajeVivo(ID_MENSAJE));
      }
      catch (ExcepcionIptv ex)
      {
        _logger.LogWarning(ex.Message);
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        //Guid objGuid = Guid.NewGuid();
        string strMensajeError = "Error en: " + this.GetType().FullName + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : ";
        //log.Error(strMensajeError + e.Message, e);
        _logger.LogError(strMensajeError + ex.Message, ex);
        return NotFound(new Exception("Error al realizar la operación, contacte al administrador del sistema"));
        //return NotFound(ex.Message);
      }
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerMensajesVivoGrupRep/{Pagina:int}/{RegistrosPagina:int}")]
    public async Task<ActionResult<ConsultaMensajeVivoDto>> ObtenerMensajesVivoGrupRep(int Pagina, int RegistrosPagina)
    {
      try
      {
        return Ok(await boMensajeVivo.ConsultaMensajesVivoGrupRep(Pagina, RegistrosPagina));
      }
      catch (ExcepcionIptv ex)
      {
        _logger.LogWarning(ex.Message);
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        //Guid objGuid = Guid.NewGuid();
        string strMensajeError = "Error en: " + this.GetType().FullName + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : ";
        //log.Error(strMensajeError + e.Message, e);
        _logger.LogError(strMensajeError + ex.Message, ex);
        return NotFound(new Exception("Error al realizar la operación, contacte al administrador del sistema"));
        //return NotFound(ex.Message);
      }
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerMensajeVivoGrupRep/{ID_GRUPO_REPRODUCTOR_MENSAJE:int}")]
    public async Task<ActionResult<MensajeVivoDto>> ObtenerMensajeVivoGrupRep(int ID_GRUPO_REPRODUCTOR_MENSAJE)
    {
      try
      {
        return Ok(await boMensajeVivo.ConsultaMensajeVivoGrupRep(ID_GRUPO_REPRODUCTOR_MENSAJE));
      }
      catch (ExcepcionIptv ex)
      {
        _logger.LogWarning(ex.Message);
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        //Guid objGuid = Guid.NewGuid();
        string strMensajeError = "Error en: " + this.GetType().FullName + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : ";
        //log.Error(strMensajeError + e.Message, e);
        _logger.LogError(strMensajeError + ex.Message, ex);
        return NotFound(new Exception("Error al realizar la operación, contacte al administrador del sistema"));
        //return NotFound(ex.Message);
      }
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpPost("AltaMensajeVivo")]
    public async Task<ActionResult<bool>> AltaMensajeVivo(AltaMensajeVivoDto altaMensajeVivoDto)
    {
      try
      {
        return Ok(await boMensajeVivo.AltaMensajeVivo(altaMensajeVivoDto));
      }
      catch (ExcepcionIptv ex)
      {
        _logger.LogWarning(ex.Message);
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        //Guid objGuid = Guid.NewGuid();
        string strMensajeError = "Error en: " + this.GetType().FullName + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : ";
        //log.Error(strMensajeError + e.Message, e);
        _logger.LogError(strMensajeError + ex.Message, ex);
        return NotFound(new Exception("Error al realizar la operación, contacte al administrador del sistema"));
        //return NotFound(ex.Message);
      }
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpPut("ActulizaMensajeVivo/{ID_MENSAJE:int}")]
    public async Task<ActionResult<bool>> ActulizaMensajeVivo(int ID_MENSAJE, AltaMensajeVivoDto altaMensajeVivoDto)
    {
      try
      {
        return Ok(await boMensajeVivo.ActulizaMensajeVivo(ID_MENSAJE, altaMensajeVivoDto));
      }
      catch (ExcepcionIptv ex)
      {
        _logger.LogWarning(ex.Message);
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        //Guid objGuid = Guid.NewGuid();
        string strMensajeError = "Error en: " + this.GetType().FullName + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : ";
        //log.Error(strMensajeError + e.Message, e);
        _logger.LogError(strMensajeError + ex.Message, ex);
        return NotFound(new Exception("Error al realizar la operación, contacte al administrador del sistema"));
        //return NotFound(ex.Message);
      }
    }
  }
}