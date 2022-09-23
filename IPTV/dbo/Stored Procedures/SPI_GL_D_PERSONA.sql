-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_D_PERSONA
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_D_PERSONA]
    @CLAVE VARCHAR(50)
    ,@NOMBRE VARCHAR(100)
    ,@APELLIDO_PATERNO VARCHAR(100)
    ,@APELLIDO_MATERNO VARCHAR(100)
    ,@ID_ESTATUS INT
    --,@ID_PAIS INT = 117
    --,@FECHA_NACIMIENTO DATETIME
    --,@ID_GENERO INT
    --,@ID_ESTADO_CIVIL INT
    --,@ID_ESCOLARIDAD INT
    --,@OCUPACION NVARCHAR(100) = ''
    --,@RELIGION NVARCHAR(100) = ''
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_D_PERSONA
    (
      CLAVE
      ,NOMBRE
      ,APELLIDO_PATERNO
      ,APELLIDO_MATERNO
      ,ID_ESTATUS
      --,ID_PAIS
      --,FECHA_NACIMIENTO
      --,ID_GENERO
      --,ID_ESTADO_CIVIL
      --,ID_ESCOLARIDAD
      --,OCUPACION
      --,RELIGION
      ,FEC_ALTA
      --,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @CLAVE
    ,@NOMBRE
    ,@APELLIDO_PATERNO
    ,@APELLIDO_MATERNO
    ,@ID_ESTATUS
    --,@ID_PAIS
    --,@FECHA_NACIMIENTO
    --,@ID_GENERO
    --,@ID_ESTADO_CIVIL
    --,@ID_ESCOLARIDAD
    --,@OCUPACION
    --,@RELIGION
    ,GETDATE()--@FEC_ALTA
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

