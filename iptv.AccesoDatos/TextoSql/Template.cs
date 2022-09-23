using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Template
    {
        public const string CONSULTATEMPLATES = @"[SPS_TV_D_TEMPLATES_All]";
        public const string CONSULTATEMPLATESCATALOGO = @"[SPS_TV_D_TEMPLATES_CATALOGO]";
        public const string CONSULTATEMPATE = @"[SPS_TV_D_TEMPLATES]";
        public const string ALTATEMPLATE = @"[SPI_TV_D_TEMPLATES]";
        public const string ACTULIZATEMPLATE = @"[SPU_TV_D_TEMPLATES]";
        public const string BORRATEMPLATECANAL = @"DELETE FROM TV_R_TEMPLATE_CANAL WHERE ID_TEMPLATE = @ID_TEMPLATE";
        public const string ALTATEMPLATECANAL = @"[SPI_TV_R_TEMPLATE_CANAL]";
        public const string TOTALTEMPLATES = @"SELECT COUNT(ID_TEMPLATE) FROM TV_D_TEMPLATES";
        public const string CONSULTATEMPLATESDIRECTO = @"


                	SELECT t.*, c.*, ct.*,ctc.ID_CANAL_CONTENIDO, ctc.FEC_INICIO, ctc.FEC_FIN,
                      ctc.INICIO_HRS, ctc.INICIO_MIN, ctc.INICIO_SEG,
                      ctc.FIN_HRS, ctc.FIN_MIN, ctc.FIN_SEG FROM TV_D_TEMPLATES t
	LEFT JOIN TV_R_TEMPLATE_CANAL tc
	ON t.ID_TEMPLATE = tc.ID_TEMPLATE 
	LEFT JOIN TV_D_CANAL c
	ON tc.ID_CANAL = c.ID_CANAL
	LEFT JOIN TV_R_CANAL_CONTENIDO ctc
	ON c.ID_CANAL = ctc.ID_CANAL
	LEFT JOIN TV_D_CONTENIDO ct
	ON ctc.ID_CONTENIDO = ct.ID_CONTENIDO 
	WHERE t.ID_TEMPLATE IN (SELECT t.ID_TEMPLATE FROM TV_D_TEMPLATES t
	LEFT JOIN TV_R_TEMPLATE_CANAL tc
	ON t.ID_TEMPLATE = tc.ID_TEMPLATE 
	LEFT JOIN TV_D_CANAL c
	ON tc.ID_CANAL = c.ID_CANAL
	LEFT JOIN TV_R_CANAL_CONTENIDO ctc
	ON c.ID_CANAL = ctc.ID_CANAL
	LEFT JOIN TV_D_CONTENIDO ct
	ON ctc.ID_CONTENIDO = ct.ID_CONTENIDO 
	WHERE (c.ID_TIPO_CANAL = 18 
                       AND t.NOMBRE LIKE CASE WHEN @Busqueda = '0' THEN t.NOMBRE ELSE '%' + @Busqueda +'%' END)
                      ORDER BY t.ID_TEMPLATE DESC
                      OFFSET ((@Pagina - 1) * @RegistroPorPagina) ROWS
                      FETCH NEXT @RegistroPorPagina ROWS ONLY )
                      AND c.ID_TIPO_CANAL = 18
                      ORDER BY t.ID_TEMPLATE DESC
        ";
        public const string CONSULTATOTALTEMPLATEDIRECTO = @"
                      SELECT COUNT(t.ID_TEMPLATE) FROM TV_D_TEMPLATES t
	LEFT JOIN TV_R_TEMPLATE_CANAL tc
	ON t.ID_TEMPLATE = tc.ID_TEMPLATE 
	LEFT JOIN TV_D_CANAL c
	ON tc.ID_CANAL = c.ID_CANAL
	WHERE c.ID_TIPO_CANAL = 18
        ";
        public const string CONSULTATEMPLATECANAL = @"
          	SELECT t.*, tc.*, c.* FROM TV_D_TEMPLATES t
	INNER JOIN TV_R_TEMPLATE_CANAL tc
	ON t.ID_TEMPLATE = tc.ID_TEMPLATE 
	INNER JOIN TV_D_CANAL c
	ON tc.ID_CANAL = c.ID_CANAL
	WHERE t.ID_TEMPLATE = @ID_TEMPLATE
         ";

        public const string CONSULTATEMPLATEREPRODUCTORES = @"
        SELECT T.*, TR.*, R.* FROM TV_D_TEMPLATES T
        INNER JOIN TV_R_TEMPLATE_REPRODUCTOR TR
        ON T.ID_TEMPLATE = TR.ID_TEMPLATE
        INNER JOIN TV_C_REPRODUCTOR R
        ON TR.ID_REPRODUCTOR  = R.ID_REPRODUCTOR
        WHERE T.ID_TEMPLATE = @ID_TEMPLATE;
        ";
    }
}
