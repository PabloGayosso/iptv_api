-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_D_DIRECCION
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_D_DIRECCION]
    @ID_TIPO_DIRECCION INT
    ,@ID_PAIS INT
    ,@ID_ESTADO INT
    ,@ID_DELEG_MUNICIPIO INT
    ,@ID_COLONIA INT
    ,@CODIGO_POSTAL VARCHAR(10)
    ,@CIUDAD VARCHAR(250) = ''
    ,@CALLE VARCHAR(250)
    ,@NUMERO_EXTERIOR VARCHAR(50)
    ,@NUMERO_INTERIOR VARCHAR(50)
    ,@ID_ESTATUS INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_D_DIRECCION
    (
      ID_TIPO_DIRECCION
      ,ID_PAIS
      ,ID_ESTADO
      ,ID_DELEG_MUNICIPIO
      ,ID_COLONIA
      ,CODIGO_POSTAL
      ,CIUDAD
      ,CALLE
      ,NUMERO_EXTERIOR
      ,NUMERO_INTERIOR
      ,ID_ESTATUS
      ,FEC_ALTA
      --,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @ID_TIPO_DIRECCION
    ,@ID_PAIS
    ,@ID_ESTADO
    ,@ID_DELEG_MUNICIPIO
    ,@ID_COLONIA
    ,@CODIGO_POSTAL
    ,@CIUDAD
    ,@CALLE
    ,@NUMERO_EXTERIOR
    ,@NUMERO_INTERIOR
    ,@ID_ESTATUS
    ,GETDATE()--@FEC_ALTA
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

