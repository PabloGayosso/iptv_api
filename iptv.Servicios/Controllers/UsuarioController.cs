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
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Microsoft.Extensions.Logging;
namespace iptv.Servicios.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsuarioController : ControllerBase
  {
    IBoUsuario boUsuario;
    IConfiguration configuration;
    ILogger<UsuarioController> _logger;
    public UsuarioController(IBoUsuario boUsuario, IConfiguration configuration, ILogger<UsuarioController> logger)
    {
      this.boUsuario = boUsuario;
      this.configuration = configuration;
      this._logger = logger;
    }
    [Authorize]
    [EnableCors("MyPolicy")]
    [HttpGet("ObtenerUsaurios/{Pagina:int}/{RegistrosPagina:int}")]
    public async Task<ActionResult<ConsultaUsuariosDto>> ObtenerUsaurios(int Pagina, int RegistrosPagina)
    {
      try
      {
        return Ok(await boUsuario.ObtenerUsuarios(Pagina, RegistrosPagina));
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
    [HttpGet("ObtnerUsaurio/{ID_USUARIO:int}")]
    public async Task<ActionResult<ConsultaUsuariosDto>> ObtnerUsaurio(int ID_USUARIO)
    {
      try
      {
        return Ok(await boUsuario.ObtenerUsuario(ID_USUARIO));
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
    [HttpPost("AltaUsuario")]
    public async Task<ActionResult<bool>> AltaUsuario(AltaUsuarioDto usuarioDto)
    {
      try
      {
        return Ok(await boUsuario.AltaUsuraio(usuarioDto));
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
    [HttpPut("ActulizaUsuario/{ID_USUARIO:int}")]
    public async Task<ActionResult<bool>> ActulizaUsuario(int ID_USUARIO, AltaUsuarioDto usuarioDto)
    {
      try
      {
        return Ok(await boUsuario.ActulizaUsuraio(ID_USUARIO, usuarioDto));
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
    [HttpGet("UsuariosReportePDF")]
    public async Task<ActionResult<HttpResponseMessage>> GeneraPDF()
    {
      try
      {
        byte[] result = null;
        List<UsuarioDto> usuariosdto = await boUsuario.ObtenerUsuarios();
        if (usuariosdto != null & usuariosdto.Count > 0)
        {
          MemoryStream ms = new MemoryStream();

          //StringReader sr = new StringReader(sw.ToString());
          iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.LETTER);
          //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
          PdfWriter writer = PdfWriter.GetInstance(pdfDoc, ms);

          //Damos un titulo al documento, titulo que se mostrara en la ventana donde se visualice el documento
          pdfDoc.AddTitle("REPORTE DE USUARIOS DE IPTV");
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

          Paragraph sistema;
          sistema = new Paragraph("IPTV", _cursiva);
          sistema.Alignment = Element.ALIGN_LEFT;
          pdfDoc.Add(sistema);
          pdfDoc.Add(Chunk.NEWLINE);

          Paragraph titulo;
          titulo = new Paragraph("REPORTE DE USUARIOS DE IPTV", _titulo);
          titulo.Alignment = Element.ALIGN_CENTER;
          pdfDoc.Add(titulo);
          pdfDoc.Add(Chunk.NEWLINE);

          Paragraph fecha;
          fecha = new Paragraph("Fecha de Generación: " + DateTime.Now.ToString(), _cursiva);
          fecha.Font.Size = 7;
          fecha.Alignment = Element.ALIGN_RIGHT;
          pdfDoc.Add(fecha);
          pdfDoc.Add(Chunk.NEWLINE);

          PdfPTable tblReporteTerminal = new PdfPTable(5);
          tblReporteTerminal.WidthPercentage = 100;
          //tblReporteTerminal.LockedWidth = true;

          float algo = tblReporteTerminal.TotalWidth;

          float[] widths = new float[] { 20.0f, 60.0f, 70.0f, 25.0f, 25.0f };
          tblReporteTerminal.SetWidths(widths);

          // Configuramos el título de las columnas de la tabla
          PdfPCell clUsuario = new PdfPCell(new Phrase("USUARIO", _standardFont));
          clUsuario.BorderWidth = 0;
          clUsuario.BorderWidthBottom = 0.75f;

          PdfPCell clPersona = new PdfPCell(new Phrase("PERSONA", _standardFont));
          clPersona.BorderWidth = 0;
          clPersona.BorderWidthBottom = 0.75f;

          PdfPCell clAPerfil = new PdfPCell(new Phrase("PERFIL", _standardFont));
          clAPerfil.BorderWidth = 0;
          clAPerfil.BorderWidthBottom = 0.75f;

          PdfPCell clEstatus = new PdfPCell(new Phrase("ESTATUS", _standardFont));
          clEstatus.BorderWidth = 0;
          clEstatus.BorderWidthBottom = 0.75f;

          PdfPCell clFchAlt = new PdfPCell(new Phrase("FECHA ALTA", _standardFont));
          clFchAlt.BorderWidth = 0;
          clFchAlt.BorderWidthBottom = 0.75f;

          //PdfPCell clFchMod = new PdfPCell(new Phrase("FECHA MODIFICACION", _standardFont));
          //clFchMod.BorderWidth = 0;
          //clFchMod.BorderWidthBottom = 0.75f;

          // Añadimos las celdas a la tabla
          tblReporteTerminal.AddCell(clUsuario);
          tblReporteTerminal.AddCell(clPersona);
          tblReporteTerminal.AddCell(clAPerfil);
          tblReporteTerminal.AddCell(clEstatus);
          tblReporteTerminal.AddCell(clFchAlt);
          //tblReporteTerminal.AddCell(clFchMod);

          foreach (UsuarioDto usuariodto in usuariosdto)
          {
            clUsuario = new PdfPCell(new Phrase(usuariodto.CLAVE_USUARIO, _tablaFont));
            clUsuario.BorderWidth = 0;

            string fullName = usuariodto.NOMBRE;
            if (usuariodto.APELLIDO_PATERNO != "")
            {
              fullName += " " + usuariodto.APELLIDO_PATERNO;
              if (usuariodto.APELLIDO_MATERNO != "")
              {
                fullName += " " + usuariodto.APELLIDO_MATERNO;
              }
            }

            clPersona = new PdfPCell(new Phrase(fullName, _tablaFont));
            clPersona.BorderWidth = 0;


            clAPerfil = new PdfPCell(new Phrase(usuariodto.Perfil, _tablaFont));
            clAPerfil.BorderWidth = 0;

            clEstatus = new PdfPCell(new Phrase(usuariodto.Estatus, _tablaFont));
            clEstatus.BorderWidth = 0;

            clFchAlt = new PdfPCell(new Phrase(usuariodto.FEC_ALTA, _tablaFont));
            clFchAlt.BorderWidth = 0;

            //clFchMod = new PdfPCell(new Phrase(usuariodto.FEC_MOD, _tablaFont));
            //clFchMod.BorderWidth = 0;

            // Añadimos las celdas a la tabla
            tblReporteTerminal.AddCell(clUsuario);
            tblReporteTerminal.AddCell(clPersona);
            tblReporteTerminal.AddCell(clAPerfil);
            tblReporteTerminal.AddCell(clEstatus);
            tblReporteTerminal.AddCell(clFchAlt);
            //tblReporteTerminal.AddCell(clFchMod);
          }
          pdfDoc.Add(tblReporteTerminal);

          pdfDoc.Close();
          result = ms.ToArray();
          string Ruta = configuration.GetSection("Rutas").GetSection("RutaContenidos").Value;
          string saveAsFileName = string.Format("Export-{0:d}.pdf", DateTime.Now).Replace("/", "-");
          System.IO.File.WriteAllBytes(Ruta + "/" + saveAsFileName, result);
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
    [HttpGet("GeneraExcel")]
    public async Task<ActionResult<HttpResponseMessage>> GeneraExcel()
    {
      try
      {
        byte[] result = null;
        List<UsuarioDto> usuariosdto = await boUsuario.ObtenerUsuarios();
        if (usuariosdto != null & usuariosdto.Count > 0)
        {
          if (usuariosdto.Count < 59999)
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

            ICell CellU = HeaderRow.CreateCell(0);
            CellU.SetCellValue("USUARIO");
            CellU.CellStyle = borderedCellStyle;

            ICell CellP = HeaderRow.CreateCell(1);
            CellP.SetCellValue("PERSONA");
            CellP.CellStyle = borderedCellStyle;

            ICell CellPe = HeaderRow.CreateCell(2);
            CellPe.SetCellValue("PERFIL");
            CellPe.CellStyle = borderedCellStyle;

            ICell CellE = HeaderRow.CreateCell(3);
            CellE.SetCellValue("ESTATUS");
            CellE.CellStyle = borderedCellStyle;

            ICell CellFa = HeaderRow.CreateCell(4);
            CellFa.SetCellValue("FECHA ALTA");
            CellFa.CellStyle = borderedCellStyle;

            ICell CellFm = HeaderRow.CreateCell(5);
            CellFm.SetCellValue("FECHA MODIFICACION");
            CellFm.CellStyle = borderedCellStyle;

            int row = 0;

            foreach (UsuarioDto usuarioDto in usuariosdto)
            {
              row++;

              IRow HeaderRowD = sheet1.CreateRow(row);

              ICell CellUD = HeaderRowD.CreateCell(0);
              CellUD.SetCellValue(usuarioDto.CLAVE_USUARIO);
              CellUD.CellStyle = borderedCellStyleData;

              string fullName = usuarioDto.NOMBRE;
              if (usuarioDto.APELLIDO_PATERNO != "")
              {
                fullName += " " + usuarioDto.APELLIDO_PATERNO;
                if (usuarioDto.APELLIDO_MATERNO != "")
                {
                  fullName += " " + usuarioDto.APELLIDO_MATERNO;
                }
              }

              ICell CellPD = HeaderRowD.CreateCell(1);
              CellPD.SetCellValue(fullName);
              CellPD.CellStyle = borderedCellStyleData;

              ICell CellPeD = HeaderRowD.CreateCell(2);
              CellPeD.SetCellValue(usuarioDto.Perfil);
              CellPeD.CellStyle = borderedCellStyleData;

              ICell CellED = HeaderRowD.CreateCell(3);
              CellED.SetCellValue(usuarioDto.Estatus);
              CellED.CellStyle = borderedCellStyleData;

              ICell CellFaD = HeaderRowD.CreateCell(4);
              CellFaD.SetCellValue(usuarioDto.FEC_ALTA);
              CellFaD.CellStyle = borderedCellStyleData;

              ICell CellFmD = HeaderRowD.CreateCell(5);
              CellFmD.SetCellValue(usuarioDto.FEC_MOD);
              CellFmD.CellStyle = borderedCellStyleData;
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
              string Ruta = configuration.GetSection("Rutas").GetSection("RutaContenidos").Value;
              string saveAsFileName = string.Format("Export-{0:d}.xlsx", DateTime.Now).Replace("/", "-");
              System.IO.File.WriteAllBytes(Ruta + "/" + saveAsFileName, result);
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
