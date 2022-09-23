
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  24/09/2018
-- Description:  Selecciona todos los registros de la tabla TV_R_REGION_CANAL
-- =============================================
CREATE PROCEDURE SPS_TV_R_REGION_CANAL_All
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_CANAL_REGION
    ,ID_REGION
    ,ID_CANAL
    ,ID_ESTATUS
    ,ALTO
    ,ANCHO
    ,POSICION_X
    ,POSICION_Y
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM TV_R_REGION_CANAL
  SET NOCOUNT OFF
END
