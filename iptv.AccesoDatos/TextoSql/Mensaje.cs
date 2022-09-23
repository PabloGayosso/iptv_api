using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Mensaje
    {
        public const string CATMENSAJE = @"SELECT * FROM TV_C_MENSAJES";
        public const string OBTENERMENSAJES = @"[SPS_TV_C_MENSAJES_All]";
        public const string OBTENERMENSAJE = @"[SPS_TV_C_MENSAJES]";
        public const string ALTAMENSAJE = @"[SPI_TV_C_MENSAJES]";
        public const string ACTULIZAMENSAJE = @"[SPU_TV_C_MENSAJES]";
        public const string TOTALMENSAJE = @"SELECT COUNT(ID_MENSAJE) FROM TV_C_MENSAJES";
        public const string ELIMINARMENSAJE = @"[SPD_TV_C_MENSAJES]";
    }
}
