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
  public class ColoniaController : ControllerBase
  {
    IBoColonia boColonia;
    IConfiguration configuration;
    ILogger<ColoniaController> _logger;
    public ColoniaController(IBoColonia boColonia, IConfiguration configuration, ILogger<ColoniaController> logger)
    {
      this.boColonia = boColonia;
      this.configuration = configuration;
      this._logger = logger;
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerColoniaDelegaccionMunicipio/{ID_ESTADO:int}/{ID_DELEG_MUNICIPIO:int}")]
    public async Task<ActionResult<List<ColoniaDto>>> ObtenerColoniaDelegaccionMunicipio(int ID_ESTADO, int ID_DELEG_MUNICIPIO)
    {
      try
      {
        return Ok(await boColonia.ObtenerColniaIdDelegacionMunicipio(ID_ESTADO, ID_DELEG_MUNICIPIO));
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
