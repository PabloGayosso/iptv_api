
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_C_PARAMETRO
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_C_PARAMETRO]
    @ID_PARAMETRO INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_C_PARAMETRO
    WHERE
      ID_PARAMETRO = @ID_PARAMETRO
  SET NOCOUNT OFF
END

