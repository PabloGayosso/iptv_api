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
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.Threading;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace iptv.Servicios.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LicenciaController : ControllerBase
  {
    IBoLicenciaActiva boLicenciaActiva;
    IConfiguration configuration;
    ILogger<LicenciaController> _logger;
    public LicenciaController(IBoLicenciaActiva boLicenciaActiva, IConfiguration configuration, ILogger<LicenciaController> logger)
    {
      this.boLicenciaActiva = boLicenciaActiva;
      this.configuration = configuration;
      this._logger = logger;
    }
    [EnableCors("MyPolicy")]
    [HttpPost("AltaLicenciaActiva")]
    public async Task<ActionResult<bool>> AltaLicenciaActiva()
    {
      try
      {
        string Licencia = "";
        FormCollection ListaArchivos = null;
        await Task.Run(() =>
        {
          HttpRequest fromData = Request;
          ListaArchivos = (FormCollection)fromData.Form;
        });
        Thread.Sleep(3000);
        await Task.Factory.StartNew(() =>
        {
          Parallel.For(0, ListaArchivos.Files.Count, iContador =>
          {
              FormFile Archivo = (FormFile)ListaArchivos.Files.ElementAt(iContador);
              StreamReader stream = new StreamReader(Archivo.OpenReadStream());
              Licencia = stream.ReadLine();
              stream.Close();
          });
        }, TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
       
        return Ok(await boLicenciaActiva.AltaLicenciaActiva(Licencia));
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
