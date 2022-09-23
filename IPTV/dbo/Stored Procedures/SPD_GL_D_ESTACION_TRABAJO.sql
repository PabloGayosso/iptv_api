
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_D_ESTACION_TRABAJO
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_D_ESTACION_TRABAJO]
    @ID_ESTACION_TRABAJO INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_D_ESTACION_TRABAJO
    WHERE
      ID_ESTACION_TRABAJO = @ID_ESTACION_TRABAJO
  SET NOCOUNT OFF
END

