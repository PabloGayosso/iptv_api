
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_AUDITORIA
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_AUDITORIA_All]
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
  SET NOCOUNT OFF
END

