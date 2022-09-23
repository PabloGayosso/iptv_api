
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_TEMPLATES_TV_DIRECTO]
AS
BEGIN
  SET NOCOUNT ON
  SELECT R.ID_REPRODUCTOR
       ,R.DESCRIPCION
	   ,R.ID_ESTATUS   
  FROM TV_C_REPRODUCTOR R
  INNER JOIN TV_R_TEMPLATE_REPRODUCTOR TR
  ON TR.ID_REPRODUCTOR = R.ID_REPRODUCTOR
  WHERE TR.ID_TEMPLATE IN(SELECT TC.ID_TEMPLATE FROM TV_R_TEMPLATE_CANAL TC 
                            WHERE TC.ID_CANAL IN(SELECT C.ID_CANAL FROM TV_D_CANAL C 
							                        WHERE C.ID_TIPO_CANAL=18))
  SET NOCOUNT OFF
END

