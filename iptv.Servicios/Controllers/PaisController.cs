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
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace iptv.Servicios.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PaisController : ControllerBase
  {
    IBoPais boPais;
    IConfiguration configuration;
    ILogger<PaisController> _logger;
    public PaisController(IBoPais boPais, IConfiguration configuration, ILogger<PaisController> logger)
    {
      this.boPais = boPais;
      this.configuration = configuration;
      this._logger = logger;
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerPais/{ID_PAIS:int}")]
    public async Task<ActionResult<PaisDto>> ObtenerPais(int ID_PAIS)
    {
      try
      {
        return Ok(await boPais.ConsultaPais(ID_PAIS));
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
    [HttpGet("ObtenerPaises")]
    public async Task<ActionResult<List<PaisDto>>> ObtenerPaises()
    {
      try
      {
        return Ok(await boPais.ConsultaPaises());
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