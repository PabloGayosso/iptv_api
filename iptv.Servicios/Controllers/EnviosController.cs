using iptv.AccesoDatos.DTO;
using iptv.Negocio;
using iptv.Negocio.Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace iptv.Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        IBoEnvios boEnvio;
        IConfiguration configuration;
        ILogger<EnviosController> _logger;
        public EnviosController(IBoEnvios boEnvio, IConfiguration configuration, ILogger<EnviosController> logger)
        {
            this.boEnvio = boEnvio;
            this.configuration = configuration;
            this._logger = logger;
        }

        [EnableCors("MyPolicy")]
        [HttpGet("ObtenerEnvios")]
        public async Task<ActionResult<Consulta_EnviosDto>> Consulta_Envios_Async()
        {
            try
            {
                return Ok(await boEnvio.Consulta_Envios_Async());
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
            }
        }

        //[Authorize]
        [EnableCors("MyPolicy")]
        [HttpGet("ObtenerEnviosEstatus/{idEnvio:int}")]
        public async Task<ActionResult<EnviosDto>> Consulta_Envio_Estatus_Async(int idEnvio)
        {
            try
            {
                return Ok(await boEnvio.Consulta_Envio_Estatus_Async(idEnvio));
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
        [HttpGet("ObtenerEnviosAct/{idEnvio:int}/{fec_Busqueda}")]
        public async Task<ActionResult<Consulta_EnviosDto>> Consulta_Envios_Post_Async(int idEnvio, string fec_Busqueda)
        {
            try
            {
                return Ok(await boEnvio.Consulta_Envios_Post_Async(idEnvio, fec_Busqueda));
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
        [HttpGet("ObtenerEnviosH/{Pagina:int}/{RegistrosPagina:int}/{fec_Ini}/{fec_Fin}")]
        public async Task<ActionResult<Consulta_EnviosHDto>> Consulta_Envios_H_Async(int Pagina, int RegistrosPagina, string fec_Ini, string fec_Fin)
        {
            try
            {
                return Ok(await boEnvio.Consulta_Envios_H_Async(Pagina, RegistrosPagina, fec_Ini, fec_Fin));
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
