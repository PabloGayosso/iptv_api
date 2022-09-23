using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Persona
    {
        public const string CONSULTAPERSONAS = @"[SPS_GL_D_PERSONA_All]";
        public const string CONSULTAPERSONASUSUARIOS = @"[SPS_GL_D_PERSONA_USUARIO_All]";
        public const string CONSULTAPERSONA = @"[SPS_GL_D_PERSONA]";
        public const string CONSULTATOTALPERSONA = @"SELECT COUNT(ID_PERSONA) FROM GL_D_PERSONA";
        public const string ALTAPERSONA = @"[SPI_GL_D_PERSONA]";
        public const string ACTULIZAPERSONA = @"[SPU_GL_D_PERSONA]";
        public const string CONSULTAPERSONASACTIVAS = @"SELECT * FROM GL_D_PERSONA WHERE ID_ESTATUS = @ID_ESTATUS ORDER BY FEC_ALTA";
    }
}
