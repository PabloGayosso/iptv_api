
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Selecciona todos los registros de la tabla TV_R_TEMPLATE_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_R_TEMPLATE_CANAL_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_CANAL_TEMPLATE
    ,ID_TEMPLATE
    ,ID_CANAL
    ,ID_ESTATUS
    ,ALTO
    ,ANCHO
    ,POSICION_X
    ,POSICION_Y
    ,ORDEN
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM TV_R_TEMPLATE_CANAL
  SET NOCOUNT OFF
END
