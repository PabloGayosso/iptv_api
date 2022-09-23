using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.Negocio.Utilidades
{
  public static class Archivos
  {
    public static string ObtenerMine(string Extencion)
    {
      string mine = "";
      switch (Extencion.ToUpper())
      {
        case "PDF":
          mine = "application/pdf";
          break;
        case "PNG":
          mine = "image/png";
          break;
        case "JPG":
        case "JPEG":
          mine = "image/jpeg";
          break;
        case "GIF":
          mine = "image/gif";
          break;
        case "MP3":
          mine = "audio/mpeg";
          break;
        case "WMA":
          mine = "audio/wma";
          break;
        case "AAC":
          mine = "audio/aac";
          break;
        case "MP4":
          mine = "video/mpeg";
          break;
        case "AVI":
          mine = "video/x-msvideo";
          break;
        case "OGA":
          mine = "audio/ogg";
          break;
        case "OGV":
          mine = "video/ogg";
          break;
        case "weba":
          mine = "audio/webm";
          break;
        case "webm":
          mine = "video/webm";
          break;
        case "webp":
          mine = "image/webp";
          break;
        case "FLAC":
          mine = "audio/flac";
          break;
        case "MKV":
          mine = "video/mkv";
          break;
      }
      return mine;
    }
  }
}
