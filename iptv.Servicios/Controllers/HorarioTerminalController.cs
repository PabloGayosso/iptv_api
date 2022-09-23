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
    public class HorarioTerminalController : ControllerBase
    {
        IBoHorarioTerminal boHorarioTerminal;
        IConfiguration configuration;
        ILogger<HorarioTerminalController> _logger;
        public HorarioTerminalController(IBoHorarioTerminal boHorarioTerminal, IConfiguration configuration, ILogger<HorarioTerminalController> logger)
        {
            this.boHorarioTerminal = boHorarioTerminal;
            this.configuration = configuration;
            this._logger = logger;
        }

        [EnableCors("MyPolicy")]
        [HttpGet("ObtenerHorariosTerminal")]
        public async Task<ActionResult<List<HorarioTerminalDto>>> ObtenerHorariosTerminal()
        {
            try
            {
                return Ok(await boHorarioTerminal.ObtenerHorarioTerminal());
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
        [HttpGet("ObtenerHorariosGrupo/{ID_GRUPO:int}")]
        public async Task<ActionResult<HorarioTerminalDto>> ObtenerHorariosGrupo(int ID_GRUPO)
        {
            try
            {
                return Ok(await boHorarioTerminal.ObtenerHorarioGrupo(ID_GRUPO));
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
        [HttpPost("AltaHorarioGrupo")]
        public async Task<ActionResult<bool>> AltaHorarioGrupo(AltaHorarioTerminalDto altaHorarioTerminalDto)
        {
            try
            {
                return Ok(await boHorarioTerminal.AltaHorarioGrupo(altaHorarioTerminalDto));
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
        [HttpPost("AltaHorarioTerminal")]
        public async Task<ActionResult<bool>> AltaHorarioTerminal(AltaHorarioTerminalDto altaHorarioTerminalDto)
        {
            try
            {
                return Ok(await boHorarioTerminal.AltaHorarioTerminal(altaHorarioTerminalDto));
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
        [HttpPut("ActulizaHorarioTerminal/{IdTvHorarioTerminal:int}")]
        public async Task<ActionResult<bool>> ActulizaHorarioTerminal(int IdTvHorarioTerminal, AltaHorarioTerminalDto altaHorarioTerminalDto)
        {
            try
            {
                return Ok(await boHorarioTerminal.ActulizaHorarioTerminal(IdTvHorarioTerminal,altaHorarioTerminalDto));
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
