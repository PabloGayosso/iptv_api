
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_LOG_EXCEPCIONES_CAD
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_LOG_EXCEPCIONES_CAD_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_LOG
      ,DESCRIPCION
      ,ID_USUARIO
      ,ID_REPRODUCTOR
      ,ID_TEMPLATE
      ,ID_REGION
      ,ID_CANAL
      ,ID_CONTENIDO
      ,FECHA_CREACION
      ,NIVEL_SEVERIDAD
      ,IP
      ,USUARIO_ATENDIDO
      ,SOLUCION
      ,FECHA_ATENDIDO
    FROM TV_D_LOG_EXCEPCIONES_CAD
  SET NOCOUNT OFF
END

