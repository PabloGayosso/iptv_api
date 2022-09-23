using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public class Envios
    {
        public const string CONSULTA_ENVIOS = @"[SPS_TV_D_ENVIOS]";
        public const string CONSULTA_ENVIO_ESTATUS = @"[SPS_TV_D_ENVIOS_ESTATUS]";
        public const string CONSULTA_ENVIOS_POST = @"[SPS_TV_D_ENVIOS_POST]";
        public const string CONSULTA_ENVIOS_H = @"[SPS_TV_D_ENVIOS_H_All]";
        public const string TOTAL_ENVIOS = @"SELECT COUNT(ID_ENVIO) FROM TV_D_ENVIO";
        public const string TOTAL_ENVIOS_H = @"SELECT COUNT(ID_ENVIO) FROM TV_D_ENVIO_HISTORICO";
        public const string ALTA_ENVIOS_H = @"[SPI_TV_D_ENVIO_HISTORICO]";
    }
}
