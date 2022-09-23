
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_D_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_D_CANAL]
    @ID_CANAL INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_D_CANAL
    WHERE
      ID_CANAL = @ID_CANAL
  SET NOCOUNT OFF
END

