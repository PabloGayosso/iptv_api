-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_C_PARAMETRO
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_C_PARAMETRO_CATALOGO]
    @PARAMETRO INT
    ,@CONSECUTIVO INT
    ,@CLAVE VARCHAR(5)
    ,@DESCRIPCION VARCHAR(100)
    ,@PREDETERMINADO BIT
    ,@FACTOR DECIMAL
    --,@ID_APLICACION_IST INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  DECLARE @MAX_PARAMETRO INT

  IF(@PARAMETRO = 0) 
  BEGIN
    SELECT @MAX_PARAMETRO = MAX(PARAMETRO)
    FROM GL_C_PARAMETRO
    
    SET @PARAMETRO = @MAX_PARAMETRO + 1
  END

  INSERT INTO GL_C_PARAMETRO
    (
      PARAMETRO
      ,CONSECUTIVO
      ,CLAVE
      ,DESCRIPCION
      ,PREDETERMINADO
      ,FACTOR
      --,ID_APLICACION_IST
      ,FEC_ALTA
      --,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @PARAMETRO
    ,@CONSECUTIVO
    ,@CLAVE
    ,@DESCRIPCION
    ,0
    ,1
    --,@ID_APLICACION_IST
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

