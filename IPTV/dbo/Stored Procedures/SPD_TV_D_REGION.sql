
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_D_REGION
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_D_REGION]
    @ID_REGION INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_D_REGION
    WHERE
      ID_REGION = @ID_REGION
  SET NOCOUNT OFF
END

