using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace iptv.Negocio.Utilidades
{
    public class ExcepcionIptv : Exception
    {
        public bool ErrorAutenticacion { get; set; } = true;
        public bool ErrorLicencia { get; set; } = true;
        public HttpStatusCode CodigoStatus { get; set; }
        public ExcepcionIptv(string strMensaje) : base(strMensaje)
        {
        }
        public ExcepcionIptv(bool ErrorLicencia, string strMensaje) : base(strMensaje)
        {
            this.ErrorLicencia = ErrorLicencia;
        }
    }
}
