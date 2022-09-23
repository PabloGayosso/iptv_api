
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_PARAMETRO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_PARAMETRO_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_PARAMETRO
      ,PARAMETRO
      ,CONSECUTIVO
      ,CLAVE
      ,DESCRIPCION
      ,PREDETERMINADO
      ,FACTOR
      ,ID_APLICACION_IST
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_PARAMETRO
  SET NOCOUNT OFF
END

