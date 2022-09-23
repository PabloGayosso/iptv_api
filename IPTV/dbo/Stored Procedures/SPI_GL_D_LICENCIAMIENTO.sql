-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_D_LICENCIAMIENTO
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_D_LICENCIAMIENTO]
    @ID_ENTIDAD INT
    ,@ID_SUCURSAL INT
    ,@ID_APLICACION_IST INT
    ,@VIGENCIA INT
    ,@CONCURRENCIA INT
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_D_LICENCIAMIENTO
  (
    ID_ENTIDAD
    ,ID_SUCURSAL
    ,ID_APLICACION_IST
    ,VIGENCIA
    ,CONCURRENCIA
    ,FEC_ALTA
    ,USUARIO
  )
  VALUES
  (
    @ID_ENTIDAD
    ,@ID_SUCURSAL
    ,@ID_APLICACION_IST
    ,@VIGENCIA
    ,@CONCURRENCIA
    ,GETDATE()
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

