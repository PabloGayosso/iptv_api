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
  public class GrupoController : ControllerBase
  {
    IBoGrupo boGrupo;
    IConfiguration configuration;
    ILogger<GrupoController> _logger;
    public GrupoController(IBoGrupo boGrupo, IConfiguration configuration, ILogger<GrupoController> logger)
    {
      this.boGrupo = boGrupo;
      this.configuration = configuration;
      this._logger = logger;
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerGrupos/{Busqueda}/{Pagina:int}/{RegistrosPagina:int}")]
    public async Task<ActionResult<ConsultaGruposDto>> ObtenerGrupos(string Busqueda, int Pagina, int RegistrosPagina)
    {
      try
      {
        return Ok(await boGrupo.CosultaGrupos(Busqueda, Pagina, RegistrosPagina));
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
    [HttpGet("ObtenerGruposCatalogo/{Opcion:int}")]
    public async Task<ActionResult<List<GrupoDto>>> ObtenerGruposCatalogo(int Opcion)
    {
      try
      {
        return Ok(await boGrupo.CosultaGruposCatalogo(Opcion));
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
    [HttpGet("ObtenerGrupo/{ID_GRUPO:int}")]
    public async Task<ActionResult<GrupoDto>> ObtenerGrupo(int ID_GRUPO)
    {
      try
      {
        return Ok(await boGrupo.ConsultaGrupo(ID_GRUPO));
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
    [HttpPost("AltaGrupo")]
    public async Task<ActionResult<bool>> AltaGrupo(AltaGrupoDto altaGrupoDto)
    {
      try
      {
        return Ok(await boGrupo.AltaGrupo(altaGrupoDto));
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
    [HttpPut("ActulizaGrupo/{ID_GRUPO:int}")]
    public async Task<ActionResult<bool>> ActulizaGrupo(int ID_GRUPO, AltaGrupoDto altaGrupoDto)
    {
      try
      {
        return Ok(await boGrupo.ActulizaGrupo(ID_GRUPO, altaGrupoDto));
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