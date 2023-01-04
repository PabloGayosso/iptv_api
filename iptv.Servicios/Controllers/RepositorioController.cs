using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using iptv.AccesoDatos.DTO;
using iptv.Negocio;
using iptv.Negocio.Utilidades;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using iptv.Servicios.Log;

namespace iptv.Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositorioController : ControllerBase
    {
        IConfiguration configuration;
        IBoRepositorio boRepositorio;
        ILogger<RepositorioController> _logger;
        public RepositorioController(IConfiguration configuration, IBoRepositorio boRepositorio, ILogger<RepositorioController> logger)
        {
            this.configuration = configuration;
            this.boRepositorio = boRepositorio;
            this._logger = logger;
        }

        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpPost("AltaContenido")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<bool>> AltaContenido()
        {
            try
            {
                string UsuarioRegistro = "ADMIN";
                FormCollection listaArchivos = null;
                string Ruta = configuration.GetSection("Rutas").GetValue<string>("RutaContenidos");
                await Task.Run(() =>
                {
                    HttpRequest fromData = Request;
                    listaArchivos = (FormCollection)fromData.Form;
                });
                await Task.Factory.StartNew(() =>
                {
                    Parallel.For(0, listaArchivos.Files.Count, iContador =>
                    {
                              FormFile Archivo = (FormFile)listaArchivos.Files.ElementAt(iContador);
                              Stream stream = Archivo.OpenReadStream();
                              BinaryReader binaryReader = new BinaryReader(stream);
                              byte[] Arreglobytes = binaryReader.ReadBytes((Int32)stream.Length);
                              string Nombre = Guid.NewGuid().ToString();
                              string Extension = Archivo.FileName.Split('.')[Archivo.FileName.Split('.').Length - 1];
                              string NombreActual = Archivo.FileName.Split('.')[0];
                              string tipoArchivo = "";
                              switch (Extension.ToLower())
                              {
                                  case "jpg":
                                  case "jpeg":
                                  case "raw":
                                  case "psd":
                                  case "png":
                                  case "gif":
                                      tipoArchivo = "Imagenes";
                                      break;
                                  case "mp3":
                                  case "wma":
                                  case "wav":
                                  case "cda":
                                  case "midi":
                                  case "aac":
                                  case "aiff":
                                  case "flac":
                                      tipoArchivo = "Musica";
                                      break;
                                  case "mp4":
                                  case "avi":
                                  case "mpeg":
                                  case "mpg":
                                  case "qt":
                                  case "wmv":
                                  case "ram":
                                  case "rm":
                                  case "flv":
                                  case "mkv":
                                      tipoArchivo = "Videos";
                                      break;
                              }
                              string RutaInterna = $"{Ruta}/{tipoArchivo}";
                              string NombreCompleto = $"{RutaInterna}/{Nombre}.{Extension}";
                              int tipoContenido = TipoContenido.getTipoContenido(Extension);
                              switch (Directory.Exists(RutaInterna))
                              {

                                  case false:
                                      Directory.CreateDirectory(RutaInterna);
                                      break;

                              }
                              System.IO.File.WriteAllBytes(NombreCompleto, Arreglobytes);
                              boRepositorio.AltaRepositorio(NombreActual, Nombre, Extension, tipoContenido, UsuarioRegistro);
                          });
                }, TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
                return Ok(true);
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                ////Guid objGuid = Guid.NewGuid();
                //string strMensajeError = "Error en: " + this.GetType().FullName + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : ";
                ////log.Error(strMensajeError + e.Message, e);
                //_logger.LogError(strMensajeError + ex.Message, ex);
                //return NotFound(new Exception("Error al realizar la operación, contacte al administrador del sistema"));
                ////return NotFound(ex.Message);

                Logger.Log_Error(_logger, this.GetType().FullName, "AltaContenido", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [EnableCors("MyPolicy")]
        [HttpGet("{IdRepositorio:int}/multimedia/{NombreActual}/{Nombre}/{Extencion}")]
        public async Task<ActionResult<HttpResponseMessage>> multimedia(int IdRepositorio, string NombreActual, string Nombre, string Extencion)
        {
            try
            {
                string tipoArchivo = "";
                switch (Extencion.ToLower())
                {
                    case "jpg":
                    case "jpeg":
                    case "raw":
                    case "psd":
                    case "png":
                    case "gif":
                        tipoArchivo = "Imagenes";
                        break;
                    case "mp3":
                    case "wma":
                    case "wav":
                    case "cda":
                    case "midi":
                    case "aac":
                    case "aiff":
                    case "flac":
                        tipoArchivo = "Musica";
                        break;
                    case "mp4":
                    case "avi":
                    case "mpeg":
                    case "mpg":
                    case "qt":
                    case "wmv":
                    case "ram":
                    case "rm":
                    case "flv":
                    case "mkv":
                        tipoArchivo = "Videos";
                        break;
                }
                string Ruta = configuration.GetSection("Rutas").GetSection("RutaContenidos").Value;
                byte[] arrayByte = System.IO.File.ReadAllBytes($"{Ruta}/{tipoArchivo}/{Nombre}.{Extencion}");
                string mediaType = Archivos.ObtenerMine(Extencion);
                return File(arrayByte, mediaType);
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "multimedia", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpGet("Repositorios/{Busqueda}/{ID_TIPO_CONTENIDO:int}/{Pagina:int}/{RegistrosPagina:int}")]
        public async Task<ActionResult<ConsultaRepositorioDto>> Repositorios(string Busqueda, int ID_TIPO_CONTENIDO, int Pagina, int RegistrosPagina)
        {
            try
            {
                return Ok(await boRepositorio.ObtnerRepositorios(Busqueda, ID_TIPO_CONTENIDO, Pagina, RegistrosPagina));
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "Repositorios", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpGet("RepositorioContenido/{ID_TIPO_CONTENIDO:int}")]
        public async Task<ActionResult<List<RepositorioDto>>> RepositorioContenido(int ID_TIPO_CONTENIDO)
        {
            try
            {
                return Ok(await boRepositorio.ObtenerRepositorioTipoContenido(ID_TIPO_CONTENIDO));
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "RepositorioContenido", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }

        [EnableCors("MyPolicy")]
        [HttpGet("ReproMultimedia/{IdRepositorio:int}/multimedia/{NombreActual}/{Nombre}/{Extencion}")]
        public async Task<ActionResult<FileResult>> ReproMultimedia(string Nombre, string Extencion)
        {
            try
            {
                string tipoArchivo = "";
                switch (Extencion.ToLower())
                {
                    case "jpg":
                    case "jpeg":
                    case "raw":
                    case "psd":
                    case "png":
                    case "gif":
                        tipoArchivo = "Imagenes";
                        break;
                    case "mp3":
                    case "wma":
                    case "wav":
                    case "cda":
                    case "midi":
                    case "aac":
                    case "aiff":
                    case "flac":
                        tipoArchivo = "Musica";
                        break;
                    case "mp4":
                    case "avi":
                    case "mpeg":
                    case "mpg":
                    case "qt":
                    case "wmv":
                    case "ram":
                    case "rm":
                    case "flv":
                    case "mkv":
                        tipoArchivo = "Videos";
                        break;
                }
                string Ruta = configuration.GetSection("Rutas").GetSection("RutaContenidos").Value;
                string mediaType = Archivos.ObtenerMine(Extencion);
                var res = File(System.IO.File.OpenRead($"{Ruta}/{tipoArchivo}/{Nombre}.{Extencion}"), mediaType);
                res.EnableRangeProcessing = true;
                return res;
                //return new VirtualFileResult($"{Ruta}/{tipoArchivo}/{Nombre}.{Extencion}", "video/mp4");
                //return PhysicalFile($"{Ruta}/{tipoArchivo}/{Nombre}.{Extencion}", "application/octet-stream", enableRangeProcessing: true);
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "ReproMultimedia", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpGet("CatReproductor/{NOMBRE}/{EXTENCION}")]
        public async Task<ActionResult<RepositorioDLNADto>> CatReproductor(string NOMBRE, string EXTENCION)
        {
            try
            {
                return Ok(await boRepositorio.ObtenerCatalogoRepositorioNombre(NOMBRE));
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "CatReproductor", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpDelete("Eliminar/{ID_REPOSITORIO:int}")]
        public async Task<ActionResult<bool>> Eliminar(int ID_REPOSITORIO)
        {
            try
            {
                RepositorioDto repositorio = await boRepositorio.ObtenerRepositorio(ID_REPOSITORIO);
                string tipoArchivo = "";
                switch (repositorio.EXTENSION.ToLower())
                {
                    case "jpg":
                    case "jpeg":
                    case "raw":
                    case "psd":
                    case "png":
                    case "gif":
                        tipoArchivo = "Imagenes";
                        break;
                    case "mp3":
                    case "wma":
                    case "wav":
                    case "cda":
                    case "midi":
                    case "aac":
                    case "aiff":
                    case "flac":
                        tipoArchivo = "Musica";
                        break;
                    case "mp4":
                    case "avi":
                    case "mpeg":
                    case "mpg":
                    case "qt":
                    case "wmv":
                    case "ram":
                    case "rm":
                    case "flv":
                    case "mkv":
                        tipoArchivo = "Videos";
                        break;
                }
                string Ruta = configuration.GetSection("Rutas").GetSection("RutaContenidos").Value;
                string mediaType = Archivos.ObtenerMine(repositorio.EXTENSION);
                string MediaRuta = $"{Ruta}/{tipoArchivo}/{repositorio.DESCRIPCION}.{repositorio.EXTENSION}";
                System.IO.File.Delete(MediaRuta);
                return Ok(await boRepositorio.EliminarRepositorio(ID_REPOSITORIO));
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "Eliminar", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
    }
}