-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_C_SUCURSAL
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_C_SUCURSAL]
    @ID_ENTIDAD INT
    ,@CLAVE VARCHAR(50)
    ,@NOMBRE VARCHAR(250)
    ,@ID_ESTATUS INT
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_C_SUCURSAL
    (
      ID_ENTIDAD
      ,CLAVE
      ,NOMBRE
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @ID_ENTIDAD
    ,@CLAVE
    ,@NOMBRE
    ,@ID_ESTATUS
    ,@FEC_ALTA
    ,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

