using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.Negocio.Utilidades
{
    public class MessageErrors
    {
        // errores bd
        public static string ERROR_100 { get; } = "Error de conexion a la BD";
        public static string ERROR_101 { get; } = "Timeout excedido";

        // errores logica X
        public static string ERROR_200 { get; } = "xyz";

        public string showExceptionMessage(string msg, Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Error: {msg}");
            sb.AppendLine("-----------------");
            sb.AppendLine($"Detalle de la excepcion: {ex?.Message}");

            return sb.ToString();
        }
    }
}
