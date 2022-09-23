
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_APLICACION_IST
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_APLICACION_IST_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_APLICACION_IST
      ,CLAVE
      ,NOMBRE
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
      ,ID_ESTATUS
    FROM GL_C_APLICACION_IST
  SET NOCOUNT OFF
END

