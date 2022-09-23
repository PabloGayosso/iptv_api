﻿-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  19/09/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_R_CANAL_CONTENIDO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_R_TEMPLATE_CANAL_DIRECTO]
    @ID_TEMPLATE INT
  AS
BEGIN
  SET NOCOUNT ON
 SELECT TC.ID_CANAL
       ,C.CLAVE
	   ,CO.ID_CONTENIDO

FROM TV_R_TEMPLATE_CANAL AS TC 
INNER JOIN TV_D_CANAL AS C
ON C.ID_CANAL=TC.ID_CANAL
INNER JOIN TV_R_CANAL_CONTENIDO AS CC
ON CC.ID_CANAL = C.ID_CANAL
INNER JOIN TV_D_CONTENIDO AS CO
ON CO.ID_CONTENIDO = CC.ID_CONTENIDO
WHERE CO.ID_TIPO_CANAL =18  AND TC.ID_TEMPLATE=@ID_TEMPLATE
  SET NOCOUNT OFF
END
