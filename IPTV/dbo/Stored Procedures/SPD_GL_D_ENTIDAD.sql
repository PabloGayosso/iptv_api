
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_D_ENTIDAD
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_D_ENTIDAD]
    @ID_ENTIDAD INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_D_ENTIDAD
    WHERE
      ID_ENTIDAD = @ID_ENTIDAD
  SET NOCOUNT OFF
END

