using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using iptv.AccesoDatos.DTO;
using iptv.Negocio;
using iptv.Negocio.Utilidades;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.Extensions.Logging;
namespace iptv.Servicios.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TablaDinamicaController : ControllerBase
  {
    IConfiguration configuration;
    IBoTablaDinamica boTablaDinamica;
    ILogger<TablaDinamicaController> _logger;
    public TablaDinamicaController(IConfiguration configuration, IBoTablaDinamica boTablaDinamica, ILogger<TablaDinamicaController> logger)
    {
      this.configuration = configuration;
      this.boTablaDinamica = boTablaDinamica;
      this._logger = logger;
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpPost("AltaTablaDinamica")]
    public async Task<ActionResult<bool>> AltaTablaDinamica()
    {
      try
      {
        string body = "";
        using (StreamReader stream = new StreamReader(Request.Body))
        {
          body = await stream.ReadToEndAsync();
        }
        return Ok(await boTablaDinamica.AltaTablaDinamica(body));
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
    [HttpGet("Catalogo")]
    public async Task<ActionResult<List<TablaDTO>>> Catalogo()
    {
      try
      {
        return Ok(await boTablaDinamica.CatalogoTablas());
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
    [HttpGet("ConsultaTablas/{Pagina:int}/{RegistroPorPagina:int}")]
    public async Task<ActionResult<ConsultaTablaDinamicaDTO>> ConsultaTablas(int Pagina, int RegistroPorPagina)
    {
      try
      {
        return Ok(await boTablaDinamica.ObtnerTablas(Pagina, RegistroPorPagina));
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
    [HttpGet("ConsultaTablaDinamica/{ID_TABLA:int}")]
    public async Task<ActionResult<List<dynamic>>> ConsultaTablaDinamica(int ID_TABLA)
    {
      try
      {
        return Ok(await boTablaDinamica.ObtenerTablaDinamicaIDTabla(ID_TABLA));
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
