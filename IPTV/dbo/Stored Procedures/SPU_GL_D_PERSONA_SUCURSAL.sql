
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_D_PERSONA_SUCURSAL
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_D_PERSONA_SUCURSAL]
    @ID_PERSONA INT
    ,@ID_SUCURSAL INT
    ,@ID_ESTATUS INT
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE GL_D_PERSONA_SUCURSAL SET
    ID_SUCURSAL = @ID_SUCURSAL
    ,ID_ESTATUS = @ID_ESTATUS
    ,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = @FEC_MOD
    ,USUARIO = @USUARIO
  WHERE
    ID_PERSONA = @ID_PERSONA
  SET NOCOUNT OFF
END

