using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Opcion
    {
        public const string CONSSULTAOPCIONPERFIL = @"
            SELECT p.*, op.*, o.* FROM GL_C_PERFIL p
            INNER JOIN GL_R_PERFIL_OPCION op
            ON p.ID_PERFIL = op.ID_PERFIL
            INNER JOIN GL_C_OPCION o
            ON op.ID_OPCION = o.ID_OPCION
            WHERE p.ID_PERFIL = @ID_PERFIL
            AND p.ID_ESTATUS = 3 AND o.ID_ESTATUS = 3
            ORDER BY p.ID_PERFIL
        ";
        public const string ALTAPERFILOPCION = @"[SPI_GL_R_PERFIL_OPCION]";
        public const string BORRARPERFILOPCION = @"[SPD_GL_R_PERFIL_OPCION]";
        public const string OPCIONASIGNADO = @"[SPS_GL_C_OPCION_ASIGNADO]";
        public const string OPCIONDESASIGNADO = @"[SPS_GL_C_OPCION_DESASIGNADO]";
    }
}
