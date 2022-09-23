using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Parametro
    {
        public const string OBTENERPARAMETROS = @"[SPS_GL_C_PARAMETRO_All]";
        public const string OBTENERPARAMETRO = @"[SPS_GL_C_PARAMETRO]";
        public const string ALTACATALOGO = @"[SPI_GL_C_PARAMETRO_CATALOGO]";
        public const string ALTAPARAMETRO = @"[SPI_GL_C_PARAMETRO_CONTENIDO]";
        public const string ACTULIZAPARAMETRO = @"[SPU_GL_C_PARAMETRO]";
        public const string OBTENERCATALOGOS = @"[SPS_GL_C_PARAMETRO_CATALOGOS]";
        public const string TOTALCATALOGO = @"SELECT COUNT(ID_PARAMETRO) FROM GL_C_PARAMETRO WHERE CONSECUTIVO = 0";
        public const string OBTENERCOMBOCATALOGO = @"[SPS_GL_C_PARAMETRO_COMBO]";
        public const string OBTENERPARAMETROSIDPADRE = @"[SPS_GL_C_PARAMETRO_CATALOGO]";
        public const string TOTALPAREMETROSID = @"
          SELECT COUNT(ID_PARAMETRO) FROM GL_C_PARAMETRO WHERE
          PARAMETRO = @PARAMETRO
          AND CONSECUTIVO <> 0
        ";
    }
}
