
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_C_SUCURSAL
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_C_SUCURSAL]
    @ID_SUCURSAL INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_C_SUCURSAL
    WHERE
      ID_SUCURSAL = @ID_SUCURSAL
  SET NOCOUNT OFF
END

