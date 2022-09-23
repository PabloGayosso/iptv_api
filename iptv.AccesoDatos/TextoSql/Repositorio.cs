using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Repositorio
    {
        public const string ALTAREPOSITORIO = @"[SPI_TV_D_REPOSITORIO]";
        public const string CONSULTAREPOSITORIO = @"[SPS_TV_D_REPOSITORIO_All]";
        public const string CONSULTAREPOSITORIOID = @"[SPS_TV_D_REPOSITORIO]";
        public const string ELIMINAREPOSITORIO = @"[SPD_TV_D_REPOSITORIO]";
        public const string ACTULIZAREPOSITORIO = @"[SPU_TV_D_REPOSITORIO]";
        public const string TOTALREPOSITORIOS = @"SELECT COUNT(ID_REPOSITORIO) FROM TV_D_REPOSITORIO";
        public const string CONSULTAPORIDTIPOCONTENIDO = @"[SPS_TV_D_REPOSITORIO_CONTENIDO]";
        public const string CONSULTACATALOGOREPOSITORIO = @"[SPS_TV_C_REPOSITORIO]";
        public const string CONSULTACATALOGOREPOSITORRIONOMBRE = @"[SPS_TV_C_REPOSITORIO_NOMBRE]";
        public const string ELIMINARCATALOGOREPOSITIRIO = @"[SPD_TV_C_REPOSITORIO]";
    }
}
