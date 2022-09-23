
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_D_AUDITORIA
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_D_AUDITORIA]
    @ID_AUDITORIA INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_D_AUDITORIA
    WHERE
      ID_AUDITORIA = @ID_AUDITORIA
  SET NOCOUNT OFF
END

