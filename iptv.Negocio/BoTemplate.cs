using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Enum;
using iptv.Negocio.Utilidades;
using AutoMapper;
using Microsoft.Extensions.Configuration;


namespace iptv.Negocio
{
    public class BoTemplate : IBoTemplate
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoTemplate(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<ConsultaTemplateDto> ConsultaTemplateDicrecto(string Busqueda, int Pagina, int RegistroPorPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Template> templates = await daoIptv.ConsultaTemplateDirecoAsync(Busqueda, Pagina, RegistroPorPagina);
                    List<TemplateDto> templateDto = _mapper.Map<List<TemplateDto>>(templates);
                    int total = await daoIptv.ConsultaTotalTemplateDirectoAync();
                    ConsultaTemplateDto consulta = new ConsultaTemplateDto()
                    {
                        template = templateDto,
                        Total = total
                    };
                    return consulta;
                }
                catch (ExcepcionIptv)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public async Task<ConsultaTemplateDto> ConsultaTemplates(string Busqueda, int Pagina, int RegistrosPagina)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Template> templates = await daoIptv.ConsultaTemplatesAsync(Busqueda, Pagina, RegistrosPagina);
                    List<TemplateDto> templateDto = _mapper.Map<List<TemplateDto>>(templates);
                    int total = await daoIptv.ConsultaTotalTemplatesAsync();
                    ConsultaTemplateDto consulta = new ConsultaTemplateDto()
                    {
                        template = templateDto,
                        Total = total
                    };
                    return consulta;
                }
                catch (ExcepcionIptv)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<List<TemplateDto>> ConsultaTemplatesCatalogo()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Template> templates = await daoIptv.ConsultaTemplatesCatalogoAsync();
                    List<TemplateDto> templateDto = _mapper.Map<List<TemplateDto>>(templates);
                    return templateDto;
                }
                catch (ExcepcionIptv)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<TemplateDto> ConsultaTemplate(int ID_TEMPLATE)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    Template template = await daoIptv.ConsultaTemplateAsync(ID_TEMPLATE);
                    TemplateDto templateDto = _mapper.Map<TemplateDto>(template);
                    return templateDto;
                }
                catch (ExcepcionIptv)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public async Task<int> AltaTemplate(AltaTemplateDto templateDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Template template = _mapper.Map<Template>(templateDto);
                    int resultado = await daoIptv.AltaTemplateAsync(template);
                    switch (resultado >= 0)
                    {
                        case true:
                            for (int i = 0; template.canal.Count > i; i++)
                            {
                                await daoIptv.AltaTemplateCanalAsync(resultado, template.ID_ESTATUS, template.canal[i]);
                            }
                            break;
                        case false:
                            throw new ExcepcionIptv("No fue posible realizar la oparacion");
                    }
                    unitOfWork.Commit();
                    return resultado;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
        public async Task<int> EstatusTemplate(int ID_TEMPLATE, AltaTemplateDto templateDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    int repuesta = 0;
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Template template = _mapper.Map<Template>(templateDto);
                    Template conTemplate = await daoIptv.ConsultaTemplateReproductorAsync(ID_TEMPLATE);
                    switch (conTemplate.Reproductores == null)
                    {
                        case true:
                            repuesta = await daoIptv.ActulizaTemplateAsync(ID_TEMPLATE, template);
                            break;
                        case false:
                            throw new ExcepcionIptv("¡Este template se encuentra en uso!");
                    }
                    unitOfWork.Commit();
                    return repuesta;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
        public async Task<int> ActulizaTemplate(int ID_TEMPLATE, AltaTemplateDto templateDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Template template = _mapper.Map<Template>(templateDto);
                    int respuesta = await daoIptv.ActulizaTemplateAsync(ID_TEMPLATE, template);
                    switch (respuesta >= 0)
                    {
                        case true:
                            await daoIptv.BorrarTemplateCanalAsync(ID_TEMPLATE);
                            for (int i = 0; i < template.canal.Count; i++)
                            {
                                await daoIptv.AltaTemplateCanalAsync(ID_TEMPLATE, template.ID_ESTATUS, template.canal[i]);
                            }
                            break;
                        case false:
                            throw new ExcepcionIptv("No fue posible realizar la oparacion");
                    }
                    unitOfWork.Commit();
                    return respuesta;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
        public async Task<int> GenerarXML(int ID_TEMPLATE, int ID_REPRODUCTOR, string ruta)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    string planntillaXML = "";
                    int respuesta = 0;
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    Template template = await daoIptv.ConsultaTemplateAsync(ID_TEMPLATE);
                    switch (template.ID_TEMPLATE > 0)
                    {
                        case true:
                            planntillaXML += "<TEMPLATE ID_TEMPLATE=\"" + template.ID_TEMPLATE + "\">\r\n";
                            switch (template.templateCanal.Count > 0)
                            {
                                case true:
                                    for (int i = 0; template.templateCanal.Count > i; i++)
                                    {
                                        for (int j = 0; template.templateCanal[i].canales.Count > j; j++)
                                        {
                                            var TipoCanal = await daoIptv.ObtenerParametroIdAsync(template.templateCanal[i].canales[j].ID_TIPO_CANAL);

                                            planntillaXML += "    <CANAL"
                                            + " ID_CANAL=\"" + template.templateCanal[i].canales[j].ID_CANAL + "\""
                                            + " NOMBRE=\"C" + template.templateCanal[i].canales[j].CLAVE.Replace(" ", "_") + "\""
                                            + " TIPO=\"" + TipoCanal.DESCRIPCION + "\""
                                            + " POSICIONX=\"" + template.templateCanal[i].POSICION_X + "\""
                                            + " POSICIONY=\"" + template.templateCanal[i].POSICION_Y + "\""
                                            + " ANCHO=\"" + template.templateCanal[i].ANCHO + "\""
                                            + " ALTO=\"" + template.templateCanal[i].ALTO + "\""
                                            + " >\r\n";
                                            planntillaXML = planntillaXML.Replace(',', '.');
                                            var contenidos = await daoIptv.ObtenerContenidosPorIdCanalAsync(template.templateCanal[i].canales[j].ID_CANAL);

                                            for (int c = 0; contenidos.Count > c; c++)
                                            {
                                                //Activar modo ingles (Chiapas)
                                                //var FechaInicio = contenidos[c].FEC_INICIO.Split(" ");
                                                //FechaInicio = FechaInicio[0].Split("/");
                                                //string f_mes = FechaInicio[0];
                                                //if (f_mes.Length == 1)
                                                //  f_mes = "0" + f_mes;
                                                //string f_dia = FechaInicio[1];
                                                //string f_anio = FechaInicio[2];
                                                //var FechaIni = new DateTime(
                                                //  Convert.ToInt32(f_anio)
                                                //  , Convert.ToInt32(f_mes)
                                                //  , Convert.ToInt32(f_dia)
                                                //);

                                                //var FechaFinal = contenidos[c].FEC_FIN.Split(" ");
                                                //FechaFinal = FechaFinal[0].Split("/");
                                                //string ff_mes = FechaFinal[0];
                                                //if (ff_mes.Length == 1)
                                                //  ff_mes = "0" + ff_mes;
                                                //string ff_dia = FechaFinal[1];
                                                //string ff_anio = FechaFinal[2];
                                                //DateTime FechaFin = new DateTime();
                                                //FechaFin = new DateTime(
                                                //   Convert.ToInt32(ff_anio)
                                                //   , Convert.ToInt32(ff_mes)
                                                //   , Convert.ToInt32(ff_dia)
                                                // );

                                                var despliegue = await daoIptv.ObtenerParametroIdAsync(contenidos[c].ID_FORMA_DESPLIEGUE);
                                                var tipoReprescentacion = await daoIptv.ObtenerParametroIdAsync(contenidos[c].ID_TIPO_PRESENTACION);
                                                var SegundoInicial = (Convert.ToInt32(contenidos[c].INICIO_SEG) + 2);
                                                LogIPTV.Logger.LogInfo("INI "+ contenidos[c].FEC_INICIO);
                                                LogIPTV.Logger.LogInfo("FIN " + contenidos[c].FEC_FIN);
                                                planntillaXML += "      <CONTENIDO"
                                                  //+ " ID_CONTENIDO=\"" + lbContenido[c].getContenido().getIdContenido() + "\""
                                                  //+ " ORDEN=\"" + lbContenido[c].getContenido().getOrden() + "\""
                                                  + " ORDEN=\"" + contenidos[c].ORDEN + "\""
                                                  + " DURACIONSEGS=\"" + contenidos[c].DURACION_SEG + "\""
                                                  + " DURACIONMINS=\"" + contenidos[c].DURACION_MIN + "\""
                                                  + " DURACIONHRS=\"" + contenidos[c].DURACION_HRS + "\""
                                                  //+ " POSICIONX=\"" + lbContenido[c].getContenido().getPosicionX() + "\""
                                                  //+ " POSICIONY=\"" + lbContenido[c].getContenido().getPosicionY() + "\""
                                                  //+ " ANCHO=\"" + lbContenido[c].getContenido().getAncho() + "\""
                                                  //+ " ALTO=\"" + lbContenido[c].getContenido().getAlto() + "\""
                                                  + " OPACIDAD=\"" + contenidos[c].OPACIDAD + "\""
                                                  + " VOLUMEN=\"" + contenidos[c].VOLUMEN + "\""
                                                  + " ES_REPETITIVO=\"" + Convert.ToInt32(contenidos[c].ES_REPETITIVO).ToString() + "\""
                                                  //ACtivar modo ingles (Chiapas)
                                                  //+ " FECHA_INICIO=\"" + FechaIni.ToString("dd/MM/yyyy") + "\""
                                                  //+ " FECHA_FINAL=\"" + FechaFin.ToString("dd/MM/yyyy") + "\""

                                                  + " FECHA_INICIO=\"" + contenidos[c].FEC_INICIO + "\""
                                                  + " FECHA_FINAL=\"" + contenidos[c].FEC_FIN + "\""

                                                  + " HORA_INICIO=\"" + contenidos[c].INICIO_HRS + "\""
                                                  + " MINUTO_INICIO=\"" + contenidos[c].INICIO_MIN + "\""
                                                  + " SEGUNDO_INICIO=\"" + SegundoInicial + "\""
                                                  + " HORAS_FINAL=\"" + contenidos[c].FIN_HRS + "\""
                                                  + " MINUTOS_FINAL=\"" + contenidos[c].FIN_MIN + "\""
                                                  + " SEGUNDOS_FINAL=\"" + contenidos[c].FIN_SEG + "\""
                                                  + " ES_COLORFONDO=\"" + Convert.ToInt32(contenidos[c].ES_COLOR_FONDO_TEXTO).ToString() + "\""
                                                  + " OPACIDADCANVAS=\"" + contenidos[c].OPACIDAD + "\""
                                                  + " COLORBG=\"" + contenidos[c].COLOR_FONDO_BARRA_TEXTO + "\""
                                                  + " RUTAIMGFONDO=\"" + contenidos[c].RUTA_IMG_FONDO_BARRA_TEXTO + "\""
                                                  + " VELOCIDAD=\"" + Convert.ToInt32(contenidos[c].VELOCIDAD_TEXTO) + "\""
                                                  + " TAMANIOLETRA=\"" + contenidos[c].TAMANIO_LETRA_TEXTO + "\""
                                                  + " TIPOLETRA=\"" + contenidos[c].TIPO_LETRA_TEXTO + "\""
                                                  + " OPACIDADTEXTO=\"" + contenidos[c].OPACIDAD_TEXTO + "\""
                                                  + " COLORTEXTO=\"" + contenidos[c].COLOR_TEXTO + "\""
                                                  + " ES_INTERMITENCIA=\"" + Convert.ToInt32(contenidos[c].ES_INTERMITENCIA).ToString() + "\""
                                                  + " INTERMITENCIA_SEG=\"" + contenidos[c].INTERMITENCIA_SEG + "\""
                                                  + " INTERMITENCIA_MIN=\"" + contenidos[c].INTERMITENCIA_MIN + "\""
                                                  + " INTERMITENCIA_HRS=\"" + contenidos[c].INTERMITENCIA_HRS + "\""
                                                  + " FORMADESPLIEGUE=\"" + despliegue.DESCRIPCION + "\""
                                                  + " TIPOPRESENTACION=\"" + tipoReprescentacion.DESCRIPCION + "\"";

                                                switch (contenidos[c].ID_TIPO_CANAL)
                                                {
                                                    case ((int)CatTipoCanal.VIDEOIMAGEN):
                                                    case ((int)CatTipoCanal.MUSICA):
                                                    case ((int)CatTipoCanal.IMAGEN):
                                                        planntillaXML += " DURACION_REAL=\"" + contenidos[c].DURACION + "\"";
                                                        planntillaXML += " RUTA=\"" + contenidos[c].RUTA + "\"";
                                                        planntillaXML += " RUTA_ONLINE=\"" + contenidos[c].RUTA_ONLINE + "\"";
                                                        break;
                                                    default:
                                                        planntillaXML += " RUTA=\"" + contenidos[c].RUTA + "\"";
                                                        planntillaXML += " DURACION_REAL=\"" + contenidos[c].RUTA_ONLINE + "\"";
                                                        break;
                                                }
                                                planntillaXML += " NOMBRE=\"" + contenidos[c].NOMBRE.TrimEnd().Replace(" ", "_") + "\"";
                                                //+ " FECHA_ALTA=\"" + lbContenido[c].getContenido().getFecAlta() + "\""
                                                //+ " ACTIVO=\"" + lbContenido[c].getContenido().getEstatus().getIdParametro() + "\"";
                                                planntillaXML = planntillaXML.Replace(',', '.');
                                                if (contenidos[c].ID_TIPO_CANAL == ((int)CatTipoCanal.TEXTO))
                                                {
                                                    var mensaje = await daoIptv.ObtenerMensajeAsync(contenidos[c].ID_MENSAJE);
                                                    planntillaXML += " TEXTO=\"" + mensaje.DESCRIPCION + "\"";
                                                }
                                                else
                                                {
                                                    planntillaXML += " TEXTO=\"\"";
                                                }
                                                planntillaXML += "/>\r\n";
                                            }
                                            planntillaXML += "    </CANAL>\r\n";
                                        }
                                    }
                                    planntillaXML += "</TEMPLATE>";
                                    break;
                                case false:
                                    throw new ExcepcionIptv("¡El template no tiene canales Asignados!");
                            }
                            break;
                        case false:
                            throw new ExcepcionIptv("¡Template no valido!");
                    }

                    Recolector recolector = await daoIptv.CosultaRecolectorTemplate(template.ID_TEMPLATE);
                    switch (recolector.ID_RECOLECTOR > 0)
                    {
                        case true:
                            recolector.ID_TEMPLATE = template.ID_TEMPLATE;
                            recolector.ARCHIVO_XML = planntillaXML;
                            recolector.USUARIO = template.USUARIO;
                            recolector.ID_ESTATUS = template.ID_ESTATUS;
                            if (ID_REPRODUCTOR > 0)
                                respuesta = await daoIptv.ActulizaRecolectorRepro(ID_REPRODUCTOR, recolector.ID_RECOLECTOR, recolector);
                            else
                                respuesta = await daoIptv.ActulizaRecolector(recolector.ID_RECOLECTOR, recolector);
                            break;
                        case false:
                            recolector.ID_TEMPLATE = template.ID_TEMPLATE;
                            recolector.ARCHIVO_XML = planntillaXML;
                            recolector.USUARIO = template.USUARIO;
                            recolector.ID_ESTATUS = template.ID_ESTATUS;
                            if (ID_REPRODUCTOR > 0)
                                respuesta = await daoIptv.AltaRecolectorReproAsync(ID_REPRODUCTOR, recolector);
                            else
                                respuesta = await daoIptv.AltaRecolectorAsync(recolector);
                            break;
                    }
                    unitOfWork.Commit();
                    return respuesta;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
        public async Task<int> PreviewTemplate(int ID_TEMPLATE)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    unitOfWork.Begin();
                    PreviewTemplate preview = await daoIptv.consultaPreviewID();
                    Template template = await daoIptv.ConsultaTemplateAsync(ID_TEMPLATE);
                    int resultado = 0;
                    switch (preview.ID_PREVIEW > 0)
                    {
                        case true:
                            if (template.ID_TEMPLATE > 0)
                            {
                                preview.ID_TEMPLATE = template.ID_TEMPLATE;
                                resultado = await daoIptv.actulizaPreview(preview);
                            }
                            else throw new ExcepcionIptv("¡Template no existente!");
                            break;
                        case false:
                            if (template.ID_TEMPLATE > 0)
                                resultado = await daoIptv.InsertaPreview(template.ID_TEMPLATE);
                            else throw new ExcepcionIptv("¡Template no existente!");
                            break;
                    }
                    unitOfWork.Commit();
                    return resultado;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
