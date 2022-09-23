
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_C_PERFIL
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_C_PERFIL]
    @ID_PERFIL INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_C_PERFIL
    WHERE
      ID_PERFIL = @ID_PERFIL
  SET NOCOUNT OFF
END

