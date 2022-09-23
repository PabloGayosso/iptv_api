-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_R_SUCURSAL_APLICACION_IST
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_R_SUCURSAL_APLICACION_IST]
    @ID_SUCURSAL INT
    ,@ID_APLICACION_IST INT
    ,@LICENCIA_ACTIVADA NVARCHAR(MAX)
    ,@LICENCIA VARCHAR(MAX)
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_R_SUCURSAL_APLICACION_IST
    (
      ID_SUCURSAL
      ,ID_APLICACION_IST
      ,LICENCIA_ACTIVADA
      ,LICENCIA
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @ID_SUCURSAL
    ,@ID_APLICACION_IST
    ,@LICENCIA_ACTIVADA
    ,@LICENCIA
    ,@FEC_ALTA
    ,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

