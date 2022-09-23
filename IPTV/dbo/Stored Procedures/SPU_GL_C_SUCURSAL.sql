
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_C_SUCURSAL
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_C_SUCURSAL]
    @ID_SUCURSAL INT
    ,@ID_ENTIDAD INT
    ,@CLAVE VARCHAR(50)
    ,@NOMBRE VARCHAR(250)
    ,@ID_ESTATUS INT
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE GL_C_SUCURSAL SET
    ID_ENTIDAD = @ID_ENTIDAD
    ,CLAVE = @CLAVE
    ,NOMBRE = @NOMBRE
    ,ID_ESTATUS = @ID_ESTATUS
    ,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = @FEC_MOD
    ,USUARIO = @USUARIO
  WHERE
      ID_SUCURSAL = @ID_SUCURSAL
  SET NOCOUNT OFF
END

