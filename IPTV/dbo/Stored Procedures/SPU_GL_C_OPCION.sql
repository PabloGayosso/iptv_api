
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_C_OPCION
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_C_OPCION]
    @ID_OPCION INT
    ,@ID_SUCURSAL INT
    ,@NOMBRE VARCHAR(50)
    ,@DESCRIPCION VARCHAR(50)
    ,@URL_ICON VARCHAR(100)
    ,@URL VARCHAR(100)
    ,@ID_ESTATUS INT
    ,@ID_APLICACION INT
    ,@OPCION_PADRE INT
    ,@NIVEL INT
    ,@ORDEN INT
    ,@FEC_MOD DATETIME
    ,@FEC_ALTA DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE GL_C_OPCION SET
    ID_SUCURSAL = @ID_SUCURSAL
    ,NOMBRE = @NOMBRE
    ,DESCRIPCION = @DESCRIPCION
    ,URL_ICON = @URL_ICON
    ,URL = @URL
    ,ID_ESTATUS = @ID_ESTATUS
    --,ID_APLICACION = @ID_APLICACION
    ,OPCION_PADRE = @OPCION_PADRE
    ,NIVEL = @NIVEL
    ,ORDEN = @ORDEN
    ,FEC_MOD = @FEC_MOD
    ,FEC_ALTA = @FEC_ALTA
    ,USUARIO = @USUARIO
  WHERE
      ID_OPCION = @ID_OPCION
  SET NOCOUNT OFF
END

