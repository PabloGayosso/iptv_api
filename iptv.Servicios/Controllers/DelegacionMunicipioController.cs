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
  public class DelegacionMunicipioController : ControllerBase
  {
    IBoDelegacionMunicipio boDelegacionMunicipio;
    IConfiguration configuration;
    ILogger<DelegacionMunicipioController> _logger;
    public DelegacionMunicipioController(IBoDelegacionMunicipio boDelegacionMunicipio, IConfiguration configuration, ILogger<DelegacionMunicipioController> logger)
    {
      this.boDelegacionMunicipio = boDelegacionMunicipio;
      this.configuration = configuration;
      this._logger = logger;
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerDelegacionMunicipio/{ID_ESTADO:int}")]
    public async Task<ActionResult<List<DelegacionMunicipioDto>>> ObtenerDelegacionMunicipio(int ID_ESTADO)
    {
      try
      {
        return Ok(await boDelegacionMunicipio.ObtenerDelegacionMunicipioEstado(ID_ESTADO));
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
