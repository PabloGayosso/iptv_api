
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_AUDITORIA
-- =============================================
CREATE PROCEDURE SPS_GL_D_AUDITORIA_REPORTE_USUARIO
   @FECHA_INIO DATETIME
   ,@FECHA_FINAL DATETIME
   ,@ID_USUARIO INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_AUDITORIA
    ,DSC_AUDITORIA
    ,ID_USUARIO
    ,FCH_ACCION
    ,DSC_ACCION
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
    ,ID_APLICACION
    ,ID_SUCURSAL
  FROM GL_D_AUDITORIA
  WHERE
    FCH_ACCION BETWEEN @FECHA_INIO AND @FECHA_FINAL
    AND ID_USUARIO = @ID_USUARIO
  SET NOCOUNT OFF
END

