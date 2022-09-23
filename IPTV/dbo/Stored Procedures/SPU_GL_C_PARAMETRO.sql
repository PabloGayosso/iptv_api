
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_C_PARAMETRO
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_C_PARAMETRO]
    @ID_PARAMETRO INT
    ,@PARAMETRO INT
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
  UPDATE GL_C_PARAMETRO SET
    PARAMETRO = @PARAMETRO
    ,CONSECUTIVO = @CONSECUTIVO
    ,CLAVE = @CLAVE
    ,DESCRIPCION = @DESCRIPCION
    ,PREDETERMINADO = @PREDETERMINADO
    ,FACTOR = @FACTOR
    --,ID_APLICACION_IST = @ID_APLICACION_IST
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,USUARIO = @USUARIO
  WHERE
      ID_PARAMETRO = @ID_PARAMETRO
  SET NOCOUNT OFF
END

