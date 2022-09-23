﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_ENVIOS_ESTATUS] 
	@ID_ENVIO INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      VELOCIDAD
      ,TAM_DESCARGADO
      ,PORCENTAJE
    FROM TV_D_ENVIO
	WHERE ID_ENVIO = @ID_ENVIO
  SET NOCOUNT OFF
END

