using iptv.AccesoDatos.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.Negocio.Utilidades
{
  public static class TipoContenido
  {
    public static int getTipoContenido(string Extencion)
    {
      int tipoContenido = 0;
      switch (Extencion)
      {
        case "flac":
        case "mp3":
        case "wma":
          tipoContenido = Convert.ToInt32(CatTipoContenido.MUSICA);
          break;
        case "jpg":
        case "jpeg":
        case "png":
        case "gif":
          tipoContenido = Convert.ToInt32(CatTipoContenido.IMAGEN);
          break;
        case "mp4":
        case "avi":
        case "webm":
        case "mkv":
          tipoContenido = Convert.ToInt32(CatTipoContenido.VIDEOIMAGEN);
          break;
      }
      return tipoContenido;
    }
    public static int getTipoCanal(string Extencion)
    {
      int tipoCanal = 0;
      switch (Extencion)
      {
        case "flac":
        case "mp3":
        case "wma":
          tipoCanal = Convert.ToInt32(CatTipoCanal.MUSICA);
          break;
        case "jpg":
        case "jpeg":
        case "png":
        case "gif":
          tipoCanal = Convert.ToInt32(CatTipoCanal.IMAGEN);
          break;
        case "mp4":
        case "avi":
        case "webm":
        case "mkv":
          tipoCanal = Convert.ToInt32(CatTipoCanal.VIDEOIMAGEN);
          break;
      }
      return tipoCanal;
    }
    public static string getTipoCarpetaContenido(string Extencion)
    {
      string tipoContenido = "";
      switch (Extencion.ToLower())
      {
        case "jpg":
        case "jpeg":
        case "raw":
        case "psd":
        case "png":
        case "gif":
          tipoContenido = "Imagenes";
          break;
        case "mp3":
        case "wma":
        case "wav":
        case "cda":
        case "midi":
        case "aac":
        case "aiff":
        case "flac":
          tipoContenido = "Musica";
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
          tipoContenido = "Videos";
          break;
      }
      return tipoContenido;
    }
    public static int validarContenido(string Extencion)
    {
      int tipoCanal = 0;
      switch (Extencion)
      {
        case "flac":
        case "mp3":
        case "wma":
          tipoCanal = Convert.ToInt32(CatTipoContenido.MUSICA);
          break;
        case "jpg":
        case "jpeg":
        case "png":
        case "gif":
          tipoCanal = Convert.ToInt32(CatTipoContenido.IMAGEN);
          break;
        case "mp4":
        case "avi":
        case "webm":
        case "mkv":
          tipoCanal = Convert.ToInt32(CatTipoContenido.VIDEOIMAGEN);
          break;
        default:
          throw new ExcepcionIptv("¡Archivo no compatible!");
      }
      return tipoCanal;
    }
  }
}
