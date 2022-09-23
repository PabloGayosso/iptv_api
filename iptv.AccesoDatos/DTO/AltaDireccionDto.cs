using iptv.AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class AltaDireccionDto
    {
        public int ID_TIPO_DIRECCION { get; set; }
        public Pais Pais { get; set; }
        public Estado Estado { get; set; }
        public DelegacionMunicipio DelegacionMunicipio { get; set; }
        public Colonia Colonia { get; set; }
        public int CODIGO_POSTAL { get; set; }
        public string CUIDAD { get; set; }
        public string CALLE { get; set; }
        public string NUMERO_EXTERIOR { get; set; }
        public string NUMERO_INTERIOR { get; set; }
        public int ID_ESTATUS { get; set; }
        public string USUARIO { get; set; }
        public Persona Persona { get; set; }
    }
}
