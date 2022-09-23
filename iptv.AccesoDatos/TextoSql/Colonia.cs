using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Colonia
    {
        public const string CONSULTACOLONIADELEGACIONMUNICIPIO = @"SELECT * FROM GL_C_COLONIA WHERE ID_DELEG_MUNICIPIO = @ID_DELEG_MUNICIPIO AND ID_ESTADO = @ID_ESTADO";
    }
}
