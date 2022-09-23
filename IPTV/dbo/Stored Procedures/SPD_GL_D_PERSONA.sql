
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_D_PERSONA
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_D_PERSONA]
    @ID_PERSONA INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_D_PERSONA
    WHERE
      ID_PERSONA = @ID_PERSONA
  SET NOCOUNT OFF
END

