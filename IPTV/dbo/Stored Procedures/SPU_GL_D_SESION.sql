
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_D_SESION
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_D_SESION]
    @ID_SESION INT
    ,@ID_ESTACION_TRABAJO INT
    ,@INICIO DATETIME
    ,@ID_ESTATUS INT
    ,@FIN DATETIME
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE GL_D_SESION SET
    ID_ESTACION_TRABAJO = @ID_ESTACION_TRABAJO
    ,INICIO = @INICIO
    ,ID_ESTATUS = @ID_ESTATUS
    ,FIN = @FIN
    ,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = @FEC_MOD
    ,USUARIO = @USUARIO
  WHERE
      ID_SESION = @ID_SESION
  SET NOCOUNT OFF
END

