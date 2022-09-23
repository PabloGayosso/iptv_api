
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_C_DISPOSITIVO
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_C_DISPOSITIVO]
    @ID_DISPOSITIVO INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_C_DISPOSITIVO
    WHERE
      ID_DISPOSITIVO = @ID_DISPOSITIVO
  SET NOCOUNT OFF
END

