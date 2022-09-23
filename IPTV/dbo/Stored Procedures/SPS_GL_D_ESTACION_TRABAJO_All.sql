
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_ESTACION_TRABAJO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_ESTACION_TRABAJO_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_ESTACION_TRABAJO
      ,ID_SUCURSAL
      ,CLAVE
      ,NOMBRE
      ,DIRECCION_IP
      ,DIRECCION_MAC
      ,ID_ESTATUS
      ,ES_SERVIDOR
      ,ID_PERSONA
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_D_ESTACION_TRABAJO
  SET NOCOUNT OFF
END

