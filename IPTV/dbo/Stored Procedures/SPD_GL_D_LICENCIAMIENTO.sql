
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_D_LICENCIAMIENTO
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_D_LICENCIAMIENTO]
    @ID_LICENCIAMIENTO INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_D_LICENCIAMIENTO
    WHERE
      ID_LICENCIAMIENTO = @ID_LICENCIAMIENTO
  SET NOCOUNT OFF
END

