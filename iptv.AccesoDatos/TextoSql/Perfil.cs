using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Perfil
    {
        public const string ALTAPERFIL = @"[SPI_GL_C_PERFIL]";
        public const string ACTULIZAPERFIL = @"[SPU_GL_C_PERFIL]";
        public const string CONSULTAPERFILES = @"[SPS_GL_C_PERFIL_All]";
        public const string CONSULTAPERFIL = @"[SPS_GL_C_PERFIL]";
        public const string CONSULTATOTALPERFILES = @"SELECT COUNT(ID_PERFIL) FROM GL_C_PERFIL;";
        public const string CONSULTACATPERFIILES = 
        @"SELECT * FROM GL_C_PERFIL
        WHERE ID_ESTATUS = 3
        ORDER BY ID_PERFIL DESC";
    }
}
