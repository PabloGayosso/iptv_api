
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_C_DISPOSITIVO
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_C_DISPOSITIVO]
    @ID_DISPOSITIVO INT
    ,@NOMBRE VARCHAR(50)
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
  UPDATE GL_C_DISPOSITIVO SET
    NOMBRE = @NOMBRE
    ,CLAVE = @CLAVE
    ,IP = @IP
    ,MAC_ADDRESS = @MAC_ADDRESS
    ,DESCRIPCION = @DESCRIPCION
    ,ID_TIPO_DISPOSITIVO = @ID_TIPO_DISPOSITIVO
    ,PUERTO = @PUERTO
    ,VISITA = @VISITA
    ,ID_ESTATUS = @ID_ESTATUS
    ,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = @FEC_MOD
    ,USUARIO = @USUARIO
  WHERE
      ID_DISPOSITIVO = @ID_DISPOSITIVO
  SET NOCOUNT OFF
END

