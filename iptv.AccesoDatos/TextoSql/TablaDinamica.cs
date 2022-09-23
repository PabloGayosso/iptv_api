using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class TablaDinamica
    {
        public const string CREARTABLA = @"[SPI_TV_D_TABLA_DINAMICA]";
        public const string CONTENIDOTABLADINAMICA = @"[SPI_TV_D_TABLA_DINAMICA_DATOS]";
        public const string CONSULTATBLANOMBRE = @"[SPS_TV_D_TABLA_NOMBRE]";
        public const string OBTENERTABLAS = @"
        SELECT * FROM TV_D_TABLA
        ORDER BY ID_TABLA
        OFFSET ((@Pagina-1) * @RegistroPorPagina) ROWS
        FETCH NEXT @RegistroPorPagina ROWS ONLY;
        ";
        public const string TOTALTABLAS = @"
        SELECT COUNT(ID_TABLA) FROM TV_D_TABLA;
        ";
        public const string OBTENERTABLASCAT = @"
        SELECT * FROM TV_D_TABLA;
        ";
        public const string OBTENERTABLAIDTABLA = @"
        SELECT * FROM TV_D_TABLA WHERE ID_TABLA = @ID_TABLA;
        ";
        public const string CONSULTATABLADINAMICA = @"[SPS_TV_D_TABLA_DINAMICA]";
    }
}
