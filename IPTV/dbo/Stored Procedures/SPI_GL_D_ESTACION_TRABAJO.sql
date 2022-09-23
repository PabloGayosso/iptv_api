-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_D_ESTACION_TRABAJO
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_D_ESTACION_TRABAJO]
    @ID_SUCURSAL INT
    ,@CLAVE VARCHAR(150)
    ,@NOMBRE VARCHAR(250)
    ,@DIRECCION_IP VARCHAR(50)
    ,@DIRECCION_MAC VARCHAR(50)
    ,@ID_ESTATUS INT
    ,@ES_SERVIDOR BIT
    ,@ID_PERSONA INT
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_D_ESTACION_TRABAJO
    (
      ID_SUCURSAL
      ,CLAVE
      ,NOMBRE
      ,DIRECCION_IP
      ,DIRECCION_MAC
      ,ID_ESTATUS
      ,ES_SERVIDOR
      ,ID_PERSONA
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @ID_SUCURSAL
    ,@CLAVE
    ,@NOMBRE
    ,@DIRECCION_IP
    ,@DIRECCION_MAC
    ,@ID_ESTATUS
    ,@ES_SERVIDOR
    ,@ID_PERSONA
    ,@FEC_ALTA
    ,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

