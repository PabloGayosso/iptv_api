using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using iptv.AccesoDatos.DTO;
using iptv.Negocio;
using iptv.Negocio.Utilidades;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using iptv.Servicios.LogIPTV;

namespace iptv.Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanalController : ControllerBase
    {
        IBoCanal boCanal;
        IConfiguration configuration;
        ILogger<CanalController> _logger;
        public CanalController(IBoCanal boCanal, IConfiguration configuration, ILogger<CanalController> logger)
        {
            this.boCanal = boCanal;
            this.configuration = configuration;
            this._logger = logger;
        }
        [EnableCors("MyPolicy")]
        [HttpGet("ObtenerCanales/{Pagina:int}/{RegistrosPagina:int}/{Busqueda}")]
        public async Task<ActionResult<ConsultaCanalDto>> ObtenerCanales(int Pagina, int RegistrosPagina, string Busqueda)
        {
            try
            {
                return Ok(await boCanal.CosultaCanales(Pagina, RegistrosPagina, Busqueda));
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
  
        [EnableCors("MyPolicy")]
        [HttpGet("ObtenerCanal/{ID_CANAL:int}")]
        public async Task<ActionResult<CanalDto>> ObtenerCanal(int ID_CANAL)
        {
            try
            {
                return Ok(await boCanal.ConsultaCanal(ID_CANAL));
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
        [EnableCors("MyPolicy")]
        [HttpGet("ObtenerCanalesActivos")]
        public async Task<ActionResult<List<CanalDto>>> ObtenerCanalesActivos()
        {
            try
            {
                return Ok(await boCanal.CanalesActivos());
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
        [HttpPost("AltaCanal")]
        public async Task<ActionResult<bool>> AltaCanal(AltaCanalDto canalDto)
        {
            try
            {
                return Ok(await boCanal.AltaCanal(canalDto));
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
                Logger.LogError("AltaCanal: " + ex.Message + " " + ex.StackTrace);
                _logger.LogError(strMensajeError + ex.Message, ex);
                return NotFound(new Exception("Error al realizar la operación, contacte al administrador del sistema"));
                //return NotFound(ex.Message);
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpPut("ActulizaCanal/{ID_CANAL:int}")]
        public async Task<ActionResult<bool>> ActulizaCanal(int ID_CANAL, AltaCanalDto canalDto)
        {
            try
            {
                return Ok(await boCanal.ActulizaCanal(ID_CANAL, canalDto));
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
        [HttpPut("CambioContenidoCanal")]
        public async Task<ActionResult<bool>> CambioContenidoCanal(AltaCanalDto canalDto)
        {
            try
            {
                return Ok(await boCanal.CambioContenidoCanal(canalDto));
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