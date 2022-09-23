using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Models
{
    public class Direccion
    {
        public int ID_DIRECCION { get; set; }
        public int ID_TIPO_DIRECCION { get; set; }
        public Pais Pais { get; set; }
        public Estado Estado { get; set; }
        public DelegacionMunicipio DelegacionMunicipio { get; set; }
        public Colonia Colonia { get; set; }
        public string CODIGO_POSTAL { get; set; }
        public string CUIDAD { get; set; }
        public string CALLE { get; set; }
        public string NUMERO_EXTERIOR { get; set; }
        public string NUMERO_INTERIOR { get; set; }
        public int ID_ESTATUS { get; set; }
        public string FEC_ALTA { get; set; }
        public string FEC_MOD { get; set; }
        public string USUARIO { get; set; }
        public Persona Persona { get; set; }
    }
}
