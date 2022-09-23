
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_R_SUCURSAL_APLICACION_IST
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_R_SUCURSAL_APLICACION_IST]
    @ID_SUCURSAL_APLICACION INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_R_SUCURSAL_APLICACION_IST
    WHERE
      ID_SUCURSAL_APLICACION = @ID_SUCURSAL_APLICACION
  SET NOCOUNT OFF
END

