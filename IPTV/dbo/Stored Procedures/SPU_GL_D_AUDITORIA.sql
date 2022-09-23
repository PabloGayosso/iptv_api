
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_D_AUDITORIA
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_D_AUDITORIA]
    @ID_AUDITORIA INT
    ,@DSC_AUDITORIA NVARCHAR(250)
    ,@ID_USUARIO INT
    ,@FCH_ACCION DATETIME
    ,@DSC_ACCION NVARCHAR(250)
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
    ,@ID_APLICACION INT
    ,@ID_SUCURSAL INT
AS
BEGIN
  SET NOCOUNT ON
  UPDATE GL_D_AUDITORIA SET
    DSC_AUDITORIA = @DSC_AUDITORIA
    ,ID_USUARIO = @ID_USUARIO
    ,FCH_ACCION = @FCH_ACCION
    ,DSC_ACCION = @DSC_ACCION
    ,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = @FEC_MOD
    ,USUARIO = @USUARIO
    ,ID_APLICACION = @ID_APLICACION
    ,ID_SUCURSAL = @ID_SUCURSAL
  WHERE
      ID_AUDITORIA = @ID_AUDITORIA
  SET NOCOUNT OFF
END

