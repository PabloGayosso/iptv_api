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
using Microsoft.Extensions.Logging;
using iptv.Servicios.Log;

namespace iptv.Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        IBoAutenticacion boAutenticacion;
        IConfiguration configuration;
        ILogger<AutenticacionController> _logger;
        public AutenticacionController(IBoAutenticacion boAutenticacion, IConfiguration configuration, ILogger<AutenticacionController> _logger)
        {
            this.boAutenticacion = boAutenticacion;
            this.configuration = configuration;
            this._logger = _logger;
        }
        [EnableCors("MyPolicy")]
        [HttpPost("Autenticar")]
        public async Task<ActionResult<AutenticarTokenDto>> Autenticar(AutenticacionDto autenticacionDto)
        {
            try
            {
                return Ok(await boAutenticacion.Autenticar(autenticacionDto));
            }
            catch (ExcepcionIptv ex)
            {
                var msg = new ExcepcionIptv(ex.ErrorLicencia, ex.Message);
                _logger.LogWarning(ex.Message);
                return BadRequest(msg);
            }
            catch (Exception ex)
            {
                //Guid objGuid = Guid.NewGuid();
                string strMensajeError = "Error en: " + this.GetType().FullName + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : ";
                //log.Error(strMensajeError + e.Message, e);
                Logger.LogError(strMensajeError + ex.Message);
                _logger.LogError(strMensajeError + ex.Message, ex);
                return NotFound(new Exception("Error al realizar la operación, contacte al administrador del sistema"));
                //return NotFound(ex.Message);
            }
        }
    [EnableCors("MyPolicy")]
    [HttpGet("GetSerial")]
    public async Task<ActionResult<SerialDTO>> GetSerial()
    {
      try
      {
        return Ok(await boAutenticacion.GetSerial());
      }
      catch (ExcepcionIptv ex)
      {
        var msg = new ExcepcionIptv(ex.ErrorLicencia, ex.Message);
        _logger.LogWarning(ex.Message);
        return BadRequest(msg);
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
