
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_D_SESION
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_D_SESION]
    @ID_SESION INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_D_SESION
    WHERE
      ID_SESION = @ID_SESION
  SET NOCOUNT OFF
END

