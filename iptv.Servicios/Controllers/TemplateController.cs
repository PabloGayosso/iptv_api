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
using iptv.Servicios.LogIPTV;

namespace iptv.Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        IBoTemplate boTemplate;
        IConfiguration configuration;
        ILogger<TemplateController> _logger;
        public TemplateController(IBoTemplate boTemplate, IConfiguration configuration, ILogger<TemplateController> logger)
        {
            this.boTemplate = boTemplate;
            this.configuration = configuration;
            this._logger = logger;
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpGet("ObtenerTemplatesDirecto/{Busqueda}/{Pagina:int}/{RegistrosPagina:int}")]
        public async Task<ActionResult<ConsultaTemplateDto>> ObtenerTemplatesDirecto(string Busqueda, int Pagina, int RegistrosPagina)
        {
            try
            {
                return Ok(await boTemplate.ConsultaTemplateDicrecto(Busqueda, Pagina, RegistrosPagina));
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
        [HttpGet("ObtenerTemplates/{Busqueda}/{Pagina:int}/{RegistrosPagina:int}")]
        public async Task<ActionResult<ConsultaTemplateDto>> ObtenerTemplates(string Busqueda, int Pagina, int RegistrosPagina)
        {
            try
            {
                return Ok(await boTemplate.ConsultaTemplates(Busqueda, Pagina, RegistrosPagina));
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
        [HttpGet("ObtenerTemplatesCatalogo")]
        public async Task<ActionResult<List<TemplateDto>>> ObtenerTemplatesCatalogo()
        {
            try
            {
                return Ok(await boTemplate.ConsultaTemplatesCatalogo());
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
        [HttpGet("ObtenerTemplate/{ID_TEMPLATE:int}")]
        public async Task<ActionResult<TemplateDto>> ObtenerTemplate(int ID_TEMPLATE)
        {
            try
            {
                return Ok(await boTemplate.ConsultaTemplate(ID_TEMPLATE));
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
        [HttpPost("AltaTemplate")]
        public async Task<ActionResult<bool>> AltaTemplate(AltaTemplateDto templateDto)
        {
            try
            {
                return Ok(await boTemplate.AltaTemplate(templateDto));
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
        //[Authorize]
        [EnableCors("MyPolicy")]
        [HttpPost("GenerarXML")]
        public async Task<ActionResult<bool>> GenerarXML(AltaXMLDto altaXml)
        {
            try
            {
                string Ruta = configuration.GetSection("Rutas").GetValue<string>("RutaContenidos");
                return Ok(await boTemplate.GenerarXML(altaXml.ID_TEMPLATE, altaXml.ID_REPRODUCTOR, Ruta));
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
                Logger.LogError(strMensajeError +" "+ ex.Message);
                _logger.LogError(strMensajeError + ex.Message, ex);
                return NotFound(new Exception("Error al realizar la operación, contacte al administrador del sistema"));
                //return NotFound(ex.Message);
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpPost("PreviewTemplate")]
        public async Task<ActionResult<bool>> PreviewTemplate(AltaXMLDto altaXml)
        {
            try
            {
                return Ok(await boTemplate.PreviewTemplate(altaXml.ID_TEMPLATE));
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
        [HttpPut("AcctulizaTemplate/{ID_TEMPLATE:int}")]
        public async Task<ActionResult<bool>> AcctulizaTemplate(int ID_TEMPLATE, AltaTemplateDto templateDto)
        {
            try
            {
                return Ok(await boTemplate.ActulizaTemplate(ID_TEMPLATE, templateDto));
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
        [HttpPut("ExtatusTemplate/{ID_TEMPLATE:int}")]
        public async Task<ActionResult<bool>> ExtatusTemplate(int ID_TEMPLATE, AltaTemplateDto templateDto)
        {
            try
            {
                return Ok(await boTemplate.EstatusTemplate(ID_TEMPLATE, templateDto));
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
