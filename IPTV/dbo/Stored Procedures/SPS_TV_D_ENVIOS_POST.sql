﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_ENVIOS_POST] 
	@ID_BUSQUEDA INT
	,@FEC_BUSQUEDA DATETIME
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_ENVIO
      ,NOMBRE_CONTENIDO
      ,REPRODUCTOR
      ,USUARIO
      ,FEC_ENVIO
      ,VELOCIDAD
      ,TAM_TOTAL
      ,TAM_DESCARGADO
      ,PORCENTAJE
	  ,convert(varchar, FEC_ALTA, 21) as FEC_ALTA
    FROM TV_D_ENVIO
	WHERE FEC_ALTA > @FEC_BUSQUEDA AND ID_ENVIO != @ID_BUSQUEDA AND PORCENTAJE != 100
	ORDER BY FEC_ALTA DESC
  SET NOCOUNT OFF
END

