-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_C_OPCION
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_C_OPCION]
    @ID_SUCURSAL INT
    ,@NOMBRE VARCHAR(50)
    ,@DESCRIPCION VARCHAR(50)
    ,@URL_ICON VARCHAR(100)
    ,@URL VARCHAR(100)
    ,@ID_ESTATUS INT
    --,@ID_APLICACION INT
    ,@OPCION_PADRE INT
    ,@NIVEL INT
    ,@ORDEN INT
    ,@FEC_MOD DATETIME
    ,@FEC_ALTA DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_C_OPCION
    (
      ID_SUCURSAL
      ,NOMBRE
      ,DESCRIPCION
      ,URL_ICON
      ,URL
      ,ID_ESTATUS
      --,ID_APLICACION
      ,OPCION_PADRE
      ,NIVEL
      ,ORDEN
      ,FEC_MOD
      ,FEC_ALTA
      ,USUARIO
    )
  VALUES
  (
    @ID_SUCURSAL
    ,@NOMBRE
    ,@DESCRIPCION
    ,@URL_ICON
    ,@URL
    ,@ID_ESTATUS
    --,@ID_APLICACION
    ,@OPCION_PADRE
    ,@NIVEL
    ,@ORDEN
    ,@FEC_MOD
    ,@FEC_ALTA
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

