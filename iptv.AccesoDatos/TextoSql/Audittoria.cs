using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Audittoria
    {
        public const string ALTAAUDITORIA = @"[SPI_GL_D_AUDITORIA]";
        public const string CONSULTAAUDITORIAFECHAS = @"[SPS_GL_D_AUDITORIA_REPORTE]";
        public const string CONSULTAAUDITORIAFECHASFILE = @"[SPS_GL_D_AUDITORIA_REPORTE_FILE]";
        public const string CONSULTAAUDITORIAFECHASTOTAL = @"SELECT COUNT(ID_AUDITORIA)"+
                "FROM GL_D_AUDITORIA WHERE FCH_ACCION > @FCH_INI AND FCH_ACCION < @FCH_FIN";


    }
}
