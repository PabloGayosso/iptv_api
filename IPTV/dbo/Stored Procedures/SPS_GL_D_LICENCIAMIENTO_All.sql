
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_LICENCIAMIENTO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_LICENCIAMIENTO_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_LICENCIAMIENTO
      ,ID_ENTIDAD
      ,ID_SUCURSAL
      ,ID_APLICACION_IST
      ,FECHA_ACTIVACION
      ,VIGENCIA
      ,CONCURRENCIA
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_D_LICENCIAMIENTO
  SET NOCOUNT OFF
END

