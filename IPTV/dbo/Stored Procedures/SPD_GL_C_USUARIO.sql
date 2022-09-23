
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_C_USUARIO
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_C_USUARIO]
    @ID_USUARIO INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_C_USUARIO
    WHERE
      ID_USUARIO = @ID_USUARIO
  SET NOCOUNT OFF
END

