
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_D_LOG_EXCEPCIONES_CAD
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_D_LOG_EXCEPCIONES_CAD]
    @ID_LOG INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_D_LOG_EXCEPCIONES_CAD
    WHERE
      ID_LOG = @ID_LOG
  SET NOCOUNT OFF
END

