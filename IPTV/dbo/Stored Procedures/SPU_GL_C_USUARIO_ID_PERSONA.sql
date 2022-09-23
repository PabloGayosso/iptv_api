
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_C_USUARIO
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_C_USUARIO_ID_PERSONA]
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
  UPDATE GL_C_USUARIO SET
    ID_PERSONA = @ID_PERSONA
    ,ID_SUCURSAL = @ID_SUCURSAL
    ,CLAVE_USUARIO = @CLAVE_USUARIO
    ,CONTRASENA = @CONTRASENA
    ,ID_PERFIL = @ID_PERFIL
    ,ID_ESTATUS = @ID_ESTATUS
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,USUARIO = @USUARIO
  WHERE
      ID_PERSONA = @ID_PERSONA
  SET NOCOUNT OFF
END

