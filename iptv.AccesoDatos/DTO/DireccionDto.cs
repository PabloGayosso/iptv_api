using iptv.AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.DTO
{
    public class DireccionDto
    {
        public int ID_DIRECCION { get; set; }
        public int ID_TIPO_DIRECCION { get; set; }
        public PaisDto Pais { get; set; }
        public EstadoDto Estado { get; set; }
        public DelegacionMunicipioDto DelegacionMunicipio { get; set; }
        public ColoniaDto Colonia { get; set; }
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
