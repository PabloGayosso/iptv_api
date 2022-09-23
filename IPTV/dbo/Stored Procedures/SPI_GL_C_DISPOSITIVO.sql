-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_C_DISPOSITIVO
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_C_DISPOSITIVO]
    @NOMBRE VARCHAR(50)
    ,@CLAVE VARCHAR(50)
    ,@IP VARCHAR(50)
    ,@MAC_ADDRESS VARCHAR(50)
    ,@DESCRIPCION VARCHAR(50)
    ,@ID_TIPO_DISPOSITIVO INT
    ,@PUERTO INT
    ,@VISITA BIT
    ,@ID_ESTATUS INT
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_C_DISPOSITIVO
    (
      NOMBRE
      ,CLAVE
      ,IP
      ,MAC_ADDRESS
      ,DESCRIPCION
      ,ID_TIPO_DISPOSITIVO
      ,PUERTO
      ,VISITA
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @NOMBRE
    ,@CLAVE
    ,@IP
    ,@MAC_ADDRESS
    ,@DESCRIPCION
    ,@ID_TIPO_DISPOSITIVO
    ,@PUERTO
    ,@VISITA
    ,@ID_ESTATUS
    ,@FEC_ALTA
    ,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

