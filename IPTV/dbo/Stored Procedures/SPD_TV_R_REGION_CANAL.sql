
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  24/09/2018
-- Description:  Elimina un registro en especifico de la tabla TV_R_REGION_CANAL
-- =============================================
CREATE PROCEDURE SPD_TV_R_REGION_CANAL
    @ID_CANAL_REGION INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_R_REGION_CANAL
  WHERE
    ID_CANAL_REGION = @ID_CANAL_REGION
  SET NOCOUNT OFF
END
