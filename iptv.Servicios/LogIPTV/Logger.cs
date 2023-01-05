using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace iptv.Servicios.LogIPTV
{
    public class Logger
    {
		const string LoggerPath = @"c:\log\IPTV_Servicios";
		const string LoggerName = "IPTV_Servicios";

		public static void Log_Error (ILogger logger, string ControllerName, string ControllerMethod, Exception e, IConfiguration configuration)
        {
            try
            {
				bool MuestraInfo = configuration.GetValue<bool>("MuestraInfoIncidencias");
				string strMensajeError = "Error en: " + ControllerName + "-" + ControllerMethod + " : ";
				
				if(MuestraInfo)
                {
					strMensajeError += e.ToString();
				}
				else
                {
					strMensajeError += e.Message;
				}
				logger.LogError(strMensajeError, e);
			}
			catch (Exception ex)
            {
				LogError(ex.ToString());
            }
        }


		public static void LogInfo(string message)
		{
			try
			{
				if (!Directory.Exists(LoggerPath))
				{
					Directory.CreateDirectory(LoggerPath);
				}

				System.IO.StreamWriter Log1 = new System.IO.StreamWriter(LoggerPath + LoggerName + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
				Log1.WriteLine("Info :" + message);
				Log1.WriteLine(System.DateTime.Now.ToString());
				Log1.WriteLine("----------------------------------------------------------------------------------------");
				Log1.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error :" + e.Message);
			}

		}

		public static void LogAdvertencia(string message)
		{
			try
			{
				if (!Directory.Exists(LoggerPath))
				{
					Directory.CreateDirectory(LoggerPath);
				}

				System.IO.StreamWriter Log1 = new System.IO.StreamWriter(LoggerPath + LoggerName + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
				Log1.WriteLine("Advertencia :" + message);
				Log1.WriteLine(System.DateTime.Now.ToString());
				Log1.WriteLine("----------------------------------------------------------------------------------------");
				Log1.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error :" + e.Message);
			}

		}
		public static void LogError(string message)
		{
			try
			{
				if (!Directory.Exists(LoggerPath))
				{
					Directory.CreateDirectory(LoggerPath);
				}

				System.IO.StreamWriter Log1 = new System.IO.StreamWriter(LoggerPath + LoggerName + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
				Log1.WriteLine("Error :" + message);
				Log1.WriteLine(System.DateTime.Now.ToString());
				Log1.WriteLine("----------------------------------------------------------------------------------------");
				Log1.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error :" + e.Message);
			}

		}

		public static void LogInfo(string message, string nombre_Archivo)
		{
			try
			{
				string tipo_Log = "Info :";
				Verifica_Archivo(); ;
				Escribe_Archivo(message, nombre_Archivo, tipo_Log);
			}
			catch (Exception e)
			{
				Console.WriteLine("Error :" + e.Message);
			}

		}

		public static void LogAdvertencia(string message, string nombre_Archivo)
		{
			try
			{
				string tipo_Log = "Advertencia :";
				Verifica_Archivo(); ;
				Escribe_Archivo(message, nombre_Archivo, tipo_Log);
			}
			catch (Exception e)
			{
				Console.WriteLine("Error :" + e.Message);
			}

		}
		public static void LogError(string message, string nombre_Archivo)
		{
			try
			{
				string tipo_Log = "Error :";
				Verifica_Archivo(); ;
				Escribe_Archivo(message, nombre_Archivo, tipo_Log);
			}
			catch (Exception e)
			{
				Console.WriteLine("Error :" + e.Message);
			}

		}

		private static void Verifica_Archivo()
		{
			try
			{
				if (!Directory.Exists(LoggerPath))
				{
					Directory.CreateDirectory(LoggerPath);
				}
			}
			catch
			{
				throw;
			}
		}

		private static void Escribe_Archivo(string message, string nombre_Archivo, string tipo_Log)
		{
			try
			{
				System.IO.StreamWriter Log1 = new System.IO.StreamWriter(LoggerPath + nombre_Archivo + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
				Log1.WriteLine(tipo_Log + message);
				Log1.WriteLine(System.DateTime.Now.ToString());
				Log1.WriteLine("----------------------------------------------------------------------------------------");
				Log1.Close();
			}
			catch
			{
				throw;
			}
		}
	}
}
