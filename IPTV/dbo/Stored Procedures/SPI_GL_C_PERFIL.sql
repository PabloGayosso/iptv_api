-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_C_PERFIL
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_C_PERFIL]
    @NOMBRE VARCHAR(40)
    ,@DESCRIPCION VARCHAR(80)
    ,@ID_ESTATUS INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_C_PERFIL
  (
    NOMBRE
    ,DESCRIPCION
    ,ID_ESTATUS
    ,FEC_ALTA
    --,FEC_MOD
    ,USUARIO
  )
  VALUES
  (
    @NOMBRE
    ,@DESCRIPCION
    ,@ID_ESTATUS
    ,GETDATE()--@FEC_ALTA
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

