using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Grupo
    {
        public const string OBTENERGRUPOS = @"[SPS_D_GRUPOS_ALL]";
        public const string OBTENERGRUPOSCATALOGO = @"[SPS_D_GRUPOS_CATALOGO]";
        public const string OBTENERGRUPOSCATALOGOALL = @"[SPS_D_GRUPOS_CATALOGO_ALL]";
        public const string TATOTALGRUPOS = @"SELECT COUNT(ID_GRUPO) FROM TV_D_GRUPOS";
        public const string OBTENERGRUPO = @"[SPS_D_GRUPOS]";
        public const string OBTENERGRUPOREPRODUCTOR = @"[SPS_TV_R_GRUPO_REPRODUCTOR_IDREPRODUCTOR]";
        public const string ALTAGRUPO = @"[SPI_TV_D_GRUPOS]";
        public const string ALTAGRUPOREPRODUCTOR = @"[SPI_TV_R_GRUPOS_REPRODUCTOR]";
        public const string ACTUALIZAGRUPO = @"[SPU_TV_D_GRUPOS]";
        public const string ELIMINARGRUPO = @"[SPD_TV_R_GRUPOS_REPRODUCTOR_ID_GRUPO]";

    }
}
