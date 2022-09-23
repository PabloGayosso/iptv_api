
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_C_REPRODUCTOR
-- =============================================
CREATE PROCEDURE [dbo].SPS_TV_C_REPRODUCTOR_TEMPLATE
    @ID_GRUPO INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
	ID_TEMPLATE AS ID_REPRODUCTOR
  FROM TV_D_GRUPOS 
  
  WHERE
    ID_GRUPO = @ID_GRUPO
  SET NOCOUNT OFF
END

