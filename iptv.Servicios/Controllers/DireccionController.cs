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
  public class DireccionController : ControllerBase
  {
    IBoDireccion boDireccion;
    IConfiguration configuration;
    ILogger<DireccionController> _logger;
    public DireccionController(IBoDireccion boDireccion, IConfiguration configuration, ILogger<DireccionController> logger)
    {
      this.boDireccion = boDireccion;
      this.configuration = configuration;
      this._logger = logger;
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerDirecciones/{Pagina:int}/{RegistrosPagina:int}")]
    public async Task<ActionResult<ConsultaDireccionDto>> ObtenerDirecciones(int Pagina, int RegistrosPagina)
    {
      try
      {
        return Ok(await boDireccion.ConsultaDirecciones(Pagina, RegistrosPagina));
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
    [HttpGet("ObtenerDireccion/{ID_DIRECCION:int}")]
    public async Task<ActionResult<DireccionDto>> ObtenerDireccion(int ID_DIRECCION)
    {
      try
      {
        return Ok(await boDireccion.ConsultaDireccion(ID_DIRECCION));
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
    [HttpPost("AltaDireccion")]
    public async Task<ActionResult<bool>> AltaDireccion(AltaDireccionDto direccionDto)
    {
      try
      {
        return Ok(await boDireccion.AltaDireccion(direccionDto));
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
    [HttpPut("ActulizaDireccion/{ID_DIRECCION:int}")]
    public async Task<ActionResult<bool>> ActulizaDireccion(int ID_DIRECCION, AltaDireccionDto direccionDto)
    {
      try
      {
        return Ok(await boDireccion.ActulizaDireccion(ID_DIRECCION, direccionDto));
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
