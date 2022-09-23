using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Usuario
    {
        public const string CONSULTAUSUARIOS = @"[SPS_GL_C_USUARIO_All]";
        public const string CONSULTAUSUARIOSREPORTE = @"[SPS_GL_C_USUARIO_REPORTE]";
        public const string CONSULTAUSUARIO = @"[SPS_GL_C_USUARIO]";
        public const string CONSULTAUSUARIOIDPERSONA = @"[SPS_GL_C_USUARIO_ID_PERSONA]";
        public const string CONSULTATOTALUSUARIOS = @"SELECT COUNT(ID_USUARIO) FROM GL_C_USUARIO";
        public const string ALTAUUAUDIO = @"[SPI_GL_C_USUARIO]";
        public const string ACTULIZAUSUARIO = @"[SPU_GL_C_USUARIO]";
        public const string ACTULIZAUSUARIOIDPERSONA = @"[SPU_GL_C_USUARIO_ID_PERSONA]";
    }
}
