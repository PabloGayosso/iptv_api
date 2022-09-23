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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Net.Http;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Microsoft.Extensions.Logging;

namespace iptv.Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        IBoAuditoria boAuditoria;
        IConfiguration configuration;
        ILogger<AuditoriaController> _logger;
        public AuditoriaController(IBoAuditoria boAuditoria, IConfiguration configuration, ILogger<AuditoriaController> logger)
        {
            this.boAuditoria = boAuditoria;
            this.configuration = configuration;
            this._logger = logger;
        }
        [Authorize]
        [EnableCors("MyPolicy")]
        [HttpPost("AltaAuditoria")]
        public async Task<ActionResult<bool>> AltaAuditoria(AltaAuditoriaDto auditoriaDto)
        {
            try
            {
                return Ok(await boAuditoria.AltaAudiroria(auditoriaDto));
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
        [HttpGet("ConsultaAuditorias/{Fch_Ini}/{Fch_Fin}/{Pagina:int}/{RegistrosPagina:int}")]
        public async Task<ActionResult<ConsultaAuditoria>> ConsultaAuditoria(string Fch_Ini, string Fch_Fin, int Pagina, int RegistrosPagina)
        {
            try
            {
                return Ok(await boAuditoria.ConsultaAuditoriaFechas(Fch_Ini, Fch_Fin, Pagina, RegistrosPagina));
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
        [HttpGet("GeneraPDF/{Fch_Ini}/{Fch_Fin}")]
        public async Task<ActionResult<HttpResponseMessage>> GeneraPDF(string Fch_Ini, string Fch_Fin)
        {
            try
            {
                byte[] result = null;
                List<AuditoriaDto> auditoriasDto = await boAuditoria.ConsultaAuditoriaFechas(Fch_Ini, Fch_Fin);
                if (auditoriasDto != null & auditoriasDto.Count > 0)
                {
                    MemoryStream ms = new MemoryStream();

                    //StringReader sr = new StringReader(sw.ToString());
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.LETTER);
                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, ms);

                    //Damos un titulo al documento, titulo que se mostrara en la ventana donde se visualice el documento
                    pdfDoc.AddTitle("REPORTE DE ACTIVIDADES DE BO IPTV");
                    pdfDoc.Open();

                    // Creamos el tipo de Font que vamos utilizar

                    BaseFont bf_standardFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                    BaseFont bf_tablaFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                    BaseFont bf_titulo = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                    BaseFont bf_cursiva = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, false);

                    iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(bf_standardFont, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    iTextSharp.text.Font _tablaFont = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    iTextSharp.text.Font _titulo = new iTextSharp.text.Font(bf_titulo, 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    iTextSharp.text.Font _cursiva = new iTextSharp.text.Font(bf_cursiva, 9, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);

                    // Nombre del sistema
                    Paragraph sistema;
                    sistema = new Paragraph("IPTV", _cursiva);
                    sistema.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(sistema);
                    pdfDoc.Add(Chunk.NEWLINE);

                    // Escribimos el encabezado en el documento
                    Paragraph titulo;
                    titulo = new Paragraph("REPORTE DE ACTIVIDADES DE BO IPTV", _titulo);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(titulo);
                    pdfDoc.Add(Chunk.NEWLINE);

                    //Escribimos la fecha que se genera
                    Paragraph fecha;
                    fecha = new Paragraph("Fecha de Generación: " + DateTime.Now.ToString(), _cursiva);
                    fecha.Font.Size = 7;
                    fecha.Alignment = Element.ALIGN_RIGHT;
                    pdfDoc.Add(fecha);
                    pdfDoc.Add(Chunk.NEWLINE);

                    PdfPTable tblReporteTerminal = new PdfPTable(6);
                    tblReporteTerminal.WidthPercentage = 100;
                    tblReporteTerminal.LockedWidth = true;

                    tblReporteTerminal.TotalWidth = pdfDoc.Right - pdfDoc.Left;

                    float algo = tblReporteTerminal.TotalWidth;

                    float[] widths = new float[] { 20.0f, 60.0f, 70.0f, 25.0f, 25.0f, 30.0f };
                    tblReporteTerminal.SetWidths(widths);

                    // Configuramos el título de las columnas de la tabla
                    PdfPCell clFchEvento = new PdfPCell(new Phrase("FECHA EVENTO", _standardFont));
                    clFchEvento.BorderWidth = 0;
                    clFchEvento.BorderWidthBottom = 0.75f;

                    PdfPCell clAccion = new PdfPCell(new Phrase("ACCION", _standardFont));
                    clAccion.BorderWidth = 0;
                    clAccion.BorderWidthBottom = 0.75f;

                    PdfPCell clAuditoria = new PdfPCell(new Phrase("AUDITORIA", _standardFont));
                    clAuditoria.BorderWidth = 0;
                    clAuditoria.BorderWidthBottom = 0.75f;

                    PdfPCell clSucursal = new PdfPCell(new Phrase("SUCURSAL", _standardFont));
                    clSucursal.BorderWidth = 0;
                    clSucursal.BorderWidthBottom = 0.75f;

                    PdfPCell clUsuario = new PdfPCell(new Phrase("USUARIO", _standardFont));
                    clUsuario.BorderWidth = 0;
                    clUsuario.BorderWidthBottom = 0.75f;

                    PdfPCell clPersona = new PdfPCell(new Phrase("PERSONA", _standardFont));
                    clPersona.BorderWidth = 0;
                    clPersona.BorderWidthBottom = 0.75f;

                    // Añadimos las celdas a la tabla
                    tblReporteTerminal.AddCell(clFchEvento);
                    tblReporteTerminal.AddCell(clAccion);
                    tblReporteTerminal.AddCell(clAuditoria);
                    //tblReporteTerminal.AddCell(clEmpresa);
                    tblReporteTerminal.AddCell(clSucursal);
                    tblReporteTerminal.AddCell(clUsuario);
                    tblReporteTerminal.AddCell(clPersona);

                    foreach (AuditoriaDto auditoria in auditoriasDto)
                    {
                        clFchEvento = new PdfPCell(new Phrase(auditoria.FCH_ACCION, _tablaFont));
                        clFchEvento.BorderWidth = 0;

                        clAccion = new PdfPCell(new Phrase(auditoria.DSC_ACCION, _tablaFont));
                        clAccion.BorderWidth = 0;

                        clAuditoria = new PdfPCell(new Phrase(auditoria.DSC_AUDITORIA, _tablaFont));
                        clAuditoria.BorderWidth = 0;

                        clSucursal = new PdfPCell(new Phrase(auditoria.CLAVE, _tablaFont));
                        clSucursal.BorderWidth = 0;

                        clUsuario = new PdfPCell(new Phrase(auditoria.USUARIO, _tablaFont));
                        clUsuario.BorderWidth = 0;

                        string fullName = auditoria.NOMBRE;
                        if (auditoria.APELLIDO_PATERNO != "")
                        {
                            fullName += " " + auditoria.APELLIDO_PATERNO;
                            if (auditoria.APELLIDO_MATERNO != "")
                            {
                                fullName += " " + auditoria.APELLIDO_MATERNO;
                            }
                        }

                        clPersona = new PdfPCell(new Phrase(fullName, _tablaFont));
                        clPersona.BorderWidth = 0;

                        // Añadimos las celdas a la tabla
                        tblReporteTerminal.AddCell(clFchEvento);
                        tblReporteTerminal.AddCell(clAccion);
                        tblReporteTerminal.AddCell(clAuditoria);
                        tblReporteTerminal.AddCell(clSucursal);
                        tblReporteTerminal.AddCell(clUsuario);
                        tblReporteTerminal.AddCell(clPersona);
                    }
                    pdfDoc.Add(tblReporteTerminal);

                    pdfDoc.Close();
                    result = ms.ToArray();
                }
                else
                {
                    throw new ExcepcionIptv("No hay datos que mostrar");
                }
                return File(result, "application/pdf");
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
        [HttpGet("GeneraExcel/{Fch_Ini}/{Fch_Fin}")]
        public async Task<ActionResult<HttpResponseMessage>> GeneraExcel(string Fch_Ini, string Fch_Fin)
        {
            try
            {
                byte[] result = null;
                List<AuditoriaDto> auditoriasDto = await boAuditoria.ConsultaAuditoriaFechas(Fch_Ini, Fch_Fin);
                if (auditoriasDto != null & auditoriasDto.Count > 0)
                {
                    if (auditoriasDto.Count < 59999)
                    {
                        //string Ruta = configuration.GetSection("Rutas").GetSection("RutaContenidos").Value;

                        IWorkbook workbook = new XSSFWorkbook();

                        XSSFFont myFont = (XSSFFont)workbook.CreateFont();
                        myFont.FontHeightInPoints = 11;
                        myFont.FontName = "Tahoma";

                        XSSFFont myFontData = (XSSFFont)workbook.CreateFont();
                        myFont.FontHeightInPoints = 11;
                        myFont.FontName = "Arial";

                        XSSFCellStyle borderedCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                        borderedCellStyle.SetFont(myFont);
                        borderedCellStyle.BorderLeft = BorderStyle.Medium;
                        borderedCellStyle.BorderTop = BorderStyle.Medium;
                        borderedCellStyle.BorderRight = BorderStyle.Medium;
                        borderedCellStyle.BorderBottom = BorderStyle.Medium;
                        borderedCellStyle.VerticalAlignment = VerticalAlignment.Center;

                        XSSFCellStyle borderedCellStyleData = (XSSFCellStyle)workbook.CreateCellStyle();
                        borderedCellStyleData.SetFont(myFontData);
                        borderedCellStyleData.BorderLeft = BorderStyle.Medium;
                        borderedCellStyleData.BorderTop = BorderStyle.Medium;
                        borderedCellStyleData.BorderRight = BorderStyle.Medium;
                        borderedCellStyleData.BorderBottom = BorderStyle.Medium;
                        borderedCellStyleData.VerticalAlignment = VerticalAlignment.Center;

                        ISheet sheet1 = workbook.CreateSheet("Reporte");
                        IRow HeaderRow = sheet1.CreateRow(0);

                        ICell Cell = HeaderRow.CreateCell(0);
                        Cell.SetCellValue("FECHA EVENTO");
                        Cell.CellStyle = borderedCellStyle;

                        ICell CellA = HeaderRow.CreateCell(1);
                        CellA.SetCellValue("ACCIÓN");
                        CellA.CellStyle = borderedCellStyle;

                        ICell CellAu = HeaderRow.CreateCell(2);
                        CellAu.SetCellValue("AUDITORIA");
                        CellAu.CellStyle = borderedCellStyle;

                        ICell CellS = HeaderRow.CreateCell(3);
                        CellS.SetCellValue("SUCURSAL");
                        CellS.CellStyle = borderedCellStyle;

                        ICell CellU = HeaderRow.CreateCell(4);
                        CellU.SetCellValue("USUARIO");
                        CellU.CellStyle = borderedCellStyle;

                        ICell CellP = HeaderRow.CreateCell(5);
                        CellP.SetCellValue("PERSONA");
                        CellP.CellStyle = borderedCellStyle;

                        int row = 0;

                        foreach (AuditoriaDto auditoriaDto in auditoriasDto)
                        {
                            row++;

                            IRow HeaderRowD = sheet1.CreateRow(row);

                            ICell CellD = HeaderRowD.CreateCell(0);
                            CellD.SetCellValue(auditoriaDto.FCH_ACCION);
                            CellD.CellStyle = borderedCellStyleData;

                            ICell CellAD = HeaderRowD.CreateCell(1);
                            CellAD.SetCellValue(auditoriaDto.DSC_ACCION);
                            CellAD.CellStyle = borderedCellStyleData;

                            ICell CellAuD = HeaderRowD.CreateCell(2);
                            CellAuD.SetCellValue(auditoriaDto.DSC_AUDITORIA);
                            CellAuD.CellStyle = borderedCellStyleData;

                            ICell CellSD = HeaderRowD.CreateCell(3);
                            CellSD.SetCellValue(auditoriaDto.CLAVE);
                            CellSD.CellStyle = borderedCellStyleData;

                            ICell CellUD = HeaderRowD.CreateCell(4);
                            CellUD.SetCellValue(auditoriaDto.CLAVE_USUARIO);
                            CellUD.CellStyle = borderedCellStyleData;

                            string fullName = auditoriaDto.NOMBRE;
                            if (auditoriaDto.APELLIDO_PATERNO != "")
                            {
                                fullName += " " + auditoriaDto.APELLIDO_PATERNO;
                                if (auditoriaDto.APELLIDO_MATERNO != "")
                                {
                                    fullName += " " + auditoriaDto.APELLIDO_MATERNO;
                                }
                            }

                            ICell CellPD = HeaderRowD.CreateCell(5);
                            CellPD.SetCellValue(fullName);
                            CellPD.CellStyle = borderedCellStyleData;
                        }

                        int lastColumNum = sheet1.GetRow(0).LastCellNum;
                        for (int i = 0; i <= lastColumNum; i++)
                        {
                            sheet1.AutoSizeColumn(i);
                            GC.Collect();
                        }

                        using (var exportData = new MemoryStream())
                        {
                            workbook.Write(exportData);
                            //string saveAsFileName = string.Format("Export-{0:d}.xlsx", DateTime.Now).Replace("/", "-");
                            result = exportData.ToArray();
                            //System.IO.File.WriteAllBytes(Ruta + "/" +saveAsFileName, result);
                        }

                        //result = ms.ToArray();

                    }
                    else
                    {
                        throw new ExcepcionIptv("Limite de registros excedido, elija un rango de fechas más corto");
                    }
                }
                else
                {
                    throw new ExcepcionIptv("No hay datos que mostrar");
                }
                return File(result, "application/vnd.ms-excel");
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
