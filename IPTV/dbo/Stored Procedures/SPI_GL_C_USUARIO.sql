-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_C_USUARIO
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_C_USUARIO]
    @ID_PERSONA INT
    ,@ID_SUCURSAL INT
    ,@CLAVE_USUARIO VARCHAR(30)
    ,@CONTRASENA VARCHAR(50)
    ,@ID_PERFIL INT
    ,@ID_ESTATUS INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_C_USUARIO
    (
      ID_PERSONA
      ,ID_SUCURSAL
      ,CLAVE_USUARIO
      ,CONTRASENA
      ,ID_PERFIL
      ,ID_ESTATUS
      ,FEC_ALTA
      --,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @ID_PERSONA
    ,@ID_SUCURSAL
    ,@CLAVE_USUARIO
    ,@CONTRASENA
    ,@ID_PERFIL
    ,@ID_ESTATUS
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

