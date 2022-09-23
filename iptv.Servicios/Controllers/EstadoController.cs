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
  public class EstadoController : ControllerBase
  {
    IBoEstado boEstado;
    IConfiguration configuration;
    ILogger<EstadoController> _logger;
    public EstadoController(IBoEstado boEstado, IConfiguration configuration, ILogger<EstadoController> logger)
    {
      this.boEstado = boEstado;
      this.configuration = configuration;
      this._logger = logger;
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerEstados")]
    public async Task<ActionResult<List<EstadoDto>>> ObtenerEstados()
    {
      try
      {
        return Ok(await boEstado.ObtenerEstados());
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
