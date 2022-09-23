
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_C_REPRODUCTOR
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_C_REPRODUCTOR]
    @ID_REPRODUCTOR INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_C_REPRODUCTOR
    WHERE
      ID_REPRODUCTOR = @ID_REPRODUCTOR
  SET NOCOUNT OFF
END

