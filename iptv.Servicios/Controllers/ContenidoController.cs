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
using iptv.AccesoDatos.Enum;
using iptv.Negocio;
using iptv.Negocio.Utilidades;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using iptv.Servicios.Log;

namespace iptv.Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContenidoController : ControllerBase
    {
        IConfiguration configuration;
        IBoContenido boContenido;
        ILogger<ContenidoController> _logger;
        public ContenidoController(IConfiguration configuration, IBoContenido boContenido, ILogger<ContenidoController> logger)
        {
            this.configuration = configuration;
            this.boContenido = boContenido;
            this._logger = logger;
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpGet("ObtenerContenidos/{Busqueda}/{Filtro:int}/{Pagina:int}/{RegistrosPagina:int}")]
        public async Task<ActionResult<ConsultaContenidoDto>> ObtenerContenidos(string Busqueda, int Filtro, int Pagina, int RegistrosPagina)
        {
            try
            {
                return Ok(await boContenido.ConsultaContenidos(Busqueda, Filtro, Pagina, RegistrosPagina));
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "ObtenerContenidos", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpGet("ObtenerContenido/{ID_CONTENIDO:int}")]
        public async Task<ActionResult<ContenidoDto>> ObtenerContenido(int ID_CONTENIDO)
        {
            try
            {
                return Ok(await boContenido.ConsultaContenido(ID_CONTENIDO));
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "ObtenerContenido", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpGet("ObtenerContenidosActivos/{ID_CANAL:int}/{ID_TIPO_CANAL:int}")]
        public async Task<ActionResult<List<ContenidoDto>>> ObtenerContenidosActivos(int ID_CANAL, int ID_TIPO_CANAL)
        {
            try
            {
                return Ok(await boContenido.ConsultaContenidosActivos(ID_CANAL, ID_TIPO_CANAL));
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "ObtenerContenidosActivos", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpPost("AltaContenidoConMultimedia")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<bool>> AltaContenidoConMultimedia()
        {
            try
            {
                FormCollection listaArchivos = null;
                string Ruta = configuration.GetSection("Rutas").GetValue<string>("RutaContenidos");
                await Task.Run(() =>
                {
                    HttpRequest fromData = Request;
                    listaArchivos = (FormCollection)fromData.Form;

                });
                Thread.Sleep(3000);
                AltaContenidoDto contenido = new AltaContenidoDto()
                {
                    ID_TIPO_CANAL = Int32.Parse(listaArchivos["iD_TIPO_CANAL"]),
                    USUARIO = listaArchivos["usuario"],
                    VOLUMEN = Int32.Parse(listaArchivos["volumen"]),
                    OPACIDAD = Int32.Parse(listaArchivos["opacidad"]),
                    ID_ESTATUS = Int32.Parse(listaArchivos["iD_ESTATUS"]),
                    DURACION_SEG = Int32.Parse(listaArchivos["duracioN_SEG"]),
                    DURACION_MIN = Int32.Parse(listaArchivos["duracioN_MIN"]),
                    DURACION_HRS = Int32.Parse(listaArchivos["duracioN_HRS"]),
                    ES_REPETITIVO = Convert.ToBoolean(listaArchivos["eS_REPETITIVO"]),
                    ES_INTERMITENCIA = Convert.ToBoolean(listaArchivos["eS_INTERMITENCIA"]),
                };
                if (contenido.ES_INTERMITENCIA)
                {
                    contenido.INTERMITENCIA_SEG = Int32.Parse(listaArchivos["intermitenciA_SEG"]);
                    contenido.INTERMITENCIA_MIN = Int32.Parse(listaArchivos["intermitenciA_MIN"]);
                    contenido.INTERMITENCIA_HRS = Int32.Parse(listaArchivos["intermitenciA_HRS"]);
                }
                switch (contenido.ID_TIPO_CANAL)
                {
                    case (int)CatTipoCanal.VIDEOIMAGEN:
                    case (int)CatTipoCanal.IMAGEN:
                    case (int)CatTipoCanal.MUSICA:
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
                                          string RutaExterna = NombreCompleto.Replace(@"/", @"\");
                                          int tipoContenido = TipoContenido.getTipoContenido(Extension);
                                          switch (Directory.Exists(RutaInterna))
                                          {
                                              case false:
                                                  Directory.CreateDirectory(RutaInterna);
                                                  break;
                                          }
                                          System.IO.File.WriteAllBytes(NombreCompleto, Arreglobytes);
                                          boContenido.AltaContenido(contenido, RutaExterna, NombreActual, Nombre, Extension, tipoContenido);
                                      });
                        }, TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
                        break;
                    case (int)CatTipoCanal.TEXTO:
                        contenido.ID_TIPO_PRESENTACION = Int32.Parse(listaArchivos["iD_TIPO_PRESENTACION"]);
                        contenido.ID_FORMA_DESPLIEGUE = Int32.Parse(listaArchivos["iD_FORMA_DESPLIEGUE"]);
                        contenido.OPACIDAD_TEXTO = Int32.Parse(listaArchivos["opacidaD_TEXTO"]);
                        contenido.OPACIDAD_BARRA_TEXTO = Int32.Parse(listaArchivos["opacidaD_BARRA_TEXTO"]);
                        contenido.VELOCIDAD_TEXTO = Int32.Parse(listaArchivos["velocidaD_TEXTO"]);
                        contenido.TAMANIO_LETRA_TEXTO = Int32.Parse(listaArchivos["tamaniO_LETRA_TEXTO"]);
                        contenido.TIPO_LETRA_TEXTO = listaArchivos["tipO_LETRA_TEXTO"];
                        contenido.COLOR_FONDO_BARRA_TEXTO = listaArchivos["coloR_FONDO_BARRA_TEXTO"];
                        contenido.COLOR_TEXTO = listaArchivos["coloR_TEXTO"];
                        contenido.ES_COLOR_FONDO_TEXTO = Convert.ToBoolean(listaArchivos["colorChk"]);
                        contenido.RUTA_IMG_FONDO_BARRA_TEXTO = listaArchivos["rutA_IMG_FONDO_BARRA_TEXTO"];
                        contenido.RUTA = listaArchivos["ruta"];
                        contenido.Mensaje = new MensajeDto();
                        contenido.Mensaje.DESCRIPCION = listaArchivos["dsC_MENSAJE"];
                        contenido.Mensaje.NOMBRE = listaArchivos["nombreMensaje"];
                        contenido.Mensaje.USUARIO = listaArchivos["usuario"];
                        contenido.Mensaje.ID_ESTATUS = Int32.Parse(listaArchivos["iD_ESTATUS"]);
                        await boContenido.AltaContenido(contenido, "", "", "", "", 0);
                        break;
                    case (int)CatTipoCanal.TVDIRECTO:
                        contenido.RUTA = listaArchivos["ruta"];
                        contenido.NOMBRE = listaArchivos["nombre"];
                        await boContenido.AltaContenido(contenido, "", "", "", "", 0);
                        break;
                }

                return Ok(true);
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "AltaContenidoConMultimedia", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpPost("AltaContenido")]
        public async Task<ActionResult<bool>> AltaContenido(AltaContenidoDto contenidoDto)
        {
            try
            {
                return Ok(await boContenido.NuevoContenido(contenidoDto));
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "AltaContenido", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpPut("ActulizaContenido/{ID_CONTENIDO:int}")]
        public async Task<ActionResult<bool>> ActulizaContenido(int ID_CONTENIDO, AltaContenidoDto contenidoDto)
        {
            try
            {
                return Ok(await boContenido.ActulizaContenido(ID_CONTENIDO, contenidoDto));
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "ActulizaContenido", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpDelete("EliminarContenido/{ID_CONTENIDO:int}")]
        public async Task<ActionResult<bool>> EliminarContenido(int ID_CONTENIDO)
        {
            try
            {
                ContenidoDto contenido = await boContenido.ConsultaContenido(ID_CONTENIDO);
                if (contenido.repositorio != null)
                {
                    string tipoArchivo = "";
                    switch (contenido.repositorio.EXTENSION.ToLower())
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
                    string mediaType = Archivos.ObtenerMine(contenido.repositorio.EXTENSION);
                    string MediaRuta = $"{Ruta}/{tipoArchivo}/{contenido.repositorio.DESCRIPCION}.{contenido.repositorio.EXTENSION}";
                    System.IO.File.Delete(MediaRuta);
                }
                return Ok(await boContenido.EliminarContenido(ID_CONTENIDO));
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "EliminarContenido", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpDelete("LimpiarRepositorioDNLA")]
        public async Task<ActionResult<bool>> LimpiarRepositorioDNLA()
        {
            try
            {
                return Ok(await boContenido.LimpiarRepositorioDLNA());
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "LimpiarRepositorioDNLA", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }

        [EnableCors("MyPolicy")]
        [HttpPost("AltaLongFile")]
        public async Task<ActionResult<UploadResponseDto>> AltaLongFile(string id, string fileName, string Extension)
        {
            try
            {
                TipoContenido.validarContenido(Extension);
                UploadResponseDto reponse = new UploadResponseDto();
                string Ruta = configuration.GetSection("Rutas").GetSection("RutaIPTV").Value;
                int chunkSize = 1048576 * Convert.ToInt32(configuration["ChunkSize"]);
                string RutaInterna = $"{Ruta}/Temp";
                switch (Directory.Exists(RutaInterna))
                {
                    case false:
                        Directory.CreateDirectory(RutaInterna);
                        break;
                }
                var chunkNumber = id;
                string newpath = Path.Combine(RutaInterna, fileName + chunkNumber);
                using (FileStream fs = System.IO.File.Create(newpath))
                {
                    byte[] bytes = new byte[chunkSize];
                    int bytesRead = 0;
                    while ((bytesRead = await Request.Body.ReadAsync(bytes, 0, bytes.Length)) > 0)
                    {
                        fs.Write(bytes, 0, bytesRead);
                    }
                }
                return Ok(reponse);
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "AltaLongFile", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }

        [EnableCors("MyPolicy")]
        [HttpPost("UploadComplete")]
        public async Task<ActionResult<bool>> UploadComplete(string fileName)
        {
            try
            {
                string tipoArchivo = "";
                TimeSpan duration = new TimeSpan();
                string ext = fileName.Split(".")[1];
                switch (ext.ToLower())
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
                    default:
                        new ExcepcionIptv("¡Archivo no compatible!");
                        break;
                }
                UploadResponseDto reponse = new UploadResponseDto();
                string Ruta = configuration.GetSection("Rutas").GetSection("RutaIPTV").Value;
                string RutaSave = configuration.GetSection("Rutas").GetSection("RutaContenidos").Value;
                string RutaInterna = $"{Ruta}/Temp";
                string videoContenido = $"{RutaSave}/{tipoArchivo}";
                string newPath = Path.Combine(RutaInterna, fileName);
                string[] filePaths = Directory.GetFiles(RutaInterna).Where(p => p.Contains(fileName)).OrderBy(p => Int32.Parse(p.Replace(fileName, "$").Split('$')[1])).ToArray();
                foreach (string filePath in filePaths)
                {
                    MergeChunks(newPath, filePath);
                }
                var tfile = TagLib.File.Create(Path.Combine(RutaInterna, fileName));
                if (tfile.Tag.Title != null)
                {
                    tfile.Tag.Title = "";
                    tfile.Save();
                }
                if (tfile.Properties.Duration != null)
                    duration = tfile.Properties.Duration;
                System.IO.File.Move(Path.Combine(RutaInterna, fileName), Path.Combine(videoContenido, fileName));
                string nombreCompleto = $"{videoContenido}/{fileName}";
                string Extension = fileName.Split('.')[fileName.Split('.').Length - 1];
                string NombreActual = fileName.Split('.')[0];
                string RutaExterna = nombreCompleto.Replace(@"/", @"\");
                int tipoContenido = TipoContenido.getTipoContenido(Extension);
                ContenidoDto contenido = await boContenido.AltaRepositorio(RutaExterna, NombreActual, Extension, duration, tipoContenido, "ADMIN");
                reponse.nombreFile = fileName;
                reponse.ID_CONTENIDO = contenido.ID_CONTENIDO;
                reponse.contenido = contenido;
                return Ok(reponse);
            }
            catch (ExcepcionIptv ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log_Error(_logger, this.GetType().FullName, "UploadComplete", ex, configuration);
                return StatusCode(500, new Exception(Common.Constantes.MSG_CLIENTE));
            }
        }
        private static void MergeChunks(string chunk1, string chunk2)
        {
            FileStream fs1 = null;
            FileStream fs2 = null;
            try
            {
                fs1 = System.IO.File.Open(chunk1, FileMode.Append);
                fs2 = System.IO.File.Open(chunk2, FileMode.Open);
                byte[] fs2Content = new byte[fs2.Length];
                fs2.Read(fs2Content, 0, (int)fs2.Length);
                fs1.Write(fs2Content, 0, (int)fs2.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
            }
            finally
            {
                if (fs1 != null) fs1.Close();
                if (fs2 != null) fs2.Close();
                System.IO.File.Delete(chunk2);
            }
        }
    }
}