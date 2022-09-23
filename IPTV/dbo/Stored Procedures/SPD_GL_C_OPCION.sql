
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_C_OPCION
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_C_OPCION]
    @ID_OPCION INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_C_OPCION
    WHERE
      ID_OPCION = @ID_OPCION
  SET NOCOUNT OFF
END

