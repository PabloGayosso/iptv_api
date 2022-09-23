
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_D_DIRECCION
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_D_DIRECCION]
    @ID_DIRECCION INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_D_DIRECCION
    WHERE
      ID_DIRECCION = @ID_DIRECCION
  SET NOCOUNT OFF
END

