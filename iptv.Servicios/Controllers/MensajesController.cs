using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using iptv.AccesoDatos.DTO;
using iptv.Negocio;
using iptv.Negocio.Utilidades;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace iptv.Servicios.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MensajesController : ControllerBase
  {
    IConfiguration configuration;
    IBoMensaje boMensaje;
    ILogger<MensajesController> _logger;
    public MensajesController(IConfiguration configuration, IBoMensaje boMensaje, ILogger<MensajesController> logger)
    {
      this.configuration = configuration;
      this.boMensaje = boMensaje;
      this._logger = logger;
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerMensajes/{Busqueda}/{Pagina:int}/{RegistrosPagina:int}")]
    public async Task<ActionResult<ConsultaMensajesDto>> ObtenerMensajes(string Busqueda, int Pagina, int RegistrosPagina)
    {
      try
      {
        return Ok(await boMensaje.ConsultarMensajes(Busqueda, Pagina, RegistrosPagina));
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
    [HttpGet("CatMensajes")]
    public async Task<ActionResult<List<MensajeDto>>> CatMensajes()
    {
      try
      {
        return Ok(await boMensaje.ConsultaCatMensajes());
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
    [HttpGet("ObtenerMensaje/{ID_MENSAJE:int}")]
    public async Task<ActionResult<ConsultaMensajesDto>> ObtenerMensaje(int ID_MENSAJE)
    {
      try
      {
        return Ok(await boMensaje.ConsultaMensaje(ID_MENSAJE));
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
    [HttpPost("AltaMensaje")]
    public async Task<ActionResult<bool>> AltaMensaje(AltaMensajeDto mensajeDto)
    {
      try
      {
        return Ok(await boMensaje.AltaMensaje(mensajeDto));
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
    [HttpPut("ActulizaMensaje/{ID_MENSAJE:int}")]
    public async Task<ActionResult<bool>> ActulizaMensaje(int ID_MENSAJE, AltaMensajeDto mensajeDto)
    {
      try
      {
        return Ok(await boMensaje.ActulizaMensaje(ID_MENSAJE, mensajeDto));
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
