
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_C_PERFIL
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_C_PERFIL]
    @ID_PERFIL INT
    ,@NOMBRE VARCHAR(40)
    ,@DESCRIPCION VARCHAR(80)
    ,@ID_ESTATUS INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE GL_C_PERFIL SET
    NOMBRE = @NOMBRE
    ,DESCRIPCION = @DESCRIPCION
    ,ID_ESTATUS = @ID_ESTATUS
    --,FEC_ALTA =  @FEC_ALTA
    ,FEC_MOD = GETDATE()--@FEC_MOD
    ,USUARIO = @USUARIO
  WHERE
      ID_PERFIL = @ID_PERFIL
  SET NOCOUNT OFF
END

