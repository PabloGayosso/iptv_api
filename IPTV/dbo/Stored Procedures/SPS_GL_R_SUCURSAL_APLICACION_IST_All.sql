
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_R_SUCURSAL_APLICACION_IST
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_R_SUCURSAL_APLICACION_IST_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_SUCURSAL_APLICACION
      ,ID_SUCURSAL
      ,ID_APLICACION_IST
      ,LICENCIA_ACTIVADA
      ,LICENCIA
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_R_SUCURSAL_APLICACION_IST
  SET NOCOUNT OFF
END

