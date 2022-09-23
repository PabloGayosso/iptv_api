
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_C_HARDWARE
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_C_HARDWARE]
    @ID_HARDWARE INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_C_HARDWARE
    WHERE
      ID_HARDWARE = @ID_HARDWARE
  SET NOCOUNT OFF
END

