using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class DelegacionMunicipio
    {
        public const string CONSULTADELEGAIONMUNICIPIOIDESTADO = @"SELECT * FROM [GL_C_DELEG_MUNICIPIO] WHERE ID_ESTADO = @ID_ESTADO";
    }
}
